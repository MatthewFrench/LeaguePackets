using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class UnknownPayloadPacket : PayloadPacket
    {
        private readonly PayloadPacketID _id;
        public override PayloadPacketID ID => _id;
        public UnknownPayloadPacket(PayloadPacketID id) => _id = id;

        public static UnknownPayloadPacket CreateBody(PacketReader reader, PayloadPacketID id)
        {
            var result = new UnknownPayloadPacket(id);
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
