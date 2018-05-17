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
    public class ClientObject
    {
        static TcpClient client; const int port = 1100;
        const string address = "127.0.0.1";
        string name;
        public string Name { get; }
        public ClientObject(string Name)
        {
            try
            {
                this.name = Name;

                client = new TcpClient(address, port);
            }
            catch
            {
                SendMessage("Сервер отключен");
            }
        }
        // Queue<string> que = new Queue<string>();
        public void ClObjProcess()
        {

            RegPacket pack = new RegPacket();
            pack.Command = PacketsToServer.RegPacket;
            pack.Name = name;
            string mes = JsonConvert.SerializeObject(pack);
            Send(mes);
            NetworkStream stream = null;
            // try
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
                    Queue<string> qupackets = new Queue<string>();
                    if (message != "")
                    {
                        string[] cases = message.Split('$');
                        for (int i = 0; i < cases.Length; i++)
                        {
                            if (cases[i] != "")
                                qupackets.Enqueue(cases[i]);
                        }
                        while (qupackets.Count != 0)
                        {
                            ReciveMesFromServ(qupackets.Dequeue());
                        }
                    }


                }
            }
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    if (stream != null)
            //        stream.Close();
            //    if (client != null)
            //        client.Close();
            //}
        }
        static private void Send(string mes)
        {

            Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            client.GetStream().Write(sendBytes, 0, sendBytes.Length);
            //Console.WriteLine(" >> " + strpacket);
            // networkStream.Close();
            //  client.GetStream().Flush();
            //NetworkStream networkStream = client.GetStream();
            //Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            //networkStream.Write(sendBytes, 0, sendBytes.Length);
            ////Console.WriteLine(" >> " + strpacket);
            //// client.Close();  
            //networkStream.Close();
        }
        public event Action ChangeFormToNewForm;
        public event Action<string> SendMessage;
        public event Action ChangeForm;
        public event Action<List<string>> ChangeForm1;
        public event Action<List<string>> ChangeForm2;
        public event Action<string> MessForME;
        public event Action<List<CardHeroes>> MakeCards;
        public void ReciveMesFromServ(string message)
        {

            switch (JsonConvert.DeserializeObject<ResultRegPacket>(message).Command)
            {
                case PacketsToServer.ResultRegPacket:
                    ResultRegPacket result = JsonConvert.DeserializeObject<ResultRegPacket>(message);
                    ChangeForm();
                    ChangeForm1(result.ListAllClients);
                    //SendQAFORstWindow();
                    break;
                case PacketsToServer.ResultRegPacketFailed:
                    ResultRegPacket resultf = JsonConvert.DeserializeObject<ResultRegPacket>(message);
                    SendMessage(string.Format("Это имя уже занято!Введите другое имя."));

                    break;
                case PacketsToServer.StartWindowPacket:
                    StartWindowPacket resultWindow = JsonConvert.DeserializeObject<StartWindowPacket>(message);
                    ChangeForm1(resultWindow.ListAllClients);
                    break;
                case PacketsToServer.ListOfAllClients:
                    ListOfAllClients list = JsonConvert.DeserializeObject<ListOfAllClients>(message);
                    ChangeForm1(list.ListAllClients);
                    break;
                case PacketsToServer.ListOfWaitingClients:
                    ListOfWaitingClients waitgapacket = JsonConvert.DeserializeObject<ListOfWaitingClients>(message);
                    ChangeForm2(waitgapacket.ListWaitingClients);
                    break;
                case PacketsToServer.AskGamePacket:
                    AskGamePacket gameasktpacket = JsonConvert.DeserializeObject<AskGamePacket>(message);
                    MessForME(gameasktpacket.login);

                    break;
                case PacketsToServer.ResultChooseEnemyPacketSuccess:
                    ResultChooseEnemyPacketSuccess gamepaket = JsonConvert.DeserializeObject<ResultChooseEnemyPacketSuccess>(message);
                    ChangeFormToNewForm();
                    MakeCards(gamepaket.listAllCards);
                    break;
                case PacketsToServer.ResultChooseEnemyPacketFailed:
                    // ChangeFormToNewForm();
                    SendMessage("Противник отклонил игру");

                    break;

            }
        }
        public void SendIFCLose()
        {

        }
        public void SendQAForWait()
        {
            WaitGamePacket wait = new WaitGamePacket();
            wait.Command = PacketsToServer.WaitGamePacket;
            wait.login = name;
            string mes = JsonConvert.SerializeObject(wait) + "$";
            Send(mes);
        }
        public void SendQAForSTOPWait()
        {
            StopLookingForGame wait = new StopLookingForGame();
            wait.Command = PacketsToServer.WaitGamePacket;
            wait.Name = name;
            string mes = JsonConvert.SerializeObject(wait) + "$";
            Send(mes);
        }
        public void SendQAFORChooseEnemy(string login)
        {
            ChooseEnemyPacket chooseenemy = new ChooseEnemyPacket();
            chooseenemy.Command = PacketsToServer.ChooseEnemyPacket;
            chooseenemy.EnemyLogin = login;
            chooseenemy.MyLogin = name;
            string mes = JsonConvert.SerializeObject(chooseenemy) + "$";
            Send(mes);
        }
        public void SendAnswerToAskGame(string names, bool flag)
        {
            AnsGamePacket ans = new AnsGamePacket();
            ans.Command = PacketsToServer.AnsGamePacket;
            ans.login = names;
            if (flag)
            {
                ans.state = true;
            }
            else
            {
                ans.state = false;
            }
            string mes = JsonConvert.SerializeObject(ans) + "$";
            Send(mes);
        }
        public void SendQAFORRandom()
        {
            RandomEnemyPacket chooseenemy = new RandomEnemyPacket();
            chooseenemy.Command = PacketsToServer.ChooseEnemyPacket;
            chooseenemy.Login = name;
            string mes = JsonConvert.SerializeObject(chooseenemy) + "$";
            Send(mes);
        }
        public void SendQAIFEXIT(string login)
        {
            Exit exit = new Exit();
            exit.Command = PacketsToServer.EXIT;
            exit.login = login;
            string mes = JsonConvert.SerializeObject(exit) + "$";
            Send(mes);
        }
    }


}