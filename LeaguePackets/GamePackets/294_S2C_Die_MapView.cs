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
    public class S2C_Die_MapView : UnusedGamePacket // 0x126
    {
        public override GamePacketID ID => GamePacketID.S2C_Die_MapView;
        //FIXME: 4.18+
        public static S2C_Die_MapView CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_Die_MapView();
            result.SenderNetID = sender;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
