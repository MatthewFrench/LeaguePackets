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
    public class Connected : GamePacket // 0x75
    {
        public override GamePacketID ID => GamePacketID.Connected;
        public static Connected CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Connected();
            result.SenderNetID = sender;
            throw new NotImplementedException("Connected.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("Connected.Write");
        }
    }
}
