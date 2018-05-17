using Game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SERVER
{
    class ServerMain
    {
        ConnectManager connectManager;
        public static Dictionary<string, TcpClient> FirstList;
        public static List<Player> gameclients = new List<Player>();

        public void ServerMainST()
        {
            connectManager = new ConnectManager(1100);
            Thread connect = new Thread(new ThreadStart(connectManager.Listening));
            
            connect.Start();
           // connect.IsBackground = true;

        }

        static public bool Check(string Name)
        {
            foreach (Player client in gameclients)
            {
                if (Name == client.Name) { return false; }
            }
            return true;
        }
    }
}
