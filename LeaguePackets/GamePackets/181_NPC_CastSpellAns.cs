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
    public class NPC_CastSpellAns : GamePacket // 0xB5
    {
        public override GamePacketID ID => GamePacketID.NPC_CastSpellAns;
        public int CasterPositionSyncID { get; set; }
        //TODO: change bitfield to enum flags or variables
        public byte Bitfield { get; set; }
        //FIXME: varaible packet :/
        public static NPC_CastSpellAns CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_CastSpellAns();
            result.SenderNetID = sender;
            throw new NotImplementedException("NPC_CastSpellAns.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("NPC_CastSpellAns.Write");
        }
    }
}
