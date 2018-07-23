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
    public class SyncSimTimeFinalS2C : GamePacket // 0x76
    {
        public override GamePacketID ID => GamePacketID.SyncSimTimeFinalS2C;
        public float TimeLastClient { get; set; }
        public float TimeRTTLastOverhead { get; set; }
        public float TimeConvergance { get; set; }
        public static SyncSimTimeFinalS2C CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SyncSimTimeFinalS2C();
            result.SenderNetID = sender;
            result.TimeLastClient = reader.ReadFloat();
            result.TimeRTTLastOverhead = reader.ReadFloat();
            result.TimeConvergance = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(TimeLastClient);
            writer.WriteFloat(TimeRTTLastOverhead);
            writer.WriteFloat(TimeConvergance);
        }
    }
}
