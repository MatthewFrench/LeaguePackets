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
    public class OnLeaveVisiblityClient : GamePacket // 0x51
    {
        public override GamePacketID ID => GamePacketID.OnLeaveVisiblityClient;
        public static OnLeaveVisiblityClient CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new OnLeaveVisiblityClient();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
