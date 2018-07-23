﻿using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_Exit : GamePacket // 0x98
    {
        public override GamePacketID ID => GamePacketID.S2C_Exit;
        public NetID NetID { get; set; }
        public bool Unknown1 { get; set; }
        public static S2C_Exit CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_Exit();
            result.SenderNetID = sender;
            result.NetID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            result.Unknown1 = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            byte bitfield = 0;
            if (Unknown1)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
