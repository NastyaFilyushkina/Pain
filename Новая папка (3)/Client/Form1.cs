using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            
        }
         string name;
      public  ClientObject client;
        Thread threadcl;
        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                NameUserLabel.Text = "!!!";
            }
            else
            {
                name = NameTextBox.Text;
                client = new ClientObject(name);
                client.ChangeForm += ChangeForm;
                client.SendMessage += Message;
                client.ChangeForm1 += ChandeForm1;
                client.ChangeForm2 += ChandeForm2;
                client.MessForME += MessFORme;
                client.ChangeFormToNewForm += ChangeToNewFormListCard;
                 threadcl = new Thread(new ThreadStart(client.ClObjProcess));
                threadcl.Start();
                
            }

        }
        void MessFORme(string names)
        {
            DialogResult result=MessageBox.Show("С вами хотят играть!Вы согласны начать игру?", name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) //Если нажал нет
            {
                client.SendAnswerToAskGame(names,false);
            }

            if (result == DialogResult.Yes) //Если нажал Да
            {
                client.SendAnswerToAskGame(names,true);
            }
        }
        void ChangeToNewFormListCard()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.Hide()));
                //this.Hide();
                this.Invoke((MethodInvoker)(() => new ChooseListOfYourCards(client).Show()));
                //ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                //ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                /*ifrm.Show();*/ // отображаем Form2
                                 // скрываем Form1 (this - текущая форма)
            }
            else
            {
                this.Hide();
                Form ifrm = new ChooseListOfYourCards(client);
                ifrm.Show();
            }
        }
        public void Message(string str)
        {
            MessageBox.Show(str);
        }
         public void ChangeForm()
        {
            ErrorMessage.Invoke((MethodInvoker)(() => ErrorMessage.Dispose()));
            NameUserLabel.Invoke((MethodInvoker)(() => NameUserLabel.Dispose()));
            NameTextBox.Invoke((MethodInvoker)(() => NameTextBox.Dispose()));
            SignINBut.Invoke((MethodInvoker)(() => SignINBut.Dispose()));
            StartGameBUT.Invoke((MethodInvoker)(() => StartGameBUT.Visible = true));
            SettingsBUT.Invoke((MethodInvoker)(() => SettingsBUT.Visible = true));
            EscapeBUT.Invoke((MethodInvoker)(() => EscapeBUT.Visible = true));
        }
        
        private void StartGameBUT_Click(object sender, EventArgs e)
        {
            StartGameBUT.Invoke((MethodInvoker)(() => StartGameBUT.Dispose()));
            SettingsBUT.Invoke((MethodInvoker)(() => SettingsBUT.Dispose()));
            EscapeBUT.Invoke((MethodInvoker)(() => EscapeBUT.Dispose()));
            Title.Invoke((MethodInvoker)(() => Title.Visible = true));
            ListOfPlayers.Invoke((MethodInvoker)(() => ListOfReadyPlayer.Visible = true));
            ListOfReadyPlayer.Invoke((MethodInvoker)(() => ListOfPlayers.Visible = true));
            Status.Invoke((MethodInvoker)(() => Status.Visible = true));
            groupChoose.Invoke((MethodInvoker)(() => groupChoose.Visible = true));
            ChooseEnemyBUT.Invoke((MethodInvoker)(() => ChooseEnemyBUT.Visible = true));
            RandomEnemyBUT.Invoke((MethodInvoker)(() => RandomEnemyBUT.Visible = true));
            this.Width = 622;
            
        }
        //public List<string> masnames(List<string> list)
        //{
        //    List<string> lists = new List<string>();
        //    foreach (string player in lists)
        //    {
        //        list.Add(player);
        //    }
        //    return lists;
        //}
        public void ChandeForm1(List<string> list)
        {
            //ListOfPlayers.Items.Clear();
            foreach (string player in list)
            {
                if (player != name && !ListOfReadyPlayer.Items.Contains(player))
                    ListOfPlayers.Invoke((MethodInvoker)(() => ListOfPlayers.Items.Add(player)));
            }
        }
        public void ChandeForm2(List<string> list)
        {
           // ListOfReadyPlayer.Items.Clear();
            foreach (string player in list)
            {
                if(player!= name && !ListOfReadyPlayer.Items.Contains(player))
                ListOfReadyPlayer.Invoke((MethodInvoker)(() => ListOfReadyPlayer.Items.Add(player)));
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //ListOfReadyPlayer.Items.Clear();
            client.SendQAForWait();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

          //  ListOfReadyPlayer.Items.Clear();
        }

        private void RandomEnemyBUT_Click(object sender, EventArgs e)
        {
            client.SendQAFORRandom();
        }

        private void ChooseEnemyBUT_Click(object sender, EventArgs e)
        {
            nameenemy = ListOfReadyPlayer.SelectedItem.ToString();
            if (nameenemy != "")
            {
                client.SendQAFORChooseEnemy(nameenemy);
            }
        }

        private void ListOfPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        string nameenemy;

       
        
   
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.SendQAIFEXIT(name);
        }

        private void ListOfReadyPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameenemy = ListOfReadyPlayer.SelectedItem.ToString();
        }
    }
}
