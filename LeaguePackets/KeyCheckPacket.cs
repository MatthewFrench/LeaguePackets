using System;
using LeaguePackets.Common;
using LeaguePackets.Extensions;

namespace LeaguePackets
{
    public class KeyCheckPacket : BasePacket
    {
        public byte ID { get; set; }
        public ClientID ClientID { get; set; }
        public PlayerID PlayerID { get; set; }
        public uint VersionNumber { get; set; }
        public ulong CheckSum { get; set; }

        public static KeyCheckPacket Create(PacketReader reader)
        {
            var result = new KeyCheckPacket();
            result.ID = reader.ReadByte();
            reader.ReadPad(3);
            result.ClientID = reader.ReadClientID();
            result.PlayerID = reader.ReadPlayerID();
            result.VersionNumber = reader.ReadUInt32();
            result.CheckSum = reader.ReadUInt64();
            return result;
        }

        public override void WriteHeader(PacketWriter writer)
        {
            writer.WriteByte(ID);
            writer.WritePad(3);
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WritePlayerID(PlayerID);
            writer.WriteUInt32(VersionNumber);
            writer.WriteUInt64(CheckSum);
        }
    }
}
