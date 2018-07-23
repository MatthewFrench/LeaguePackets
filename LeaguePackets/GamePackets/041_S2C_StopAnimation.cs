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
    public class S2C_StopAnimation : GamePacket // 0x29
    {
        public override GamePacketID ID => GamePacketID.S2C_StopAnimation;
        public bool Fade { get; set; }
        public bool Unlock { get; set; }
        public bool StopAll { get; set; }
        public string AnimationName { get; set; }
        public static S2C_StopAnimation CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_StopAnimation();
            result.SenderNetID = sender;
            byte flags = reader.ReadByte();
            result.Fade = (flags & 1) != 0;
            result.Unlock = (flags & 2) != 0;
            result.StopAll = (flags & 4) != 0;
            result.AnimationName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte flags = 0;
            if (Fade)
                flags |= 1;
            if (Unlock)
                flags |= 2;
            if (StopAll)
                flags |= 4;
            writer.WriteByte(flags);
            writer.WriteFixedString(AnimationName, 64);
        }
    }
}
