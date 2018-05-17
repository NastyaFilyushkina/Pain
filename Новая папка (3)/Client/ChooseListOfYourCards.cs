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
       // ClientObject client;
        public ChooseListOfYourCards(ClientObject client )
        {
            InitializeComponent();
            client.MakeCards += MakeCards;
        }
        void MakeCards(List<CardHeroes> list)
        {
            foreach (Control value in Controls)
            {
                if (value is PictureBox)
                {
                    (value as PictureBox).Image = Resource1.mana11;
                }
                
            }
        }
        private void Ready_Click(object sender, EventArgs e)
        {

        }

        
    }
}
