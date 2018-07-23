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
    public class SPM_RemoveListener : UnusedGamePacket // 0x8B
    {
        public override GamePacketID ID => GamePacketID.SPM_RemoveListener;
        public static SPM_RemoveListener CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SPM_RemoveListener();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
