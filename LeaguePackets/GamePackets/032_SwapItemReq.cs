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
    public class SwapItemReq : GamePacket // 0x20
    {
        public override GamePacketID ID => GamePacketID.SwapItemReq;
        public byte Source { get; set; }
        public byte Destination { get; set; }
        public static SwapItemReq CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SwapItemReq();
            result.SenderNetID = sender;
            result.Source = reader.ReadByte();
            result.Destination = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Source);
            writer.WriteByte(Destination);
        }
    }
}
