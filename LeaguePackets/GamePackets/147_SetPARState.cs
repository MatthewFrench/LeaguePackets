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
    public class SetPARState : GamePacket // 0x93
    {
        public override GamePacketID ID => GamePacketID.SetPARState;
        public NetID UnitNetID { get; set; }
        public PARState PARState { get; set; }
        public static SetPARState CreateBody(PacketReader reader, NetID sender)
        {
            var result = new SetPARState();
            result.SenderNetID = sender;
            result.UnitNetID = reader.ReadNetID();
            result.PARState = reader.ReadPARState();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(UnitNetID);
            writer.WritePARState(PARState);
        }
    }
}
