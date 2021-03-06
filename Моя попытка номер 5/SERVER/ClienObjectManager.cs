﻿using ClassLibrary1;
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
        static readonly object _locker = new object();
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
        public Player WhoIsHe(string name)
        {
            foreach (Player a in ServerMain.gameclients)
            {
                if (a.Name == name)
                {
                    return a;
                }
            }
            return null;
        }
        public void ReciveMessages(string message)
        {
            // try
            // {
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
                        Thread.Sleep(50);
                        lock (ServerMain.FirstList)
                        {
                            ServerMain.FirstList.Add(reg.Name, this.client);
                        }
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
                    foreach (Player b in ServerMain.gameclients)
                    {
                        if (b.Name == waitfg.login)
                        {
                            b.Status = StatusGamer.lookforgame;
                        }
                    }
                    sendingList();
                    break;
                case PacketsToServer.StopLookingforGamePacket:
                    StopLookingForGame stop = JsonConvert.DeserializeObject<StopLookingForGame>(message);
                    foreach (Player b in ServerMain.gameclients)
                    {
                        if (b.Name == stop.Name)
                        {
                            b.Status = StatusGamer.sleeping;
                        }
                    }
                    sendingList();
                    break;
                case PacketsToServer.EXIT:
                    Exit ex = JsonConvert.DeserializeObject<Exit>(message);
                    Console.WriteLine("Клиент покинул игру");
                    foreach (Player b in ServerMain.gameclients)
                    {
                        if (b.Name == ex.login)
                        {
                            ServerMain.gameclients.Remove(b);
                            //  ServerMain.FirstList.Remove(b.Name);
                        }
                    }
                    ListOfAllClients list1 = new ListOfAllClients();
                    list1.Command = PacketsToServer.ListOfAllClients;
                    list1.ListAllClients = makelist();
                    strpacket = JsonConvert.SerializeObject(list1) + "$";
                    SendToAllPlayersInTheGameWithOutME(strpacket);
                    foreach (KeyValuePair<string, TcpClient> b in ServerMain.FirstList)
                    {
                        if (b.Key == ex.login)
                        {
                            b.Value.Close();
                            ServerMain.FirstList.Remove(b.Key);
                            return;
                        }
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
                        resultchen.enemylogin = answer.Enemylogin;//логин врага
                        resultchen.MyLogin = answer.Mylogin;//логин врага
                        var obj = JsonConvert.DeserializeObject<List<CardHeroes>>(File.ReadAllText("1.json"));
                        resultchen.listAllCards = obj;
                        strpacket = JsonConvert.SerializeObject(resultchen) + "$";
                        Send(strpacket);
                        resultchen.enemylogin = answer.Mylogin;
                        resultchen.MyLogin = answer.Enemylogin;
                        strpacket = JsonConvert.SerializeObject(resultchen) + "$";
                        SendToEnemy(strpacket, answer.Enemylogin);
                        Rooms room = new Rooms();
                        room.Player1 = clientinf;
                        room.Player2 = WhoIsHe(answer.Enemylogin);
                        ServerMain.rooms.Add(room);

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
                    lock (_locker)
                    {
                        ChoosenCardListPacket kol = JsonConvert.DeserializeObject<ChoosenCardListPacket>(message);
                        ResultChooseCardList packetcheck = new ResultChooseCardList();
                        ISErrorOfEnemy err = new ISErrorOfEnemy();
                        err.Command = PacketsToServer.ISErrorOfEnemy;
                        packetcheck.Command = PacketsToServer.ResultChooseCardList;
                        if (checkkoloda(kol.Koloda))
                        {
                            err.ISErr = false;
                            packetcheck.ResultOfChooseCard = Status.success;
                            clientinf.Deck = kol.Koloda;
                        }
                        else
                        {
                            err.ISErr = true;
                            packetcheck.ResultOfChooseCard = Status.fail;
                        }
                        strpacket = JsonConvert.SerializeObject(packetcheck) + "$";
                        clientinf.NumRoom = InWhichRoom(clientinf);
                        Send(strpacket);
                        strpacket = JsonConvert.SerializeObject(err) + "$";
                        ////int i=InWhichRoom()
                        ////if(ServerMain.rooms[].Player1.Name!=kol.Me)
                        ////SendToEnemy(strpacket, rooms.Player1.Name);
                        if (ServerMain.rooms[clientinf.NumRoom].Player2.Name != clientinf.Name) SendToEnemy(strpacket, ServerMain.rooms[clientinf.NumRoom].Player2.Name);
                        else { SendToEnemy(strpacket, ServerMain.rooms[clientinf.NumRoom].Player1.Name); }
                    }
                    break;

                case PacketsToServer.StartGamePacket:
                    lock (_locker)
                    {
                        StartGamePacket stgapacket = JsonConvert.DeserializeObject<StartGamePacket>(message);
                        foreach (Player pl in ServerMain.gameclients)
                        {
                            if (stgapacket.Me == pl.Name || stgapacket.Enemy == pl.Name)
                            {
                                pl.Status = StatusGamer.playing;
                            }
                        }
                        sendingList();
                        foreach (Player pl in ServerMain.gameclients)
                        {
                            if (stgapacket.Enemy == pl.Name)
                            {
                                StartGame(pl);
                            }
                        }
                    }
                    break;
                case PacketsToServer.StepPacket:
                    StepPacket stpac = JsonConvert.DeserializeObject<StepPacket>(message);
                    GameStep(stpac.EnemyCard, stpac.MyCard, WhoIsHe(stpac.Enemy));

                    break;
                case PacketsToServer.EndStep:
                    EndStep step = JsonConvert.DeserializeObject<EndStep>(message);
                    SendDataToUsers a;
                    if (ServerMain.rooms[clientinf.NumRoom].Player1 == clientinf)
                    {
                        controller.IsmHoda(clientinf, ServerMain.rooms[clientinf.NumRoom].Player2);
                        a = DataToSendPrepare(ServerMain.rooms[clientinf.NumRoom].Player2);
                        a.AmIFirst = clientinf.IsHod;
                        strpacket = JsonConvert.SerializeObject(a) + "$";
                        Send(strpacket);
                        a = DataToSendPrepareEnemy(ServerMain.rooms[clientinf.NumRoom].Player2);
                        strpacket = JsonConvert.SerializeObject(a) + "$";
                        SendToEnemy(strpacket, ServerMain.rooms[clientinf.NumRoom].Player2.Name);
                    }
                    else
                    {
                        controller.IsmHoda(clientinf, ServerMain.rooms[clientinf.NumRoom].Player1);
                        a = DataToSendPrepare(ServerMain.rooms[clientinf.NumRoom].Player1);
                        a.AmIFirst = clientinf.IsHod;
                        strpacket = JsonConvert.SerializeObject(a) + "$";
                        Send(strpacket);
                        a = DataToSendPrepareEnemy(ServerMain.rooms[clientinf.NumRoom].Player1);
                        strpacket = JsonConvert.SerializeObject(a) + "$";
                        SendToEnemy(strpacket, ServerMain.rooms[clientinf.NumRoom].Player1.Name);
                    }
                    break;
                case PacketsToServer.PacketArenaCardNow:
                    PacketArenaCardNow parcadnow = JsonConvert.DeserializeObject<PacketArenaCardNow>(message);
                    if (parcadnow.MyCard.Price <= this.clientinf.Mana)
                    {

                        controller.ToArena(this.clientinf, parcadnow.MyCard);
                        CardOnABoard card = new CardOnABoard();
                        card.Command = PacketsToServer.CardOnABoard;
                        card.login = clientinf.Name;
                        parcadnow.MyCard.Index = parcadnow.IndeXMyCard;
                        card.card = parcadnow.MyCard;
                        strpacket = JsonConvert.SerializeObject(card) + "$";
                        if (clientinf.Name != ServerMain.rooms[clientinf.NumRoom].Player2.Name)
                            SendToAllPlayersInTheRoom(strpacket, ServerMain.rooms[clientinf.NumRoom].Player2.Name);
                        else SendToAllPlayersInTheRoom(strpacket, ServerMain.rooms[clientinf.NumRoom].Player1.Name);
                    }
                    else
                    {
                        Error error = new Error();
                        error.Command = PacketsToServer.Error;
                        error.ErrorToUser = MessagesToClientErrors.NotEnouthMana;
                    }
                    break;

                case PacketsToServer.EnemyLeftGamePacket:
                    EnemyLeftGamePacket left = JsonConvert.DeserializeObject<EnemyLeftGamePacket>(message);
                    EnemyLeftGamePacket newleft = new EnemyLeftGamePacket();
                    newleft.Command = PacketsToServer.EnemyLeftGamePacket;
                    newleft.login = left.login;
                    strpacket = JsonConvert.SerializeObject(newleft) + "$";
                    if (ServerMain.rooms[clientinf.NumRoom].Player1 == clientinf)
                    {
                        SendToEnemy(strpacket, ServerMain.rooms[clientinf.NumRoom].Player2.Name);
                        foreach (Player player in ServerMain.gameclients)
                        {
                            if (player == clientinf || player == ServerMain.rooms[clientinf.NumRoom].Player2) { player.Status = StatusGamer.sleeping; sendingList(); }
                        }
                    }
                    else
                    {
                        SendToEnemy(strpacket, ServerMain.rooms[clientinf.NumRoom].Player1.Name);
                        foreach (Player player in ServerMain.gameclients)
                        {
                            if (player == clientinf || player == ServerMain.rooms[clientinf.NumRoom].Player2) { player.Status = StatusGamer.sleeping; sendingList(); }
                        }
                    }

                    ServerMain.gameclients.Remove(WhoIsHe(left.login));
                    ServerMain.FirstList.Remove(left.login);
                    ServerMain.rooms.Remove(ServerMain.rooms[clientinf.NumRoom]);

                    break;

            }
        }
        //catch
        //{
        //    Console.WriteLine("Ошибочный пакет");




        int InWhichRoom(Player pl)
        {
            for (int i = 0; i < ServerMain.rooms.Count; i++)
            {
                if (ServerMain.rooms[i].Player1 == pl || ServerMain.rooms[i].Player2 == pl)
                {
                    return i;
                }
            }
            return 0;
        }

        Rooms rooms;
        bool checkkoloda(List<CardHeroes> koloda)
        {
            if (koloda.Count == 15)
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
        public void StartGame(Player Player2)
        {
            controller = new Controller();

            Player FirstPlayer = controller.GameStart(clientinf, Player2);
            lock (_locker)
            {
                try
                {
                    if (ServerMain.rooms[clientinf.NumRoom].playerFirst.Name == null)
                        ServerMain.rooms[clientinf.NumRoom].playerFirst = FirstPlayer;
                    else FirstPlayer = ServerMain.rooms[clientinf.NumRoom].playerFirst;
                }
                catch
                {

                    ServerMain.rooms[clientinf.NumRoom].playerFirst = FirstPlayer;
                }
            }
            SendDataToUsersFirstTime send = new SendDataToUsersFirstTime();
            send.Command = PacketsToServer.SendDataToUserFirstTime;
            send.EnemyName = Player2.Name;
            send.EnemyHealth = Player2.Health;
            send.MyHealth = clientinf.Health;
            send.MyMana = clientinf.Mana;

            send.StartKoloda = clientinf.Deck;
            send.ListCardInAHandFirst = clientinf.CardHand;
            bool whosfirst;

            if (ServerMain.rooms[clientinf.NumRoom].playerFirst.Name == clientinf.Name)
            {
                whosfirst = true;
            }
            else whosfirst = false;
            send.AmIFirst = whosfirst;
            strpacket = JsonConvert.SerializeObject(send) + "$";
            Send(strpacket);
        }

        public void GameStep(CardHeroes EnemyCard, CardHeroes MyCard, Player Enemy)
        {
            if (EnemyCard.Name == Enemy.Name)
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
            send.AmIFirst = clientinf.IsHod;
            send.EnemyHealth = Enemy.Health;
            send.MyHealth = clientinf.Health;
            send.MyMana = clientinf.Mana;
            send.Arena1 = clientinf.CardArena1;
            send.Arena2 = clientinf.CardArena2;
            send.EnemyArena1 = Enemy.CardArena1;
            send.EnemyArena2 = Enemy.CardArena2;
            return send;
        }
        public SendDataToUsers DataToSendPrepareEnemy(Player Enemy)
        {
            SendDataToUsers send = new SendDataToUsers();
            send.Command = PacketsToServer.SendDataToUsers;
            send.AmIFirst = Enemy.IsHod;
            send.EnemyHealth = clientinf.Health;
            send.MyHealth = Enemy.Health;
            send.MyMana = Enemy.Mana;
            send.Arena1 = Enemy.CardArena1;
            send.Arena2 = Enemy.CardArena2;
            send.EnemyArena1 = clientinf.CardArena1;
            send.EnemyArena2 = clientinf.CardArena2;
            return send;
        }
    }
}

