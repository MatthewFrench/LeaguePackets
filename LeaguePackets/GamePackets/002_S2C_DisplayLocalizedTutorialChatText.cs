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
    public class S2C_DisplayLocalizedTutorialChatText : GamePacket // 0x2
    {
        public override GamePacketID ID => GamePacketID.S2C_DisplayLocalizedTutorialChatText;
        public string Message { get; set; }
        public static S2C_DisplayLocalizedTutorialChatText CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_DisplayLocalizedTutorialChatText();
            result.SenderNetID = sender;
            result.Message = reader.ReadZeroTerminatedString();

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(Message);
        }
    }
}
