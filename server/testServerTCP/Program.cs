using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace testServerTCP
{
    class Program
    {

        static async void StartServer()
        {
            ServerObject server = new ServerObject("192.168.0.113", 11555);// создаем сервер
            await server.ListenAsync(); // запускаем сервер
        }
        static void Main(string[] args)
        {
            StartServer();
            Console.ReadKey();
        }
    }
}
