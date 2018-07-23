using LeaguePackets.Common;
using LeaguePackets.Extensions;
using LeaguePackets.GamePackets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets
{
    public abstract partial class GamePacket : BasePacket
    {
        public abstract GamePacketID ID { get; }
        public NetID SenderNetID { get; set; }
        public override void WriteHeader(PacketWriter writer)
        {
            if(ID > GamePacketID.Batched)
            {
                writer.WriteByte((byte)GamePacketID.ExtendedPacket);
                writer.WriteNetID(SenderNetID);
                writer.WriteUInt16((ushort)ID);
            }
            else
            {
                writer.WriteByte((byte)ID);
                writer.WriteNetID(SenderNetID);
            }
        }
        public static GamePacket Create(PacketReader reader)
        {
            var id = (GamePacketID)reader.ReadByte();
            var sender = reader.ReadNetID();
            if( id == GamePacketID.ExtendedPacket)
            {
                id = (GamePacketID)reader.ReadUInt16();
            }
            GamePacket packet;
            if (!Enum.IsDefined(typeof(GamePacketID), id) || id == GamePacketID.ExtendedPacket)
            {
                packet = UnknownGamePacket.CreateBody(reader, sender, id);
            }
            else
            {
                packet = _lookup[id](reader, sender);
            }
            packet.ExtraBytes = reader.ReadLeft();
            return packet;
        }
    }
}