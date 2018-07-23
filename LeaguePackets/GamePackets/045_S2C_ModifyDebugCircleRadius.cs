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
    public class S2C_ModifyDebugCircleRadius : GamePacket // 0x2D
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugCircleRadius;
        public int ObjectID { get; set; }
        public float Radius { get; set; }
        public static S2C_ModifyDebugCircleRadius CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ModifyDebugCircleRadius();
            result.SenderNetID = sender;
            result.ObjectID = reader.ReadInt32();
            result.Radius = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteFloat(Radius);
        }
    }
}
