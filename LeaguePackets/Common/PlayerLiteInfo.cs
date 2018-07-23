using System;
namespace LeaguePackets.Common
{
    public struct PlayerLiteInfo
    {
        public PlayerID PlayerID { get; set; }
        public ushort SummonorLevel { get; set; }
        public uint SummonorSpell1 { get; set; }
        public uint SummonorSpell2 { get; set; }
        //TODO: change bitfield to enum or variables
        public byte Bitfield { get; set; }
        public TeamID TeamId { get; set; }
        public string BotName { get; set; }
        public string BotSkinName { get; set; }
        public string EloRanking { get; set; }
        public int BotSkinID { get; set; }
        public int BotDifficulty { get; set; }
        public int ProfileIconId { get; set; }
        public byte AllyBadgeID { get; set; }
        public byte EnemyBadgeID { get; set; }
    }
}
