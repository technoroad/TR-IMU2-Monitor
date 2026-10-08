using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMU_PlatformTool2.Models
{
    // raws と calc を同一時系列で束ねる入れ物
    public sealed class ConfigData
    {
        public readonly RawData Raws;  // スナップショット
        public readonly DecordData Decords;  // スナップショット
        public readonly ulong Count;    // データカウント
        public readonly long TimestampUtc; // 任意: 取得時刻（DateTime.UtcNow.Ticks 等）

        public ConfigData(RawData raws, DecordData decords, ulong cnt, long tsUtc)
        {
            if (raws == null) throw new ArgumentNullException("raws");
            if (decords == null) throw new ArgumentNullException("decords");
            Raws = raws;
            Decords = decords;
            Count = cnt;
            TimestampUtc = tsUtc;
        }

        public ConfigData(ConfigData data)
        {
            if (data == null) throw new ArgumentNullException("data");
            Raws = data.Raws;
            Decords = data.Decords;
            Count = data.Count;
            TimestampUtc = data.TimestampUtc;
        }

        public ConfigData(RawData raws, ulong cnt, long tsUtc)
        {
            if (raws == null) throw new ArgumentNullException("raws");
            Raws = raws;
            Decords = Decord(raws);
            Count = cnt;
            TimestampUtc = tsUtc;
        }

        private DecordData Decord(RawData raws)
        {
            if (raws == null) throw new ArgumentNullException("raws");

            DecordData d = new DecordData();
            if((raws.peripheral_en & 0x01) == 0x01)
            {
                d.usb_en = true;
            }
            if ((raws.peripheral_en & 0x02) == 0x02)
            {
                d.fdcan_en = true;
            }
            if ((raws.peripheral_en & 0x04) == 0x04)
            {
                d.uart4_en = true;
            }

            d.read32bit_en = raws.read32bit_en != 0 ? true : false;

            d.accl_sens = raws.accl_sens * 1e-6;
            d.gyro_sens = raws.gyro_sens * 1e-6;

            if (raws.board == 0)
            {
                d.board = "TR-IMU16607";
            }
            else if (raws.board == 1)
            {
                d.board = "TR-IMU-Platform2";
            }

            d.gravity_corr_en = raws.gravity_corr_en!= 0 ? true : false;

            return d;
        }

        public sealed class RawData
        {
            public byte Cmd;
            public byte warning;
            public uint SendCount;

            public uint version;
            public byte peripheral_en;
            public byte read32bit_en;
            public byte filter_select;
            public ulong accl_sens;
            public ulong gyro_sens;
            public ushort sample_rate;
            public byte imu_maker;
            public ushort product_id;
            public byte model;
            public byte board;
            public byte gravity_corr_en;
            public byte in0_pupd;
            public byte in0_trigger;
        }

        public sealed class DecordData
        {
            public bool usb_en;
            public bool fdcan_en;
            public bool uart4_en;
            public bool read32bit_en;
            public double accl_sens;
            public double gyro_sens;
            public string board;
            public bool gravity_corr_en;
        }
    }
}
