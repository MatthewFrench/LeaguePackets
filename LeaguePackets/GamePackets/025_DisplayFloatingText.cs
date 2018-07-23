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
    public class DisplayFloatingText : GamePacket // 0x19
    {
        public override GamePacketID ID => GamePacketID.DisplayFloatingText;
        public NetID TargetNetID { get; set; }

        public FloatTextType FloatingTextType { get; set; }
        public int Param { get; set; }
        public string Message { get; set; }
        public static DisplayFloatingText CreateBody(PacketReader reader, NetID sender)
        {
            var result = new DisplayFloatingText();
            result.SenderNetID = sender;
            result.TargetNetID = reader.ReadNetID();
            result.FloatingTextType = reader.ReadFloatTextType();
            result.Param = reader.ReadInt32();
            result.Message = reader.ReadFixedString(128);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteFloatTextType(FloatingTextType);
            writer.WriteInt32(Param);
            writer.WriteFixedString(Message, 128);
        }
    }
}
