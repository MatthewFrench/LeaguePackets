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
    public class S2C_SetHoverIndicatorTarget : GamePacket // 0xF5
    {
        public override GamePacketID ID => GamePacketID.S2C_SetHoverIndicatorTarget;
        public NetID TargetNetID { get; set; }
        public static S2C_SetHoverIndicatorTarget CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SetHoverIndicatorTarget();
            result.SenderNetID = sender;
            result.TargetNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
        }
    }
}
