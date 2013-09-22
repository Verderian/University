using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace ICMP_request
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter IP:");
                string hostname = Console.ReadLine();
                Console.WriteLine("Enter String");
                string input = Console.ReadLine();

                Ping pingSender = new Ping();
                byte[] buffer = Encoding.ASCII.GetBytes(input);
                PingReply reply = pingSender.Send(Dns.Resolve(hostname).AddressList[0], 10000, buffer);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Address: " + reply.Address.ToString());
                    Console.WriteLine("Time to live: " + reply.Options.Ttl);
                }
                else
                {
                    Console.WriteLine(reply.Status);
                }
                Console.WriteLine("\n");
            }
        }
    }
}