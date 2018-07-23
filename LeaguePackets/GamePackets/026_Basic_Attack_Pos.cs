using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class Basic_Attack_Pos : GamePacket // 0x1A
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack_Pos;
        public CommonBasicAttack Attack { get; set; }
        public Vector2 Position { get; set; }
        public static Basic_Attack_Pos CreateBody(PacketReader reader, NetID sender)
        {
            var result = new Basic_Attack_Pos();
            result.SenderNetID = sender;
            result.Attack = reader.ReadCommonBasicAttack();
            result.Position = reader.ReadVector2();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteCommonBasicAttack(Attack);
            writer.WriteVector2(Position);
        }
    }
}
