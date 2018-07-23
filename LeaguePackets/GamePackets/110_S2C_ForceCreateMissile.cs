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
    public class S2C_ForceCreateMissile : GamePacket // 0x6E
    {
        public override GamePacketID ID => GamePacketID.S2C_ForceCreateMissile;
        public NetID MissileNetID { get; set; }
        public static S2C_ForceCreateMissile CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ForceCreateMissile();
            result.SenderNetID = sender;
            result.MissileNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(MissileNetID);
        }
    }
}
