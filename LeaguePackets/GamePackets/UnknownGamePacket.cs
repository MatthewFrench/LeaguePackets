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
    public class UnknownGamePacket : GamePacket
    {
        private readonly GamePacketID _id;
        public override GamePacketID ID => _id;
        public UnknownGamePacket(GamePacketID id) => _id = id;

        public static UnknownGamePacket CreateBody(PacketReader reader, NetID sender, GamePacketID id)
        {
            var result = new UnknownGamePacket(id);
            result.SenderNetID = sender;
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
