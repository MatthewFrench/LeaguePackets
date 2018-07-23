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
    public class UNK_0x12E : UnusedGamePacket // 0x12E
    {
        public override GamePacketID ID => GamePacketID.UNK_0x12E;
        //FIXME: 4.18+
        public static UNK_0x12E CreateBody(PacketReader reader, NetID sender)
        {
            var result = new UNK_0x12E();
            result.SenderNetID = sender;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
