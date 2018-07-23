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
    public class SPM_HierarchicalMemoryUpdate : UnusedGamePacket // 0x4E
    {
        public override GamePacketID ID => GamePacketID.SPM_HierarchicalMemoryUpdate;
        public static SPM_HierarchicalMemoryUpdate CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SPM_HierarchicalMemoryUpdate();
            result.SenderNetID = sender;

            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
