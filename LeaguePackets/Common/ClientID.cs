using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Common
{
    public struct ClientID
    {
        public uint ID { get; private set; }
        public static explicit operator ClientID(uint id) => new ClientID { ID = id };
        public static explicit operator uint(ClientID id) => id.ID;
        public static bool operator ==(ClientID a, ClientID b) => a.ID == b.ID;
        public static bool operator !=(ClientID a, ClientID b) => !(a == b);
        public override bool Equals(Object obj) => (obj is ClientID b) && this == b;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
