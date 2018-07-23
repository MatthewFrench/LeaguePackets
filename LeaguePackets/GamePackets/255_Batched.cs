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
    public class Batched : GamePacket // 0xFF
    {
        public override GamePacketID ID => GamePacketID.Batched;
        public static Batched CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Batched();
            result.SenderNetID = sender;
            throw new NotImplementedException("Batched.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("Batched.Write");
        }
    }
}
