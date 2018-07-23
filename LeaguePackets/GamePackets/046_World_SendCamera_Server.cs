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
    public class World_SendCamera_Server : GamePacket // 0x2E
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server;
        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraDirection { get; set; }
        public ClientID ClientID { get; set; }
        public byte SyncID { get; set; }
        public static World_SendCamera_Server CreateBody(PacketReader reader, NetID sender)
        {
            var result = new World_SendCamera_Server();
            result.SenderNetID = sender;
            result.CameraPosition = reader.ReadVector3();
            result.CameraDirection = reader.ReadVector3();
            result.ClientID = reader.ReadClientID();
            result.SyncID = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(CameraPosition);
            writer.WriteVector3(CameraDirection);
            writer.WriteClientID(ClientID);
            writer.WriteByte(SyncID);
        }
    }
}
