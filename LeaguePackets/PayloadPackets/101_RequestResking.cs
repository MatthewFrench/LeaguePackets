﻿using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class RequestResking : PayloadPacket // 0x65
    {
        public override PayloadPacketID ID => PayloadPacketID.RequestResking;
        public PlayerID PlayerID { get; set; }
        public uint SkinID { get; set; }
        public string SkinName { get; set; }

        public static RequestResking CreateBody(PacketReader reader)
        {
            var result = new RequestResking();
            result.PlayerID = reader.ReadPlayerID();
            result.SkinID = reader.ReadUInt32();
            result.SkinName = reader.ReadSizedFixedString(128);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePlayerID(PlayerID);
            writer.WriteUInt32(SkinID);
            writer.WriteSizedFixedString(SkinName, 128);
        }
    }
}
