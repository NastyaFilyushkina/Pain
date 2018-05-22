﻿using ClassLibrary1;
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
        List<CardHeroes> EnemyArena = new List<CardHeroes>();
        List<CardHeroes>MyArena = new List<CardHeroes>();
        public Batll(ClientObject client)
        {
            InitializeComponent();
            lNamePlayer1.Text = client.Name;
            client.ChangeGameForm += RasdachaCard;
            client.MessForME += messforme;
            client.CardOnABoard += CardOnABoard;
            client.CardOnOtherABoard += CardOnAOtherBoard;
            this.client = client;
            client.ChangeAftepStep += ChangeAfterStep;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        public void CardOnABoard(CardHeroes card)
        {
            MyArena.Add(card);
            foreach (CardsForm a in pMyHand.Controls)
            {
                CardHeroes cardh = null;
                int count = pMyHand.Controls.IndexOf(a);
                if (card.Index == count)
                {
                     CardHand.Remove(card);
                        a.Invoke((MethodInvoker)(() =>
                        a.Visible = false));
                        CardHand.Remove(card);
                        a.Invoke((MethodInvoker)(() =>
                        a.NameCards = ""));
                        CardHand.Remove(card);
                        a.Invoke((MethodInvoker)(() =>
                        a.Power = 0));
                        CardHand.Remove(card);
                        a.Invoke((MethodInvoker)(() =>
                        a.Price = 0));
                        CardHand.Remove(card);
                        a.Invoke((MethodInvoker)(() =>
                        a.Health = 0));
                        a.Invoke((MethodInvoker)(() => a.Image = null));
                        break;
                    
                }
            }
            foreach (CardsForm b in pMe.Controls)
            {
                if (b.Visible == false)
                {
                    card.Index = b.Index;
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
        }
        public void CardOnAOtherBoard(CardHeroes card)
        {
            EnemyArena.Add(card);
            foreach (CardsForm b in pEnemy.Controls)
            {
                if (b.Visible == false)
                {
                    card.Index = b.Index;
                    b.Invoke((MethodInvoker)(() =>
                    b.Visible = true));
                    b.Invoke((MethodInvoker)(() =>
                    b.Health = card.Health));
                    b.Invoke((MethodInvoker)(() =>
                    b.Power = card.Power));
                    b.Invoke((MethodInvoker)(() =>
                    b.Price = card.Price));
                    b.Invoke((MethodInvoker)(() =>
                    b.Image = (Image)Resource1.ResourceManager.GetObject(card.Name)));
                    break;
                }
            }
        }
        void messforme(string str)
        {
            MessageBox.Show(str);
        }

        void RasdachaCard(bool AmIFirst, int EnemyHealth, string EnemyName, int MyHealth, int MyMana, List<CardHeroes> StartKoloda, string name, List<CardHeroes> FirstInHand)
        {
            int mana = MyMana;
            foreach (PictureBox a in pMana.Controls)
            {
                while (mana != 0)
                {
                    a.Invoke((MethodInvoker)(() =>
                  a.Visible = true));
                    mana--;
                }
            }
            CardHand = FirstInHand;
            if (this.InvokeRequired)
            {
                lNamePlayer1.Invoke((MethodInvoker)(() => lNamePlayer1.Text = name));
                lNamePlayer2.Invoke((MethodInvoker)(() => lNamePlayer2.Text = EnemyName));
                lHealthPlayer2.Invoke((MethodInvoker)(() => lHealthPlayer2.Text = MyHealth.ToString()));
                lHealthPlayer1.Invoke((MethodInvoker)(() => lHealthPlayer1.Text = EnemyHealth.ToString()));
               
                for (int i = 0; i < 7; i++)
                {
                    foreach (CardsForm a in pMyHand.Controls)
                    {
                        bool flag = false;
                        a.Invoke((MethodInvoker)(() => flag = (bool)Equals(a.Image, null)));
                        if (flag)
                        {
                            // a.Index = count;
                            FirstInHand[i].Index = a.Index;
                            a.Invoke((MethodInvoker)(() => a.Index = pMyHand.Controls.IndexOf(a)));
                            a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(FirstInHand[i].Name)));
                            a.Invoke((MethodInvoker)(() => a.NameCards = FirstInHand[i].Name));
                            a.Invoke((MethodInvoker)(() => a.Power = FirstInHand[i].Power));
                            a.Invoke((MethodInvoker)(() => a.Health = FirstInHand[i].Health));
                            a.Invoke((MethodInvoker)(() => a.Price = FirstInHand[i].Price));
                            break;
                        }

                    }
                }
                if (AmIFirst == false)
                {
                   this.Invoke((MethodInvoker)(() => this.Enabled=false));
                    ENSt.Invoke((MethodInvoker)(() => ENSt.Visible = true));
                   
                }
                else
                {
                    this.Enabled = true;
                    ENSt.Visible = false;
                }
            }
            else
            {

            }

        }
        int count = 0;
        List<CardHeroes> ClickCards = new List<CardHeroes>();
        List<CardHeroes> CardHand = new List<CardHeroes>(); //как достать с сервера?
        private void ChangeAfterStep(bool AmIFirst, int EnemyHealth, string enemyName, int MyHealth,
            int MyMana, List<CardHeroes> Arena1, List<CardHeroes> Arena2)
        {
            int mana = MyMana;
            foreach (PictureBox a in pMana.Controls)
            {
                while (mana > 0)
                {
                    a.Invoke((MethodInvoker)(() => a.Visible = true));
                    mana--;
                }
            }
            if (AmIFirst == false)
            {
                if (this.InvokeRequired)
                {
                    lHealthPlayer2.Invoke((MethodInvoker)(() => lHealthPlayer2.Text = MyHealth.ToString()));
                    lHealthPlayer1.Invoke((MethodInvoker)(() => lHealthPlayer1.Text = EnemyHealth.ToString()));

                    foreach (CardsForm a in pMe.Controls)
                    {
                        if (a.Image != null)
                        {
                            for (int i = 0; i < Arena1.Count; i++)
                            {
                                if (Arena1[i].Name != null)
                                {
                                    if (a.Index == Arena1[i].Index)
                                    {
                                        a.Invoke((MethodInvoker)(() => a.Index = pMyHand.Controls.IndexOf(a)));
                                        a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(Arena1[i].Name)));
                                        a.Invoke((MethodInvoker)(() => a.NameCards = Arena1[i].Name));
                                        a.Invoke((MethodInvoker)(() => a.Power = Arena1[i].Power));
                                        a.Invoke((MethodInvoker)(() => a.Health = Arena1[i].Health));
                                        a.Invoke((MethodInvoker)(() => a.Price = Arena1[i].Price));

                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < Arena2.Count; i++)
                            {
                                if (Arena2[i].Name != null)
                                {
                                    if (a.Index == Arena2[i].Index)
                                    {
                                        a.Invoke((MethodInvoker)(() => a.Index = pMyHand.Controls.IndexOf(a)));
                                        a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(Arena2[i].Name)));
                                        a.Invoke((MethodInvoker)(() => a.NameCards = Arena2[i].Name));
                                        a.Invoke((MethodInvoker)(() => a.Power = Arena2[i].Power));
                                        a.Invoke((MethodInvoker)(() => a.Health = Arena2[i].Health));
                                        a.Invoke((MethodInvoker)(() => a.Price = Arena2[i].Price));

                                        break;
                                    }
                                }
                            }

                        }
                    }

                }
                this.Invoke((MethodInvoker)(() => this.Enabled = false));
                ENSt.Invoke((MethodInvoker)(() => ENSt.Visible = true));
            }
            else
            {

                this.Invoke((MethodInvoker)(() => this.Enabled = true));
                ENSt.Invoke((MethodInvoker)(() => ENSt.Visible = false));
                if (this.InvokeRequired)
                {
                    lHealthPlayer2.Invoke((MethodInvoker)(() => lHealthPlayer2.Text = MyHealth.ToString()));
                    lHealthPlayer1.Invoke((MethodInvoker)(() => lHealthPlayer1.Text = EnemyHealth.ToString()));

                    foreach (CardsForm a in pEnemy.Controls)
                    {
                        if (a.Image != null)
                        {
                            for (int i = 0; i < Arena1.Count; i++)
                            {
                                if (Arena1[i].Name != null)
                                {
                                    if (a.Index == Arena1[i].Index)
                                    {
                                        a.Invoke((MethodInvoker)(() => a.Index = pMyHand.Controls.IndexOf(a)));
                                        a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(Arena1[i].Name)));
                                        a.Invoke((MethodInvoker)(() => a.NameCards = Arena1[i].Name));
                                        a.Invoke((MethodInvoker)(() => a.Power = Arena1[i].Power));
                                        a.Invoke((MethodInvoker)(() => a.Health = Arena1[i].Health));
                                        a.Invoke((MethodInvoker)(() => a.Price = Arena1[i].Price)); break;
                                    }
                                }
                            }
                            for (int i = 0; i < Arena2.Count; i++)
                            {
                                if (Arena2[i].Name != null)
                                {
                                    if (a.Index == Arena2[i].Index)
                                    {
                                        a.Invoke((MethodInvoker)(() => a.Index = pMyHand.Controls.IndexOf(a)));
                                        a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(Arena2[i].Name)));
                                        a.Invoke((MethodInvoker)(() => a.NameCards = Arena2[i].Name));
                                        a.Invoke((MethodInvoker)(() => a.Power = Arena2[i].Power));
                                        a.Invoke((MethodInvoker)(() => a.Health = Arena2[i].Health));
                                        a.Invoke((MethodInvoker)(() => a.Price = Arena2[i].Price));
                                        break;
                                    }
                                }
                            }

                        }

                    }
                }
            }
        }

        private void bPas_Click(object sender, EventArgs e)
        {
            client.sendStepPass();
        }
        CardsForm choosenCard;
        CardsForm choosenEnemyCard;
        private void bArena_Click(object sender, EventArgs e)
        {
            int count = pMyHand.Controls.IndexOf(choosenCard);
            CardHeroes cardh = CardHand.ElementAt(count);
            client.ArenaCardNowSend(cardh, count);
        }

        private void cardsForm1_Click(object sender, EventArgs e)
        {
            CardsForm card = (CardsForm)sender;
            if (pEnemy.Contains((CardsForm)sender))
            {
              // lNamePlayer2.Enabled = true;
                if (card.ISPRESSED == false)
                {
                    choosenEnemyCard = (CardsForm)sender;
                    choosenEnemyCard.ISPRESSED = true;
                    choosenEnemyCard.Index = card.Index;
                    card.BackgroundImage = Resource1.ВЫБРАННАЯКАРТА;
                    if (choosenEnemyCard != null && choosenEnemyCard != null)
                    {
                        Step.Visible = true;
                    }
                }
                else
                {
                    choosenEnemyCard.ISPRESSED = false;
                    choosenEnemyCard = null;
                    choosenEnemyCard.Index = -1;
                    card.BackgroundImage = Resource1.ФОН_ЛИСТА;
                    Step.Visible = false;
                }
            }else
            if (pMyArena.Contains((CardsForm)sender))
            {
                lNamePlayer2.Enabled = true;
                if (card.ISPRESSED == false)
                {
                    choosenCard = (CardsForm)sender;
                    choosenCard.ISPRESSED = true;
                    choosenCard.Index = card.Index;
                    card.BackgroundImage = Resource1.ВЫБРАННАЯКАРТА;
                    if (choosenCard != null && choosenEnemyCard != null)
                    {
                        Step.Visible = true;
                    }
                    foreach (CardsForm a in pEnemy.Controls)
                    {
                        if (this.InvokeRequired)
                        {
                            a.Invoke((MethodInvoker)(() => a.Enabled = true));
                        }else
                        {
                            a.Enabled = true;
                        }
                    }
                    ENSt.Invoke((MethodInvoker)(() => ENSt.Enabled = true));
                }
                else
                {
                    choosenCard.ISPRESSED = false;
                    choosenCard = null;

                    card.BackgroundImage = Resource1.ФОН_ЛИСТА;
                    Step.Visible = false;
                    foreach (CardsForm a in pEnemy.Controls)
                    {
                        a.Invoke((MethodInvoker)(() => a.Enabled = false));
                    }
                    ENSt.Invoke((MethodInvoker)(() => ENSt.Enabled = false));
                }
            }
            else
            {
                if (choosenCard != sender && choosenCard != null)
                {
                    chooseFace = false;
                    choosenCard.BackgroundImage = Resource1.ФОН_ЛИСТА;
                    choosenCard.ISPRESSED = false;
                    choosenCard = (CardsForm)sender;
                    if (!pMyArena.Contains((CardsForm)sender))
                        bArena.Visible = true;

                }
                if (card.ISPRESSED == false)
                {
                    card.BackgroundImage = Resource1.ВЫБРАННАЯКАРТА;
                    card.ISPRESSED = true;
                    choosenCard = card;
                    choosenCard.Index = card.Index;
                    if (!pMyArena.Contains((CardsForm)sender))
                        bArena.Visible = true;
                }
                else
                {
                    card.BackgroundImage = Resource1.ФОН_ЛИСТА;
                    card.ISPRESSED = false;
                    choosenCard = null;
                    choosenCard.Index = 0;
                    bArena.Visible = false;
                }
            }
        }

        private void Step_Click(object sender, EventArgs e)
        {
            CardHeroes my = null;
            CardHeroes enemy = null; 
            foreach(CardHeroes a in EnemyArena)
            {
                if (choosenEnemyCard.Index == a.Index)
                {
                    enemy = a;
                }
            }
            foreach (CardHeroes a in MyArena)
            {
                if (choosenCard.Index == a.Index)
                {
                    my = a;
                }
            }
            client.StepToSend(enemy, my);
        }
        bool chooseFace = false;
        private void lNamePlayer2_Click(object sender, EventArgs e)
        {
            chooseFace = true;
            if (chooseFace == true && choosenCard != null && choosenEnemyCard == null)
            {
                client.EndSteps();
                ENSt.Visible = true;
            }
            CardHeroes player = new CardHeroes(0,Convert.ToInt16(lHealthPlayer2.Text),lNamePlayer2.Text);
            CardHeroes my=null;
            foreach (CardsForm a in pMe.Controls)
            {
                int count = pMyArena.Controls.IndexOf(choosenCard);
                CardHeroes cardh = CardHand.ElementAt(count);
                my = cardh;
            }
            client.StepToSend(player, my);

        }

        private void EndStep_Click(object sender, EventArgs e)
        {
            client.EndSteps();
        }

    }
}


