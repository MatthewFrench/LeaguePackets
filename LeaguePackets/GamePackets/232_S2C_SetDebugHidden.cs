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
    public class S2C_SetDebugHidden : GamePacket // 0xE8
    {
        public override GamePacketID ID => GamePacketID.S2C_SetDebugHidden;
        public int ObjectID { get; set; }
        public byte Bitfield { get; set; }
        public static S2C_SetDebugHidden CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SetDebugHidden();
            result.SenderNetID = sender;
            result.ObjectID = reader.ReadInt32();
            result.Bitfield = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteByte(Bitfield);
        }
    }
}
