using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Building_Die : GamePacket // 0x89
    {
        public override GamePacketID ID => GamePacketID.Building_Die;
        public NetID AttackerNetID { get; set; }
        public NetID LastHeroNetID { get; set; }
        public static Building_Die CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Building_Die();
            result.SenderNetID = sender;
            result.AttackerNetID = reader.ReadNetID();
            result.LastHeroNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(AttackerNetID);
            writer.WriteNetID(LastHeroNetID);
        }
    }
}
