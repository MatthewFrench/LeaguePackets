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
    public class ServerTick : GamePacket // 0x28
    {
        public override GamePacketID ID => GamePacketID.ServerTick;
        public float Delta { get; set; }
        public static ServerTick CreateBody(PacketReader reader, NetID sender)
        {
            var result = new ServerTick();
            result.SenderNetID = sender;
            result.Delta = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Delta);
        }
    }
}
