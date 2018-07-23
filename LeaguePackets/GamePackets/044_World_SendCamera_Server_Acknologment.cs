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
    public class World_SendCamera_Server_Acknologment : GamePacket // 0x2C
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server_Acknologment;
        public byte SyncID { get; set; }
        public static World_SendCamera_Server_Acknologment CreateBody(PacketReader reader, NetID sender)
        {
            var result = new World_SendCamera_Server_Acknologment();
            result.SenderNetID = sender;
            result.SyncID = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(SyncID);
        }
    }
}
