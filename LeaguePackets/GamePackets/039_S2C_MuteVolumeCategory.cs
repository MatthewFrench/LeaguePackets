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
    public class S2C_MuteVolumeCategory : GamePacket // 0x27
    {
        public override GamePacketID ID => GamePacketID.S2C_MuteVolumeCategory;
        public VolumeCategoryType VolumeCategory { get; set; }
        public bool Mute { get; set; }

        public static S2C_MuteVolumeCategory CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_MuteVolumeCategory();
            result.SenderNetID = sender;
            result.VolumeCategory = reader.ReadVolumeCategoryType();
            byte bitfield = reader.ReadByte();
            result.Mute = (bitfield & 0x01u) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVolumeCategoryType(VolumeCategory);
            byte bitfield = 0;
            if (Mute)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
