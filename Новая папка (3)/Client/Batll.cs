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
        public Batll()
        {
            InitializeComponent();
        }

        private void cardsForm1_MouseDown(object sender, MouseEventArgs e)
        {
            cardsForm1.DoDragDrop(sender, DragDropEffects.Copy);
        }

        private void cardsForm1_Move(object sender, EventArgs e)
        {
            cardsForm1.MyPictureBox.Image = null;
            cardsForm1.Visible = false;
            
        }
        
    }
}
