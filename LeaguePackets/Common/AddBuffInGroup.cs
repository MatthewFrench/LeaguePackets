using System;
namespace LeaguePackets.Common
{
    public class AddBuffInGroup
    {
        public NetID OwnerNetID { get; set; }
        public NetID CasterNetID { get; set; }
        public byte Slot { get; set; }
        public byte Count { get; set; }
        public bool IsHidden { get; set; }
    }
}
