using System;
using System.Numerics;

namespace LeaguePackets.Common
{
    public struct CommonBasicAttack
    {
        public NetID TargetNetID { get; set; }
        public Vector3 TargetPosition { get; set; }
        public byte ExtraTime { get; set; }
        public NetID MissileNextID { get; set; }
        public byte AttackSlot { get; set; }
    }
}
