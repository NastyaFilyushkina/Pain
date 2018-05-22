using ClassLibrary1;
using Game.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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

        public void ClObjProcess()
        {


            NetworkStream stream = null;
            //try
            //{
            stream = client.GetStream();
            byte[] data = new byte[1024]; // буфер для получаемых данных
            RegPacket pack = new RegPacket();
            pack.Command = PacketsToServer.RegPacket;
            pack.Name = name;
            string mes = JsonConvert.SerializeObject(pack) + "$";
            Thread.Sleep(5);
            Send(mes);
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
    
        static private void Send(string mes)
        {

            Byte[] sendBytes = Encoding.Unicode.GetBytes(mes);
            client.GetStream().Write(sendBytes, 0, sendBytes.Length);
          
        }
        public event Action ChangeFormToNewForm;
        public event Action<string> SendMessage;
        public event Action ChangeForm;
        public event Action<List<string>> ChangeForm1;
        public event Action<List<string>> ChangeForm2;
        public event Action<string> MessForME;
        public event Action<string> MessForMEWait;
        public event Action<List<CardHeroes>> MakeCards;
        public event Action ChangeFormCard;
        public event Action ChangeToFormGame;
        public event Action CardClose;
        public event Action<CardHeroes> CardOnABoard;
        public event Action<CardHeroes> CardOnOtherABoard;
        public event Action<string> IfEnemyLeft;
        public event Action <bool ,int ,string ,int ,int ,List<CardHeroes>,string, List<CardHeroes>> ChangeGameForm;
        public event Action<bool, int, string, int, int, List<CardHeroes>, List<CardHeroes>> ChangeAftepStep;
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
                case PacketsToServer.ResultChooseCardList:
                    ResultChooseCardList anscard = JsonConvert.DeserializeObject<ResultChooseCardList>(message);
                    if (anscard.ResultOfChooseCard == Status.fail)
                    {
                        ISCardRight = false;
                        //  ChangeFormCard();//добавить обработчик
                    }
                    else
                    {
                        ISCardRight = true;
                    }
                    if (ISCardRightEnemy == true && ISCardRight == true)
                    {
                        ChangeToFormGame(); SendStart(enemyName);
                    }
                    break;
                case PacketsToServer.ISErrorOfEnemy:
                    ISErrorOfEnemy errEnemy = JsonConvert.DeserializeObject<ISErrorOfEnemy>(message);
                    if (errEnemy.ISErr == false)
                    {
                        ISCardRightEnemy = true;
                    }
                    else
                    if (errEnemy.ISErr != false && ISCardRight == true)
                    {
                        ISCardRightEnemy = false;
                        MessForMEWait("подождите, ваш противник еще выбирает карты");
                        // CardClose();//добавить обработчик
                    }
                    if (ISCardRightEnemy == true && ISCardRight == true)
                    {
                        ChangeToFormGame(); SendStart(enemyName);
                    }
                    break;
                case PacketsToServer.SendDataToUserFirstTime:
                    SendDataToUsersFirstTime DataFirst = JsonConvert.DeserializeObject<SendDataToUsersFirstTime>(message);
                    ChangeGameForm(DataFirst.AmIFirst, DataFirst.EnemyHealth, DataFirst.EnemyName, DataFirst.MyHealth, DataFirst.MyMana, DataFirst.StartKoloda, name, DataFirst.ListCardInAHandFirst);
                    break;
                case PacketsToServer.Error:
                    Error carder = JsonConvert.DeserializeObject<Error>(message);
                    if (carder.ErrorToUser == MessagesToClientErrors.NotEnouthMana)
                    {
                        MessForME("У вас не хватает маны");
                    }
                    break;
                case PacketsToServer.CardOnABoard:
                    CardOnABoard card = JsonConvert.DeserializeObject<CardOnABoard>(message);
                    if (card.login == name)
                    {
                        CardOnABoard(card.card);
                    }
                    else
                    {
                        CardOnOtherABoard(card.card);
                    }
                    break;
                case PacketsToServer.SendDataToUsers:
                    SendDataToUsers Data = JsonConvert.DeserializeObject<SendDataToUsers>(message);
                    ChangeAftepStep(Data.AmIFirst, Data.EnemyHealth, enemyName, Data.MyHealth, Data.MyMana, Data.Arena1, Data.Arena2);
                    break;
                case PacketsToServer.EnemyLeftGamePacket:
                    IfEnemyLeft("Ваш противник сдался! Вы выйграли!");
                    break;
            }
        }
        //
        string enemyName = "";
        bool ISCardRight = false;//для проверки можно ли начинать игру ,норм ли колоды?
        bool ISCardRightEnemy = false;
        public void SendIFCLose()
        {
            EnemyLeftGamePacket pack = new EnemyLeftGamePacket();
            pack.Command = PacketsToServer.EnemyLeftGamePacket;
            pack.login = name;
            string mes = JsonConvert.SerializeObject(pack) + "$";
            Send(mes);
        }
        public void EndSteps()
        {
            EndStep end = new EndStep();
            end.Command = PacketsToServer.EndStep;
            string mes = JsonConvert.SerializeObject(end) + "$";
            Send(mes);
        }
        public void SendStart(string enemy)
        {
            StartGamePacket st = new StartGamePacket();
            st.Command = PacketsToServer.StartGamePacket;
            st.Enemy = enemy;
            st.Me = name;
            string mes = JsonConvert.SerializeObject(st) + "$";
            Send(mes);
        }
        public void SendListCard(List<CardHeroes> a)
        {
            ChoosenCardListPacket choosecard = new ChoosenCardListPacket();
            choosecard.Command = PacketsToServer.ChoosenCardListPacket;
            choosecard.Koloda = a;
            choosecard.Me = name;
            string mes = JsonConvert.SerializeObject(choosecard) + "$";
            Send(mes);
        }
        public void SendQAForWait()
        {
            WaitGamePacket wait = new WaitGamePacket();
            wait.Command = PacketsToServer.WaitGamePacket;
            wait.login = name;
            string mes = JsonConvert.SerializeObject(wait) + "$";
            Send(mes);
        }
        public void SendIleft()
        {
            EnemyLeftGamePacket left = new EnemyLeftGamePacket();
            left.Command = PacketsToServer.WaitGamePacket;
            left.login = name;
            string mes = JsonConvert.SerializeObject(left) + "$";
            Send(mes);
        }
        public void StepToSend(CardHeroes EnemyCard, CardHeroes MyCard)
        {
            StepPacket step = new StepPacket();
            step.Command = PacketsToServer.StepPacket;
            step.Enemy = enemyName;
            step.EnemyCard = EnemyCard;
            step.MyCard = MyCard;
            string mes = JsonConvert.SerializeObject(step) + "$";
            Send(mes);
        }
        public void ArenaCardNowSend(CardHeroes MyCard, int index)
        {
            PacketArenaCardNow pack = new PacketArenaCardNow();
            pack.Command = PacketsToServer.PacketArenaCardNow;
            pack.MyCard = MyCard;
            pack.IndeXMyCard = index;
            string mes = JsonConvert.SerializeObject(pack) + "$";
            Send(mes);

        }
        public void PickAndPayMana(CardHeroes MyCard)
        {
            PacketPickCard pick = new PacketPickCard();//оплата карты маной из предложенной коллоды
            pick.Command = PacketsToServer.PacketPickCard;
            pick.Card = MyCard;
            string mes = JsonConvert.SerializeObject(pick) + "$";
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
        public void sendStepPass()
        {
            StepIsNull step = new StepIsNull();
            step.Command = PacketsToServer.StepIsNull;
            string mes = JsonConvert.SerializeObject(step) + "$";
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
            enemyName = login;
        }
        public void SendAnswerToAskGame(string names, bool flag)
        {
            AnsGamePacket ans = new AnsGamePacket();
            ans.Command = PacketsToServer.AnsGamePacket;
            ans.Enemylogin = names;
            ans.Mylogin = name;
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
            enemyName = names;
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