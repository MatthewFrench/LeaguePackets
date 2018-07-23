using System;
namespace LeaguePackets.Common
{
    public struct UpdateCountBuffInGroup
    {
        public NetID OwnerNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public byte Count { get; set; }
    }
}
