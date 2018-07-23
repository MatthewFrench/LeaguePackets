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
    public class S2C_OnEnterTeamVisiblity : GamePacket // 0xE0
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEnterTeamVisiblity;
        public static S2C_OnEnterTeamVisiblity CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_OnEnterTeamVisiblity();
            result.SenderNetID = sender;
            throw new NotImplementedException("S2C_OnEnterTeamVisiblity.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("S2C_OnEnterTeamVisiblity.Write");
        }
    }
}
