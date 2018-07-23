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
    public class C2S_OnTipEvent : GamePacket // 0x6D
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTipEvent;
        public TipCommand TipCommand { get; set; }
        public TipID TipID { get; set; }

        public static C2S_OnTipEvent CreateBody(PacketReader reader, NetID sender)
        {
            var result = new C2S_OnTipEvent();
            result.SenderNetID = sender;
            result.TipCommand = reader.ReadTipCommand();
            result.TipID = reader.ReadTipID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteTipCommand(TipCommand);
            writer.WriteTipID(TipID);
        }
    }
}
