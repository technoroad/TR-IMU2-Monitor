using IMU_PlatformTool2.Services;
using System;
using System.Reflection;

namespace IMU_PlatformTool2.Models
{
    public enum CommMode
    {
        Tcp,
        Serial
    }

    public interface ISender
    {
        bool IsConnected { get; }
        bool IsServiceStarted { get; }
        CommMode Mode { get; }
        void ServiceStart();
        void ServiceEnd();
        void Send(byte[] data);
    }

    public sealed class SwitchableSender : ISender
    {
        private readonly TcpClientManager _tcp;
        private readonly SerialService _serial;
        private ISender _inner;

        public SwitchableSender(
            CommMode initialMode,
            TcpClientManager tcp,
            SerialService serial)
        {
            if (tcp == null) throw new ArgumentNullException(nameof(tcp));
            if (serial == null) throw new ArgumentNullException(nameof(serial));

            _tcp = tcp;
            _serial = serial;

            _inner = Create(initialMode);
        }

        public void Switch(CommMode mode)
        {
            if (_inner.Mode == mode) return;
            _inner = Create(mode);
        }

        private ISender Create(CommMode mode)
        {
            switch (mode)
            {
                case CommMode.Tcp:
                    return new TcpSenderAdapter(_tcp);

                case CommMode.Serial:
                    return new SerialSenderAdapter(_serial);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mode));
            }
        }

        public bool IsConnected => _inner.IsConnected;
        public bool IsServiceStarted => _inner.IsServiceStarted;
        public CommMode Mode => _inner.Mode;
        public void ServiceStart() => _inner.ServiceStart();
        public void ServiceEnd() => _inner.ServiceEnd();
        public void Send(byte[] data) => _inner.Send(data);
    }

    sealed class TcpSenderAdapter : ISender
    {
        private readonly TcpClientManager _tcp;

        public TcpSenderAdapter(TcpClientManager tcp)
        {
            _tcp = tcp;
        }

        public bool IsConnected => _tcp.IsConnected;
        public bool IsServiceStarted => _tcp.IsRunning;
        public CommMode Mode => CommMode.Tcp;
        public void ServiceStart() => _tcp.ServiceStart();
        public void ServiceEnd() => _tcp.ServiceEnd();
        public void Send(byte[] data) => _tcp.Send(data, data.Length);
    }

    sealed class SerialSenderAdapter : ISender
    {
        private readonly SerialService _serial;

        public SerialSenderAdapter(SerialService serial)
        {
            _serial = serial;
        }

        public bool IsConnected => _serial.IsConnected;
        public bool IsServiceStarted => _serial.IsRunning;
        public CommMode Mode => CommMode.Serial;
        public void ServiceStart() => _serial.ServiceStart();
        public void ServiceEnd() => _serial.ServiceEnd();
        public void Send(byte[] data) => _serial.Send(data, data.Length);
    }
}
