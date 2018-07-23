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
    public class S2C_ShopItemSubstitutionSet : GamePacket // 0x11C
    {
        public override GamePacketID ID => GamePacketID.S2C_ShopItemSubstitutionSet;
        public ItemID OriginalItemID { get; set; }
        public ItemID ReplacementItemID { get; set; }
        public static S2C_ShopItemSubstitutionSet CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ShopItemSubstitutionSet();
            result.SenderNetID = sender;
            result.OriginalItemID = reader.ReadItemID();
            result.ReplacementItemID = reader.ReadItemID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemID(OriginalItemID);
            writer.WriteItemID(ReplacementItemID);
        }
    }
}
