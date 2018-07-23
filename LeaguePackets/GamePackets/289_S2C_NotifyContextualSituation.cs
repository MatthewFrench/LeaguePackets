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
    public class S2C_NotifyContextualSituation : GamePacket // 0x121
    {
        public override GamePacketID ID => GamePacketID.S2C_NotifyContextualSituation;
        public uint SituationNameHash { get; set; }
        public static S2C_NotifyContextualSituation CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_NotifyContextualSituation();
            result.SenderNetID = sender;
            result.SituationNameHash = reader.ReadUInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(SituationNameHash);
        }
    }
}
