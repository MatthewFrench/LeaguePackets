using System;
namespace LeaguePackets.Common
{
    public struct ReplaceBuffInGroup
    {
        public NetID OwnerNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public byte Slot { get; set; } 
    }
}
