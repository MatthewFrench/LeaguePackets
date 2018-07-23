using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class S2C_ActivateMinionCamp : GamePacket // 0xE9
    {
        public override GamePacketID ID => GamePacketID.S2C_ActivateMinionCamp;
        public Vector3 Position { get; set; }
        public float SpawnDuration { get; set; }
        public byte CampIndex { get; set; }
        public int TimerType { get; set; }
        public static S2C_ActivateMinionCamp CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ActivateMinionCamp();
            result.SenderNetID = sender;
            result.Position = reader.ReadVector3();
            result.SpawnDuration = reader.ReadFloat();
            result.CampIndex = reader.ReadByte();
            result.TimerType = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteFloat(SpawnDuration);
            writer.WriteByte(CampIndex);
            writer.WriteInt32(TimerType);
        }
    }
}
