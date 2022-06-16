using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using ChatCore;

namespace ChatServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var server = new ChatCore.ChatServer();
            server.Bind(4099);
            server.Start();
        }

    }
}