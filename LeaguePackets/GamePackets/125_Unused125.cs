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
    public class Unused125 : UnusedGamePacket // 0x7D
    {
        public override GamePacketID ID => GamePacketID.Unused125;
        public static Unused125 CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new Unused125();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
