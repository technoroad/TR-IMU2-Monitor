using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IMU_PlatformTool2.Models;
using IMU_PlatformTool2.Services;

public class CommLinkManager
{
    private SerialService _serialService;
    private TcpClientManager _tcpClientManager;
    private SwitchableSender _link;

    public event Action<byte[]> BytesReceived;

    public CommLinkManager(
        CommMode initialMode,
        TcpEndpoint endpoint,
        SerialPort serial)
    {
        _serialService = new SerialService(serial);
        _tcpClientManager = new TcpClientManager(endpoint);
        _link = new SwitchableSender(initialMode, _tcpClientManager, _serialService);


        // ★ 下位層の受信イベントに登録（イベント名は実装に合わせて置換）
        _serialService.BytesReceived += OnBytesReceived;
        _tcpClientManager.BytesReceived += OnBytesReceived;
    }

    private void OnBytesReceived(byte[] bytes)
    {
        if (bytes != null && bytes.Length > 0)
        {
            var h = this.BytesReceived;
            if (h != null) h(bytes);
        }
    }


    public void Dispose()
    {
        ServiceEnd();
        GC.SuppressFinalize(this);
    }

    public bool IsConnected => _link.IsConnected;
    public bool IsServiceStarted => _link.IsServiceStarted;
    public CommMode Mode => _link.Mode;
    public void ServiceStart() => _link.ServiceStart();
    public void ServiceEnd() => _link.ServiceEnd();
    public void Send(byte[] data) => _link.Send(data);
    public void Switch(CommMode mode) => _link.Switch(mode);
}