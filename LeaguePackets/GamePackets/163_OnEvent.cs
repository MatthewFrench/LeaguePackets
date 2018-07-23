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
    public class OnEvent : GamePacket // 0xA3
    {
        public override GamePacketID ID => GamePacketID.OnEvent;
        //TODO: change to enum or struct?
        public byte EventNameID { get; set; }
        //FIXME: unknown structure
        public static OnEvent CreateBody(PacketReader reader, NetID sender)
        {
            var result = new OnEvent();
            result.SenderNetID = sender;
            throw new NotImplementedException("OnEvent.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("OnEvent.Write");
        }
    }
}
