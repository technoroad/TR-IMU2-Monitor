using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public sealed class PacketFramer : IDisposable
{
    // 入力（生バイト列）の待ち行列とシグナル
    private readonly ConcurrentQueue<byte[]> _rxQueue = new ConcurrentQueue<byte[]>();
    private readonly SemaphoreSlim _dataAvailable = new SemaphoreSlim(0, int.MaxValue);

    // 実行制御
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();
    private Task _framerTask;

    // 固定長
    private const int FixedPayloadLength = 37;

    public event Action<byte[]> PacketReceived;

    /// <summary>
    /// 推奨: usePollingPump=false（プロデューサから OnBytesReceived を呼ぶ設計にすると完全非ポーリング）
    /// 互換: usePollingPump=true（既存の _link.TryDequeue をブリッジ。内部で最小限ポーリング）
    /// </summary>
    public PacketFramer()
    {
        // フレーミングタスク開始
        _framerTask = Task.Run(() => PacketFramerAsync(_cts.Token));
    }

    /// <summary>
    /// 推奨経路：受信側（Tcp/Serial）から新着データを渡す（完全非ポーリング）
    /// </summary>
    public void OnBytesReceived(byte[] chunk)
    {
        if (chunk == null || chunk.Length == 0) return;
        _rxQueue.Enqueue(chunk);
        _dataAvailable.Release();
    }

    /// <summary>
    /// ストリームからフレーム（パケット）を切り出すワーカー（非ポーリング）
    /// </summary>
    private async Task PacketFramerAsync(CancellationToken ct)
    {
        var packetBuf = new List<byte>(FixedPayloadLength + 4); // ヘッダ＋チェックサム分を余裕みて
        int state = 0, length = 0, counter = 0;
        uint checksum = 0;

        while (!ct.IsCancellationRequested)
        {
            // データ到着までブロック（非ポーリング）
            await _dataAvailable.WaitAsync(ct).ConfigureAwait(false);

            // 到着分をできるだけまとめて処理
            while (_rxQueue.TryDequeue(out var data))
            {
                foreach (byte c in data)
                {
                    switch (state)
                    {
                        case 0: // HEADER1
                            if (c == 0xAA)
                            {
                                packetBuf.Clear();
                                packetBuf.Add(c);
                                state = 1;
                                checksum = 0;
                            }
                            break;

                        case 1: // HEADER2
                            if (c == 0xAA)
                            {
                                packetBuf.Add(c);
                                state = 2;
                            }
                            else state = 0;
                            break;

                        case 2: // COMMAND
                            packetBuf.Add(c);
                            checksum += c;
                            state = 3;
                            break;

                        case 3: // LENGTH
                            if (c != 0)
                            {
                                length = c;
                                packetBuf.Add(c);
                                checksum += c;
                                state = 4;
                                counter = 0;
                            }
                            else
                            {
                                // 無限ループ防止
                                state = 0;
                                Debug.WriteLine("lengthエラー");
                            }
                            break;

                        case 4: // DATA
                            packetBuf.Add(c);
                            checksum += c;
                            counter++;
                            if (counter >= length)
                            {
                                state = 5;
                            }
                            break;

                        case 5: // CHECKSUM1
                            packetBuf.Add(c);
                            checksum += c;
                            state = 6;
                            break;

                        case 6: // CHECKSUM2
                            packetBuf.Add(c);
                            checksum += (uint)(c << 8);
                            uint oc = checksum;
                            while ((oc & 0xFFFF0000) != 0) oc = (oc & 0xFFFF) + (oc >> 16);

                            if (oc == 0xFFFF)
                            {
                                // ★イベント発火
                                var h = PacketReceived;
                                if (h != null) h(packetBuf.ToArray());
                            }
                            else
                            {
                                Debug.WriteLine("csumエラー");
                            }

                            state = 0;
                            break;
                    }
                }
            }
        }
    }

    public void Stop()
    {
        _cts.Cancel();
        try { _framerTask?.Wait(); } catch { /* swallow */ }
    }

    public void Dispose()
    {
        Stop();
        _cts.Dispose();
        _dataAvailable.Dispose();
        // _packetQueue / _rxQueue はマネージのみ
    }
}
