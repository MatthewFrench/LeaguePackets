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
    public class SPM_SamplingProfilerUpdate : UnusedGamePacket // 0xC7
    {
        public override GamePacketID ID => GamePacketID.SPM_SamplingProfilerUpdate;
        public static SPM_SamplingProfilerUpdate CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new SPM_SamplingProfilerUpdate();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
