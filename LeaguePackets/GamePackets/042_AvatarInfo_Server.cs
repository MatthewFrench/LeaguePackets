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
    public class AvatarInfo_Server : GamePacket // 0x2A
    {
        public override GamePacketID ID => GamePacketID.AvatarInfo_Server;
        public AvatarInfo AvatarInfo { get; set; }

        public static AvatarInfo_Server CreateBody(PacketReader reader, NetID sender)
        {
            var result = new AvatarInfo_Server();
            result.SenderNetID = sender;
            result.AvatarInfo = reader.ReadAvatarInfo();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteAvatarInfo(AvatarInfo);
        }
    }
}
