using Game.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ChooseListOfYourCards : Form
    {
        ClientObject client;
        public ChooseListOfYourCards(ClientObject client)
        {
            InitializeComponent();
            client.MakeCards += MakeCards;
            client.ChangeToFormGame += changeToGame;
            client.MessForME += Mess;
            this.client = client;
        }
        List<CardHeroes> allcards;
        void Mess(string s)
        {
            MessageBox.Show(s);
        }
        void changeToGame()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.Hide()));
                //this.Hide();
                this.Invoke((MethodInvoker)(() => new Batll(client).Show()));
            }
            else
            {
                this.Hide();
                Form ifrm = new Batll(client);
                ifrm.Show();
            }
        }
        void MakeCards(List<CardHeroes> list)
        {
            allcards = list;
            int count = 0;
            foreach (Control value in this.groupBox1.Controls)
            {
                if (value.InvokeRequired)
                {
                    if (value is CardsForm)
                    {
                        (value as CardsForm).Invoke((MethodInvoker)(() => (value as CardsForm).Image = (Image)Resource1.ResourceManager.GetObject(list[count].Name)));
                        (value as CardsForm).Invoke((MethodInvoker)(() => (value as CardsForm).NameCards = list[count].Name));
                        (value as CardsForm).Invoke((MethodInvoker)(() => (value as CardsForm).Price = list[count].Price));
                        (value as CardsForm).Invoke((MethodInvoker)(() => (value as CardsForm).Health = list[count].Health));
                        (value as CardsForm).Invoke((MethodInvoker)(() => (value as CardsForm).Power = list[count].Power));
                        count++;
                    }
                }
                else
                {
                    if (value is CardsForm)
                    {
                        (value as CardsForm).Image = (Image)Resource1.ResourceManager.GetObject(list[count].Name);
                        (value as CardsForm).Name = list[count].Name;
                        (value as CardsForm).Price = list[count].Price;
                        (value as CardsForm).Power = list[count].Power;
                        (value as CardsForm).Health = list[count].Health;
                        count++;
                    }
                }
            }
        }

        int count = 0;
        List<CardHeroes> koloda= new List<CardHeroes>();


        private void cardsFormCLick(object sender, EventArgs e)
        {
            if (count != 15)
            {
                CardsForm card = (CardsForm)sender;
                if (card.ISPRESSED == false)
                {
                    card.BackgroundImage = Resource1.ВЫБРАННАЯКАРТА;
                    foreach (CardHeroes a in allcards)
                    {
                        if (card.NameCards == a.Name)
                        {
                            koloda.Add(a);
                            count++;
                            card.ISPRESSED = true;
                        }
                    }
                }
                else
                {
                    card.BackgroundImage = Resource1.ФОН_ЛИСТА;
                    foreach (CardHeroes a in allcards)
                    {
                        if (card.NameCards == a.Name)
                        {
                            count--;
                            card.ISPRESSED = false;
                            koloda.Remove(a);

                        }
                    }
                }
                if (count < 15) { Ready.Visible = false; }
                else
            if (count == 15) Ready.Visible = true;

            }
        }
        private void Ready_Click(object sender, EventArgs e)
        {
            client.SendListCard(koloda);
        }
    }
}
