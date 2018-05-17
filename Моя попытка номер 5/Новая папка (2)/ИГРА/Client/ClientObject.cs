using ClassLibrary1;
using Game.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class ClientObject
    {
       static TcpClient client; const int port = 1100;
        const string address = "127.0.0.1";
        string name;
        public ClientObject(string Name)
        {
            this.name = Name;
        }
        Queue<string> que = new Queue<string>();
        public void ClObjProcess()
        {

            RegPacket pack = new RegPacket();
            pack.Command = PacketsToServer.RegPacket;
            pack.Name = name;
            string mes = JsonConvert.SerializeObject(pack);
            Send(mes);
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[1024]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                     que.Enqueue(message);
                    ReciveMesFromServ(message);
                

                }
        }
            catch (Exception ex)
            {

            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
       static private void Send(string mes)
        {
            client = new TcpClient(address, port);

            NetworkStream networkStream = client.GetStream();
            Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            //Console.WriteLine(" >> " + strpacket);
             // client.Close();
        }
        public event Action ChangeFormToNewForm;
        public event Action<string> SendMessage;
        public event Action ChangeForm;
        public event Action<List<string>> ChangeForm1;
        public void ReciveMesFromServ(string message)
        {

            switch (JsonConvert.DeserializeObject<ResultRegPacket>(message).Command)
            {
                case PacketsToServer.ResultRegPacket:
                    ResultRegPacket result = JsonConvert.DeserializeObject<ResultRegPacket>(message);
                    if (result.StatusOfRegistr == Status.fail)
                    {
                        SendMessage(string.Format("Это имя уже занято!Введите другое имя."));
                    }
                    else
                    {
                        ChangeForm();
                        //SendQAFORstWindow();
                    }
                    break;
                case PacketsToServer.StartWindowPacket:
                    StartWindowPacket resultWindow = JsonConvert.DeserializeObject<StartWindowPacket>(message);
                    
                    ChangeForm1(resultWindow.ListAllClients);
                    break;
                case PacketsToServer.ListOfAllClients:
                    ListOfAllClients list = JsonConvert.DeserializeObject<ListOfAllClients>(message);
                    
                    ChangeForm1(list.ListAllClients);
                    break;
                case PacketsToServer.WaitGamePacket:
                    WaitGamePacket waitgapacket = JsonConvert.DeserializeObject<WaitGamePacket>(message);
                    
                        break;
                case PacketsToServer.ResultChooseEnemyPacketSuccess:
                    ResultChooseEnemyPacketSuccess gamepaketpacket = JsonConvert.DeserializeObject<ResultChooseEnemyPacketSuccess>(message);
                    ChangeFormToNewForm();
                    
                    break;
                case PacketsToServer.ResultChooseEnemyPacketFailed:
                    ChangeFormToNewForm();


                    break;
               
            }
        }
        public void Sending()
        {

        }
        public void SendQAForWait()
        {
            WaitGamePacket wait = new WaitGamePacket();
            wait.Command = PacketsToServer.WaitGamePacket;
            wait.login = name;
            string mes = JsonConvert.SerializeObject(wait);
            Send(mes);
        }
        public void SendQAFORChoseEnemy()
        {
            AskGamePacket askpgamepc = new AskGamePacket();
            askpgamepc.Command = PacketsToServer.AskGamePacket;
            string mes = JsonConvert.SerializeObject(askpgamepc);
            Send(mes);
        }
        public void SendQAFORRandom(string login)
        {
            ChooseEnemyPacket chooseenemy = new ChooseEnemyPacket();
            chooseenemy.Command = PacketsToServer.ChooseEnemyPacket;
            chooseenemy.EnemyLogin = login;
            string mes = JsonConvert.SerializeObject(chooseenemy);
            Send(mes);
        }
    }
    
}