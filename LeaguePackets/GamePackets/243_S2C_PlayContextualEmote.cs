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
    public class S2C_PlayContextualEmote : GamePacket // 0xF3
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayContextualEmote;
        public ContextualEmoteID EmoteID { get; set; }
        public uint HashedParam { get; set; }
        public ContextualEmoteFlags EmoteFlags { get; set; }
        public static S2C_PlayContextualEmote CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_PlayContextualEmote();
            result.SenderNetID = sender;
            result.EmoteID = reader.ReadContextualEmoteID();
            result.HashedParam = reader.ReadUInt32();
            result.EmoteFlags = reader.ReadContextualEmoteFlags();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteContextualEmoteID(EmoteID);
            writer.WriteUInt32(HashedParam);
            writer.WriteContextualEmoteFlags(EmoteFlags);
        }
    }
}
