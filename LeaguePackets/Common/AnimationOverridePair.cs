using System;
namespace LeaguePackets.Common
{
    public struct AnimationOverridePair
    {
        public string From { get; set; }
        public string To { get; set; }
        public static bool operator ==(AnimationOverridePair a, AnimationOverridePair b)
        {
            return a.From == b.From &&
                   a.To == b.To;
        }
        public static bool operator !=(AnimationOverridePair a, AnimationOverridePair b) => !(a == b);
        public override bool Equals(Object obj) => (obj is AnimationOverridePair b) && this == b;
        public override int GetHashCode()
        {
            return Tuple.Create(From, To).GetHashCode();
        }
    }
}
