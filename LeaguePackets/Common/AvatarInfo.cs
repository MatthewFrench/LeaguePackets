using System;
namespace LeaguePackets.Common
{
    public class AvatarInfo
    {
        private uint[] _itemIDs = new uint[30];
        private uint[] _summonerSpellIDs = new uint[2];
        private Talent[] _talents = new Talent[80];
        public uint[] ItemIDs => _itemIDs;
        public uint[] SummonerIDs => _summonerSpellIDs;
        public Talent[] Talents => _talents;
        public byte Level { get; set; }
        public byte WardSkin { get; set; }
    }
}
