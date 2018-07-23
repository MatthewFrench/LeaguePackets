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
    public class RemoveRegion : GamePacket // 0x33
    {
        public override GamePacketID ID => GamePacketID.RemoveRegion;
        public NetID RegionNetID { get; set; }
        public static RemoveRegion CreateBody(PacketReader reader, NetID sender)
        {
            var result = new RemoveRegion();
            result.SenderNetID = sender;
            result.RegionNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(RegionNetID);
        }
    }
}
