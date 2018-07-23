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
    public class PausePacket : GamePacket // 0xA1
    {
        public override GamePacketID ID => GamePacketID.PausePacket;
        public ClientID ClientID { get; set; }
        public int PauseTimeRemaining { get; set; }
        public bool IsTournament { get; set; }
        public static PausePacket CreateBody(PacketReader reader, NetID sender)
        {
            var result = new PausePacket();
            result.SenderNetID = sender;
            result.ClientID = reader.ReadClientID();
            result.PauseTimeRemaining = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            result.IsTournament = (bitfield & 1) != 0;

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WriteInt32(PauseTimeRemaining);
            byte bitfield = 0;
            if (IsTournament)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
