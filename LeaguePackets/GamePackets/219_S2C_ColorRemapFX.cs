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
    public class S2C_ColorRemapFX : GamePacket // 0xDB
    {
        public override GamePacketID ID => GamePacketID.S2C_ColorRemapFX;
        public bool IsFadingIn { get; set; }
        public float FadeTime { get; set; }
        public TeamID TeamID { get; set; }
        public Color Color { get; set; }
        public float MaxWeight { get; set; }
        public static S2C_ColorRemapFX CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ColorRemapFX();
            result.SenderNetID = sender;
            result.IsFadingIn = reader.ReadBool();
            result.FadeTime = reader.ReadFloat();
            result.TeamID = reader.ReadTeamID();
            result.Color = reader.ReadColor();
            result.MaxWeight = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(IsFadingIn);
            writer.WriteFloat(FadeTime);
            writer.WriteTeamID(TeamID);
            writer.WriteColor(Color);
            writer.WriteFloat(MaxWeight);
        }
    }
}
