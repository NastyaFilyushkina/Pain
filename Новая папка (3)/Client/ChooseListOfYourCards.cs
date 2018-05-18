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
            int count = 0;
            foreach (Control value in this.groupBox1.Controls)
            {
                if (value.InvokeRequired)
                {
                    if (value is CardsForm)
                        (value as CardsForm).Invoke((MethodInvoker)(() => (value as CardsForm).Image = (Image)Resource1.ResourceManager.GetObject(list[count].Name)));
                    
                }
                else
                {
                    if (value is CardsForm)
                        (value as CardsForm).Image = (Image)Resource1.ResourceManager.GetObject(list[count].Name);
                }
                count++;
            }
        }
                
            
        

        private void cardsFormCLick(object sender, EventArgs e)
        {
            CardsForm card = (CardsForm)sender;
            if (card.BackgroundImage != Resource1.ВЫБРАННАЯКАРТА)
            {
                card.BackgroundImage = Resource1.ВЫБРАННАЯКАРТА;
            }
            else
            {
                card.BackgroundImage = Resource1.ФОН_ЛИСТА;
            }
        }
    }
}
