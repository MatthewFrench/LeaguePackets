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
    public class C2S_UpdateGameOptions : GamePacket // 0x47
    {
        public override GamePacketID ID => GamePacketID.C2S_UpdateGameOptions;
        public bool AutoAttackEnabled { get;set; }
        public static C2S_UpdateGameOptions CreateBody(PacketReader reader, NetID sender)
        {
            var result = new C2S_UpdateGameOptions();
            result.SenderNetID = sender;
            result.AutoAttackEnabled = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(AutoAttackEnabled);
        }
    }
}
