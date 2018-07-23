using System;
namespace LeaguePackets.Common
{
    public struct NavFlagCricle
    {
        public float PositionX { get; set; }
        public float PositionZ { get; set; }
        public float Radius { get; set; }
        public uint Flags { get; set; }
    }
}
