using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network_UDP
{
    internal class Server
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int port = 11000;

            using UdpClient udpServer = new UdpClient();

            udpServer.EnableBroadcast = true;

            IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), port);

            while (true)
            {
                string timeMessage = DateTime.Now.ToString("HH:mm:ss");
                byte[] data = Encoding.UTF8.GetBytes(timeMessage);

                await udpServer.SendAsync(data, data.Length, EndPoint);
                await Task.Delay(1000);
            }
        }
    }
}
