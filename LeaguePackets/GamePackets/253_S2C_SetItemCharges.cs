using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetItemCharges : GamePacket // 0xFD
    {
        public override GamePacketID ID => GamePacketID.S2C_SetItemCharges;
        public byte Slot { get; set; }
        public byte SpellCharges { get; set; }
        public static S2C_SetItemCharges CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SetItemCharges();
            result.SenderNetID = sender;
            result.Slot = reader.ReadByte();
            result.SpellCharges = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(SpellCharges);
        }
    }
}
