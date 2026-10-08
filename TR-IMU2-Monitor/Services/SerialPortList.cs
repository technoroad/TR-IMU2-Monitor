using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;//プロパティから追加指定もすること
using System.Text.RegularExpressions;

/*
The MIT License (MIT)

Copyright (c) 2019 Techno Road Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

namespace IMU_PlatformTool2.Services
{
    class SerialPortList
    {
        List<String> mDevName;//デバイスマネージャでの表示名
        List<String> mPortName;//COM12等のCOM名
        List<string> mPnpDeviceId; // 追加

        public SerialPortList()
        {
            mDevName = new List<String>();
            mPortName = new List<String>();
            mPnpDeviceId = new List<String>();
            this.Update();
        }

        //データを更新する
        public void Update()
        {
            //クリア
            mDevName.Clear();
            mPortName.Clear();
            mPnpDeviceId.Clear();

            //Windowsにデバイスのリストを要求
            ManagementClass mcW32SerPort = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObj = mcW32SerPort.GetInstances();

            //デバイスリストからCOMポート関連を抽出
            foreach (ManagementObject aSerialPort in manageObj)
            {
                Object deviceCaption = aSerialPort.GetPropertyValue("Caption");
                if (deviceCaption == null) continue;

                String deviceName = deviceCaption.ToString();
                String portName = this.PickUpComName(deviceName);
                if (deviceName != "" && portName != "")
                {
                    //COMポート関連なら、データ登録
                    mDevName.Add(deviceName);
                    mPortName.Add(portName);

                    string pnpId = aSerialPort.GetPropertyValue("PNPDeviceID")?.ToString() ?? "";
                    mPnpDeviceId.Add(pnpId);
                }
            }
        }
        //指定の名前のCOMポートを探す
        public String GetComFromDevName(String dev_name,String ignore_name)
        {
            String ret = "";
            foreach (String dev in mDevName)
            {
                System.Diagnostics.Debug.WriteLine(dev);

                if (dev.Contains(dev_name))
                {
                    if (!dev.Contains(ignore_name))
                    {
                        ret = PickUpComName(dev);
                        break;
                    }
                }
            }
            return ret;

        }

        //指定の名前のCOMポートを探す
        public String GetDevNameFromCom(String com_name)
        {
            String ret = "";
            foreach (String dev in mDevName)
            {
                System.Diagnostics.Debug.WriteLine(dev);

                if (dev == null || com_name == null)
                {
                    break;
                }

                if (dev.IndexOf(com_name) !=-1)
                {
                    ret = dev;
                    break;
                }
            }
            return ret;

        }

        //ほげ(COMx)ほげ から、COMxを正規表現で抽出する。該当が無ければ""を返す。
        String PickUpComName(String inname)
        {
            String ret = "";
            if (Regex.IsMatch(inname, "\\(COM\\d+\\)"))
            {
                Match m = Regex.Match(inname, "\\(COM\\d+\\)");
                m.NextMatch();
                String temp = m.Value;
                if (Regex.IsMatch(inname, "COM\\d+"))
                {
                    Match m2 = Regex.Match(inname, "COM\\d+");
                    m2.NextMatch();
                    ret = m2.Value;
                }
            }
            else {
            }
            return ret;
        }

        public string GetComFromVidPid(string vid, string pid, string ignorePnpIdContains = "")
        {
            if (string.IsNullOrWhiteSpace(vid) || string.IsNullOrWhiteSpace(pid)) return "";

            // VID/PID の表記ゆれ対策（小文字/大文字、0x付き等）
            vid = NormalizeHex4(vid);
            pid = NormalizeHex4(pid);

            string keyVid = "VID_" + vid;
            string keyPid = "PID_" + pid;

            for (int i = 0; i < mPnpDeviceId.Count; i++)
            {
                string pnp = mPnpDeviceId[i] ?? "";
                if (pnp.IndexOf(keyVid, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    pnp.IndexOf(keyPid, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (!string.IsNullOrEmpty(ignorePnpIdContains) &&
                        pnp.IndexOf(ignorePnpIdContains, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        continue;
                    }
                    return mPortName[i]; // Update()で既に COM を拾っている
                }
            }
            return "";
        }

        private static string NormalizeHex4(string s)
        {
            s = s.Trim();
            if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                s = s.Substring(2);
            s = s.ToUpperInvariant();
            // 4桁に寄せたい場合（VID/PIDは通常4桁）
            if (s.Length < 4) s = s.PadLeft(4, '0');
            return s;
        }

    }
}
