using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class OnReplication : GamePacket // 0xC4
    {
        public override GamePacketID ID => GamePacketID.OnReplication;
        public uint SyncID { get; set; }
        public SByte Count { get; set; }
        //TODO: variable data!
        public static OnReplication CreateBody(PacketReader reader, NetID sender)
        {
            var result = new OnReplication();
            result.SenderNetID = sender;
            throw new NotImplementedException("OnReplication.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("OnReplication.Write");
        }
    }
}
