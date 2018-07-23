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
    public class SynchVersionC2S : GamePacket // 0xBD
    {
        public override GamePacketID ID => GamePacketID.SynchVersionC2S;
        public ClientID ClientIDNet { get; set; }
        public string Version { get; set; }
        public static SynchVersionC2S CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SynchVersionC2S();
            result.SenderNetID = sender;
            result.ClientIDNet = reader.ReadClientID();
            result.Version = reader.ReadFixedString(256);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientIDNet);
            writer.WriteFixedString(Version, 256);
        }
    }
}
