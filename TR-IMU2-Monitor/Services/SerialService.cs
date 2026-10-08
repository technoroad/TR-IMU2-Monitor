using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Buffers;

namespace IMU_PlatformTool2.Services
{
    public class SerialService
    {
        private SerialPort serialPort;
        private CancellationTokenSource cts;
        private int maxRecvData = 8192;
        private const int MinimumReadBufferSize = 262144;
        private const int DataReceivedThreshold = 128;
        private const int DrainFallbackIntervalMs = 10;
        private readonly AutoResetEvent rxSignal = new AutoResetEvent(false);
        private readonly object readLock = new object();
        private readonly object eventLock = new object();
        private bool dataReceivedAttached;

        public event Action<byte[]> BytesReceived;

        public SerialService(SerialPort port)
        {
            serialPort = port ?? throw new ArgumentNullException(nameof(port));
            cts = new CancellationTokenSource();
            cts.Cancel();
        }

        public void Dispose()
        {
            ServiceEnd();
            GC.SuppressFinalize(this);
        }

        public bool IsConnected => serialPort?.IsOpen == true;

        public bool IsRunning => !cts.IsCancellationRequested;

        public void ServiceStart()
        {
            if (cts.IsCancellationRequested)
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;
                AttachDataReceived();
                Task.Run(() => ConnectAsync(token));
                Task.Run(() => ReceiveLoop(token));
            }
        }

        public void ServiceEnd()
        {
            if (!cts.IsCancellationRequested)
            {
                Console.WriteLine($"client({serialPort}): disconnecting...");
                cts.Cancel();
                rxSignal.Set();
                DetachDataReceived();
                Disconnect();
                Console.WriteLine($"client({serialPort}): disconnected!");
            }
        }

        public void Disconnect()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Disconnect error: {ex.Message}");
            }
        }

        private void AttachDataReceived()
        {
            lock (eventLock)
            {
                if (dataReceivedAttached) return;

                serialPort.DataReceived += SerialPort_DataReceived;
                dataReceivedAttached = true;
            }
        }

        private void DetachDataReceived()
        {
            lock (eventLock)
            {
                if (!dataReceivedAttached) return;

                serialPort.DataReceived -= SerialPort_DataReceived;
                dataReceivedAttached = false;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!cts.IsCancellationRequested)
            {
                rxSignal.Set();
            }
        }

        private void ConfigureBeforeOpen()
        {
            try
            {
                if (serialPort.ReadBufferSize < MinimumReadBufferSize)
                {
                    serialPort.ReadBufferSize = MinimumReadBufferSize;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ReadBufferSize config error: {ex.Message}");
            }

            try
            {
                serialPort.ReceivedBytesThreshold = DataReceivedThreshold;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ReceivedBytesThreshold config error: {ex.Message}");
            }
        }

        private async Task ConnectAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!IsConnected)
                    {
                        ConfigureBeforeOpen();
                        serialPort.Open();
                        rxSignal.Set();
                        Console.WriteLine($"{serialPort.PortName}:accepted connection");
                    }
                }
                catch (Exception e)
                {
                    if (!token.IsCancellationRequested)
                    {
                        Console.WriteLine($"Connection error: {e.Message}");
                    }
                }

                try
                {
                    await Task.Delay(1000, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        private void ReceiveLoop(CancellationToken token)
        {
            var handles = new WaitHandle[] { rxSignal, token.WaitHandle };

            while (!token.IsCancellationRequested)
            {
                int waitResult = WaitHandle.WaitAny(handles, DrainFallbackIntervalMs);
                if (waitResult == 1 || token.IsCancellationRequested)
                {
                    break;
                }

                DrainSerialPort(token);
            }
        }

        private void DrainSerialPort(CancellationToken token)
        {
            lock (readLock)
            {
                while (!token.IsCancellationRequested)
                {
                    int available;

                    try
                    {
                        if (serialPort == null || !serialPort.IsOpen)
                        {
                            return;
                        }

                        available = serialPort.BytesToRead;
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                    catch (InvalidOperationException)
                    {
                        return;
                    }

                    if (available <= 0)
                    {
                        return;
                    }

                    int readLength = Math.Min(available, maxRecvData);
                    byte[] packet = new byte[readLength];
                    int received;

                    try
                    {
                        received = serialPort.Read(packet, 0, readLength);
                    }
                    catch (TimeoutException)
                    {
                        return;
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                    catch (InvalidOperationException)
                    {
                        return;
                    }
                    catch (IOException ex)
                    {
                        Debug.WriteLine($"Serial read error: {ex.Message}");
                        Disconnect();
                        return;
                    }
                    catch (Exception ex)
                    {
                        if (!token.IsCancellationRequested)
                        {
                            Debug.WriteLine($"Serial read error: {ex.Message}");
                            Disconnect();
                        }
                        return;
                    }

                    if (received <= 0)
                    {
                        return;
                    }

                    if (received != packet.Length)
                    {
                        byte[] trimmed = new byte[received];
                        Buffer.BlockCopy(packet, 0, trimmed, 0, received);
                        packet = trimmed;
                    }

                    // ★イベント発火
                    var h = BytesReceived;
                    if (h != null) h(packet);
                }
            }
        }

        public void Send(byte[] buffer, int count)
        {
            try
            {
                serialPort.Write(buffer, 0, count);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"write error: {ex}");
            }
        }
    }
}
