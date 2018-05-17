using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class CardsForm : UserControl
    {
        int index;
        public CardsForm()
        {
            InitializeComponent();
            PaintControl();

        }

        public int Price
        {
            get
            {
                return int.Parse(lPrice.Text);
            }
            set
            {
                lPrice.Text = value.ToString();
            }
        }

        public int Health
        {
            get
            {
                return int.Parse(lHealth.Text);
            }
            set
            {
                lHealth.Text = value.ToString();
            }
        }

        public int Power
        {
            get
            {
                return int.Parse(lPower.Text);
            }
            set
            {
                lPower.Text = value.ToString();
            }
        }

        public string NameCards
        {
            get
            {
                return lName.Text;
            }
            set
            {
                lName.Text = value;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public PictureBox MyPictureBox
        {
           get { return pictureBox1; }

        }

        public void CardsForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        
        private void PaintControl()
        {
            this.Width = (int)(this.Height / 1.5);
            lName.Location = new Point(this.Width / 2 - this.Width / 4, 0);
            lName.Font = new Font(this.Font.FontFamily, (int)(0.1 * this.Width));
            lName.UseCompatibleTextRendering = true;
            lPower.Location = new Point(0, lName.Height + pictureBox1.Height);
            lPower.Font = new Font(this.Font.FontFamily, (int)(0.1 * this.Width));
            lPower.UseCompatibleTextRendering = true;
            lHealth.Location = new Point(this.Width - lHealth.Width, lName.Height + pictureBox1.Height);
            lHealth.Font = new Font(this.Font.FontFamily, (int)(0.1 * this.Width));
            lHealth.UseCompatibleTextRendering = true;
            lPrice.Location = new Point(this.Width / 2 - this.Width / 12, this.Height - lPrice.Height);
            lPrice.Font = new Font(this.Font.FontFamily, (int)(0.1 * this.Width));
            lPrice.UseCompatibleTextRendering = true;
            pictureBox1.Location = new Point(0, lName.Height);
            pictureBox1.Width = this.Width;
            pictureBox1.Height = (int)(0.6f * this.Height);

        }

        private void CardsForm_Paint(object sender, PaintEventArgs e)
        {
            PaintControl();
        }
    }
}
