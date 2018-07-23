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
    public class C2S_UndoItemReq : GamePacket // 0x10A
    {
        public override GamePacketID ID => GamePacketID.C2S_UndoItemReq;
        public static C2S_UndoItemReq CreateBody(PacketReader reader, NetID sender) 
        {
            var result = new C2S_UndoItemReq();
            result.SenderNetID = sender;
            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
