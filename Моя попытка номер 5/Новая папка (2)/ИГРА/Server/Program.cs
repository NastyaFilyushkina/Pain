using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(1100);
            Thread serv = new Thread(new ThreadStart(server.Listen));
            serv.Start();
        }
    }
}
