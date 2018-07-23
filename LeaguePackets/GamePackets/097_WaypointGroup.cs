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
    public class WaypointGroup : GamePacket // 0x61
    {
        public override GamePacketID ID => GamePacketID.WaypointGroup;
        public static WaypointGroup CreateBody(PacketReader reader, NetID sender)
        {
            var result = new WaypointGroup();
            result.SenderNetID = sender;
            throw new NotImplementedException("WaypointGroup.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("WaypointGroup.Write");
        }
    }
}
