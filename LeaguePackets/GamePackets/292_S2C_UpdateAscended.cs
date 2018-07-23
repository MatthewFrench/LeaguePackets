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
    public class S2C_UpdateAscended : GamePacket // 0x124
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateAscended;
        public NetID AscendedNetID { get; set; }
        public static S2C_UpdateAscended CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UpdateAscended();
            result.SenderNetID = sender;
            result.AscendedNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(AscendedNetID);
        }
    }
}
