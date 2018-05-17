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

namespace SERVER
{
    class ClienObjectManager
    {
        TcpClient client;
        public ClienObjectManager(TcpClient client)
        {
            this.client = client;
        }
        public void Proccess()
        {
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
                    ReciveMessages(message);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ServerMain.gameclients.Remove(clientinf);
               // ServerMain.FirstList.Remove(room.Player1.Name);
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
        public void SendToAllPlayersInTheGame(string mes)
        {
            NetworkStream networkStream = client.GetStream();
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                if (a.Key != clientinf.Name)
                {
                    networkStream = a.Value.GetStream();
                    Byte[] sendBytes = Encoding.Unicode.GetBytes(strpacket);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                }
            }
          
        }
        public void SendToAllPlayersInTheRoom(string mes, Player Enemy)
        {
            NetworkStream networkStream = client.GetStream();
            NetworkStream networkStream1 = null;
            foreach (KeyValuePair<string, TcpClient> a in ServerMain.FirstList)
            {
                if (a.Key == Enemy.Name)
                {
                    networkStream = a.Value.GetStream();
                }
            }
            Byte[] sendBytes = Encoding.Unicode.GetBytes(strpacket);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            networkStream1.Write(sendBytes, 0, sendBytes.Length);
            //Console.WriteLine(" >> " + strpacket);
            //client.Close();
        }
        public void Send(string mes)
        {
            NetworkStream networkStream = client.GetStream();
            Byte[] sendBytes = Encoding.Unicode.GetBytes(strpacket);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            //Console.WriteLine(" >> " + strpacket);
             //client.Close();
        }
        string strpacket;
        Player clientinf = null;

        public List<string> makelist()
        {
            List<string> list = new List<string>();
            foreach (Player a in ServerMain.gameclients)
            { list.Add(a.Name); }
            return list;
        }
        public void ReciveMessages(string message)
        {

            switch (JsonConvert.DeserializeObject<RegPacket>(message).Command)
            {
                case PacketsToServer.RegPacket:
                    RegPacket reg = JsonConvert.DeserializeObject<RegPacket>(message);
                    bool flag = ServerMain.Check(reg.Name);
                    ResultRegPacket result = new ResultRegPacket();
                    if (flag)
                    {
                        result.Command = PacketsToServer.ResultRegPacket;
                        result.StatusOfRegistr = Status.success;
                        clientinf = new Player(reg.Name);
                        ServerMain.gameclients.Add(clientinf);
                        ServerMain.FirstList.Add(reg.Name, client);
                        Console.WriteLine("Имя клиента "+reg.Name );
                        ListOfAllClients list = new ListOfAllClients();
                        list.Command = PacketsToServer.ListOfAllClients;
                        list.ListAllClients = makelist();
                        strpacket = JsonConvert.SerializeObject(list);
                        SendToAllPlayersInTheGame(strpacket);
                    }
                    else
                    {
                        result.Command = PacketsToServer.ResultRegPacket;
                        result.StatusOfRegistr = Status.fail;
                        Console.WriteLine("Клиент с таким именем уже существует");
                    }
                    strpacket = JsonConvert.SerializeObject(result);
                    Send(strpacket);
                    break;
                case PacketsToServer.AskGamePacket:

                    AskGamePacket stwp = JsonConvert.DeserializeObject<AskGamePacket>(message);
                    StartWindowPacket stgapc = new StartWindowPacket();//отправляю список клиента при входе в игру
                    stgapc.Command = PacketsToServer.StartWindowPacket;
                    stgapc.ListAllClients = makelist();
                    strpacket = JsonConvert.SerializeObject(stgapc);
                    Send(strpacket);

                    break;

                case PacketsToServer.WaitGamePacket:
                    WaitGamePacket waitfg = JsonConvert.DeserializeObject<WaitGamePacket>(message);
                    this.clientinf.Status = StatusGamer.lookforgame;
                    List<Player> listWaitingplayers = MakeReadyForGameListOfPlayers();
                    ListOfWaitingClients waitcl = new ListOfWaitingClients();
                    waitcl.Command = PacketsToServer.ListOfWaitingClients;
                    waitcl.ListWaitingClients = makelist();
                    strpacket = JsonConvert.SerializeObject(waitcl);
                    Send(strpacket);
                    break;
                case PacketsToServer.ChooseEnemyPacket:
                    ChooseEnemyPacket ch = JsonConvert.DeserializeObject<ChooseEnemyPacket>(message);
                    this.clientinf.Status = StatusGamer.lookforgame;

                    foreach (Player client in ServerMain.gameclients)
                    {
                        if (client.Name == ch.EnemyLogin && client.Status == StatusGamer.lookforgame
                            && CheckMe(clientinf) == StatusGamer.lookforgame)
                        {
                            ResultChooseEnemyPacketSuccess resultchen = new ResultChooseEnemyPacketSuccess();
                            resultchen.Command = PacketsToServer.ResultChooseEnemyPacketSuccess;
                            resultchen.StatusOfChoseEnemy = Status.success;
                            resultchen.enemylogin = ch.EnemyLogin;
                            var obj = JsonConvert.DeserializeObject < List < Card>>(File.ReadAllText("1.json"));
                            resultchen.listAllCards = obj;
                            strpacket = JsonConvert.SerializeObject(resultchen);
                            Send(strpacket);

                            return;
                        }
                        else
                        {
                            ResultChooseEnemyPacketFailed pack2 = new ResultChooseEnemyPacketFailed();
                            pack2.Command = PacketsToServer.ResultChooseEnemyPacketFailed;
                            pack2.StatusOfChoseEnemy = Status.fail;
                            strpacket = JsonConvert.SerializeObject(pack2);
                            Send(strpacket);
                            return;
                        }
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
                    strpacket = JsonConvert.SerializeObject(packetcheck);
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
                        strpacket = JsonConvert.SerializeObject(send);
                        SendToAllPlayersInTheRoom(strpacket, room.Player2);
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

        public List<Player> MakeReadyForGameListOfPlayers()
        {
            List<Player> list = new List<Player>();
            foreach (Player player in ServerMain.gameclients)
            {
                if (player.Status == StatusGamer.lookforgame)
                {
                    list.Add(player);
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
            var obj = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText("Heroes.json"));
            send.ListCard = obj;
            send.WhoIsFirst = controller.First(Player1, Player2);
            strpacket = JsonConvert.SerializeObject(send);
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
            strpacket = JsonConvert.SerializeObject(send);
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

