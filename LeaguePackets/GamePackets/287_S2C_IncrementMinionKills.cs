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
    public class S2C_IncrementMinionKills : GamePacket // 0x11F
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementMinionKills;
        public NetID PlayerNetID { get; set; }
        public static S2C_IncrementMinionKills CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_IncrementMinionKills();
            result.SenderNetID = sender;
            result.PlayerNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(PlayerNetID);
        }
    }
}
