using LeaguePackets.Common;
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
    public class MovementDriverReplication : GamePacket // 0x3C
    {
        public override GamePacketID ID => GamePacketID.MovementDriverReplication;
        // TODO: change this to enum ?
        public byte MovementTypeID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        // TODO: make a class that reads/writer this data
        //public byte MovementInfoBuffer[512] { get; set; }
        public static MovementDriverReplication CreateBody(PacketReader reader, NetID sender)
        {
            var result = new MovementDriverReplication();
            result.SenderNetID = sender;
            throw new NotImplementedException("MovementDriverReplication.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("MovementDriverReplication.Write");
        }
    }
}
