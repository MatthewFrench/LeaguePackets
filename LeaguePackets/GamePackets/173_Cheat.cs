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
    public class Cheat : GamePacket // 0xAD
    {
        public override GamePacketID ID => GamePacketID.Cheat;
        public static Cheat CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Cheat();
            result.SenderNetID = sender;
            throw new NotImplementedException("Cheat.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("Cheat.Write");
        }
    }
}
