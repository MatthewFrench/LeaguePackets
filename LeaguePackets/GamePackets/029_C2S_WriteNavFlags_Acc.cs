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
    public class C2S_WriteNavFlags_Acc : GamePacket // 0x1D
    {
        public override GamePacketID ID => GamePacketID.C2S_WriteNavFlags_Acc;
        public int SyncID { get; set; }
        public static C2S_WriteNavFlags_Acc CreateBody(PacketReader reader, NetID sender)
        {
            var result = new C2S_WriteNavFlags_Acc();
            result.SenderNetID = sender;
            result.SyncID = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SyncID);
        }
    }
}
