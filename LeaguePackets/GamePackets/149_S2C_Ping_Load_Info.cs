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
    public class S2C_Ping_Load_Info : GamePacket // 0x95
    {
        public override GamePacketID ID => GamePacketID.S2C_Ping_Load_Info;
        public ConnectionInfo ConnectionInfo { get; set; }
        public static S2C_Ping_Load_Info CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_Ping_Load_Info();
            result.SenderNetID = sender;
            result.ConnectionInfo = reader.ReadConnectionInfo();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteConnectionInfo(ConnectionInfo);
        }
    }
}
