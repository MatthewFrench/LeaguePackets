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
    public class S2C_PlayEmote : GamePacket // 0x42
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayEmote;
        public EmoteID EmoteID { get; set; }
        public static S2C_PlayEmote CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_PlayEmote();
            result.SenderNetID = sender;
            result.EmoteID = reader.ReadEmoteID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteEmoteID(EmoteID);
        }
    }
}
