﻿using LeaguePackets.Common;
using LeaguePackets.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AttachFlexParticleS2C : GamePacket // 0xD2
    {
        public override GamePacketID ID => GamePacketID.AttachFlexParticleS2C;
        public NetID NetID { get; set; }
        public ParticleFlexID FlexID { get; set; }
        public byte CpIndex { get; set; }
        public ParticleAttachType ParticleAttachType { get; set; }
        public static AttachFlexParticleS2C CreateBody(PacketReader reader, NetID sender)
        {
            var result = new AttachFlexParticleS2C();
            result.SenderNetID = sender;
            result.NetID = reader.ReadNetID();
            result.FlexID = reader.ReadFlexID();
            result.CpIndex = reader.ReadByte();
            result.ParticleAttachType = reader.ReadParticleAttachType();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteFlexID(FlexID);
            writer.WriteByte(CpIndex);
            writer.WriteParticleAttachType(ParticleAttachType);
        }
    }
}
