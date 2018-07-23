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
    public class NPC_ForceDead : GamePacket // 0x1B
    {
        public override GamePacketID ID => GamePacketID.NPC_ForceDead;
        public float DeathDuration { get; set; }
        public static NPC_ForceDead CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_ForceDead();
            result.SenderNetID = sender;
            result.DeathDuration = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(DeathDuration);
        }
    }
}
