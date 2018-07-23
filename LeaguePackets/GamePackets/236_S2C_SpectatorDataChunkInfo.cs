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
    public class S2C_SpectatorDataChunkInfo : GamePacket // 0xEC
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorDataChunkInfo;
        public int StartGameChunkId { get; set; }
        public int EndGameChunkId { get; set; }
        public static S2C_SpectatorDataChunkInfo CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_SpectatorDataChunkInfo();
            result.SenderNetID = sender;
            result.StartGameChunkId = reader.ReadInt32();
            result.EndGameChunkId = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(StartGameChunkId);
            writer.WriteInt32(EndGameChunkId);
        }
    }
}
