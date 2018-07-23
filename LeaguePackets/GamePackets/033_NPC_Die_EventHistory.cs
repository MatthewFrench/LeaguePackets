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
    public class NPC_Die_EventHistory : GamePacket // 0x21
    {
        public override GamePacketID ID => GamePacketID.NPC_Die_EventHistory;
        public static NPC_Die_EventHistory CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_Die_EventHistory();
            result.SenderNetID = sender;
            throw new NotImplementedException("NPC_Die_EventHistory.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("NPC_Die_EventHistory.Write");
        }
    }
}
