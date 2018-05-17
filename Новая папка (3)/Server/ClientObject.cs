using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Game.model;
using ClassLibrary1;
using Game;
using System.IO;

namespace Server
{
    class ClientObject
    {
        TcpClient client;
        public ClientObject(TcpClient client)
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
                        builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
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
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
        public void SendToAllPlayersInTheRoom(string mes,Player Enemy)
        {
            NetworkStream networkStream = client.GetStream();
            NetworkStream networkStream1=null;
            foreach (KeyValuePair<string,TcpClient> a in Server.FirstList)
            {
                if (a.Key == Enemy.Name)
                {
                    networkStream = a.Value.GetStream();
                }
            }
            Byte[] sendBytes = Encoding.ASCII.GetBytes(strpacket);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            networkStream1.Write(sendBytes, 0, sendBytes.Length);
            //Console.WriteLine(" >> " + strpacket);
            client.Close();
        }
        public void Send(string mes)
        {
            NetworkStream networkStream = client.GetStream();
            Byte[] sendBytes = Encoding.ASCII.GetBytes(strpacket);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            //Console.WriteLine(" >> " + strpacket);
          //  client.Close();
        }
        string strpacket;
        Player clientinf= null;


        public void ReciveMessages(string message)
        {

            switch (JsonConvert.DeserializeObject<RegPacket>(message).Command)
             {
                case PacketsToServer.RegPacket:
                    RegPacket reg = JsonConvert.DeserializeObject<RegPacket>(message);
                    bool flag = Server.Check(reg.Name);
                    ResultRegPacket result = new ResultRegPacket();
                    if (flag)
                    {
                        result.Command = PacketsToServer.ResultRegPacket;
                        result.StatusOfRegistr = Status.success;
                        clientinf = new Player(reg.Name);
                        Server.gameclients.Add(clientinf);
                        Server.FirstList.Add(reg.Name, client);
                        
                    }
                    else
                    {
                        result.Command = PacketsToServer.ResultRegPacket;
                        result.StatusOfRegistr = Status.fail;
                    }
                    strpacket = JsonConvert.SerializeObject(result);
                    Send(strpacket);
                    break;
                case PacketsToServer.StartWindowPacket:

                    StartWindowPacket stwp = JsonConvert.DeserializeObject<StartWindowPacket>(message);
                    ListOfAllClients list = new ListOfAllClients();//отправляю список клиента при входе в игру
                    list.Command = PacketsToServer.ListOfAllClients;
                  //  list.ListAllClients = Server.gameclients;
                    strpacket = JsonConvert.SerializeObject(list);
                    Send(strpacket);
                  
                    break;

                case PacketsToServer.WaitGamePacket:
                     WaitGamePacket waitfg = JsonConvert.DeserializeObject<WaitGamePacket>(message);
                     this.clientinf.Status = StatusGamer.lookforgame;
                     List<Player> listWaitingplayers = MakeReadyForGameListOfPlayers();
                    ListOfWaitingClients waitcl = new ListOfWaitingClients();
                    waitcl.Command = PacketsToServer.ListOfWaitingClients;
                   // waitcl.ListWaitingClients = listWaitingplayers;
                    strpacket = JsonConvert.SerializeObject(waitcl);
                    Send(strpacket);
                    break;
                case PacketsToServer.ChooseEnemyPacket:
                    ChooseEnemyPacket ch = JsonConvert.DeserializeObject<ChooseEnemyPacket>(message);
                    this.clientinf.Status = StatusGamer.lookforgame;
                    
                    foreach (Player client in Server.gameclients)
                    {
                        if (client.Name == ch.EnemyLogin&&client.Status==StatusGamer.lookforgame
                            && CheckMe(clientinf) == StatusGamer.lookforgame)
                        {
                            ResultChooseEnemyPacketSuccess resultchen = new ResultChooseEnemyPacketSuccess();
                            resultchen.Command = PacketsToServer.ResultChooseEnemyPacketSuccess;
                            resultchen.StatusOfChoseEnemy = Status.success;
                            resultchen.enemylogin = ch.EnemyLogin;
                            strpacket = JsonConvert.SerializeObject(resultchen);
                            Send(strpacket);

                            return;
                        }
                        else
                        {
                            ResultChooseEnemyPacketFailed pack2 = new ResultChooseEnemyPacketFailed();
                            pack2.Command = PacketsToServer.ResultChooseEnemyPacketFailed;
                            pack2.StatusOfChoseEnemy = Status.fail ;
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
                    room = new Room();
                    room.PlayerEnemy1 = clientinf;
                    room.PlayerEnemy2 = stgapacket.Enemy;
                    StartGame( this.clientinf, stgapacket.Enemy);
                    break;
                case PacketsToServer.StepPacket:
                    StepPacket stpac = JsonConvert.DeserializeObject<StepPacket>(message);
                    GameStep(stpac.EnemyCard,stpac.MyCard,stpac.Enemy);

                    break;
                case PacketsToServer.PacketArenaCardNow:
                    PacketArenaCardNow parcadnow= JsonConvert.DeserializeObject<PacketArenaCardNow>(message);
                    if (parcadnow.MyCard.Price < this.clientinf.Mana)
                    {
                        controller.ToArena(this.clientinf, parcadnow.MyCard);
                        SendDataToUsers send = DataToSendPrepare(room.PlayerEnemy2);
                        strpacket = JsonConvert.SerializeObject(send);
                        SendToAllPlayersInTheRoom(strpacket, room.PlayerEnemy2);
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
        Room room;
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
            foreach (Player player in Server.gameclients)
            {
                if (player.Status == StatusGamer.lookforgame)
                {
                    list.Add(player);
                }
            }return list;
        }
        Controller controller;
        public void StartGame( Player Player1, Player Player2)
        {
            controller = new Controller();
            controller.GameStart(Player1,Player2);
            SendDataToUsersFirstTime send = new SendDataToUsersFirstTime();
            send.Command = PacketsToServer.SendDataToUsers;
            send.Player1 = Player1;
            send.Player2 = Player2;
            var obj = JsonConvert.DeserializeObject < List<Card>>(File.ReadAllText("Heroes.json"));
            send.ListCard = obj;
            send.WhoIsFirst = controller.First(Player1, Player2);
            strpacket = JsonConvert.SerializeObject(send);
            Send(strpacket);
        }
        
        public void GameStep(Card EnemyCard,Card MyCard,Player Enemy)
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
}
