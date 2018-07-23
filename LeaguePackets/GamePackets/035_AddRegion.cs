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
    public class AddRegion : GamePacket // 0x23
    {
        public override GamePacketID ID => GamePacketID.AddRegion;
        public static AddRegion CreateBody(PacketReader reader, NetID sender)
        {
            var result = new AddRegion();
            result.SenderNetID = sender;
            throw new NotImplementedException("AddRegion.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("AddRegion.Write");
        }
    }
}
