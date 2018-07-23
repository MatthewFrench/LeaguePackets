﻿using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class S2C_CreateMinionCamp : GamePacket // 0x122
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateMinionCamp;
        public Vector3 Position { get; set; }
        public string MinimapIcon { get; set; }
        public byte CampIndex { get; set; }
        public AudioVOComponentEvent VOComponentRevealEvent { get; set; }
        public TeamID TeamSide { get; set; }
        public int TimerType { get; set; }
        public float Expire { get; set; }

        public static S2C_CreateMinionCamp CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_CreateMinionCamp();
            result.SenderNetID = sender;
            result.Position = reader.ReadVector3();
            result.MinimapIcon = reader.ReadFixedString(64);
            result.CampIndex = reader.ReadByte();
            result.VOComponentRevealEvent = reader.ReadAudioVOComponentEvent();
            result.TeamSide = (TeamID)reader.ReadByte();
            result.TimerType = reader.ReadInt32();
            result.Expire = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteFixedString(MinimapIcon, 64);
            writer.WriteByte(CampIndex);
            writer.WriteAudioVOComponentEvent(VOComponentRevealEvent);
            writer.WriteByte((byte)TeamSide);
            writer.WriteInt32(TimerType);
            writer.WriteFloat(Expire);
        }
    }
}
