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
    public class S2C_DestroyClientMissile : GamePacket // 0x5A
    {
        public override GamePacketID ID => GamePacketID.S2C_DestroyClientMissile;
        public static S2C_DestroyClientMissile CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new S2C_DestroyClientMissile();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
