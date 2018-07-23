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
    public class S2C_PopCharacterData : GamePacket // 0x67
    {
        public override GamePacketID ID => GamePacketID.S2C_PopCharacterData;
        public uint PopID { get; set; }
        public static S2C_PopCharacterData CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_PopCharacterData();
            result.SenderNetID = sender;
            result.PopID = reader.ReadUInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(PopID);
        }
    }
}
