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
    public class Unused222 : UnusedGamePacket // 0xDE
    {
        public override GamePacketID ID => GamePacketID.Unused222;
        public static Unused222 CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new Unused222();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
