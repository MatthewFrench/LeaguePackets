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
    public class FX_Create_Group : GamePacket // 0x87
    {
        public override GamePacketID ID => GamePacketID.FX_Create_Group;
        public static FX_Create_Group CreateBody(PacketReader reader, NetID sender)
        {
            var result = new FX_Create_Group();
            result.SenderNetID = sender;
            throw new NotImplementedException("FX_Create_Group.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("FX_Create_Group.Write");
        }
    }
}
