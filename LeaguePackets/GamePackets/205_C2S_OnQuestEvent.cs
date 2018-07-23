﻿using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_OnQuestEvent : GamePacket // 0xCD
    {
        public override GamePacketID ID => GamePacketID.C2S_OnQuestEvent;
        public QuestEvent QuestEvent { get; set; }
        public QuestID QuestID { get; set; }
        public static C2S_OnQuestEvent CreateBody(PacketReader reader, NetID sender)
        {
            var result = new C2S_OnQuestEvent();
            result.SenderNetID = sender;
            result.QuestEvent = reader.ReadQuestEvent();
            result.QuestID = reader.ReadQuestID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteQuestEvent(QuestEvent);
            writer.WriteQuestID(QuestID);
        }
    }
}
