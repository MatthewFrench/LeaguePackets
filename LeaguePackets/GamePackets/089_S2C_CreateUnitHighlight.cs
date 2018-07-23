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
    public class S2C_CreateUnitHighlight : GamePacket // 0x59
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateUnitHighlight;
        public NetID TargetNetID { get; set; }
        public static S2C_CreateUnitHighlight CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_CreateUnitHighlight();
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
