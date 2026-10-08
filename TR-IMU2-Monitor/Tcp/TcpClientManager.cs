using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

public class TcpClientManager
{
    private readonly TcpEndpoint endpoint;

    // 接続中のクライアント
    public Socket clientSocket;
    public IPEndPoint IPEndPoint => endpoint.ToIPEndPoint();

    private CancellationTokenSource cts;
    private bool connected;
    private int maxRecvData = 8192;

    public event Action<byte[]> BytesReceived;

    public TcpClientManager(TcpEndpoint endpoint, string name = "client")
    {
        this.endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));

        connected = false;
        cts = new CancellationTokenSource();
        cts.Cancel();
    }

    public void Dispose()
    {
        ServiceEnd();
        GC.SuppressFinalize(this);
    }

    public bool IsConnected => connected;

    public bool IsRunning => !cts.IsCancellationRequested;

    public void ServiceStart()
    {
        if (cts.IsCancellationRequested)
        {
            cts = new CancellationTokenSource();
            clientSocket = new Socket(IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.ReceiveTimeout = 10000;
            clientSocket.SendTimeout = 1000;

            Task.Run(ConnectAsync);
            Task.Run(ReceiveAsync);
        }
    }

    public void ServiceEnd()
    {
        if (!cts.IsCancellationRequested)
        {
            Console.WriteLine($"client({clientSocket}): disconnecting...");
            cts.Cancel();
            this.Disconnect();
            Console.WriteLine($"client({clientSocket}): disconnected!");
        }
    }

    private void Disconnect()
    {
        if (connected)
        {
            connected = false;
            clientSocket.Close();
            clientSocket = new Socket(IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
    }

    private async Task ConnectAsync()
    {
        while (!cts.IsCancellationRequested)
        {
            try
            {
                if (!connected)
                {
                    clientSocket.Connect(endpoint.ToIPEndPoint());
                    connected = true;
                    Console.WriteLine($"{clientSocket.LocalEndPoint}:accepted connection");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Connection error: {e.Message}");
            }
            await Task.Delay(1000);
        }
    }

    private async Task ReceiveAsync()
    {
        while (!cts.IsCancellationRequested)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(maxRecvData);
            int received = 0;
            try
            {
                if (!connected || clientSocket == null || !clientSocket.Connected)
                {
                    // 接続が確立されるまで待機（過度なCPU消費を避ける）
                    await Task.Delay(100, cts.Token);
                    continue;
                }

                var memory = buffer.AsMemory(0, maxRecvData);
                received = await clientSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer, 0, maxRecvData), SocketFlags.None);
                if (received > 0)
                {
                    byte[] packet = new byte[received];
                    Buffer.BlockCopy(buffer, 0, packet, 0, received);

                    // ★イベント発火
                    var h = BytesReceived;
                    if (h != null) h(packet);
                }
                else
                {
                    Debug.WriteLine($"相手の切断?");
                }
            }
            catch (SocketException e)
            {
                if (e.NativeErrorCode.Equals(10054))
                {
                    Console.WriteLine($"Connection error: {e.Message}");
                    this.Disconnect();
                    await Task.Delay(1000); // 再接続までの待機時間
                }
                else
                {
                }
            }
            catch
            {
                Console.WriteLine("レシーブエラー");
            }
            finally
            {
                // 借りたバッファは必ず返却
                ArrayPool<byte>.Shared.Return(buffer);
            }

            await Task.Delay(1);
        }
    }

    // クライアントへのメッセージ送信処理

    public void Send(byte[] buffer, int length)
    {
        if (!connected || clientSocket == null) return;

        try
        {
            int offset = 0;

            while (length > 0)
            {
                int sent = clientSocket.Send(buffer, offset, length, SocketFlags.None);
                if (sent <= 0)
                {
                    throw new SocketException((int)SocketError.ConnectionReset);
                }
                offset += sent;
                length -= sent;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error sending data: {e.Message}");
            this.Disconnect();
        }
    }
}

public class TcpEndpoint
{
    public string Ip;
    public int Port;

    public IPEndPoint ToIPEndPoint()
    {
        return new IPEndPoint(IPAddress.Parse(Ip), Port);
    }
}