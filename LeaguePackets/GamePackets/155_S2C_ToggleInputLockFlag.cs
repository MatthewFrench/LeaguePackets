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
    public class S2C_ToggleInputLockFlag : GamePacket // 0x9B
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleInputLockFlag;
        public InputLockFlags InputLockingFlags { get; set; }
        public static S2C_ToggleInputLockFlag CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ToggleInputLockFlag();
            result.SenderNetID = sender;
            result.InputLockingFlags = reader.ReadInputLockFlags();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInputLockFlags(InputLockingFlags);
        }
    }
}
