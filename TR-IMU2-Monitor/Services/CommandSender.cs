using System;
using System.IO.Ports;
using System.Text;
using IMU_PlatformTool2.Models;

namespace IMU_PlatformTool2.Services
{
    // 送信モード切替用クラス
    public class CommandSender
    {
        private CommLinkManager _link;
        private readonly SendLayout commandMaker = new SendLayout();

        public CommandSender(CommLinkManager s)
        {
            _link = s;
        }

        /// <summary>
        /// 現在のモードを取得（未選択時は null）
        /// </summary>
        public CommMode? CurrentMode => _link?.Mode;

        /// <summary>
        /// 互換ショートカット
        /// </summary>
        public CommMode? GetCurrentMode() => CurrentMode;

        public bool IsConnected() => _link.IsConnected;

        public void SendMessage(string message)
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                _link.Send(data);
                Console.WriteLine($"Sent: {message}");
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void PeriodicStart()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.PeriodicStartCmd();
                byte[] cmd2 = commandMaker.ReadConfigureCmd();

                byte[] merged = new byte[cmd.Length + cmd2.Length];

                Buffer.BlockCopy(cmd, 0, merged, 0, cmd.Length);
                Buffer.BlockCopy(cmd2, 0, merged, cmd.Length, cmd2.Length);

                _link.Send(merged);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void PeriodicStop()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.PeriodicStopCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void ResetPose()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.ResetPoseEstinateCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void SystemReset()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.SystemResetCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void JumpDfu()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.JumpDfuCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void ReadConfigure()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.ReadConfigureCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void SaveConfigure()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.SaveConfigureCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void ResetConfigure()
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.ResetConfigureCmd();
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void PeripheralEnable(bool usb, bool fdcan, bool uart4)
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.PeripheralEnableCmd(usb, fdcan, uart4);
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void Read32bitEnable(bool enable)
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.Read32bitCmd(enable);
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void FilterSelect(int idx)
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.FilterSelectCmd(idx);
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void GravityCorrectionEnable(bool enable)
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.GravityCorrEnableCmd(enable);
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }

        public void In0Config(int pupd, int trigger)
        {
            if (_link == null)
                return;

            if (_link.IsConnected)
            {
                byte[] cmd = commandMaker.In0ConfigCmd(pupd, trigger);
                _link.Send(cmd);
            }
            else
            {
                Console.WriteLine("No active connection.");
            }
        }
    }
}
