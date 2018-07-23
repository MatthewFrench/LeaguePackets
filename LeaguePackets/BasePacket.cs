using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Extensions;
using LeaguePackets.PayloadPackets;

namespace LeaguePackets
{
    public abstract class BasePacket
    {
        public byte[] ExtraBytes { get; set; } = new byte[0];
        public virtual void WriteBody(PacketWriter writer) { }
        public virtual void WriteHeader(PacketWriter writer) { }
        public void Write(PacketWriter writer)
        {
            WriteHeader(writer);
            WriteBody(writer);
            writer.WriteBytes(ExtraBytes);
        }

        public BasePacket Create(PacketReader reader, ChannelID channel)
        {
            switch (channel)
            {
                case ChannelID.Default:
                    return KeyCheckPacket.Create(reader);
                case ChannelID.ClientToServer:
                case ChannelID.SynchClock:
                case ChannelID.Broadcast:
                case ChannelID.BroadcastUnreliable:
                    return GamePacket.Create(reader);
                case ChannelID.Chat:
                    reader.ReadPad(0);
                    return Chat.CreateBody(reader);
                case ChannelID.QuickChat:
                    reader.ReadPad(0);
                    return QuickChat.CreateBody(reader);
                case ChannelID.LoadingScreen:
                    return PayloadPacket.Create(reader);
                default:
                    return null;
            }
        }
    }
}
