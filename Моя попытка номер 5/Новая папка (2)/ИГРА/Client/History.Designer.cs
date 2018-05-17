namespace Client
{
    partial class History
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ris = new System.Windows.Forms.PictureBox();
            this.bNext = new System.Windows.Forms.Button();
            this.tBtext = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Ris)).BeginInit();
            this.SuspendLayout();
            // 
            // Ris
            // 
            this.Ris.Location = new System.Drawing.Point(139, 116);
            this.Ris.Name = "Ris";
            this.Ris.Size = new System.Drawing.Size(201, 335);
            this.Ris.TabIndex = 0;
            this.Ris.TabStop = false;
            // 
            // bNext
            // 
            this.bNext.BackgroundImage = global::Client.Resource1.ФОН_КНОПКИ;
            this.bNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bNext.Location = new System.Drawing.Point(683, 484);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(76, 29);
            this.bNext.TabIndex = 1;
            this.bNext.Text = "Дальше";
            this.bNext.UseVisualStyleBackColor = true;
            // 
            // tBtext
            // 
            this.tBtext.Enabled = false;
            this.tBtext.Location = new System.Drawing.Point(346, 116);
            this.tBtext.Multiline = true;
            this.tBtext.Name = "tBtext";
            this.tBtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBtext.Size = new System.Drawing.Size(426, 335);
            this.tBtext.TabIndex = 2;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lName.Image = global::Client.Resource1.History;
            this.lName.Location = new System.Drawing.Point(349, 18);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(126, 46);
            this.lName.TabIndex = 3;
            this.lName.Text = "label1";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Resource1.History1;
            this.ClientSize = new System.Drawing.Size(874, 516);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tBtext);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.Ris);
            this.Name = "History";
            this.Text = "History";
            ((System.ComponentModel.ISupportInitialize)(this.Ris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Ris;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.TextBox tBtext;
        private System.Windows.Forms.Label lName;
    }
}