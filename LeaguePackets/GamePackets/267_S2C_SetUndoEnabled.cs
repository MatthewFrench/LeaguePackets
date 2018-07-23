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
    public class S2C_SetUndoEnabled : GamePacket // 0x10B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetUndoEnabled;
        public byte UndoStackSize { get; set; }
        public static S2C_SetUndoEnabled CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SetUndoEnabled();
            result.SenderNetID = sender;
            result.UndoStackSize = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(UndoStackSize);
        }
    }
}
