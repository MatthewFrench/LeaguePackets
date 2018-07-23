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
    public class S2C_FX_OnEnterTeamVisiblity : GamePacket // 0xE2
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_OnEnterTeamVisiblity;
        public static S2C_FX_OnEnterTeamVisiblity CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_FX_OnEnterTeamVisiblity();
            result.SenderNetID = sender;
            throw new NotImplementedException("S2C_FX_OnEnterTeamVisiblity.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("S2C_FX_OnEnterTeamVisiblity.Write");
        }
    }
}
