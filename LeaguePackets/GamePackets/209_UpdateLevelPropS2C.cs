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
    public class UpdateLevelPropS2C : GamePacket // 0xD1
    {
        public override GamePacketID ID => GamePacketID.UpdateLevelPropS2C;
        public string StringParam1 { get; set; }
        public float FloatParam1 { get; set; }
        public float FloatParam2 { get; set; }
        public NetID NetID { get; set; }
        public uint Flags1 { get; set; }
        public byte Command { get; set; }
        public byte ByteParam1 { get; set; }
        public byte ByteParam2 { get; set; }
        public byte ByteParam3 { get; set; }
        public static UpdateLevelPropS2C CreateBody(PacketReader reader, NetID sender)
        {
            var result = new UpdateLevelPropS2C();
            result.SenderNetID = sender;
            result.StringParam1 = reader.ReadFixedString(64);
            result.FloatParam1 = reader.ReadFloat();
            result.FloatParam2 = reader.ReadFloat();
            result.NetID = reader.ReadNetID();
            result.Flags1 = reader.ReadUInt32();
            result.Command = reader.ReadByte();
            result.ByteParam1 = reader.ReadByte();
            result.ByteParam2 = reader.ReadByte();
            result.ByteParam3 = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(StringParam1, 64);
            writer.WriteFloat(FloatParam1);
            writer.WriteFloat(FloatParam2);
            writer.WriteNetID(NetID);
            writer.WriteUInt32(Flags1);
            writer.WriteByte(Command);
            writer.WriteByte(ByteParam1);
            writer.WriteByte(ByteParam2);
            writer.WriteByte(ByteParam3);
        }
    }
}
