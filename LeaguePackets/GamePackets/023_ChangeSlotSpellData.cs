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
    public class ChangeSlotSpellData : GamePacket // 0x17
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellData;
        public ChangeData ChangeData { get; set; }
        public static ChangeSlotSpellData CreateBody(PacketReader reader, NetID sender)
        {
            var result = new ChangeSlotSpellData();
            result.SenderNetID = sender;
            result.ChangeData = reader.ReadChangeData();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteChangeData(ChangeData);
        }
    }
}
