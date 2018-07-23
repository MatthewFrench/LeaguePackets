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
    public class BuyItemAns : GamePacket // 0x6F
    {
        public override GamePacketID ID => GamePacketID.BuyItemAns;
        public ItemPacket Item { get; set; }
        // TODO: change bitfield to enum or variables
        public byte Bitfield { get; set; }
        public static BuyItemAns CreateBody(PacketReader reader, NetID sender)
        {
            var result = new BuyItemAns();
            result.SenderNetID = sender;
            result.Item = reader.ReadItemPacket();
            result.Bitfield = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemPacket(Item);
            writer.WriteByte(Bitfield);
        }
    }
}
