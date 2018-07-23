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
    public class Unused221 : UnusedGamePacket // 0xDD
    {
        public override GamePacketID ID => GamePacketID.Unused221;
        public static Unused221 CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Unused221();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
