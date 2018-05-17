using Game.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public string name;
        ClientObject client;

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                NameUserLabel.Text = "!!!";
            }
            else
            {
                string name = NameTextBox.Text;
                client = new ClientObject(name);
                client.ChangeForm += ChangeForm;
                client.SendMessage += Message;
                client.ChangeForm1 += ChandeForm1;
                Thread threadcl = new Thread(new ThreadStart(client.ClObjProcess));
                threadcl.Start();
                
            }

        }
        
        public void Message(string str)
        {
            ErrorMessage.Invoke((MethodInvoker)(() => ErrorMessage.Text = str));
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
            ListOfPlayers.Invoke((MethodInvoker)(() => ListOfPlayers.Visible = true));
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
            foreach (string player in list)
            {
                ListOfPlayers.Invoke((MethodInvoker)(() => ListOfPlayers.Items.Add(player)));
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            client.SendQAForWait();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RandomEnemyBUT_Click(object sender, EventArgs e)
        {

        }

        private void ChooseEnemyBUT_Click(object sender, EventArgs e)
        {
            if (nameenemy != "")
            {
                client.SendQAFORChoseEnemy();
            }
        }

        private void ListOfPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameenemy =ListOfPlayers.SelectedItem.ToString();
        }
        string nameenemy;
    }
}
