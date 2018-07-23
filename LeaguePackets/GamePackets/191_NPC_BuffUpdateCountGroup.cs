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
    public class NPC_BuffUpdateCountGroup : GamePacket // 0xBF
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCountGroup;
        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public List<UpdateCountBuffInGroup> Buffs { get; set; } = new List<UpdateCountBuffInGroup>();
        public static NPC_BuffUpdateCountGroup CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_BuffUpdateCountGroup();
            result.SenderNetID = sender;
            result.Duration = reader.ReadFloat();
            result.RunningTime = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                result.Buffs.Add(reader.ReadUpdateCountBuffInGroup());
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Duration);
            writer.WriteFloat(RunningTime);
            int numInGroup = Buffs.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteUpdateCountBuffInGroup(Buffs[i]);
            }
        }
    }
}
