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
    public class Waypoint_Acc : GamePacket // 0x77
    {
        public override GamePacketID ID => GamePacketID.Waypoint_Acc;
        public int SyncID { get; set; }
        public byte TeleportCount { get; set; }
        public static Waypoint_Acc CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Waypoint_Acc();
            result.SenderNetID = sender;
            result.SyncID = reader.ReadInt32();
            result.TeleportCount = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SyncID);
            writer.WriteByte(TeleportCount);
        }
    }
}
