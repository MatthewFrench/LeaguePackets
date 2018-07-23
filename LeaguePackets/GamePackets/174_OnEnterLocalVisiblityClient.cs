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
    public class OnEnterLocalVisiblityClient : GamePacket // 0xAE
    {
        public override GamePacketID ID => GamePacketID.OnEnterLocalVisiblityClient;
        public static OnEnterLocalVisiblityClient CreateBody(PacketReader reader, NetID sender)
        {
            var result = new OnEnterLocalVisiblityClient();
            result.SenderNetID = sender;
            throw new NotImplementedException("OnEnterLocalVisiblityClient.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("OnEnterLocalVisiblityClient.Write");
        }
    }
}
