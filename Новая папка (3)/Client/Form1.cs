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
            if (this.InvokeRequired)
            {
                bool flag = (bool)NameTextBox.Invoke((MethodInvoker)(() => Equals(NameTextBox.Text, "")));
                if (!flag)
                {
                    ErrorMessage.Invoke((MethodInvoker)(() => ErrorMessage.Text="Введите имя"));
                }
                else
                {
                    NameTextBox.Invoke((MethodInvoker)(() => name = NameTextBox.Text));
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
            else
            {
                if (NameTextBox.Text == "")
                {
                    NameUserLabel.Text = "Введите имя";
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
      
        }
        void MessFORme(string names)
        {
            DialogResult result=MessageBox.Show("С вами хотят играть! Вы согласны начать игру?", name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                this.Invoke((MethodInvoker)(() => new ChooseListOfYourCards(client).Show()));
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
            if (this.InvokeRequired)
            {
                ErrorMessage.Invoke((MethodInvoker)(() => ErrorMessage.Dispose()));
                NameUserLabel.Invoke((MethodInvoker)(() => NameUserLabel.Dispose()));
                NameTextBox.Invoke((MethodInvoker)(() => NameTextBox.Dispose()));
                SignINBut.Invoke((MethodInvoker)(() => SignINBut.Dispose()));
                StartGameBUT.Invoke((MethodInvoker)(() => StartGameBUT.Visible = true));
                SettingsBUT.Invoke((MethodInvoker)(() => SettingsBUT.Visible = true));
                EscapeBUT.Invoke((MethodInvoker)(() => EscapeBUT.Visible = true));
            }
            else
            {
                ErrorMessage.Dispose();
                NameUserLabel.Dispose();
                SignINBut.Dispose();
                NameTextBox.Dispose(); StartGameBUT.Visible = true;
                SettingsBUT.Visible = true; EscapeBUT.Visible = true;
            }
           
        }
        
        private void StartGameBUT_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
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
            else
            {
                StartGameBUT.Dispose();
                SettingsBUT.Dispose();
                EscapeBUT.Dispose(); Title.Visible = true; ListOfReadyPlayer.Visible = true; ListOfPlayers.Visible = true;
                Status.Visible = true; groupChoose.Visible = true; ChooseEnemyBUT.Visible = true; RandomEnemyBUT.Visible = true; this.Width = 622;
            }
           
            
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
            if (list != null)
            {
                //ListOfPlayers.Items.Clear();
                foreach (string player in list)
                {
                    bool fla = false;
                    ListOfPlayers.Invoke((MethodInvoker)(() => fla = ListOfPlayers.Items.Contains(player)));

                    if (player != name && fla == false)
                        ListOfPlayers.Invoke((MethodInvoker)(() => ListOfPlayers.Items.Add(player)));
                }
            }
        }
        public void ChandeForm2(List<string> list)
        {
            // ListOfReadyPlayer.Items.Clear();
            foreach (string player in list)
            {
                bool fla = false;
                ListOfReadyPlayer.Invoke((MethodInvoker)(() => fla = ListOfReadyPlayer.Items.Contains(player)));

                if (player != name && fla == false)
                    ListOfReadyPlayer.Invoke((MethodInvoker)(() => ListOfReadyPlayer.Items.Add(player)));
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                ListOfReadyPlayer.Invoke((MethodInvoker)(() => ListOfReadyPlayer.Items.Clear()));
            }
            else
            {
                ListOfReadyPlayer.Items.Clear();
            }
            client.SendQAForWait();
         
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                ListOfReadyPlayer.Invoke((MethodInvoker)(() => ListOfReadyPlayer.Items.Clear()));
            }
            else
            {
                ListOfReadyPlayer.Items.Clear();
            }
           
            client.SendQAForSTOPWait();
            
          //  ListOfReadyPlayer. ListOfReadyPlayer.Items.Clear();
        }

        private void RandomEnemyBUT_Click(object sender, EventArgs e)
        {
            client.SendQAFORRandom();
        }

        private void ChooseEnemyBUT_Click(object sender, EventArgs e)
        {
            if (nameenemy != "")
            {
                nameenemy = ListOfReadyPlayer.SelectedItem.ToString();
                if (nameenemy != "")
                {
                    client.SendQAFORChooseEnemy(nameenemy);
                }
            }
        }

        private void ListOfPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        string nameenemy;

       
        
   
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            client.SendQAIFEXIT(name);
            threadcl.Abort();
        }

        private void ListOfReadyPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameenemy = ListOfReadyPlayer.SelectedItem.ToString();
        }
    }
}
