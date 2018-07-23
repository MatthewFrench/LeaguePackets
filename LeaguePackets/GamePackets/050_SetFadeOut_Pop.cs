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
    public class SetFadeOut_Pop : GamePacket // 0x32
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Pop;
        public short StackID { get; set; }
        public static SetFadeOut_Pop CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SetFadeOut_Pop();
            result.SenderNetID = sender;
            result.StackID = reader.ReadInt16();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt16(StackID);
        }
    }
}
