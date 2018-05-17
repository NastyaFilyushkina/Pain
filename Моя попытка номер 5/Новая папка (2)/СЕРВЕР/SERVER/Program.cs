using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SERVER
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerMain server = new ServerMain();
            Thread thread = new Thread(new ThreadStart(server.ServerMainST));
            thread.Start();
        }
    }
}
