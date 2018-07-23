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
    public class S2C_UnlockAnimation : UnusedGamePacket // 0x12F
    {
        public override GamePacketID ID => GamePacketID.S2C_UnlockAnimation;
        //FIXME: 4.18+
        public static S2C_UnlockAnimation CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UnlockAnimation();
            result.SenderNetID = sender;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
