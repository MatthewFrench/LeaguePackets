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
    public class SynchSimTimeS2C : GamePacket // 0xC1
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeS2C;
        public float SynchTime { get; set; }
        public static SynchSimTimeS2C CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SynchSimTimeS2C();
            result.SenderNetID = sender;
            result.SynchTime = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(SynchTime);
        }
    }
}
