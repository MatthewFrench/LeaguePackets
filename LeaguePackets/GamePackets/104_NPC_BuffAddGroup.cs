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
    public class NPC_BuffAddGroup : GamePacket // 0x68
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffAddGroup;
        public BuffType BuffType { get; set; }
        public uint BuffNameHash { get; set; }
        public uint PackageHash { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public List<AddBuffInGroup> Buffs { get; set; } = new List<AddBuffInGroup>();
        public static NPC_BuffAddGroup CreateBody(PacketReader reader, NetID sender)
        {
            var result = new NPC_BuffAddGroup();
            result.SenderNetID = sender;
            result.BuffType = reader.ReadBuffType();
            result.BuffNameHash = reader.ReadUInt32();
            result.PackageHash = reader.ReadUInt32();
            result.RunningTime = reader.ReadFloat();
            result.Duration = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (var i = 0; i < numInGroup; i++)
            {
                result.Buffs.Add(reader.ReadAddBuffInGroup());
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBuffType(BuffType);
            writer.WriteUInt32(BuffNameHash);
            writer.WriteUInt32(PackageHash);
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            int numInGroup = Buffs.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs in list!");
            }
            writer.WriteByte((byte)numInGroup);
            for (var i = 0; i < numInGroup; i++)
            {
                writer.WriteAddBuffInGroup(Buffs[i]);
            }
        }
    }
}
