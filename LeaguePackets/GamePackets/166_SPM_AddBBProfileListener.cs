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
    public class SPM_AddBBProfileListener : UnusedGamePacket // 0xA6
    {
        public override GamePacketID ID => GamePacketID.SPM_AddBBProfileListener;
        public static SPM_AddBBProfileListener CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SPM_AddBBProfileListener();
            result.SenderNetID = sender;

            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
