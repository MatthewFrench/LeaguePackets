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
    public class S2C_UnitChangeTeam : GamePacket // 0xD7
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitChangeTeam;
        public NetID UnitNetID { get; set; }
        public TeamID TeamID { get; set; }
        public static S2C_UnitChangeTeam CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UnitChangeTeam();
            result.SenderNetID = sender;
            result.UnitNetID = reader.ReadNetID();
            result.TeamID = reader.ReadTeamID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(UnitNetID);
            writer.WriteTeamID(TeamID);
        }
    }
}
