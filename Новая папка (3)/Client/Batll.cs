using ClassLibrary1;
using Game.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Batll : Form
    {
        ClientObject client;
        public Batll(ClientObject client)
        {
            InitializeComponent();
            lNamePlayer1.Text = client.Name;
            client.ChangeGameForm += RasdachaCard;
            client.MessForME += messforme;
            client.CardOnABoard += CardOnABoard;
            client.CardOnOtherABoard += CardOnAOtherBoard;
            this.client = client;
        }
        public void CardOnABoard(CardHeroes card)
        {
            foreach (CardsForm b in pMe.Controls)
            {
                if (b.Visible == false)
                {
                    b.Invoke((MethodInvoker)(() =>
                    b.Visible = true));
                    b.Invoke((MethodInvoker)(() =>
                   b.Health = card.Health));
                    b.Invoke((MethodInvoker)(() =>
                    b.Power = card.Power));
                    b.Invoke((MethodInvoker)(() =>
                    b.Price = card.Price));
                    b.Invoke((MethodInvoker)(() => b.Image = (Image)Resource1.ResourceManager.GetObject(card.Name))); break;
                }
            }
           foreach(CardsForm a in pMyHand.Controls)
            {
                int count = pMyHand.Controls.IndexOf(a);
                CardHeroes cardh = CardHand.ElementAt(count);
                if (card == cardh)
                {
                    a.Invoke((MethodInvoker)(() =>
                   a.Visible = true)); break;
                }
            }
        }
        public void CardOnAOtherBoard(CardHeroes card)
        {
            foreach (CardsForm b in pEnemy.Controls)
            {
                if (b.Visible == false)
                {
                        b.Invoke((MethodInvoker)(() =>
                        b.Visible = true));
                        b.Invoke((MethodInvoker)(() =>
                        b.Health = card.Health));
                        b.Invoke((MethodInvoker)(() =>
                        b.Power = card.Power));
                        b.Invoke((MethodInvoker)(() =>
                        b.Price = card.Price));
                        b.Invoke((MethodInvoker)(() => b.Image = (Image)Resource1.ResourceManager.GetObject(card.Name)));
                    break;
                }
            }
        }
        void messforme(string str)
        {
            MessageBox.Show(str);
        }
        void RasdachaCard(bool AmIFirst, int EnemyHealth, string EnemyName, int MyHealth,int MyMana,List<CardHeroes> StartKoloda,string name,List<CardHeroes> FirstInHand)
        {
            CardHand = FirstInHand;
            if (this.InvokeRequired)
            {
                lNamePlayer1.Invoke((MethodInvoker)(() => lNamePlayer1.Text=name));
                lNamePlayer2.Invoke((MethodInvoker)(() => lNamePlayer2.Text=EnemyName));
                lHealthPlayer1.Invoke((MethodInvoker)(() => lHealthPlayer1.Text=MyHealth.ToString()));
                lHealthPlayer2.Invoke((MethodInvoker)(() => lHealthPlayer2.Text=EnemyHealth.ToString()));
                //foreach(PictureBox a in Controls)
                //{
                //    if (MyMana == 1)
                //    {
                //        a.Visible = true; return;

                //    }
                //}
                for (int i = 0; i < 7; i++)
                {
                    foreach (CardsForm a in pMyHand.Controls)
                    {
                        bool flag = false;
                        a.Invoke((MethodInvoker)(() =>flag =(bool)Equals(a.Image,null)));
                        if (flag)
                        {
                            a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(FirstInHand[i].Name)));
                            a.Invoke((MethodInvoker)(() => a.NameCards = FirstInHand[i].Name));
                            a.Invoke((MethodInvoker)(() => a.Power = FirstInHand[i].Power));
                            a.Invoke((MethodInvoker)(() => a.Health = FirstInHand[i].Health));
                            a.Invoke((MethodInvoker)(() => a.Price = FirstInHand[i].Price));
                            break;
                        }
                        
                    }
                }
            }
            else
            {
                
            }

        }
        int count = 0;
        List<CardHeroes> ClickCards = new List<CardHeroes>();
        List<CardHeroes> CardHand = new List<CardHeroes>(); //как достать с сервера?
    

        private void bPas_Click(object sender, EventArgs e)
        {
            client.sendStepPass();
        }
        CardsForm choosenCard;
        private void bArena_Click(object sender, EventArgs e)
        {
            int count = pMyHand.Controls.IndexOf(choosenCard);
            CardHeroes cardh= CardHand.ElementAt(count);
            client.ArenaCardNowSend(cardh,count);
        }

        private void cardsForm1_Click(object sender, EventArgs e)
        {
            CardsForm card = (CardsForm)sender;
            //int count = pMyHand.Controls.IndexOf(card);
            //CardHeroes cardh= CardHand.ElementAt(count);
            if (choosenCard != sender&&choosenCard!=null)
            {
                choosenCard.BackgroundImage = Resource1.ФОН_ЛИСТА;
                choosenCard.ISPRESSED = false;
                choosenCard = (CardsForm)sender;
                bArena.Visible = true;

            }
            if (card.ISPRESSED == false)
            {
                card.BackgroundImage = Resource1.ВЫБРАННАЯКАРТА;
                card.ISPRESSED = true;
                choosenCard = card;
                bArena.Visible = true;
            }
            else
            {
                card.BackgroundImage = Resource1.ФОН_ЛИСТА;
                card.ISPRESSED = false;
                choosenCard = null;
                bArena.Visible = false;
            }
        }
            
            
        }
    }


        
