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
    public class NPC_IssueOrderReq : GamePacket // 0x72
    {
        public override GamePacketID ID => GamePacketID.NPC_IssueOrderReq;
        public static NPC_IssueOrderReq CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_IssueOrderReq();
            result.SenderNetID = sender;
            throw new NotImplementedException("NPC_IssueOrderReq.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("NPC_IssueOrderReq.Write");
        }
    }
}
