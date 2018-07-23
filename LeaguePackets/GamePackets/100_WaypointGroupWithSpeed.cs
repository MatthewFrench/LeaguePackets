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
    public class WaypointGroupWithSpeed : GamePacket // 0x64
    {
        public override GamePacketID ID => GamePacketID.WaypointGroupWithSpeed;
        public static WaypointGroupWithSpeed CreateBody(PacketReader reader, NetID sender)
        {
            var result = new WaypointGroupWithSpeed();
            result.SenderNetID = sender;
            throw new NotImplementedException("WaypointGroupWithSpeed.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("WaypointGroupWithSpeed.Write");
        }
    }
}
