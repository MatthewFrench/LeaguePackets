using System;
namespace LeaguePackets.Common
{
    public struct TipConfig
    {
        //TODO: posible use enums?
        public sbyte TipID { get; set; }
        public sbyte ColorID { get; set;}
        public sbyte DurationID { get; set; }
        public sbyte Flags { get; set; }
    }
}
