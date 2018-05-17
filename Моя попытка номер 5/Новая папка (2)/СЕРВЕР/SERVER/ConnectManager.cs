using Game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SERVER
{
    class ConnectManager
    {
        TcpListener listener;
        int port;

        TcpClient client;
       
        public ConnectManager(int port)
        {
            this.port = port;
        }
        public void Listening()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("Ожидание ...");

                while (true)
                {
                    client = listener.AcceptTcpClient();
                    ServerMain.FirstList = new Dictionary<string, TcpClient>();
                    Console.WriteLine("Клиент подключен");
                    ClienObjectManager clientObject = new ClienObjectManager(client);
                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Proccess));
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
        
    }
}
