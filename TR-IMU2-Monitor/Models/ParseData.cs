using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Quaternion = System.Windows.Media.Media3D.Quaternion;

namespace IMU_PlatformTool2.Models
{
    // raws と calc を同一時系列で束ねる入れ物
    public sealed class TelemetryData
    {
        public readonly RawData Raws;  // スナップショット
        public readonly DecordData Decords;  // スナップショット
        public readonly ulong Count;    // データカウント
        public readonly long TimestampUtc; // 任意: 取得時刻（DateTime.UtcNow.Ticks 等）

        public TelemetryData(RawData raws, DecordData decords, ulong cnt, long tsUtc)
        {
            if (raws == null) throw new ArgumentNullException("raws");
            if (decords == null) throw new ArgumentNullException("decords");
            Raws = raws;
            Decords = decords;
            Count = cnt;
            TimestampUtc = tsUtc;
        }

        public TelemetryData(TelemetryData data)
        {
            if (data == null) throw new ArgumentNullException("data");
            Raws = data.Raws;
            Decords = data.Decords;
            Count = data.Count;
            TimestampUtc = data.TimestampUtc;
        }

        public TelemetryData(RawData raws, ulong cnt, long tsUtc)
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

            float[] quat = new float[4]; // w,x,y,z
            short rawq;
            rawq = unchecked((short)raws.Quat_w);
            quat[0] = rawq * (1.0f / 32767.0f);
            rawq = unchecked((short)raws.Quat_x);
            quat[1] = rawq * (1.0f / 32767.0f);
            rawq = unchecked((short)raws.Quat_y);
            quat[2] = rawq * (1.0f / 32767.0f);
            rawq = unchecked((short)raws.Quat_z);
            quat[3] = rawq * (1.0f / 32767.0f);

            var q = new Quaternion(
                quat[1], quat[2], quat[3], quat[0]);
            q.Normalize();

            d.QuatNorm.W = q.W;
            d.QuatNorm.X = q.X;
            d.QuatNorm.Y = q.Y;
            d.QuatNorm.Z = q.Z;
            d.EulerDeg = ToEulerAngles(q);
            d.TempC = raws.Temp / 10.0f;

            if ((raws.in0_pin & 0x01) == 0x01)
            {
                d.in0_trig = true;
            }
            else
            {
                d.in0_trig = false;
            }

            if ((raws.in0_pin & 0x02) == 0x02)
            {
                d.in0_input = true;
            }
            else
            {
                d.in0_input = false;
            }
            return d;
        }

        private static Vector3 ToEulerAngles(Quaternion q)
        {
            double w = q.W;
            double x = q.X;
            double y = q.Y;
            double z = q.Z;

            // Roll (X)
            double sinr = 2.0 * (w * x + y * z);
            double cosr = 1.0 - 2.0 * (x * x + y * y);
            double roll = Math.Atan2(sinr, cosr);

            // Pitch (Y)
            double sinp = 2.0 * (w * y - z * x);
            double pitch;
            if (Math.Abs(sinp) >= 1.0)
                pitch = Math.Sign(sinp) * (Math.PI / 2.0);
            else
                pitch = Math.Asin(sinp);

            // Yaw (Z) 
            double siny = 2.0 * (w * z + x * y);
            double cosy = 1.0 - 2.0 * (y * y + z * z);
            double yaw = Math.Atan2(siny, cosy);

            // rad → deg
            const double rad2deg = 180.0 / Math.PI;

            return new Vector3(
                (float)(roll * rad2deg),
                (float)(pitch * rad2deg),
                (float)(yaw * rad2deg)
            );
        }

        public sealed class RawData
        {
            public byte Cmd;
            public byte warning;
            public uint SendCount;

            public ushort Quat_w;
            public ushort Quat_x;
            public ushort Quat_y;
            public ushort Quat_z;
            public uint Accl_x;
            public uint Accl_y;
            public uint Accl_z;
            public uint Gyro_x;
            public uint Gyro_y;
            public uint Gyro_z;
            public ushort Temp;
            public ushort ImuCount;
            public ushort DroppedCount;
            public ushort ComputationTime;
            public ushort SpiTime;
            public byte in0_pin;
            public ulong Timestamp;
        }

        public sealed class DecordData
        {
            public Quaternion QuatNorm = new Quaternion(); // w,x,y,z
            public float TempC;
            public System.Numerics.Vector3 EulerDeg;
            public bool in0_trig;
            public bool in0_input;
        }
    }
}
