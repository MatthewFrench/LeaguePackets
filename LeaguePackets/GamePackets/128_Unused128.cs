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
    public class Unused128 : UnusedGamePacket // 0x80
    {
        public override GamePacketID ID => GamePacketID.Unused128;
        public static Unused128 CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Unused128();
            result.SenderNetID = sender;
            throw new NotImplementedException("Unused128.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("Unused128.Write");
        }
    }
}
