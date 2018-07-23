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
    public class Unused223 : UnusedGamePacket // 0xDF
    {
        public override GamePacketID ID => GamePacketID.Unused223;
        public static Unused223 CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new Unused223();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
