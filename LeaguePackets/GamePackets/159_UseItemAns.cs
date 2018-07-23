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
    public class UseItemAns : GamePacket // 0x9F
    {
        public override GamePacketID ID => GamePacketID.UseItemAns;
        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }
        public static UseItemAns CreateBody(PacketReader reader, NetID sender)
        {
            var result = new UseItemAns();
            result.SenderNetID = sender;
            result.Slot = reader.ReadByte();
            result.ItemsInSlot = reader.ReadByte();
            result.SpellCharges = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);
            writer.WriteByte(SpellCharges);
        }
    }
}
