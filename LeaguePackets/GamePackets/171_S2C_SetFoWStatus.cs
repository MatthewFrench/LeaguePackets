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
    public class S2C_SetFoWStatus : GamePacket // 0xAB
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFoWStatus;
        public bool Enabled { get; set; }
        public static S2C_SetFoWStatus CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SetFoWStatus();
            result.SenderNetID = sender;
            byte bitfield = reader.ReadByte();
            result.Enabled = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 1; 
            writer.WriteByte(bitfield);
        }
    }
}
