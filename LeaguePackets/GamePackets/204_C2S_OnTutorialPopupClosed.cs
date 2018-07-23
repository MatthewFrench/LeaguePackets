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
    public class C2S_OnTutorialPopupClosed : GamePacket // 0xCC
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTutorialPopupClosed;
        public static C2S_OnTutorialPopupClosed CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new C2S_OnTutorialPopupClosed();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer){}
    }
}
