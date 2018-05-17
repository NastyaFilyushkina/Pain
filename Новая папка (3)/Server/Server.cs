using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Game.model;

namespace Server
{
    class Server
    {
        TcpListener listener;
        int port;
        public static Dictionary<string,TcpClient> FirstList;
        TcpClient client;
        public static List<Player> gameclients = new List<Player>();
        public Server(int port)
        {
            this.port = port;
        }
        public void Listen()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                // Console.WriteLine("Ожидание ...");

                while (true)
                {
                    client = listener.AcceptTcpClient();
                    FirstList = new Dictionary<string,TcpClient>();
                  
                    ClientObject clientObject = new ClientObject(client);
                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Proccess));
                    Console.WriteLine("Клиент подключен");
                    clientThread.Start();
                    
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
        public void Stop()
        {

        }
       
          static  public bool Check(string Name)
        {
            foreach(Player client in gameclients)
            {
                if (Name == client.Name) { return false; }
            }
            return true;
        }
        
    }
}
