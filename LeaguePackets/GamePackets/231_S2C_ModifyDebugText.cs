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
    public class S2C_ModifyDebugText : GamePacket // 0xE7
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugText;
        public string Text { get; set; }
        public static S2C_ModifyDebugText CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ModifyDebugText();
            result.SenderNetID = sender;
            result.Text = reader.ReadSizedString();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSizedString(Text);
        }
    }
}
