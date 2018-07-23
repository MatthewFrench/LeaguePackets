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
    public class S2C_AI_State : GamePacket // 0xAA
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_State;
        public AIState AIState { get; set; }
        public static S2C_AI_State CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_AI_State();
            result.SenderNetID = sender;
            result.AIState = reader.ReadAIState();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteAIState(AIState);
        }
    }
}
