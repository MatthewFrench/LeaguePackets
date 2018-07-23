using System;
namespace LeaguePackets.Common
{
    public struct ItemPacket
    {
        public ItemID ItemID { get; set; }
        public byte Slot { get; set;}
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }
    }
}
