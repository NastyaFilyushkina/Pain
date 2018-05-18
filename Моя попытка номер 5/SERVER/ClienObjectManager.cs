using ClassLibrary1;
using Game;
using Game.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SERVER
{
    class ClienObjectManager
    {
        TcpClient client;
        public ClienObjectManager(TcpClient client)
        {
            this.client = client;
        }
        NetworkStream stream = null;
        public void Proccess()
        {
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
                            ReciveMessages(qupackets.Dequeue());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //Console.WriteLine("Клиент покинул игру");
                //foreach (Player a in ServerMain.gameclients)
                //{
                //    if (a.Name == clientinf.Name)
                //    {
                //        ServerMain.gameclients.Remove(a);
                //        ServerMain.FirstList.Remove(a.Name);
                //    }
                //}
                // ServerMain.FirstList.Remove(room.Player1.Name);
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

        public void SendToEnemy(string mes, string Enemy)
        {
            NetworkStream networkStream = client.GetStream();
            NetworkStream networkStream1 = null;
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                if (a.Key == Enemy)
                {
                    networkStream1 = a.Value.GetStream();
                }
            }
            Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            networkStream1.Write(sendBytes, 0, sendBytes.Length);

        }
        public void SendToAllREADYPlayersInTheGame(string mes)
        {
            NetworkStream networkStream;
            List<string> listred = MakeReadyForGameListOfPlayers();
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                if (listred.Contains(a.Key))
                {
                    networkStream = a.Value.GetStream();
                    Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                }
            }
        }
        public void SendToAllPlayersInTheGameWithOutME(string mes)
        {
            NetworkStream networkStream;
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                if (a.Key != clientinf.Name)
                {
                    networkStream = a.Value.GetStream();
                    Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                }
            }
        }
        public void SendToAllPlayersInTheGame(string mes)
        {
            NetworkStream networkStream;
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                networkStream = a.Value.GetStream();
                Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
                networkStream.Write(sendBytes, 0, sendBytes.Length);

            }

        }
        public void SendToAllPlayersInTheRoom(string mes, string Enemy)
        {
            //  NetworkStream networkStream = client.GetStream();
            NetworkStream networkStream1 = null;
            Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                if (a.Key == Enemy || a.Key == clientinf.Name)
                {
                    networkStream1 = a.Value.GetStream();
                    networkStream1.Write(sendBytes, 0, sendBytes.Length);
                    Console.WriteLine("отправлено " + a.Key);
                }
            }

            // networkStream.Write(sendBytes, 0, sendBytes.Length);
            //Thread.Sleep(100);


        }
        public void Send(string mes)
        {
            NetworkStream networkStream = client.GetStream();
            Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            networkStream.Write(sendBytes, 0, sendBytes.Length);

        }

        string strpacket;
        Player clientinf;

        public List<string> makelist()
        {
            List<string> list = new List<string>();
            foreach (Player a in ServerMain.gameclients)
            { list.Add(a.Name); }
            return list;
        }
        public void ReciveMessages(string message)
        {
            try
            {
                switch (JsonConvert.DeserializeObject<RegPacket>(message).Command)
                {
                    case PacketsToServer.RegPacket:
                        RegPacket reg = JsonConvert.DeserializeObject<RegPacket>(message);
                        bool flag = ServerMain.Check(reg.Name);

                        if (flag)
                        {
                            ResultRegPacket result = new ResultRegPacket();
                            result.Command = PacketsToServer.ResultRegPacket;
                            result.StatusOfRegistr = Status.success;
                            clientinf = new Player(reg.Name);
                            ServerMain.gameclients.Add(clientinf);
                            ServerMain.FirstList.Add(reg.Name, client);
                            result.ListAllClients = makelist();
                            strpacket = JsonConvert.SerializeObject(result) + "$";
                            Console.WriteLine("Имя клиента " + reg.Name);

                        }
                        else
                        {
                            ResultRegPacketFailed result = new ResultRegPacketFailed();
                            result.Command = PacketsToServer.ResultRegPacket;
                            result.StatusOfRegistr = Status.fail;
                            strpacket = JsonConvert.SerializeObject(result) + "$";
                            Console.WriteLine("Клиент с таким именем уже существует");
                        }

                        Send(strpacket);
                        ListOfAllClients list = new ListOfAllClients();
                        list.Command = PacketsToServer.ListOfAllClients;
                        list.ListAllClients = makelist();
                        strpacket = JsonConvert.SerializeObject(list) + "$";
                        SendToAllPlayersInTheGameWithOutME(strpacket);
                        break;
                    case PacketsToServer.AskGamePacket:

                        AskGamePacket stwp = JsonConvert.DeserializeObject<AskGamePacket>(message);
                        StartWindowPacket stgapc = new StartWindowPacket();//отправляю список клиента при входе в игру
                        stgapc.Command = PacketsToServer.StartWindowPacket;
                        stgapc.ListAllClients = makelist();
                        strpacket = JsonConvert.SerializeObject(stgapc) + "$";
                        Send(strpacket);

                        break;

                    case PacketsToServer.WaitGamePacket:
                        WaitGamePacket waitfg = JsonConvert.DeserializeObject<WaitGamePacket>(message);
                        foreach (Player a in ServerMain.gameclients)
                        {
                            if (a.Name == waitfg.login)
                            {
                                a.Status = StatusGamer.lookforgame;
                            }
                        }
                        sendingList();
                        break;
                    case PacketsToServer.StopLookingforGamePacket:
                        StopLookingForGame stop = JsonConvert.DeserializeObject<StopLookingForGame>(message);
                        foreach (Player a in ServerMain.gameclients)
                        {
                            if (a.Name == stop.Name)
                            {
                                a.Status = StatusGamer.sleeping;
                            }
                        }
                        sendingList();
                        break;
                    case PacketsToServer.EXIT:
                        Exit ex = JsonConvert.DeserializeObject<Exit>(message);
                        Console.WriteLine("Клиент покинул игру");
                        foreach (Player a in ServerMain.gameclients)
                        {
                            if (a.Name == ex.login)
                            {
                                ServerMain.gameclients.Remove(a);
                                ServerMain.FirstList.Remove(a.Name);
                            }
                        }
                        ListOfAllClients list1 = new ListOfAllClients();
                        list1.Command = PacketsToServer.ListOfAllClients;
                        list1.ListAllClients = makelist();
                        strpacket = JsonConvert.SerializeObject(list1) + "$";
                        SendToAllPlayersInTheGameWithOutME(strpacket);
                        foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
                        {
                            if (a.Key == ex.login)
                            {
                                a.Value.Close();
                                ServerMain.FirstList.Remove(a.Key);
                                return;
                            }
                        }
                        {

                        }
                        break;
                    case PacketsToServer.ChooseEnemyPacket:
                        ChooseEnemyPacket ch = JsonConvert.DeserializeObject<ChooseEnemyPacket>(message);
                        this.clientinf.Status = StatusGamer.lookforgame;

                        foreach (Player client in ServerMain.gameclients)
                        {
                            if (client.Name == ch.EnemyLogin && client.Status == StatusGamer.lookforgame
                                && CheckMe(clientinf) == StatusGamer.lookforgame)
                            {
                                AskGamePacket packet = new AskGamePacket();
                                packet.Command = PacketsToServer.AskGamePacket;
                                packet.login = ch.MyLogin;
                                strpacket = JsonConvert.SerializeObject(packet) + "$";

                                SendToEnemy(strpacket, ch.EnemyLogin);

                                return;
                            }
                            else if (client.Name != clientinf.Name)
                            {
                                ResultChooseEnemyPacketFailed pack2 = new ResultChooseEnemyPacketFailed();
                                pack2.Command = PacketsToServer.ResultChooseEnemyPacketFailed;
                                pack2.StatusOfChoseEnemy = Status.fail;
                                strpacket = JsonConvert.SerializeObject(pack2) + "$";
                                Send(strpacket);

                            }
                        }
                        break;
                    case PacketsToServer.AnsGamePacket:
                        AnsGamePacket answer = JsonConvert.DeserializeObject<AnsGamePacket>(message);
                        if (answer.state == true)
                        {
                            ResultChooseEnemyPacketSuccess resultchen = new ResultChooseEnemyPacketSuccess();
                            resultchen.Command = PacketsToServer.ResultChooseEnemyPacketSuccess;
                            resultchen.StatusOfChoseEnemy = Status.success;
                            resultchen.enemylogin = answer.login;//логин врага
                            var obj = JsonConvert.DeserializeObject<List<CardHeroes>>(File.ReadAllText("1.json"));
                            resultchen.listAllCards = obj;
                            strpacket = JsonConvert.SerializeObject(resultchen) + "$";
                            SendToAllPlayersInTheRoom(strpacket, answer.login);

                        }
                        else
                        {
                            ResultChooseEnemyPacketFailed pack2 = new ResultChooseEnemyPacketFailed();
                            pack2.Command = PacketsToServer.ResultChooseEnemyPacketFailed;
                            pack2.StatusOfChoseEnemy = Status.fail;
                            strpacket = JsonConvert.SerializeObject(pack2) + "$";
                            Send(strpacket);

                        }

                        break;
                    case PacketsToServer.ChoosenCardListPacket:
                        ChoosenCardListPacket kol = JsonConvert.DeserializeObject<ChoosenCardListPacket>(message);
                        ResultChooseCardList packetcheck = new ResultChooseCardList();
                        packetcheck.Command = PacketsToServer.ResultChooseCardList;
                        if (checkkoloda(kol.Koloda))
                        {
                            packetcheck.ResultOfChooseCard = Status.success;
                        }
                        else
                        {
                            packetcheck.ResultOfChooseCard = Status.fail;
                        }
                        strpacket = JsonConvert.SerializeObject(packetcheck) + "$";
                        Send(strpacket);
                        break;
                    case PacketsToServer.StartGamePacket:
                        StartGamePacket stgapacket = JsonConvert.DeserializeObject<StartGamePacket>(message);
                        stgapacket.Me.Status = StatusGamer.playing;
                        stgapacket.Enemy.Status = StatusGamer.playing;
                        room = new Rooms();
                        room.Player1 = clientinf;
                        room.Player2 = stgapacket.Enemy;
                        StartGame(this.clientinf, stgapacket.Enemy);
                        break;
                    case PacketsToServer.StepPacket:
                        StepPacket stpac = JsonConvert.DeserializeObject<StepPacket>(message);
                        GameStep(stpac.EnemyCard, stpac.MyCard, stpac.Enemy);

                        break;
                    case PacketsToServer.PacketArenaCardNow:
                        PacketArenaCardNow parcadnow = JsonConvert.DeserializeObject<PacketArenaCardNow>(message);
                        if (parcadnow.MyCard.Price < this.clientinf.Mana)
                        {
                            controller.ToArena(this.clientinf, parcadnow.MyCard);
                            SendDataToUsers send = DataToSendPrepare(room.Player2);
                            strpacket = JsonConvert.SerializeObject(send) + "$";
                            SendToAllPlayersInTheRoom(strpacket, room.Player2.Name);
                        }
                        else
                        {
                            Error error = new Error();
                            error.Command = PacketsToServer.Error;
                            error.ErrorToUser = "Not enouth mana to bring this card";
                        }
                        break;

                }
            }
            catch
            {
                Console.WriteLine("Ошибочный пакет");

            }


        }
        Rooms room;
        bool checkkoloda(List<Card> koloda)
        {
            if (koloda.Count == 14)
            {
                return true;
            }
            else return false;
        }

        public StatusGamer CheckMe(Player client)
        {
            if (client.Status == StatusGamer.lookforgame) return StatusGamer.lookforgame;
            else if (client.Status == StatusGamer.playing) return StatusGamer.playing;
            else return StatusGamer.sleeping;
        }
        void sendingList()
        {
            List<string> listWaitingplayers = MakeReadyForGameListOfPlayers();
            ListOfWaitingClients waitcl = new ListOfWaitingClients();
            waitcl.Command = PacketsToServer.ListOfWaitingClients;
            waitcl.ListWaitingClients = listWaitingplayers;
            strpacket = JsonConvert.SerializeObject(waitcl) + "$";
            SendToAllREADYPlayersInTheGame(strpacket);

        }
        public List<string> MakeReadyForGameListOfPlayers()
        {
            List<string> list = new List<string>();
            foreach (Player player in ServerMain.gameclients)
            {
                if (player.Status == StatusGamer.lookforgame)
                {
                    list.Add(player.Name);
                }
            }
            return list;
        }
        Controller controller;
        public void StartGame(Player Player1, Player Player2)
        {
            controller = new Controller();
            controller.GameStart(Player1, Player2);
            SendDataToUsersFirstTime send = new SendDataToUsersFirstTime();
            send.Command = PacketsToServer.SendDataToUsers;
            send.Player1 = Player1;
            send.Player2 = Player2;
            var obj = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText("1.json"));
            send.ListCard = obj;
            send.WhoIsFirst = controller.First(Player1, Player2);
            strpacket = JsonConvert.SerializeObject(send) + "$";
            Send(strpacket);
        }

        public void GameStep(Card EnemyCard, Card MyCard, Player Enemy)
        {
            if (EnemyCard == null)
            {
                controller.AttackLico(this.clientinf, Enemy, (CardHeroes)MyCard);
                if (Enemy.Health <= 0)
                {
                    //пакет вин
                }

            }
            else
            {
                controller.AttackCard(this.clientinf, Enemy, (CardHeroes)MyCard, (CardHeroes)EnemyCard);
            }
            SendDataToUsers send = new SendDataToUsers();
            send = DataToSendPrepare(Enemy);
            strpacket = JsonConvert.SerializeObject(send) + "$";
            Send(strpacket);
        }
        public SendDataToUsers DataToSendPrepare(Player Enemy)
        {
            SendDataToUsers send = new SendDataToUsers();
            send.Command = PacketsToServer.SendDataToUsers;
            send.Player1 = this.clientinf;
            send.Player2 = Enemy;
            send.WhoIsFirst = Enemy;
            return send;
        }
    }

    internal class Room
    {
        public Room()
        {
        }
    }
}

