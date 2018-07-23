using System;
using System.Collections.Generic;
using System.IO;
using LeaguePackets.Common;
using LeaguePackets.Extensions;

namespace LeaguePackets.Common
{
    public enum ChangeSlotSpellDataType : byte
    {
        TargetingType = 0x0,
        SpellName = 0x1,
        Range = 0x2,
        MaxGrowthRange = 0x3,
        RangeDisplay = 0x4,
        IconIndex = 0x5,
        OffsetTarget = 0x6,
    }

    public abstract class ChangeData
    {
        public byte SpellSlot { get; set; }
        public bool IsSummonerSpell { get; set; }
        public abstract ChangeSlotSpellDataType ChangeSlotSpellDataType { get; }
        public abstract void ReadBody(PacketReader reader);
        public abstract void WriteBody(PacketWriter writer);
    }

    public class ChangeDataUnknown : ChangeData
    {
        private ChangeSlotSpellDataType _changeSlotSpellDataType;
        public ChangeDataUnknown(ChangeSlotSpellDataType type) => _changeSlotSpellDataType = type;
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => _changeSlotSpellDataType;
        public override void ReadBody(PacketReader reader) { }
        public override void WriteBody(PacketWriter writer) { }
    }

    public class ChangeDataTargetingType : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.TargetingType;
        public TargetingType TargetingType { get; set; }
        public override void ReadBody(PacketReader reader)
        {
            TargetingType = reader.ReadTargetingType();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteTargetingType(TargetingType);
        }
    }

    public class ChangeDataSpellName : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.SpellName;
        public string SpellName { get; set; }
        public override void ReadBody(PacketReader reader)
        {
            SpellName = reader.ReadZeroTerminatedString();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteZeroTerminatedString(SpellName);
        }
    }

    public class ChangeDataRange : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.Range;
        public float CastRange { get; set; }
        public override void ReadBody(PacketReader reader)
        {
            CastRange = reader.ReadFloat();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(CastRange);
        }
    }

    public class ChangeDataMaxGrowthRange : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.MaxGrowthRange;
        public float OverrideMaxCastRange { get; set; }
        public override void ReadBody(PacketReader reader)
        {
            OverrideMaxCastRange = reader.ReadFloat();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(OverrideMaxCastRange);
        }
    }

    public class ChangeDataRangeDisplay : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.RangeDisplay;
        public float OverrideCastRangeDisplay { get; set; }
        public override void ReadBody(PacketReader reader)
        {
            OverrideCastRangeDisplay = reader.ReadFloat();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(OverrideCastRangeDisplay);
        }
    }

    public class ChangeDataIconIndex : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.IconIndex;
        public byte IconIndex { get; set; }
        public override void ReadBody(PacketReader reader)
        {
            IconIndex = reader.ReadByte();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(IconIndex);
        }
    }

    public class ChangeDataOffsetTarget : ChangeData
    {
        public override ChangeSlotSpellDataType ChangeSlotSpellDataType => ChangeSlotSpellDataType.OffsetTarget;
        public List<NetID> Targets { get; set; } = new List<NetID>();
        public override void ReadBody(PacketReader reader)
        {
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Targets.Add(reader.ReadNetID());
            }
        }
        public override void WriteBody(PacketWriter writer)
        {
            var count = Targets.Count;
            if (count > 0xFF)
            {
                throw new IOException("Too many targets!");
            }
            writer.WriteByte((byte)count);
            for (var i = 0; i < count; i++)
            {
                writer.WriteNetID(Targets[i]);
            }
        }
    }
}
