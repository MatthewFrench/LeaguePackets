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
    public class MissileReplication : GamePacket // 0x3B
    {
        public override GamePacketID ID => GamePacketID.MissileReplication;
        public Vector3 Position { get; set; }
        public Vector3 CasterPosition { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 StartPoint { get; set; }
        public Vector3 EndPoint { get; set; }
        public Vector3 UnitPosition { get; set; }
        public float TimeFromCreation { get; set; }
        public float Speed { get; set; }
        public float LifePercentage { get; set; }
        public float TimedSpeedDelta { get; set; }
        public float TimedSpeedDeltaTime { get; set; }
        // TODO: change bitfield to enum or variables
        public byte Bitfield { get; set; }
        // TODO: make a class that reads/writer this data
        //public byte CastInfoBuffer[512] {get; set; }
        public static MissileReplication CreateBody(PacketReader reader, NetID sender)
        {
            var result = new MissileReplication();
            result.SenderNetID = sender;
            throw new NotImplementedException("MissileReplication.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("MissileReplication.Write");
        }
    }
}
