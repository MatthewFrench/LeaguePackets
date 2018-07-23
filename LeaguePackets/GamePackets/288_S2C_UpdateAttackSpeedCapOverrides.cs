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
    public class S2C_UpdateAttackSpeedCapOverrides : GamePacket // 0x120
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateAttackSpeedCapOverrides;
        public bool DoOverrideMax { get; set; }
        public bool DoOverrideMin { get; set; }
        public float MaxAttackSpeedOverride { get; set; }
        public float MinAttackSpeedOverride { get; set; }
        public static S2C_UpdateAttackSpeedCapOverrides CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_UpdateAttackSpeedCapOverrides();
            result.SenderNetID = sender;
            result.DoOverrideMax = reader.ReadBool();
            result.DoOverrideMin = reader.ReadBool();
            result.MaxAttackSpeedOverride = reader.ReadFloat();
            result.MinAttackSpeedOverride = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(DoOverrideMax);
            writer.WriteBool(DoOverrideMin);
            writer.WriteFloat(MaxAttackSpeedOverride);
            writer.WriteFloat(MinAttackSpeedOverride);
        }
    }
}
