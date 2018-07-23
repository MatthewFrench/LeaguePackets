using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class TeamRosterUpdate : PayloadPacket // 0x67
    {
        public override PayloadPacketID ID => PayloadPacketID.TeamRosterUpdate;
        public uint TeamSizeOrder { get; set; }
        public uint TeamSizeChaos { get; set; }
        public List<PlayerID> OrderMembers { get; set; } = new List<PlayerID>();
        public List<PlayerID> ChaosMembers { get; set; } = new List<PlayerID>();

        public static TeamRosterUpdate CreateBody(PacketReader reader)
        {
            var result = new TeamRosterUpdate();
            result.TeamSizeOrder = reader.ReadUInt32();
            result.TeamSizeChaos = reader.ReadUInt32();
            var order = new PlayerID[24];
            for(int i = 0; i < 24; i++)
                order[i] = reader.ReadPlayerID();
            var chaos = new PlayerID[24];
            for(int i = 0; i < 24; i++)
                chaos[i] = reader.ReadPlayerID();
            var orderCount = reader.ReadInt32();
            var chaosCount = reader.ReadInt32();
            result.OrderMembers = order.Take(orderCount).ToList();
            result.ChaosMembers = chaos.Take(chaosCount).ToList();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(TeamSizeOrder);
            writer.WriteUInt32(TeamSizeChaos);
            for(int i = 0; i < OrderMembers.Count; i++)
                writer.WritePlayerID(OrderMembers[i]);
            for(int i =  OrderMembers.Count; i < 24; i++)
                writer.WritePlayerID((PlayerID)0);
            for (int i = 0; i < ChaosMembers.Count; i++)
                writer.WritePlayerID(ChaosMembers[i]);
            for (int i = ChaosMembers.Count; i < 24; i++)
                writer.WritePlayerID((PlayerID)0);
            writer.WriteInt32(OrderMembers.Count);
            writer.WriteInt32(ChaosMembers.Count);
        }
    }
}
