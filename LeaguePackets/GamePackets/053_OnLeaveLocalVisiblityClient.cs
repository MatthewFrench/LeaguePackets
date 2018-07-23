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
    public class OnLeaveLocalVisiblityClient : GamePacket // 0x35
    {
        public override GamePacketID ID => GamePacketID.OnLeaveLocalVisiblityClient;
        public static OnLeaveLocalVisiblityClient CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new OnLeaveLocalVisiblityClient();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
