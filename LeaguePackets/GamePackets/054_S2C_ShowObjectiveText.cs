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
    public class S2C_ShowObjectiveText : GamePacket // 0x36
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowObjectiveText;
        public string Message { get; set; }
        public static S2C_ShowObjectiveText CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ShowObjectiveText();
            result.SenderNetID = sender;
            result.Message = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(Message,128);
        }
    }
}
