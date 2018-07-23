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
    public class UnitAddEXP : GamePacket // 0x10
    {
        public override GamePacketID ID => GamePacketID.UnitAddEXP;
        public NetID TargetNetID { get; set; }
        public float ExpAmmount { get; set; }
        public static UnitAddEXP CreateBody(PacketReader reader, NetID sender)
        {
            var result = new UnitAddEXP();
            result.SenderNetID = sender;
            result.TargetNetID = reader.ReadNetID();
            result.ExpAmmount = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteFloat(ExpAmmount);
        }
    }
}
