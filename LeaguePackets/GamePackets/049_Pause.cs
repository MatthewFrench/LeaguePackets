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
    public class Pause : GamePacket // 0x31
    {
        public override GamePacketID ID => GamePacketID.Pause;
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public int SyncID { get; set; }
        public static Pause CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Pause();
            result.SenderNetID = sender;
            result.Position = reader.ReadVector3();
            result.Forward = reader.ReadVector3();
            result.SyncID = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteVector3(Forward);
            writer.WriteInt32(SyncID);
        }
    }
}
