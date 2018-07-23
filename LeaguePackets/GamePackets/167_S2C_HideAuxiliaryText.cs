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
    public class S2C_HideAuxiliaryText : GamePacket // 0xA7
    {
        public override GamePacketID ID => GamePacketID.S2C_HideAuxiliaryText;
        public static S2C_HideAuxiliaryText CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new S2C_HideAuxiliaryText();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
