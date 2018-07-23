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
    public class S2C_ShowAuxiliaryText : GamePacket // 0xA0
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowAuxiliaryText;
        public string MessageID { get; set; }
        public static S2C_ShowAuxiliaryText CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ShowAuxiliaryText();
            result.SenderNetID = sender;
            result.MessageID = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(MessageID, 128);
        }
    }
}
