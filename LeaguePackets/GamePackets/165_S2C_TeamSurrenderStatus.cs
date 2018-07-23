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
    public class S2C_TeamSurrenderStatus : GamePacket // 0xA5
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderStatus;
        public SurrenderReason Reason { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public TeamID TeamID { get; set; }
        public static S2C_TeamSurrenderStatus CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_TeamSurrenderStatus();
            result.SenderNetID = sender;
            result.Reason = reader.ReadSurrenderReason();
            result.ForVote = reader.ReadByte();
            result.AgainstVote = reader.ReadByte();
            result.TeamID = reader.ReadTeamID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSurrenderReason(Reason);
            writer.WriteByte(ForVote);
            writer.WriteByte(AgainstVote);
            writer.WriteTeamID(TeamID);
        }
    }
}
