﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syroot.BinaryData;
using Syroot.BinaryData.Core;
using Syroot.BinaryData.Memory;

namespace GTToolsSharp.Headers
{
    public class FileDeviceGTFSHeader : VolumeHeaderBase
    {
        public override int HeaderSize => 0x14;

        private static readonly byte[] HeaderMagic = { 0x5B, 0x74, 0x51, 0x61 };

        public bool HasCustomGameID { get; set; }

        public override void Read(Span<byte> buffer)
        {
            SpanReader sr = new SpanReader(buffer, Endian.Big);

            Magic = sr.ReadBytes(4);
            sr.Position += 4;
            ToCNodeIndex = sr.ReadUInt32();
            CompressedTOCSize = sr.ReadUInt32();
            ExpandedTOCSize = sr.ReadUInt32();
        }

        public override byte[] Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
