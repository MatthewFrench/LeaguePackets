using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Extensions;

namespace LeaguePackets
{
    public abstract class BasePacket
    {
        public byte[] ExtraBytes { get; set; } = new byte[0];
        public virtual void WriteBody(PacketWriter writer) {}
        public virtual void WriteHeader(PacketWriter writer) {}
        public void Write(PacketWriter writer)
        {
            WriteHeader(writer);
            WriteBody(writer);
            writer.WriteBytes(ExtraBytes);
        }
    }
}
