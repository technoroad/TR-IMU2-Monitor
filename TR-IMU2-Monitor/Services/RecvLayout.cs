using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMU_PlatformTool2.Models;

namespace IMU_PlatformTool2.Services
{
    internal static class TelemetryPacketLayout
    {
        internal static readonly PacketLayout Layout =
            new PacketLayoutBuilder()
            .Reserved(2)  // ヘッダ 2byte

            .AddU8(nameof(TelemetryData.RawData.Cmd))
            .Reserved(1)  // データ長 1byte
            .AddU8(nameof(TelemetryData.RawData.warning))
            .AddU32(nameof(TelemetryData.RawData.SendCount))

            .AddU16(nameof(TelemetryData.RawData.Quat_w))
            .AddU16(nameof(TelemetryData.RawData.Quat_x))
            .AddU16(nameof(TelemetryData.RawData.Quat_y))
            .AddU16(nameof(TelemetryData.RawData.Quat_z))

            .AddU32(nameof(TelemetryData.RawData.Accl_x))
            .AddU32(nameof(TelemetryData.RawData.Accl_y))
            .AddU32(nameof(TelemetryData.RawData.Accl_z))

            .AddU32(nameof(TelemetryData.RawData.Gyro_x))
            .AddU32(nameof(TelemetryData.RawData.Gyro_y))
            .AddU32(nameof(TelemetryData.RawData.Gyro_z))

            .AddU16(nameof(TelemetryData.RawData.Temp))
            .AddU16(nameof(TelemetryData.RawData.ImuCount))
            .AddU16(nameof(TelemetryData.RawData.DroppedCount))
            .AddU16(nameof(TelemetryData.RawData.ComputationTime))
            .AddU16(nameof(TelemetryData.RawData.SpiTime))
            .AddU8(nameof(TelemetryData.RawData.in0_pin))
            .AddU64(nameof(TelemetryData.RawData.Timestamp))

            .Reserved(8) // 予備16byte

            .Build();
    }

    internal static class ConfigPacketLayout
    {
        internal static readonly PacketLayout Layout =
            new PacketLayoutBuilder()
            .Reserved(2)  // ヘッダ 2byte

            .AddU8(nameof(ConfigData.RawData.Cmd))
            .Reserved(1)  // データ長 1byte
            .AddU8(nameof(ConfigData.RawData.warning))
            .AddU32(nameof(ConfigData.RawData.SendCount))

            .AddU32(nameof(ConfigData.RawData.version))
            .AddU8(nameof(ConfigData.RawData.peripheral_en))
            .AddU8(nameof(ConfigData.RawData.read32bit_en))
            .AddU8(nameof(ConfigData.RawData.filter_select))

            .AddU64(nameof(ConfigData.RawData.accl_sens))
            .AddU64(nameof(ConfigData.RawData.gyro_sens))

            .AddU16(nameof(ConfigData.RawData.sample_rate))
            .AddU8(nameof(ConfigData.RawData.imu_maker))
            .AddU16(nameof(ConfigData.RawData.product_id))
            .AddU8(nameof(ConfigData.RawData.model))
            .AddU8(nameof(ConfigData.RawData.board))
            .AddU8(nameof(ConfigData.RawData.gravity_corr_en))
            .AddU8(nameof(ConfigData.RawData.in0_pupd))
            .AddU8(nameof(ConfigData.RawData.in0_trigger))

            .Reserved(26) // 予備26byte

            .Build();
    }

    public class PacketParser
    {
        private PacketReader p_read = new PacketReader(Endian.Little);
        private ulong telemetry_count;
        private ulong config_count;

        private PacketFramer framer;

        private readonly ConcurrentQueue<TelemetryData> _telemetry_queue = new ConcurrentQueue<TelemetryData>();
        private readonly ConcurrentQueue<ConfigData> _config_queue = new ConcurrentQueue<ConfigData>();

        public PacketParser(CommLinkManager link)
        {
            if (link == null) throw new ArgumentNullException(nameof(link));

            // アプリ起動時に呼ぶ
            _ = TelemetryPacketLayout.Layout.TotalLength;

            framer = new PacketFramer();
            link.BytesReceived += framer.OnBytesReceived;
            framer.PacketReceived += this.Parse;
        }

        public void Parse(byte[] packet)
        {
            byte cmd = packet[2];
            // 0x70以下ならテレメトリコマンドそれ以上なら、コンフィグコマンド
            if (cmd < 0x70)
            {
                // 長さチェック（最低限）
                if (packet.Length < TelemetryPacketLayout.Layout.TotalLength)
                {
                    Debug.WriteLine("telemetry parser:lengthエラー");
                    return;
                }

                var lay = TelemetryPacketLayout.Layout;
                var d = new TelemetryData.RawData();

                d.Cmd = p_read.U8(packet, lay[nameof(TelemetryData.RawData.Cmd)].Offset);
                d.warning = p_read.U8(packet, lay[nameof(TelemetryData.RawData.warning)].Offset);
                d.SendCount = p_read.U32(packet, lay[nameof(TelemetryData.RawData.SendCount)].Offset);

                d.Quat_w = p_read.U16(packet, lay[nameof(TelemetryData.RawData.Quat_w)].Offset);
                d.Quat_x = p_read.U16(packet, lay[nameof(TelemetryData.RawData.Quat_x)].Offset);
                d.Quat_y = p_read.U16(packet, lay[nameof(TelemetryData.RawData.Quat_y)].Offset);
                d.Quat_z = p_read.U16(packet, lay[nameof(TelemetryData.RawData.Quat_z)].Offset);

                d.Accl_x = p_read.U32(packet, lay[nameof(TelemetryData.RawData.Accl_x)].Offset);
                d.Accl_y = p_read.U32(packet, lay[nameof(TelemetryData.RawData.Accl_y)].Offset);
                d.Accl_z = p_read.U32(packet, lay[nameof(TelemetryData.RawData.Accl_z)].Offset);

                d.Gyro_x = p_read.U32(packet, lay[nameof(TelemetryData.RawData.Gyro_x)].Offset);
                d.Gyro_y = p_read.U32(packet, lay[nameof(TelemetryData.RawData.Gyro_y)].Offset);
                d.Gyro_z = p_read.U32(packet, lay[nameof(TelemetryData.RawData.Gyro_z)].Offset);

                d.Temp = p_read.U16(packet, lay[nameof(TelemetryData.RawData.Temp)].Offset);
                d.ImuCount = p_read.U16(packet, lay[nameof(TelemetryData.RawData.ImuCount)].Offset);
                d.DroppedCount = p_read.U16(packet, lay[nameof(TelemetryData.RawData.DroppedCount)].Offset);
                d.ComputationTime = p_read.U16(packet, lay[nameof(TelemetryData.RawData.ComputationTime)].Offset);
                d.SpiTime = p_read.U16(packet, lay[nameof(TelemetryData.RawData.SpiTime)].Offset);
                d.in0_pin = p_read.U8(packet, lay[nameof(TelemetryData.RawData.in0_pin)].Offset);
                d.Timestamp = p_read.U64(packet, lay[nameof(TelemetryData.RawData.Timestamp)].Offset);
                telemetry_count++;

                TelemetryData trm = new TelemetryData(d, telemetry_count, DateTime.UtcNow.Ticks);
                _telemetry_queue.Enqueue(trm);
            }
            else if(cmd < 0xB0)
            {
                // 長さチェック（最低限）
                if (packet.Length < ConfigPacketLayout.Layout.TotalLength)
                {
                    Debug.WriteLine("config parser:lengthエラー");
                    return;
                }

                var lay = ConfigPacketLayout.Layout;
                var d = new ConfigData.RawData();

                d.Cmd = p_read.U8(packet, lay[nameof(ConfigData.RawData.Cmd)].Offset);
                d.warning = p_read.U8(packet, lay[nameof(ConfigData.RawData.warning)].Offset);
                d.SendCount = p_read.U32(packet, lay[nameof(ConfigData.RawData.SendCount)].Offset);

                d.version = p_read.U32(packet, lay[nameof(ConfigData.RawData.version)].Offset);
                d.peripheral_en = p_read.U8(packet, lay[nameof(ConfigData.RawData.peripheral_en)].Offset);
                d.read32bit_en = p_read.U8(packet, lay[nameof(ConfigData.RawData.read32bit_en)].Offset);
                d.filter_select = p_read.U8(packet, lay[nameof(ConfigData.RawData.filter_select)].Offset);
                d.accl_sens = p_read.U64(packet, lay[nameof(ConfigData.RawData.accl_sens)].Offset);
                d.gyro_sens = p_read.U64(packet, lay[nameof(ConfigData.RawData.gyro_sens)].Offset);
                d.sample_rate = p_read.U16(packet, lay[nameof(ConfigData.RawData.sample_rate)].Offset);
                d.imu_maker = p_read.U8(packet, lay[nameof(ConfigData.RawData.imu_maker)].Offset);
                d.product_id = p_read.U16(packet, lay[nameof(ConfigData.RawData.product_id)].Offset);
                d.model = p_read.U8(packet, lay[nameof(ConfigData.RawData.model)].Offset);

                d.board = p_read.U8(packet, lay[nameof(ConfigData.RawData.board)].Offset);
                d.gravity_corr_en = p_read.U8(packet, lay[nameof(ConfigData.RawData.gravity_corr_en)].Offset);
                d.in0_pupd = p_read.U8(packet, lay[nameof(ConfigData.RawData.in0_pupd)].Offset);
                d.in0_trigger = p_read.U8(packet, lay[nameof(ConfigData.RawData.in0_trigger)].Offset);
                config_count++;

                ConfigData conf = new ConfigData(d, config_count, DateTime.UtcNow.Ticks);
                _config_queue.Enqueue(conf);
            }
            else
            {

            }
        }

        /// <summary>
        /// キューから 1 件取り出します（非ブロッキング）
        /// 取り出せたら true、空なら false を返します。
        /// </summary>
        public bool TryDequeueTelemetry(out TelemetryData data)
        {
            return _telemetry_queue.TryDequeue(out data);
        }

        /// <summary>
        /// キューから 1 件取り出します（非ブロッキング）
        /// 取り出せたら true、空なら false を返します。
        /// </summary>
        public bool TryDequeueConfig(out ConfigData data)
        {
            return _config_queue.TryDequeue(out data);
        }
    }
}
