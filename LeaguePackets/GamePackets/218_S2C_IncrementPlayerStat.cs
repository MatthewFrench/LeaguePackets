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
    public class S2C_IncrementPlayerStat : GamePacket // 0xDA
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementPlayerStat;
        public NetID PlayerNetID { get; set; }
        public StatEvent StatEvent { get; set; }
        public static S2C_IncrementPlayerStat CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_IncrementPlayerStat();
            result.SenderNetID = sender;
            result.PlayerNetID = reader.ReadNetID();
            result.StatEvent = reader.ReadStatEvent();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(PlayerNetID);
            writer.WriteStatEvent(StatEvent);
        }
    }
}
