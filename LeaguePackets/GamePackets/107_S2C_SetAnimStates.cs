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
    public class S2C_SetAnimStates : GamePacket // 0x6B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetAnimStates;
        public List<AnimationOverridePair> AnimationOverrides { get; set; } = new List<AnimationOverridePair>();
        public static S2C_SetAnimStates CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SetAnimStates();
            result.SenderNetID = sender;
            int number = reader.ReadByte();
            for (int i = 0; i < number;i++)
            {
                result.AnimationOverrides.Add(reader.ReadAnimationOverridePair());
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            int number = AnimationOverrides.Count;
            if(number > 0xFF)
            {
                throw new IOException("AnimationOverrides list too big!");
            }
            for (int i = 0; i < number; i++)
            {
                writer.WriteAnimationOverridePair(AnimationOverrides[i]);
            }
        }
    }
}
