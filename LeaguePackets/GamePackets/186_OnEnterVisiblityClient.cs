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
    public class OnEnterVisiblityClient : GamePacket // 0xBA
    {
        public override GamePacketID ID => GamePacketID.OnEnterVisiblityClient;
        public static OnEnterVisiblityClient CreateBody(PacketReader reader, NetID sender)
        {
            var result = new OnEnterVisiblityClient();
            result.SenderNetID = sender;
            throw new NotImplementedException("OnEnterVisiblityClient.Read");

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("OnEnterVisiblityClient.Write");
        }
    }
}
