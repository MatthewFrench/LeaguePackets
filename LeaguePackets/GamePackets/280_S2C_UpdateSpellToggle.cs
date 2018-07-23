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
    public class S2C_UpdateSpellToggle : GamePacket // 0x118
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateSpellToggle;
        public int SpellSlot { get; set; }
        public bool ToggleValue { get; set; }
        public static S2C_UpdateSpellToggle CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UpdateSpellToggle();
            result.SenderNetID = sender;
            result.SpellSlot = reader.ReadInt32();
            result.ToggleValue = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SpellSlot);
            writer.WriteBool(ToggleValue);
        }
    }
}
