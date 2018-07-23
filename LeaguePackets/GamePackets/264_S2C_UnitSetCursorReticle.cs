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
    public class S2C_UnitSetCursorReticle : GamePacket // 0x108
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetCursorReticle;
        public float Radius { get; set; }
        public float SecondaryRadius { get; set; }
        public static S2C_UnitSetCursorReticle CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UnitSetCursorReticle();
            result.SenderNetID = sender;
            result.Radius = reader.ReadFloat();
            result.SecondaryRadius = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Radius);
            writer.WriteFloat(SecondaryRadius);
        }
    }
}
