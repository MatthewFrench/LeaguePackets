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
    public class Basic_Attack : GamePacket // 0xC
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack;
        public CommonBasicAttack Attack { get; set; } = new CommonBasicAttack();
        public static Basic_Attack CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Basic_Attack();
            result.SenderNetID = sender;
            result.Attack = reader.ReadCommonBasicAttack();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteCommonBasicAttack(Attack);
        }
    }
}
