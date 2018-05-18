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
            this.pictureBox1.Location = new System.Drawing.Point(0, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 92);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(49, 6);
            this.lName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(49, 17);
            this.lName.TabIndex = 1;
            this.lName.Text = "Name";
            // 
            // lPower
            // 
            this.lPower.AutoSize = true;
            this.lPower.BackColor = System.Drawing.Color.Red;
            this.lPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPower.Location = new System.Drawing.Point(4, 122);
            this.lPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPower.Name = "lPower";
            this.lPower.Size = new System.Drawing.Size(19, 20);
            this.lPower.TabIndex = 2;
            this.lPower.Text = "0";
            // 
            // lHealth
            // 
            this.lHealth.AutoSize = true;
            this.lHealth.BackColor = System.Drawing.Color.Aqua;
            this.lHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lHealth.Location = new System.Drawing.Point(117, 121);
            this.lHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lHealth.Name = "lHealth";
            this.lHealth.Size = new System.Drawing.Size(19, 20);
            this.lHealth.TabIndex = 3;
            this.lHealth.Text = "0";
            this.lHealth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lPrice
            // 
            this.lPrice.AutoSize = true;
            this.lPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPrice.Location = new System.Drawing.Point(61, 140);
            this.lPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(19, 20);
            this.lPrice.TabIndex = 4;
            this.lPrice.Text = "0";
            // 
            // CardsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Resource1.ФОН_ЛИСТА;
            this.Controls.Add(this.lPrice);
            this.Controls.Add(this.lHealth);
            this.Controls.Add(this.lPower);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CardsForm";
            this.Size = new System.Drawing.Size(139, 161);
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
