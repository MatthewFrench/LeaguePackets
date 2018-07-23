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
    public class S2C_HandleQuestUpdate : GamePacket // 0x8C
    {
        public abstract class Command
        {
            public abstract QuestCommand QuestCommand { get; }
            public abstract byte Bitfield { get; set; }
        }

        public class CommandActivate : Command
        {
            public override QuestCommand QuestCommand => QuestCommand.Activate;
            public bool HandleRollovers { get; set; }
            public bool Ceremony { get; set; }
            public override byte Bitfield 
            {
                get 
                {
                    byte bitfield = 0;
                    if(HandleRollovers)
                    {
                        bitfield |= 1;
                    }
                    if(Ceremony)
                    {
                        bitfield |= 2;
                    }
                    return bitfield;
                }
                set
                {
                    HandleRollovers = (value & 1) != 0;
                    Ceremony = (value & 2) != 0;
                }
            }
        }

        public class CommandComplete : Command
        {
            public override QuestCommand QuestCommand => QuestCommand.Complete;
            public bool Success { get; set; }
            public override byte Bitfield
            {
                get
                {
                    byte bitfield = 0;
                    if (Success)
                    {
                        bitfield |= 1;
                    }
                    return bitfield;
                }
                set
                {
                    Success = (value & 1) != 0;
                }
            }
        }

        public class CommandRemove : Command
        {
            public override QuestCommand QuestCommand => QuestCommand.Remove;
            public override byte Bitfield { get; set; }
        }

        public class CommandUnknown : Command
        {
            private QuestCommand _questCommand;
            public override QuestCommand QuestCommand => _questCommand;
            public override byte Bitfield { get; set; }
            public CommandUnknown(QuestCommand command) => _questCommand = command;
        }


        public override GamePacketID ID => GamePacketID.S2C_HandleQuestUpdate;
        public string Objective { get; set; }
        public string Icon { get; set; }
        public string Tooltip { get; set; }
        public string Reward { get; set; }
        public QuestType QuestType { get; set; }
        public Command CommandQuest { get; set; } = new CommandComplete();
        public QuestID QuestID { get; set; }
        public static S2C_HandleQuestUpdate CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_HandleQuestUpdate();
            result.SenderNetID = sender;
            result.Objective = reader.ReadFixedString(128);
            result.Icon = reader.ReadFixedString(128);
            result.Tooltip = reader.ReadFixedString(128);
            result.Reward = reader.ReadFixedString(128);
            result.QuestType = reader.ReadQuestType();
            QuestCommand questCommand = reader.ReadQuestCommand();
            switch(questCommand)
            {
                case QuestCommand.Activate:
                    result.CommandQuest = new CommandActivate();
                    break;
                case QuestCommand.Complete:
                    result.CommandQuest = new CommandComplete();
                    break;
                case QuestCommand.Remove:
                    result.CommandQuest = new CommandRemove();
                    break;
                default:
                    result.CommandQuest = new CommandUnknown(questCommand);
                    break;
            }
            result.CommandQuest.Bitfield = reader.ReadByte();
            result.QuestID = reader.ReadQuestID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(Objective, 128);
            writer.WriteFixedString(Icon, 128);
            writer.WriteFixedString(Tooltip, 128);
            writer.WriteFixedString(Reward, 128);
            writer.WriteQuestType(QuestType);
            writer.WriteQuestCommand(CommandQuest.QuestCommand);
            writer.WriteByte(CommandQuest.Bitfield);
            writer.WriteQuestID(QuestID);
        }
    }
}
