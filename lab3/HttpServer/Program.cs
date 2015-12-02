using System;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var localhost = "http://127.0.0.1";
            var port = Console.ReadLine();
            var server = new Server(localhost, port);
            server.Start();
        }
    }
}
