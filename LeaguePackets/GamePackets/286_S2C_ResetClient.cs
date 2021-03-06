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
    public class S2C_ResetClient : GamePacket // 0x11E
    {
        public override GamePacketID ID => GamePacketID.S2C_ResetClient;
        //FIXME: this should be empty?
        public static S2C_ResetClient CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ResetClient();
            result.SenderNetID = sender;
            throw new NotImplementedException("S2C_ResetClient.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("S2C_ResetClient.Write");
        }
    }
}
