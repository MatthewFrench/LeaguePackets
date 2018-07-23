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
    public class C2S_CheatLogGoldSources : GamePacket // 0x11B
    {
        public override GamePacketID ID => GamePacketID.C2S_CheatLogGoldSources;
        public static C2S_CheatLogGoldSources CreateBody(PacketReader reader, NetID sender)
        {
            var result = new C2S_CheatLogGoldSources();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            
        }
    }
}
