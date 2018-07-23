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
    public class UpdateGoldRedirectTarget : GamePacket // 0x7
    {
        public override GamePacketID ID => GamePacketID.UpdateGoldRedirectTarget;
        public NetID TargetNetID { get; set; }

        public static UpdateGoldRedirectTarget CreateBody(PacketReader reader, NetID sender)
        {
            var result = new UpdateGoldRedirectTarget();
            result.SenderNetID = sender;
            result.TargetNetID = reader.ReadNetID();

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
        }
    }
}
