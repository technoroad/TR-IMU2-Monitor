using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using IMU_PlatformTool2.Models;
using System.Threading;


namespace IMU_PlatformTool2.Services
{
    public enum Endian
    {
        Little,
        Big
    }

    internal struct FieldDef
    {
        public readonly string Key;
        public readonly int Offset;
        public readonly int Size;

        public FieldDef(string key, int offset, int size)
        {
            Key = key;
            Offset = offset;
            Size = size;
        }

        public override string ToString()
        {
            return string.Format("{0} @ {1} ({2} bytes)", Key, Offset, Size);
        }
    }

    internal sealed class PacketLayout
    {
        private readonly Dictionary<string, FieldDef> _map;
        public readonly int TotalLength;

        internal PacketLayout(Dictionary<string, FieldDef> map, int totalLength)
        {
            _map = map;
            TotalLength = totalLength;
        }

        public FieldDef this[string key]
        {
            get { return _map[key]; }
        }

        public bool TryGet(string key, out FieldDef def)
        {
            return _map.TryGetValue(key, out def);
        }
    }

    internal sealed class PacketLayoutBuilder
    {
        private readonly Dictionary<string, FieldDef> _map = new Dictionary<string, FieldDef>();
        private int _offset;

        public PacketLayoutBuilder Add(string key, int size)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("key is null/empty", nameof(key));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            if (_map.ContainsKey(key)) throw new InvalidOperationException("Duplicate key: " + key);

            _map[key] = new FieldDef(key, _offset, size);
            _offset += size;
            return this;
        }

        public PacketLayoutBuilder AddU8(string key) { return Add(key, 1); }
        public PacketLayoutBuilder AddU16(string key) { return Add(key, 2); }
        public PacketLayoutBuilder AddU32(string key) { return Add(key, 4); }
        public PacketLayoutBuilder AddU64(string key) { return Add(key, 8); }

        public PacketLayoutBuilder Reserved(int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            _offset += size;
            return this;
        }

        public PacketLayout Build()
        {
            return new PacketLayout(_map, _offset);
        }
    }

    internal class PacketReader
    {
        private readonly Endian _byteOrder;

        public PacketReader(Endian byteOrder)
        {
            _byteOrder = byteOrder;
        }

        public byte U8(ReadOnlySpan<byte> p, int offset)
        {
            return p[offset];
        }

        public ushort U16(ReadOnlySpan<byte> p, int offset)
        {
            if (_byteOrder == Endian.Little)
            {
                return (ushort)(
                    p[offset] |
                    (p[offset + 1] << 8)
                );
            }
            else
            {
                return (ushort)(
                    (p[offset] << 8) |
                    p[offset + 1]
                );
            }
        }

        public uint U32(ReadOnlySpan<byte> p, int offset)
        {
            if (_byteOrder == Endian.Little)
            {
                return
                    (uint)p[offset] |
                    ((uint)p[offset + 1] << 8) |
                    ((uint)p[offset + 2] << 16) |
                    ((uint)p[offset + 3] << 24);
            }
            else
            {
                return
                    ((uint)p[offset] << 24) |
                    ((uint)p[offset + 1] << 16) |
                    ((uint)p[offset + 2] << 8) |
                    (uint)p[offset + 3];
            }
        }

        public ulong U64(ReadOnlySpan<byte> p, int offset)
        {
            // ここでは p の範囲チェックは呼び出し側に任せる想定です
            // （必要なら if (offset < 0 || offset + 8 > p.Length) throw ...）

            if (_byteOrder == Endian.Little)
            {
                return
                    (ulong)p[offset] |
                    ((ulong)p[offset + 1] << 8) |
                    ((ulong)p[offset + 2] << 16) |
                    ((ulong)p[offset + 3] << 24) |
                    ((ulong)p[offset + 4] << 32) |
                    ((ulong)p[offset + 5] << 40) |
                    ((ulong)p[offset + 6] << 48) |
                    ((ulong)p[offset + 7] << 56);
            }
            else // Big-endian
            {
                return
                    ((ulong)p[offset] << 56) |
                    ((ulong)p[offset + 1] << 48) |
                    ((ulong)p[offset + 2] << 40) |
                    ((ulong)p[offset + 3] << 32) |
                    ((ulong)p[offset + 4] << 24) |
                    ((ulong)p[offset + 5] << 16) |
                    ((ulong)p[offset + 6] << 8) |
                    (ulong)p[offset + 7];
            }
        }
    }
}
