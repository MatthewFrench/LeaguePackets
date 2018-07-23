using System;
namespace LeaguePackets.Common
{
    public struct DeathDataPacket
    {
        public NetID KillerNetID { get; set; }
        public DamageInfo DamageInfo { get; set; }
        public float DeathDuration { get; set; }
        //TODO: change to enum or variables
        public byte Bitfield { get; set; }
        //TODO: enum?
        public byte DieType { get; set; }
    }
}
