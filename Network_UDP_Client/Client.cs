using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network_UDP_Client
{
    internal class Client
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int port = 11000;

            using UdpClient udpClient = new UdpClient(port);

            try
            {
                while (true)
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();

                    string timeMessage = Encoding.UTF8.GetString(result.Buffer);

                    Console.Clear();
                    Console.WriteLine($"ГОДИННИК: {timeMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
