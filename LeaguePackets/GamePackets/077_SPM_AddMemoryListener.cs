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
    public class SPM_AddMemoryListener : UnusedGamePacket // 0x4D
    {
        public override GamePacketID ID => GamePacketID.SPM_AddMemoryListener;
        public static SPM_AddMemoryListener CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SPM_AddMemoryListener();
            result.SenderNetID = sender;

            return result;
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
