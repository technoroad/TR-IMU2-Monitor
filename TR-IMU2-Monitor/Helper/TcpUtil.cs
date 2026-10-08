using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMU_PlatformTool2.Helper
{
    public static class TcpUtil
    {
        public static bool IsUsableIPv4(string value)
        {
            if (!IPAddress.TryParse(value, out var ip)) return false;
            if (ip.AddressFamily != AddressFamily.InterNetwork) return false;

            var bytes = ip.GetAddressBytes();

            // 0.0.0.0
            if (bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0 && bytes[3] == 0)
                return false;

            // 255.255.255.255
            if (bytes[0] == 255 && bytes[1] == 255 && bytes[2] == 255 && bytes[3] == 255)
                return false;

            return true;
        }


        public static string ToBroadcast255(string ip)
        {
            var parts = ip.Split('.');
            if (parts.Length != 4)
                throw new FormatException("Invalid IPv4 address");

            parts[3] = "255";
            return string.Join(".", parts);
        }
    }
}
