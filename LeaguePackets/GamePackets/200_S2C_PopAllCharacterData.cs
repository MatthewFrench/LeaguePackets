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
    public class S2C_PopAllCharacterData : GamePacket // 0xC8
    {
        public override GamePacketID ID => GamePacketID.S2C_PopAllCharacterData;
        public static S2C_PopAllCharacterData CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_PopAllCharacterData();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
