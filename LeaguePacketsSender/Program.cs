using System;
using ENet;

namespace LeaguePacketsSender
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var host = new ENet.Host();
            host.Create(new Address(Address.IPv4HostAny, 5119), 32, 8, 0, 0);
            while(true)
            {
                while (host.Service(0, out Event eevent) != 0)
                {
                    switch (eevent.Type)
                    {
                        case EventType.None:
                            Console.WriteLine("Event: none!");
                            break;
                        case EventType.Connect:
                            Console.WriteLine("Event: connect!");
                            break;
                        case EventType.Disconnect:
                            Console.WriteLine("Event: disconnect!");
                            break;
                        case EventType.Receive:
                            Console.WriteLine("Event: recieve!");
                            break;
                    }
                }   
            }
        }
    }
}
