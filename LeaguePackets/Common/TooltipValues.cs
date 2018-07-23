using System;
using LeaguePackets.Common;

namespace LeaguePackets.Common
{
    public class TooltipValues
    {
        private float[] _values = new float[16];
        private bool[] _hideFromEnemy = new bool[16];
        public NetID OwnerNetID { get; set; }
        public byte SlotIndex { get; set; }
        public float[] Values => _values;
        public bool[] HideFromEnemy => _hideFromEnemy;
    }
}
