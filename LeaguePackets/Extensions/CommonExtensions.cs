using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Extensions
{
    public static class CommonExtensions
    {
        public static void WriteNetID(this PacketWriter writer, NetID netID)
        {
            writer.WriteUInt32((uint)netID);
        }

        public static NetID ReadNetID(this PacketReader reader)
        {
            return (NetID)reader.ReadUInt32();
        }

        public static void WriteClientID(this PacketWriter writer, ClientID clientId)
        {
            writer.WriteUInt32((uint)clientId);
        }

        public static ClientID ReadClientID(this PacketReader reader)
        {
            return (ClientID)reader.ReadUInt32();
        }

        public static void WritePlayerID(this PacketWriter writer, PlayerID clientId)
        {
            writer.WriteUInt64((uint)clientId);
        }

        public static PlayerID ReadPlayerID(this PacketReader reader)
        {
            return (PlayerID)reader.ReadUInt64();
        }

        public static void WriteNetNodeID(this PacketWriter writer, NetNodeID nodeID)
        {
            writer.WriteByte((byte)nodeID);
        }

        public static NetNodeID ReadNetNodeID(this PacketReader reader)
        {
            return (NetNodeID)(reader.ReadByte());
        }

        public static void WriteNetTeam(this PacketWriter writer, NetTeam temaId)
        {
            writer.WriteUInt32((uint)temaId);
        }

        public static NetTeam ReadNetTeam(this PacketReader reader)
        {
            return (NetTeam)(reader.ReadUInt32());
        }

        public static void WriteChatType(this PacketWriter writer, ChatType chatType)
        {
            writer.WriteUInt32((uint)chatType);
        }

        public static ChatType ReadChatType(this PacketReader reader)
        {
            return (ChatType)(reader.ReadUInt32());
        }

        public static void WriteCommonBasicAttack(this PacketWriter writer, CommonBasicAttack attack)
        {
            writer.WriteNetID(attack.TargetNetID);
            writer.WriteVector3(attack.TargetPosition);
            writer.WriteByte(attack.ExtraTime);
            writer.WriteNetID(attack.MissileNextID);
            writer.WriteByte(attack.AttackSlot);
        }

        public static CommonBasicAttack ReadCommonBasicAttack(this PacketReader reader)
        {
            var attack = new CommonBasicAttack();
            attack.TargetNetID = reader.ReadNetID();
            attack.TargetPosition = reader.ReadVector3();
            attack.ExtraTime = reader.ReadByte();
            attack.MissileNextID = reader.ReadNetID();
            attack.AttackSlot = reader.ReadByte();
            return attack;
        }

        public static void WriteConnectionInfo(this PacketWriter writer, ConnectionInfo info)
        {
            writer.WriteClientID(info.ClientID);
            writer.WritePlayerID(info.PlayerID);
            writer.WriteFloat(info.Percentage);
            writer.WriteFloat(info.ETA);
            writer.WriteUInt32(info.Bitfield);
        }

        public static ConnectionInfo ReadConnectionInfo(this PacketReader reader)
        {
            var info = new ConnectionInfo();
            info.ClientID = reader.ReadClientID();
            info.PlayerID = reader.ReadPlayerID();
            info.Percentage = reader.ReadFloat();
            info.ETA = reader.ReadFloat();
            info.Bitfield = reader.ReadUInt32();
            return info;
        }

        public static void WriteTalent(this PacketWriter writer, Talent talent)
        {
            writer.WriteUInt32(talent.Hash);
            writer.WriteByte(talent.Level);
        }

        public static Talent ReadTalent(this PacketReader reader)
        {
            var talent = new Talent();
            talent.Hash = reader.ReadUInt32();
            talent.Level = reader.ReadByte();
            return talent;
        }

        public static void WriteAvatarInfo(this PacketWriter writer, AvatarInfo info)
        {
            for (var i = 0; i < info.ItemIDs.Length; i++)
            {
                writer.WriteUInt32(info.ItemIDs[i]);
            }
            for (var i = 0; i < info.SummonerIDs.Length; i++)
            {
                writer.WriteUInt32(info.SummonerIDs[i]);
            }
            for (var i = 0; i < info.Talents.Length; i++)
            {
                writer.WriteTalent(info.Talents[i]);
            }
            writer.WriteByte(info.Level);
            writer.WriteByte(info.WardSkin);
        }

        public static AvatarInfo ReadAvatarInfo(this PacketReader reader)
        {
            var info = new AvatarInfo();
            for (var i = 0; i < info.ItemIDs.Length; i++)
            {
                info.ItemIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < info.SummonerIDs.Length; i++)
            {
                info.SummonerIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < info.Talents.Length; i++)
            {
                info.Talents[i] = reader.ReadTalent();
            }
            info.Level = reader.ReadByte();
            info.WardSkin = reader.ReadByte();
            return info;
        }

        public static void WriteTeamID(this PacketWriter writer, TeamID temaId)
        {
            writer.WriteUInt32((uint)temaId);
        }

        public static TeamID ReadTeamID(this PacketReader reader)
        {
            return (TeamID)(reader.ReadUInt32());
        }

        public static TipConfig ReadTipConfig(this PacketReader reader)
        {
            var tip = new TipConfig();
            tip.TipID = reader.ReadSByte();
            tip.ColorID = reader.ReadSByte();
            tip.DurationID = reader.ReadSByte();
            tip.Flags = reader.ReadSByte();
            return tip;
        }

        public static void WriteTipConfig(this PacketWriter writer, TipConfig tip)
        {
            writer.WriteSByte(tip.TipID);
            writer.WriteSByte(tip.ColorID);
            writer.WriteSByte(tip.DurationID);
            writer.WriteSByte(tip.Flags);
        }

        public static ItemPacket ReadItemPacket(this PacketReader reader)
        {
            var item = new ItemPacket();
            item.ItemID = reader.ReadItemID();
            item.Slot = reader.ReadByte();
            item.ItemsInSlot = reader.ReadByte();
            item.SpellCharges = reader.ReadByte();
            return item;
        }
        public static void WriteItemPacket(this PacketWriter writer, ItemPacket item)
        {
            writer.WriteItemID(item.ItemID);
            writer.WriteByte(item.Slot);
            writer.WriteByte(item.ItemsInSlot);
            writer.WriteByte(item.SpellCharges);
        }
        public static PlayerLiteInfo ReadPlayerLiteInfo(this PacketReader reader)
        {
            var info = new PlayerLiteInfo();
            info.PlayerID = reader.ReadPlayerID();
            info.SummonorLevel = reader.ReadUInt16();
            info.SummonorSpell1 = reader.ReadUInt32();
            info.SummonorSpell2 = reader.ReadUInt32();
            info.Bitfield = reader.ReadByte();
            info.TeamId = reader.ReadTeamID();
            info.BotName = reader.ReadFixedString(64);
            info.BotSkinName = reader.ReadFixedString(64);
            info.EloRanking = reader.ReadFixedString(16);
            info.BotSkinID = reader.ReadInt32();
            info.BotDifficulty = reader.ReadInt32();
            info.ProfileIconId = reader.ReadInt32();
            info.AllyBadgeID = reader.ReadByte();
            info.EnemyBadgeID = reader.ReadByte();
            return info;
        }
        public static void WritePlayerLiteInfo(this PacketWriter writer, PlayerLiteInfo info)
        {
            writer.WritePlayerID(info.PlayerID);
            writer.WriteUInt16(info.SummonorLevel);
            writer.WriteUInt32(info.SummonorSpell1);
            writer.WriteUInt32(info.SummonorSpell2);
            writer.WriteByte(info.Bitfield);
            writer.WriteTeamID(info.TeamId);
            writer.WriteFixedString(info.BotName, 64);
            writer.WriteFixedString(info.BotSkinName, 64);
            writer.WriteFixedString(info.EloRanking, 16);
            writer.WriteInt32(info.BotSkinID);
            writer.WriteInt32(info.BotDifficulty);
            writer.WriteInt32(info.ProfileIconId);
            writer.WriteByte(info.AllyBadgeID);
            writer.WriteByte(info.EnemyBadgeID);
        }

        public static DamageType ReadDamageType(this PacketReader reader)
        {
            return (DamageType)(reader.ReadUInt32());
        }

        public static void WriteDamageType(this PacketWriter writer, DamageType type)
        {
            writer.WriteUInt32((uint)type);
        }


        public static DamageSource ReadDamageSource(this PacketReader reader)
        {
            return (DamageSource)(reader.ReadUInt32());
        }

        public static void WriteDamageSource(this PacketWriter writer, DamageSource type)
        {
            writer.WriteUInt32((uint)type);
        }


        public static DamageInfo ReadDamageInfo(this PacketReader reader)
        {
            var info = new DamageInfo();
            info.DamageType = reader.ReadDamageType();
            info.DamageSource = reader.ReadDamageSource();
            return info;
        }

        public static void WriteDamageInfo(this PacketWriter writer, DamageInfo info)
        {
            writer.WriteDamageType(info.DamageType);
            writer.WriteDamageSource(info.DamageSource);
        }

        public static DeathDataPacket ReadDeathDataPacket(this PacketReader reader)
        {
            var data = new DeathDataPacket();
            data.KillerNetID = reader.ReadNetID();
            data.DamageInfo = reader.ReadDamageInfo();
            data.DeathDuration = reader.ReadFloat();
            data.Bitfield = reader.ReadByte();
            data.DieType = reader.ReadByte();
            return data;
        }

        public static void WriteDeathDataPacket(this PacketWriter writer, DeathDataPacket data)
        {
            writer.WriteNetID(data.KillerNetID);
            writer.WriteDamageInfo(data.DamageInfo);
            writer.WriteFloat(data.DeathDuration);
            writer.WriteByte(data.Bitfield);
            writer.WriteByte(data.DieType);
        }

        public static MinionRoamState ReadMinionRoamState(this PacketReader reader)
        {
            return (MinionRoamState)(reader.ReadUInt32());
        }

        public static void WriteMinionRoamState(this PacketWriter writer, MinionRoamState data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static BuffType ReadBuffType(this PacketReader reader)
        {
            return (BuffType)(reader.ReadByte());
        }

        public static void WriteBuffType(this PacketWriter writer, BuffType data)
        {
            writer.WriteByte((byte)data);
        }

        public static Color ReadColor(this PacketReader reader)
        {
            var data = new Color();
            data.Blue = reader.ReadByte();
            data.Green = reader.ReadByte();
            data.Red = reader.ReadByte();
            data.Alpha = reader.ReadByte();
            return data;
        }

        public static void WriteColor(this PacketWriter writer, Color data)
        {
            writer.WriteByte(data.Blue);
            writer.WriteByte(data.Green);
            writer.WriteByte(data.Red);
            writer.WriteByte(data.Alpha);
        }

        public static AudioEventID ReadAudioEventID(this PacketReader reader)
        {
            return (AudioEventID)reader.ReadUInt32();
        }

        public static void WriteAudioEventID(this PacketWriter writer,AudioEventID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static MusicCommand ReadMusicCommand(this PacketReader reader)
        {
            return (MusicCommand)(reader.ReadByte());
        }

        public static void WriteMusicCommand(this PacketWriter writer, MusicCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static GroundAttackMode ReadGroundAttackMode(this PacketReader reader)
        {
            return (GroundAttackMode)(reader.ReadByte());
        }

        public static void WriteGroundAttackMode(this PacketWriter writer, GroundAttackMode data)
        {
            writer.WriteByte((byte)data);
        }

        public static EmoteID ReadEmoteID(this PacketReader reader)
        {
            return (EmoteID)(reader.ReadByte());
        }

        public static void WriteEmoteID(this PacketWriter writer, EmoteID data)
        {
            writer.WriteByte((byte)data);
        }

        public static VolumeCategoryType ReadVolumeCategoryType(this PacketReader reader)
        {
            return (VolumeCategoryType)(reader.ReadByte());
        }

        public static void WriteVolumeCategoryType(this PacketWriter writer, VolumeCategoryType data)
        {
            writer.WriteByte((byte)data);
        }

        public static SpellFlags ReadSpellFlags(this PacketReader reader)
        {
            return (SpellFlags)(reader.ReadUInt32());
        }

        public static void WriteSpellFlags (this PacketWriter writer, SpellFlags data)
        {
            writer.WriteUInt32((uint)data);
        }


        public static FloatTextType ReadFloatTextType(this PacketReader reader)
        {
            return (FloatTextType)(reader.ReadByte());
        }

        public static void WriteFloatTextType(this PacketWriter writer, FloatTextType data)
        {
            writer.WriteByte((byte)data);
        }

        public static AudioVOEventType ReadAudioVOEventType(this PacketReader reader)
        {
            return (AudioVOEventType)(reader.ReadByte());
        }

        public static void WriteAudioVOEventType(this PacketWriter writer, AudioVOEventType data)
        {
            writer.WriteByte((byte)data);
        }

        public static SurrenderReason ReadSurrenderReason(this PacketReader reader)
        {
            return (SurrenderReason)(reader.ReadByte());
        }

        public static void WriteSurrenderReason (this PacketWriter writer, SurrenderReason data)
        {
            writer.WriteByte((byte)data);
        }

        public static UIElement ReadUIElement(this PacketReader reader)
        {
            return (UIElement)(reader.ReadByte());
        }

        public static void WriteUIElement(this PacketWriter writer, UIElement data)
        {
            writer.WriteByte((byte)data);
        }

        public static UIHighlightCommand ReadUIHighlightCommand(this PacketReader reader)
        {
            return (UIHighlightCommand)(reader.ReadByte());
        }

        public static void WriteUIHighlightCommand(this PacketWriter writer, UIHighlightCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static RespawnPointCommand ReadRespawnPointCommand(this PacketReader reader)
        {
            return (RespawnPointCommand)(reader.ReadByte());
        }

        public static void WriteRespawnPointCommand(this PacketWriter writer, RespawnPointCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static RespawnPointUIID ReadRespawnPointUIID(this PacketReader reader)
        {
            return (RespawnPointUIID)reader.ReadByte();
        }

        public static void WriteRespawnPointUIID(this PacketWriter writer, RespawnPointUIID data)
        {
            writer.WriteByte((byte)data);
        }

        public static RespawnPointEvent ReadRespawnPointEvent(this PacketReader reader)
        {
            return (RespawnPointEvent)(reader.ReadByte());
        }

        public static void WriteRespawnPointEvent(this PacketWriter writer, RespawnPointEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static ItemID ReadItemID(this PacketReader reader)
        {
            return (ItemID)reader.ReadUInt32();
        }

        public static void WriteItemID(this PacketWriter writer, ItemID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static PARType ReadPARType(this PacketReader reader)
        {
            return (PARType)(reader.ReadByte());
        }

        public static void WritePARType(this PacketWriter writer, PARType data)
        {
            writer.WriteByte((byte)data);
        }

        public static CostType ReadCostType(this PacketReader reader)
        {
            return (CostType)(reader.ReadByte());
        }

        public static void WriteCostType(this PacketWriter writer, CostType data)
        {
            writer.WriteByte((byte)data);
        }

        public static LookAtType ReadLookAtType(this PacketReader reader)
        {
            return (LookAtType)(reader.ReadByte());
        }

        public static void WriteLookAtType(this PacketWriter writer, LookAtType data)
        {
            writer.WriteByte((byte)data);
        }

        public static DrawPathNodeType ReadDrawPathNodeType(this PacketReader reader)
        {
            return (DrawPathNodeType)(reader.ReadByte());
        }

        public static void WriteDrawPathNodeType(this PacketWriter writer, DrawPathNodeType data)
        {
            writer.WriteByte((byte)data);
        }

        public static DrawPathMode ReadDrawPathMode(this PacketReader reader)
        {
            return (DrawPathMode)(reader.ReadByte());
        }

        public static void WriteDrawPathMode(this PacketWriter writer, DrawPathMode data)
        {
            writer.WriteByte((byte)data);
        }

        public static ContextualEmoteID ReadContextualEmoteID(this PacketReader reader)
        {
            return (ContextualEmoteID)(reader.ReadByte());
        }

        public static void WriteContextualEmoteID(this PacketWriter writer, ContextualEmoteID data)
        {
            writer.WriteByte((byte)data);
        }

        public static ContextualEmoteFlags ReadContextualEmoteFlags(this PacketReader reader)
        {
            return (ContextualEmoteFlags)(reader.ReadByte());
        }

        public static void WriteContextualEmoteFlags(this PacketWriter writer, ContextualEmoteFlags data)
        {
            writer.WriteByte((byte)data);
        }

        public static AudioVOComponentEvent ReadAudioVOComponentEvent(this PacketReader reader)
        {
            return (AudioVOComponentEvent)(reader.ReadByte());
        }

        public static void WriteAudioVOComponentEvent(this PacketWriter writer, AudioVOComponentEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static VisibilityTeam ReadVisibilityTeam(this PacketReader reader)
        {
            return (VisibilityTeam)(reader.ReadByte());
        }

        public static void WriteVisibilityTeam(this PacketWriter writer, VisibilityTeam data)
        {
            writer.WriteByte((byte)data);
        }

        public static StatEvent ReadStatEvent(this PacketReader reader)
        {
            return (StatEvent)(reader.ReadByte());
        }

        public static void WriteStatEvent(this PacketWriter writer, StatEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static ScoreEvent ReadScoreEvent(this PacketReader reader)
        {
            return (ScoreEvent)(reader.ReadByte());
        }

        public static void WriteScoreEvent(this PacketWriter writer, ScoreEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static ScoreCategory ReadScoreCategory(this PacketReader reader)
        {
            return (ScoreCategory)(reader.ReadByte());
        }

        public static void WriteScoreCategory(this PacketWriter writer, ScoreCategory data)
        {
            writer.WriteByte((byte)data);
        }

        public static CapturePointUpdateCommand ReadCapturePointUpdateCommand(this PacketReader reader)
        {
            return (CapturePointUpdateCommand)(reader.ReadByte());
        }

        public static void WriteCapturePointUpdateCommand(this PacketWriter writer, CapturePointUpdateCommand data)
        {
            writer.WriteByte((byte)data);
        }


        public static InputLockFlags ReadInputLockFlags(this PacketReader reader)
        {
            return (InputLockFlags)(reader.ReadUInt32());
        }

        public static void WriteInputLockFlags(this PacketWriter writer, InputLockFlags data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static QuestEvent ReadQuestEvent(this PacketReader reader)
        {
            return (QuestEvent)(reader.ReadByte());
        }

        public static void WriteQuestEvent(this PacketWriter writer, QuestEvent data)
        {
            writer.WriteByte((byte)data);
        }

        public static QuestID ReadQuestID(this PacketReader reader)
        {
            return (QuestID)reader.ReadUInt32();
        }

        public static void WriteQuestID(this PacketWriter writer, QuestID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static QuestCommand ReadQuestCommand(this PacketReader reader)
        {
            return (QuestCommand)(reader.ReadByte());
        }

        public static void WriteQuestCommand(this PacketWriter writer, QuestCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static QuestType ReadQuestType(this PacketReader reader)
        {
            return (QuestType)(reader.ReadByte());
        }

        public static void WriteQuestType(this PacketWriter writer, QuestType data)
        {
            writer.WriteByte((byte)data);
        }

        public static ParticleFlexID ReadFlexID(this PacketReader reader)
        {
            return (ParticleFlexID)reader.ReadByte();
        }

        public static void WriteFlexID(this PacketWriter writer, ParticleFlexID data)
        {
            writer.WriteByte((byte)data);
        }

        public static AIState ReadAIState(this PacketReader reader)
        {
            return (AIState)(reader.ReadUInt32());
        }

        public static void WriteAIState(this PacketWriter writer, AIState data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static AnimationFlags ReadAnimationFlags(this PacketReader reader)
        {
            return (AnimationFlags)(reader.ReadUInt32());
        }

        public static void WriteAnimationFlags(this PacketWriter writer, AnimationFlags data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static ParticleAttachType ReadParticleAttachType(this PacketReader reader)
        {
            return (ParticleAttachType)(reader.ReadByte());
        }

        public static void WriteParticleAttachType(this PacketWriter writer, ParticleAttachType data)
        {
            writer.WriteByte((byte)data);
        }

        public static PARState ReadPARState(this PacketReader reader)
        {
            return (PARState)(reader.ReadUInt32());
        }

        public static void WritePARState(this PacketWriter writer, PARState data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static MusicID ReadMusicID(this PacketReader reader)
        {
            return (MusicID)reader.ReadUInt32();
        }

        public static void WriteMusicID(this PacketWriter writer, MusicID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static TipCommand ReadTipCommand(this PacketReader reader)
        {
            return (TipCommand)(reader.ReadByte());
        }

        public static void WriteTipCommand(this PacketWriter writer, TipCommand data)
        {
            writer.WriteByte((byte)data);
        }

        public static TipID ReadTipID(this PacketReader reader)
        {
            return (TipID)reader.ReadUInt32();
        }

        public static void WriteTipID(this PacketWriter writer, TipID data)
        {
            writer.WriteUInt32((uint)data);
        }

        public static HealthBarType ReadHealthBarType(this PacketReader reader)
        {
            return (HealthBarType)(reader.ReadByte());
        }

        public static void WriteHealthBarType(this PacketWriter writer, HealthBarType data)
        {
            writer.WriteByte((byte)data);
        }

        public static GameFeatures ReadGameFeatures(this PacketReader reader)
        {
            return (GameFeatures)(reader.ReadUInt64());
        }

        public static void WriteGameFeatures(this PacketWriter writer, GameFeatures data)
        {
            writer.WriteUInt64((ulong)data);
        }

        public static TargetingType ReadTargetingType(this PacketReader reader)
        {
            return (TargetingType)(reader.ReadByte());
        }

        public static void WriteTargetingType(this PacketWriter writer, TargetingType data)
        {
            writer.WriteByte((byte)data);
        }

        public static ChangeData ReadChangeData(this PacketReader reader)
        {
            byte bitfield = reader.ReadByte();
            byte spellSlot = (byte)(bitfield & 0x3F);
            bool isSummonerSpell = (bitfield & 0x40) != 0;
            ChangeData data;
            ChangeSlotSpellDataType type = (ChangeSlotSpellDataType)reader.ReadByte();
            switch (type)
            {
                case ChangeSlotSpellDataType.TargetingType:
                    data = new ChangeDataTargetingType();
                    break;
                case ChangeSlotSpellDataType.SpellName:
                    data = new ChangeDataSpellName();
                    break;
                case ChangeSlotSpellDataType.Range:
                    data = new ChangeDataRange();
                    break;
                case ChangeSlotSpellDataType.MaxGrowthRange:
                    data = new ChangeDataMaxGrowthRange();
                    break;
                case ChangeSlotSpellDataType.RangeDisplay:
                    data = new ChangeDataRangeDisplay();
                    break;
                case ChangeSlotSpellDataType.IconIndex:
                    data = new ChangeDataIconIndex();
                    break;
                case ChangeSlotSpellDataType.OffsetTarget:
                    data = new ChangeDataOffsetTarget();
                    break;
                default:
                    data = new ChangeDataUnknown(type);
                    break;
            }
            data.SpellSlot = spellSlot;
            data.IsSummonerSpell = isSummonerSpell;
            data.ReadBody(reader);
            return data;
        }

        public static void WriteChangeData(this PacketWriter writer, ChangeData data)
        {
            byte bitfield = 0;
            bitfield |= (byte)((byte)data.SpellSlot & 0x3F);
            if (data.IsSummonerSpell)
                bitfield |= 0x40;
            writer.WriteByte((byte)data.ChangeSlotSpellDataType);
            data.WriteBody(writer);
        }


        public static ReplaceBuffInGroup ReadReplaceBuffInGroup(this PacketReader reader)
        {
            var data = new ReplaceBuffInGroup();
            data.OwnerNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.Slot = reader.ReadByte();
            return data;

        }

        public static void WriteReplaceBuffInGroup(this PacketWriter writer, ReplaceBuffInGroup data)
        {
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteByte(data.Slot);
        }

        public static AddBuffInGroup ReadAddBuffInGroup(this PacketReader reader)
        {
            var data = new AddBuffInGroup();
            data.OwnerNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.Slot = reader.ReadByte();
            data.Count = reader.ReadByte();
            data.IsHidden = reader.ReadBool();
            return data;

        }

        public static void WriteAddBuffInGroup(this PacketWriter writer, AddBuffInGroup data)
        {
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteByte(data.Slot);
            writer.WriteByte(data.Count);
            writer.WriteBool(data.IsHidden);
        }


        public static UpdateCountBuffInGroup ReadUpdateCountBuffInGroup(this PacketReader reader)
        {
            var data = new UpdateCountBuffInGroup();
            data.OwnerNetID = reader.ReadNetID();
            data.CasterNetID = reader.ReadNetID();
            data.Count = reader.ReadByte();
            return data;
        }

        public static void WriteUpdateCountBuffInGroup(this PacketWriter writer, UpdateCountBuffInGroup data)
        {
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteNetID(data.CasterNetID);
            writer.WriteByte(data.Count);
        }

        public static RemoveBuffInGroup ReadRemoveBuffInGroup(this PacketReader reader)
        {
            var data = new RemoveBuffInGroup();
            data.OwnerNetID = reader.ReadNetID();
            data.Slot = reader.ReadByte();
            data.RunTimeRemove = reader.ReadFloat();
            return data;
        }

        public static void WriteRemoveBuffInGroup(this PacketWriter writer, RemoveBuffInGroup data)
        {
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteByte(data.Slot);
            writer.WriteFloat(data.RunTimeRemove);
        }

        public static NavFlagCricle ReadNavFlagCricle(this PacketReader reader)
        {
            var data = new NavFlagCricle();
            data.PositionX = reader.ReadFloat();
            data.PositionZ = reader.ReadFloat();
            data.Radius = reader.ReadFloat();
            data.Flags = reader.ReadUInt32();
            return data;
        }

        public static void WriteNavFlagCricle(this PacketWriter writer, NavFlagCricle data)
        {
            writer.WriteFloat(data.PositionX);
            writer.WriteFloat(data.PositionZ);
            writer.WriteFloat(data.Radius);
            writer.WriteUInt32(data.Flags);
        }

        public static AnimationOverridePair ReadAnimationOverridePair(this PacketReader reader)
        {
            var data = new AnimationOverridePair();
            data.From = reader.ReadSizedString();
            data.To = reader.ReadSizedString();
            return data;
        }

        public static void WriteAnimationOverridePair(this PacketWriter writer, AnimationOverridePair data)
        {
            writer.WriteSizedString(data.From);
            writer.WriteSizedString(data.To);
        }

        public static WaypointSpeedParams ReadWaypointSpeedParams(this PacketReader reader)
        {
            var data = new WaypointSpeedParams();
            data.PathSpeedOverride = reader.ReadFloat();
            data.ParabolicGravity = reader.ReadFloat();
            data.ParabolicStartPoint = reader.ReadVector2();
            data.Facing = reader.ReadBool();
            data.FollowNetID = reader.ReadNetID();
            data.FollowDistance = reader.ReadFloat();
            data.FollowBackDistance = reader.ReadFloat();
            data.FollowTravelTime = reader.ReadFloat();
            return data;
        }

        public static void WriteWaypointSpeedParams(this PacketWriter writer, WaypointSpeedParams data)
        {
            writer.WriteFloat(data.PathSpeedOverride);
            writer.WriteFloat(data.ParabolicGravity);
            writer.WriteVector2(data.ParabolicStartPoint);
            writer.WriteBool(data.Facing);
            writer.WriteNetID(data.FollowNetID);
            writer.WriteFloat(data.FollowDistance);
            writer.WriteFloat(data.FollowBackDistance);
            writer.WriteFloat(data.FollowTravelTime);
        }


        public static TooltipValues ReadTooltipValues(this PacketReader reader)
        {
            var data = new TooltipValues();
            data.OwnerNetID = reader.ReadNetID();
            data.SlotIndex = reader.ReadByte();
            for (int i = 0; i < data.Values.Length; i++)
            {
                data.Values[i] = reader.ReadFloat();
            }
            for (int i = 0; i < data.HideFromEnemy.Length; i++)
            {
                data.HideFromEnemy[i] = reader.ReadBool();
            }
            return data;
        }

        public static void WriteTooltipValues(this PacketWriter writer, TooltipValues data)
        {
            writer.WriteNetID(data.OwnerNetID);
            writer.WriteByte(data.SlotIndex);
            for (int i = 0; i < data.Values.Length; i++)
            {
                writer.WriteFloat(data.Values[i]);
            }
            for (int i = 0; i < data.HideFromEnemy.Length; i++)
            {
                writer.WriteBool(data.HideFromEnemy[i]);
            }
        }

        public static SpectatorChunkType ReadSpectatorChunkType(this PacketReader reader)
        {
            return (SpectatorChunkType)(reader.ReadByte());
        }

        public static void WriteSpectatorChunkType(this PacketWriter writer, SpectatorChunkType data)
        {
            writer.WriteByte((byte)data);
        }
    }
}
