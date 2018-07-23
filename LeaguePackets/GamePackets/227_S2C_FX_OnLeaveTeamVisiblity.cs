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
    public class S2C_FX_OnLeaveTeamVisiblity : GamePacket // 0xE3
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_OnLeaveTeamVisiblity;
        public NetID NetID { get; set; }
        public VisibilityTeam VisibilityTeam { get; set; }
        public static S2C_FX_OnLeaveTeamVisiblity CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_FX_OnLeaveTeamVisiblity();
            result.SenderNetID = sender;
            result.NetID = reader.ReadNetID();
            result.VisibilityTeam = reader.ReadVisibilityTeam();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteVisibilityTeam(VisibilityTeam);
        }
    }
}
