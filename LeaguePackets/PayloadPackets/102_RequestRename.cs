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
    public class RequestRename : PayloadPacket // 0x66
    {
        public override PayloadPacketID ID => PayloadPacketID.RequestRename;
        public PlayerID PlayerID { get; set; }
        public uint SkinID { get; set; }
        public string ChampionName { get; set; }

        public static RequestRename CreateBody(PacketReader reader)
        {
            var result = new RequestRename();
            result.PlayerID = reader.ReadPlayerID();
            result.SkinID = reader.ReadUInt32();
            result.ChampionName = reader.ReadSizedFixedString(128);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePlayerID(PlayerID);
            writer.WriteUInt32(SkinID);
            writer.WriteSizedFixedString(ChampionName, 128);
        }
    }
}
