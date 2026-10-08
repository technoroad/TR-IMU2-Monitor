using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace IMU_PlatformTool2.Udp
{

    public class UdpCommunicator
    {
        private UdpClient udpClient;
        private IPEndPoint remoteEndPoint;
        private Thread receiveThread;
        private bool isReceiving = false;
        private readonly ConcurrentQueue<byte[]> recvQueue = new ConcurrentQueue<byte[]>();
        private const int QueueCapacity = 4096;

        public UdpCommunicator(int listenPort)
        {
            udpClient = new UdpClient(listenPort);
        }

        public void StartReceiving()
        {
            isReceiving = true;
            receiveThread = new Thread(ReceiveLoop);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        public void StopReceiving()
        {
            isReceiving = false;
            udpClient?.Close();
            receiveThread?.Join();
        }

        private void ReceiveLoop()
        {
            while (isReceiving)
            {
                try
                {
                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = udpClient.Receive(ref sender);

                    // キューの容量制限
                    if (recvQueue.Count < QueueCapacity)
                    {
                        recvQueue.Enqueue(data);
                    }
                    else
                    {
                        Debug.WriteLine($"キューの容量オーバーで削除");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("受信エラー: " + ex.Message);
                }
            }
        }

        public void SendText(string message, string ipAddress, int port)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                remoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                udpClient.Send(data, data.Length, remoteEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("送信エラー: " + ex.Message);
            }
        }

        public void SendBinary(byte[] data, string ipAddress, int port)
        {
            try
            {
                remoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                udpClient.Send(data, data.Length, remoteEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("送信エラー: " + ex.Message);
            }
        }

        public Dictionary<string, (string, int)> GetW55RP20Address(Dictionary<string, (string, int)> dev)
        {
            if (recvQueue.TryDequeue(out byte[] packet)){
                List<byte[]> list = SplitByCRLF(packet);
                string mac = "";
                string ip = "";
                int port = 0;

                foreach (byte[] data in list)
                {
                    string str = "";
                    str += Encoding.UTF8.GetString(data);
                    Debug.WriteLine(str);

                    if (data[0] == 'L' && data[1] == 'I')
                    {
                        ip = str.Remove(0, 2);
                    }

                    if (data[0] == 'M' && data[1] == 'C')
                    {
                        mac = str.Remove(0, 2);
                    }

                    if (data[0] == 'L' && data[1] == 'P')
                    {
                        port = int.Parse(str.Remove(0,2));
                    }

                    if (mac != "" && ip != "" && port != 0)
                    {
                        try
                        {
                            dev.Add(mac, (ip, port));
                        }
                        catch(Exception ex)
                        {
                            // データ重複
                            Console.WriteLine("データ重複: " + ex.Message);
                        }
                    }
                }
            }

            return dev;
        }


        public static List<byte[]> SplitByCRLF(byte[] input)
        {
            List<byte[]> result = new List<byte[]>();
            List<byte> buffer = new List<byte>();

            for (int i = 0; i < input.Length; i++)
            {
                // Check for CR+LF
                if (i < input.Length - 1 && input[i] == 0x0D && input[i + 1] == 0x0A)
                {
                    result.Add(buffer.ToArray());
                    buffer.Clear();
                    i++; // Skip LF
                }
                else
                {
                    buffer.Add(input[i]);
                }
            }

            // Add remaining buffer if any
            if (buffer.Count > 0)
            {
                result.Add(buffer.ToArray());
            }

            return result;
        }

    }
}
