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
    public class S2C_UpdateRestrictedChatCount : GamePacket // 0xF9
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateRestrictedChatCount;
        public int Count { get; set; }
        public static S2C_UpdateRestrictedChatCount CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UpdateRestrictedChatCount();
            result.SenderNetID = sender;
            result.Count = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(Count);
        }
    }
}
