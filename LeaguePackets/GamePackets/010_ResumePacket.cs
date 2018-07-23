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
    public class ResumePacket : GamePacket // 0xA
    {
        public override GamePacketID ID => GamePacketID.ResumePacket;
        public ClientID ClientID { get; set; }
        public bool Delayed { get; set; }
        public static ResumePacket CreateBody(PacketReader reader, NetID sender)
        {
            var result = new ResumePacket();
            result.SenderNetID = sender;
            result.ClientID = reader.ReadClientID();
            byte bitfield = reader.ReadByte();
            result.Delayed = (bitfield & 0x01) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            byte bitfield = 0;
            if (Delayed)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
