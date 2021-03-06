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
    public class S2C_Reconnect : GamePacket // 0xF
    {
        public override GamePacketID ID => GamePacketID.S2C_Reconnect;
        public ClientID ClientID { get; set; }
        public static S2C_Reconnect CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_Reconnect();
            result.SenderNetID = sender;
            result.ClientID = reader.ReadClientID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
        }
    }
}
