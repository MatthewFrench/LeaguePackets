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
    public class World_LockCamera_Server : GamePacket // 0x81
    {
        public override GamePacketID ID => GamePacketID.World_LockCamera_Server;
        public bool Locked { get; set; }
        public ClientID ClientID { get; set; }
        public static World_LockCamera_Server CreateBody(PacketReader reader, NetID sender)
        {
            var result = new World_LockCamera_Server();
            result.SenderNetID = sender;
            result.Locked = reader.ReadBool();
            result.ClientID = reader.ReadClientID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(Locked);
            writer.WriteClientID(ClientID);
        }
    }
}
