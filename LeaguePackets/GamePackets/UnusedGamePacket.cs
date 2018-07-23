using System;
using System.IO;

namespace LeaguePackets.GamePackets
{
    public abstract class UnusedGamePacket : GamePacket 
    { 
        public override void WriteBody(PacketWriter writer) { }
    }
}
