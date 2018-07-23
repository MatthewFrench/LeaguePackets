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
    public class SPM_RemoveBBProfileListener : UnusedGamePacket // 0x99
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveBBProfileListener;
        public static SPM_RemoveBBProfileListener CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new SPM_RemoveBBProfileListener();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
