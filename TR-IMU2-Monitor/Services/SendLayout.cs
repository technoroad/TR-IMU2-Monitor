using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMU_PlatformTool2.Services
{
    public class SendLayout
    {
        public SendLayout()
        {
        }

        private UInt16 csum_calc(byte[] pkt)
        {
            // 合計値を求める
            UInt32 sum = 0;
            for (int i = 2; i < 4 + pkt[3]; i++)
            {
                sum += pkt[i];
            }

            // 1の補数和を求める
            UInt32 oc = sum;
            while ((oc & 0xFFFF0000) != 0)
            {
                oc = (oc & 0xFFFF) + (oc >> 16);
            }

            // 1の補数和の1補数を求める
            UInt16 oco = (UInt16)(oc ^ 0xFFFF);

            return oco;
        }

        public byte[] DoNothingCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x30);
            dat.Add(0x01);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] PeriodicStartCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x31);
            dat.Add(0x01);
            dat.Add(0x00);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] PeriodicStopCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x32);
            dat.Add(0x01);
            dat.Add(0x00);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] ResetPoseEstinateCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x33);
            dat.Add(0x01);
            dat.Add(0x00);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] SystemResetCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0xB0);
            dat.Add(0x01);
            dat.Add(0x00);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] JumpDfuCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0xB1);
            dat.Add(0x04);
            dat.Add(0x12);
            dat.Add(0x34);
            dat.Add(0x56);
            dat.Add(0x78);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }


        public byte[] ReadConfigureCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x70);
            dat.Add(0x01);
            dat.Add(0x00);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }


        public byte[] SaveConfigureCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x71);
            dat.Add(0x02);
            dat.Add(0x12);
            dat.Add(0x34);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] ResetConfigureCmd()
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x72);
            dat.Add(0x01);
            dat.Add(0x00);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] PeripheralEnableCmd(bool usb, bool fdcan, bool uart4)
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x73);
            dat.Add(0x01);

            int flag = usb ? 0x01 : 0x00;
            flag |= fdcan ? 0x02 : 0x00;
            flag |= uart4 ? 0x04 : 0x00;
            dat.Add((byte)(flag & 0xFF));

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] Read32bitCmd(bool enable)
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x74);
            dat.Add(0x01);

            int flag = enable ? 0x01 : 0x00;
            dat.Add((byte)(flag & 0xFF));

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] FilterSelectCmd(int idx)
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x75);
            dat.Add(0x01);

            dat.Add((byte)idx);

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }

        public byte[] GravityCorrEnableCmd(bool enable)
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x76);
            dat.Add(0x01);

            int flag = enable ? 0x01 : 0x00;
            dat.Add((byte)(flag & 0xFF));

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }


        public byte[] In0ConfigCmd(int pupd, int trigger)
        {
            List<byte> dat = new List<byte>();
            dat.Add(0xAA);
            dat.Add(0xAA);
            dat.Add(0x77);
            dat.Add(0x02);

            dat.Add((byte)(pupd & 0xFF));
            dat.Add((byte)(trigger & 0xFF));

            UInt16 csum = csum_calc(dat.ToArray());
            dat.Add((byte)csum);
            dat.Add((byte)(csum >> 8));

            return dat.ToArray();
        }
    }
}
