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
    public class S2C_HeroStats : GamePacket // 0x46
    {
        public override GamePacketID ID => GamePacketID.S2C_HeroStats;
        public static S2C_HeroStats CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_HeroStats();
            result.SenderNetID = sender;
            throw new NotImplementedException("S2C_HeroStats.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("S2C_HeroStats.Write");
        }
    }
}
