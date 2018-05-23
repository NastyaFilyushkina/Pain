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
            client.IfEnemyLeft += IFENEMYLEFT;
            this.client = client;
            client.ChangeAftepStep += ChangeAfterStep;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    
    bool ICloser = true;
    void IFENEMYLEFT(string a)
    {
        ICloser = false;
        Application.OpenForms[2].Invoke((MethodInvoker)(() =>
                  Application.OpenForms[2].Close()));

        //Form ifrm1 = Application.OpenForms[1];
        // ifrm1.Close();
        // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
        Form ifrm = Application.OpenForms[0];
        ifrm.Invoke((MethodInvoker)(() => ifrm.StartPosition = FormStartPosition.Manual));
        ifrm.Invoke((MethodInvoker)(() => ifrm.Left = this.Left));
        ifrm.Invoke((MethodInvoker)(() => ifrm.Top = this.Top));
        ifrm.Invoke((MethodInvoker)(() => ifrm.Show()));// меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
                                                        // отображаем Form1
        MessageBox.Show(a);

    }
    public void CardOnABoard(CardHeroes card)
    {
        MyArena.Add(card);
        foreach (CardsForm a in pMyHand.Controls)
        {
            CardHeroes cardh = null;
            int count = pMyHand.Controls.IndexOf(a);
            if (oldIndex == count)
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
                b.Invoke((MethodInvoker)(() =>
                b.Enabled = false));
                card.Index = b.Index;
                index = card.Index;
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
    int index = 0;
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
                             
                            CardHand[i].Index = a.Index;
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
              int MyMana, List<CardHeroes> Arena1, List<CardHeroes> Arena2, List<CardHeroes> EnemyArena1, List<CardHeroes> EnemyArena2)
        {
            int mana = MyMana;

            while (mana > 0)
            {
                if (pMana.InvokeRequired)
                {
                    pMana.Invoke((MethodInvoker)(() => pMana.Controls[mana - 1].Visible = true));
                }
                else
                {

                    pMana.Controls[mana - 1].Visible = true;
                }
                mana--;
            }
            
                if (this.InvokeRequired)
                {
                    lHealthPlayer2.Invoke((MethodInvoker)(() => lHealthPlayer2.Text = MyHealth.ToString()));
                    lHealthPlayer1.Invoke((MethodInvoker)(() => lHealthPlayer1.Text = EnemyHealth.ToString()));
                    int count1 = 0; int count2 = 0;
                    for (int i = 0; i < Arena1.Count; i++)
                    {
                        foreach (CardsForm a in pMe.Controls)
                        {
                            if (a.Image != null)
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
                                        a.Invoke((MethodInvoker)(() => a.Enabled = false));

                                        break;
                                    }
                                }
                            }
                        }

                        for (int j = 0; j < Arena2.Count; j++)
                        {
                            foreach (CardsForm a in pMe.Controls)
                            {
                                if (a.Image != null)
                                {
                                    if (a.Index == Arena2[j].Index)
                                    {
                                        if (Arena2[j].Name != null)
                                        {
                                            a.Invoke((MethodInvoker)(() => a.Index = pMyHand.Controls.IndexOf(a)));
                                            a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(Arena2[j].Name)));
                                            a.Invoke((MethodInvoker)(() => a.NameCards = Arena2[j].Name));
                                            a.Invoke((MethodInvoker)(() => a.Power = Arena2[j].Power));
                                            a.Invoke((MethodInvoker)(() => a.Health = Arena2[j].Health));
                                            a.Invoke((MethodInvoker)(() => a.Price = Arena2[j].Price));
                                            a.Invoke((MethodInvoker)(() => a.Enabled = true));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (AmIFirst == false)
                    {
                        this.Invoke((MethodInvoker)(() => this.Enabled = false));
                        ENSt.Invoke((MethodInvoker)(() => ENSt.Visible = true));
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)(() => this.Enabled = true));
                        ENSt.Invoke((MethodInvoker)(() => ENSt.Visible = false));
                    }



                    foreach (CardsForm a in pEnemy.Controls)
                    {
                        if (a.Image != null)
                        {
                            for (int i = 0; i < EnemyArena1.Count; i++)
                            {
                                if (EnemyArena1[i].Name != null)
                                {
                                    if (a.Index == EnemyArena1[i].Index)
                                    {
                                        a.Invoke((MethodInvoker)(() => a.Index = pEnemy.Controls.IndexOf(a)));
                                        a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(EnemyArena1[i].Name)));
                                        a.Invoke((MethodInvoker)(() => a.NameCards = EnemyArena1[i].Name));
                                        a.Invoke((MethodInvoker)(() => a.Power = EnemyArena1[i].Power));
                                        a.Invoke((MethodInvoker)(() => a.Health = EnemyArena1[i].Health));
                                        a.Invoke((MethodInvoker)(() => a.Price = EnemyArena1[i].Price));
                                        a.Invoke((MethodInvoker)(() => a.Enabled = false));

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < EnemyArena2.Count; i++)
                    {
                        foreach (CardsForm a in pEnemy.Controls)
                        {
                            if (a.Image != null)
                            {
                                if (EnemyArena2[i].Name != null)
                                {
                                    if (a.Index == EnemyArena2[i].Index)
                                    {
                                        a.Invoke((MethodInvoker)(() => a.Index = pEnemy.Controls.IndexOf(a)));
                                        a.Invoke((MethodInvoker)(() => a.Image = (Image)Resource1.ResourceManager.GetObject(EnemyArena2[i].Name)));
                                        a.Invoke((MethodInvoker)(() => a.NameCards = EnemyArena2[i].Name));
                                        a.Invoke((MethodInvoker)(() => a.Power = EnemyArena2[i].Power));
                                        a.Invoke((MethodInvoker)(() => a.Health = EnemyArena2[i].Health));
                                        a.Invoke((MethodInvoker)(() => a.Price = EnemyArena2[i].Price));

                                        break;
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
        int oldIndex = 0;
        private void bArena_Click(object sender, EventArgs e)
        {
            int count = pMyHand.Controls.IndexOf(choosenCard);
            oldIndex = count;
            CardHeroes cardh = CardHand.ElementAt(count);
            client.ArenaCardNowSend(cardh, index);
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

                    card.BackgroundImage = Resource1.ФОН_ЛИСТА;
                    Step.Visible = false;
                }
            }
            else
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
                        }
                        else
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

                    bArena.Visible = false;
                }
            }
        }

        private void Step_Click(object sender, EventArgs e)
        {
            CardHeroes my = null;
            CardHeroes enemy = null;
            foreach (CardHeroes a in EnemyArena)
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
            CardHeroes player = new CardHeroes(0, Convert.ToInt16(lHealthPlayer2.Text), lNamePlayer2.Text);
            CardHeroes my = null;
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

        private void Batll_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ICloser != false)
            {

                DialogResult result = MessageBox.Show("Вы хотите покинуть игру?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No) //Если нажал нет
                {

                }

                if (result == DialogResult.Yes) //Если нажал Да
                {
                    client.SendIFCLose();
                    Form ifrm1 = Application.OpenForms[1];
                    ifrm1.Close();
                    // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
                    Form ifrm = Application.OpenForms[0];
                    ifrm.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
                    ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                    ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                    ifrm.Show(); // отображаем Form1
                }

            }
        }
    }
}


