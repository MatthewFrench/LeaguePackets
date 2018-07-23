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
    public class S2C_OnEventWorld : GamePacket // 0x45
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEventWorld;
        public byte EventID { get; set; }
        public NetID SourceNetID { get; set; }
        //FIXME: variable from here:
        public NetID OtherNetID { get; set; }

        public static S2C_OnEventWorld CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_OnEventWorld();
            result.SenderNetID = sender;
            result.EventID = reader.ReadByte();
            result.SourceNetID = reader.ReadNetID();
            result.OtherNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(EventID);
            writer.WriteNetID(SourceNetID);
            writer.WriteNetID(OtherNetID);
        }
    }
}
