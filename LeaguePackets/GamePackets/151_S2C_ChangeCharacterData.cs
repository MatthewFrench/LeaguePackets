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
    public class S2C_ChangeCharacterData : GamePacket // 0x97
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeCharacterData;
        //should be current SkinID which should be changed
        public uint IDToChange { get; set; }
        public bool UseSpells { get; set; }
        public bool ModelOnly { get; set; }
        public bool ReplaceCharacterPackage { get; set; }

        public uint SkinID { get; set; }
        public string SkinName { get; set; }
        public static S2C_ChangeCharacterData CreateBody(PacketReader reader, NetID sender)
        {
            var result = new S2C_ChangeCharacterData();
            result.SenderNetID = sender;
            result.IDToChange = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            result.UseSpells = (bitfield & 1) != 0;
            result.ModelOnly = (bitfield & 2) != 0;
            result.ReplaceCharacterPackage = (bitfield & 4) != 0;

            result.SkinID = reader.ReadUInt32();
            result.SkinName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(IDToChange);
            byte bitfield = 0;
            if(UseSpells)
            {
                bitfield |= 1;
            }
            if(ModelOnly)
            {
                bitfield |= 2;
            }
            if(ReplaceCharacterPackage)
            {
                bitfield |= 4;
            }
            writer.WriteByte(bitfield);

            writer.WriteUInt32(SkinID);
            writer.WriteFixedString(SkinName, 64);
        }
    }
}
