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
    public class S2C_QueryStatusAns : GamePacket // 0x88
    {
        public override GamePacketID ID => GamePacketID.S2C_QueryStatusAns;
        public bool Response { get; set; }
        public static S2C_QueryStatusAns CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_QueryStatusAns();
            result.SenderNetID = sender;
            result.Response = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(Response);
        }
    }
}
