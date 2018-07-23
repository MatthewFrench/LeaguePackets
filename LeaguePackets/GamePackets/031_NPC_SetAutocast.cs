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
    public class NPC_SetAutocast : GamePacket // 0x1F
    {
        public override GamePacketID ID => GamePacketID.NPC_SetAutocast;
        public byte Slot { get; set; }
        public byte CritSlot { get; set; }
        public static NPC_SetAutocast CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_SetAutocast();
            result.SenderNetID = sender;
            result.Slot = reader.ReadByte();
            result.CritSlot = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(CritSlot);
        }
    }
}
