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
    public class S2C_RemoveDebugObject : GamePacket // 0x58
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveDebugObject;
        public int ObjectID { get; set; }
        public static S2C_RemoveDebugObject CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_RemoveDebugObject();
            result.SenderNetID = sender;
            result.ObjectID = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
        }
    }
}
