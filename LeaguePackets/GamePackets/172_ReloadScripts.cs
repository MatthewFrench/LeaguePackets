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
    public class ReloadScripts : GamePacket // 0xAC
    {
        public override GamePacketID ID => GamePacketID.ReloadScripts;
        public static ReloadScripts CreateBody(PacketReader reader, NetID sender)
        {
            var result = new ReloadScripts();
            result.SenderNetID = sender;
            throw new NotImplementedException("ReloadScripts.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("ReloadScripts.Write");
        }
    }
}
