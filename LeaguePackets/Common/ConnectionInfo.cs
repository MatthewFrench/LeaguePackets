using System;
namespace LeaguePackets.Common
{
    public struct ConnectionInfo
    {
        public ClientID ClientID { get; set; }
        public PlayerID PlayerID { get; set; }
        public float Percentage { get; set; }
        public float ETA { get; set; }
        // TODO: change bitfield to variables
        public uint Bitfield { get; set; }
    }
}
