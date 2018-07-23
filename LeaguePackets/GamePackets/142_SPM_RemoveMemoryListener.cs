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
    public class SPM_RemoveMemoryListener : UnusedGamePacket // 0x8E
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveMemoryListener;
        public static SPM_RemoveMemoryListener CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new SPM_RemoveMemoryListener();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
