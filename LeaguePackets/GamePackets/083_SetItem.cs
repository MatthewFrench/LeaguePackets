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
    public class SetItem : GamePacket // 0x53
    {
        public override GamePacketID ID => GamePacketID.SetItem;
        public ItemPacket Item { get; set; }
        public static SetItem CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SetItem();
            result.SenderNetID = sender;
            result.Item = reader.ReadItemPacket();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteItemPacket(Item);
        }
    }
}
