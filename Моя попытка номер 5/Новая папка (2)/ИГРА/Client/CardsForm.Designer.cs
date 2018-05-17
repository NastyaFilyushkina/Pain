namespace Client
{
    partial class CardsForm
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lName = new System.Windows.Forms.Label();
            this.lPower = new System.Windows.Forms.Label();
            this.lHealth = new System.Windows.Forms.Label();
            this.lPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 75);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(37, 5);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(39, 13);
            this.lName.TabIndex = 1;
            this.lName.Text = "Name";
            // 
            // lPower
            // 
            this.lPower.AutoSize = true;
            this.lPower.BackColor = System.Drawing.Color.Red;
            this.lPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPower.Location = new System.Drawing.Point(3, 99);
            this.lPower.Name = "lPower";
            this.lPower.Size = new System.Drawing.Size(16, 16);
            this.lPower.TabIndex = 2;
            this.lPower.Text = "0";
            // 
            // lHealth
            // 
            this.lHealth.AutoSize = true;
            this.lHealth.BackColor = System.Drawing.Color.Aqua;
            this.lHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lHealth.Location = new System.Drawing.Point(88, 98);
            this.lHealth.Name = "lHealth";
            this.lHealth.Size = new System.Drawing.Size(16, 16);
            this.lHealth.TabIndex = 3;
            this.lHealth.Text = "0";
            this.lHealth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lPrice
            // 
            this.lPrice.AutoSize = true;
            this.lPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPrice.Location = new System.Drawing.Point(46, 114);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(16, 16);
            this.lPrice.TabIndex = 4;
            this.lPrice.Text = "0";
            // 
            // CardsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Resource1.ФОН_ЛИСТА;
            this.Controls.Add(this.lPrice);
            this.Controls.Add(this.lHealth);
            this.Controls.Add(this.lPower);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CardsForm";
            this.Size = new System.Drawing.Size(104, 131);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CardsForm_Paint);
            this.Resize += new System.EventHandler(this.CardsForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lPower;
        private System.Windows.Forms.Label lHealth;
        private System.Windows.Forms.Label lPrice;
    }
}
