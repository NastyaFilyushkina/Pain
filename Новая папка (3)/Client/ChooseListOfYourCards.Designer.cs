﻿namespace Client
{
    partial class ChooseListOfYourCards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseListOfYourCards));
            this.Ready = new System.Windows.Forms.Button();
            this.Cards = new System.Windows.Forms.GroupBox();
            this.Wait = new System.Windows.Forms.Label();
            this.cardsForm22 = new Client.CardsForm();
            this.cardsForm23 = new Client.CardsForm();
            this.cardsForm24 = new Client.CardsForm();
            this.cardsForm17 = new Client.CardsForm();
            this.cardsForm18 = new Client.CardsForm();
            this.cardsForm19 = new Client.CardsForm();
            this.cardsForm20 = new Client.CardsForm();
            this.cardsForm13 = new Client.CardsForm();
            this.cardsForm14 = new Client.CardsForm();
            this.cardsForm15 = new Client.CardsForm();
            this.cardsForm16 = new Client.CardsForm();
            this.cardsForm9 = new Client.CardsForm();
            this.cardsForm10 = new Client.CardsForm();
            this.cardsForm11 = new Client.CardsForm();
            this.cardsForm12 = new Client.CardsForm();
            this.cardsForm5 = new Client.CardsForm();
            this.cardsForm6 = new Client.CardsForm();
            this.cardsForm7 = new Client.CardsForm();
            this.cardsForm8 = new Client.CardsForm();
            this.cardsForm3 = new Client.CardsForm();
            this.cardsForm4 = new Client.CardsForm();
            this.cardsForm2 = new Client.CardsForm();
            this.cardsForm1 = new Client.CardsForm();
            this.label2 = new System.Windows.Forms.Label();
            this.Cards.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ready
            // 
            this.Ready.BackgroundImage = global::Client.Resource1.ФОН_КНОПКИ;
            this.Ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ready.Location = new System.Drawing.Point(509, 658);
            this.Ready.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ready.Name = "Ready";
            this.Ready.Size = new System.Drawing.Size(191, 52);
            this.Ready.TabIndex = 0;
            this.Ready.Text = "Готово!";
            this.Ready.UseVisualStyleBackColor = true;
            this.Ready.Visible = false;
            this.Ready.Click += new System.EventHandler(this.Ready_Click);
            // 
            // Cards
            // 
            this.Cards.BackColor = System.Drawing.Color.Sienna;
            this.Cards.Controls.Add(this.Wait);
            this.Cards.Controls.Add(this.cardsForm22);
            this.Cards.Controls.Add(this.cardsForm23);
            this.Cards.Controls.Add(this.cardsForm24);
            this.Cards.Controls.Add(this.cardsForm17);
            this.Cards.Controls.Add(this.cardsForm18);
            this.Cards.Controls.Add(this.cardsForm19);
            this.Cards.Controls.Add(this.cardsForm20);
            this.Cards.Controls.Add(this.cardsForm13);
            this.Cards.Controls.Add(this.cardsForm14);
            this.Cards.Controls.Add(this.cardsForm15);
            this.Cards.Controls.Add(this.cardsForm16);
            this.Cards.Controls.Add(this.cardsForm9);
            this.Cards.Controls.Add(this.cardsForm10);
            this.Cards.Controls.Add(this.cardsForm11);
            this.Cards.Controls.Add(this.cardsForm12);
            this.Cards.Controls.Add(this.cardsForm5);
            this.Cards.Controls.Add(this.cardsForm6);
            this.Cards.Controls.Add(this.cardsForm7);
            this.Cards.Controls.Add(this.cardsForm8);
            this.Cards.Controls.Add(this.cardsForm3);
            this.Cards.Controls.Add(this.cardsForm4);
            this.Cards.Controls.Add(this.cardsForm2);
            this.Cards.Controls.Add(this.cardsForm1);
            this.Cards.Location = new System.Drawing.Point(20, 48);
            this.Cards.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cards.Name = "Cards";
            this.Cards.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cards.Size = new System.Drawing.Size(1163, 606);
            this.Cards.TabIndex = 1;
            this.Cards.TabStop = false;
            this.Cards.Text = "Карты";
            // 
            // Wait
            // 
            this.Wait.BackColor = System.Drawing.Color.Coral;
            this.Wait.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Wait.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Wait.Location = new System.Drawing.Point(76, 245);
            this.Wait.Name = "Wait";
            this.Wait.Size = new System.Drawing.Size(1036, 77);
            this.Wait.TabIndex = 23;
            this.Wait.Text = "Подождите, ваш противник выбирает колоду!";
            this.Wait.Visible = false;
            // 
            // cardsForm22
            // 
            this.cardsForm22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm22.BackgroundImage")));
            this.cardsForm22.Health = 0;
            this.cardsForm22.Image = null;
            this.cardsForm22.Index = 0;
            this.cardsForm22.ISPRESSED = false;
            this.cardsForm22.Location = new System.Drawing.Point(853, 410);
            this.cardsForm22.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm22.Name = "cardsForm22";
            this.cardsForm22.NameCards = "Name";
            this.cardsForm22.Power = 0;
            this.cardsForm22.Price = 0;
            this.cardsForm22.Size = new System.Drawing.Size(102, 153);
            this.cardsForm22.TabIndex = 22;
            this.cardsForm22.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm23
            // 
            this.cardsForm23.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm23.BackgroundImage")));
            this.cardsForm23.Health = 0;
            this.cardsForm23.Image = null;
            this.cardsForm23.Index = 0;
            this.cardsForm23.ISPRESSED = false;
            this.cardsForm23.Location = new System.Drawing.Point(712, 410);
            this.cardsForm23.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm23.Name = "cardsForm23";
            this.cardsForm23.NameCards = "Name";
            this.cardsForm23.Power = 0;
            this.cardsForm23.Price = 0;
            this.cardsForm23.Size = new System.Drawing.Size(102, 153);
            this.cardsForm23.TabIndex = 21;
            this.cardsForm23.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm24
            // 
            this.cardsForm24.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm24.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm24.BackgroundImage")));
            this.cardsForm24.Health = 0;
            this.cardsForm24.Image = null;
            this.cardsForm24.Index = 0;
            this.cardsForm24.ISPRESSED = false;
            this.cardsForm24.Location = new System.Drawing.Point(579, 410);
            this.cardsForm24.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm24.Name = "cardsForm24";
            this.cardsForm24.NameCards = "Name";
            this.cardsForm24.Power = 0;
            this.cardsForm24.Price = 0;
            this.cardsForm24.Size = new System.Drawing.Size(102, 153);
            this.cardsForm24.TabIndex = 20;
            this.cardsForm24.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm17
            // 
            this.cardsForm17.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm17.BackgroundImage")));
            this.cardsForm17.Health = 0;
            this.cardsForm17.Image = null;
            this.cardsForm17.Index = 0;
            this.cardsForm17.ISPRESSED = false;
            this.cardsForm17.Location = new System.Drawing.Point(440, 410);
            this.cardsForm17.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm17.Name = "cardsForm17";
            this.cardsForm17.NameCards = "Name";
            this.cardsForm17.Power = 0;
            this.cardsForm17.Price = 0;
            this.cardsForm17.Size = new System.Drawing.Size(102, 153);
            this.cardsForm17.TabIndex = 19;
            this.cardsForm17.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm18
            // 
            this.cardsForm18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm18.BackgroundImage")));
            this.cardsForm18.Health = 0;
            this.cardsForm18.Image = null;
            this.cardsForm18.Index = 0;
            this.cardsForm18.ISPRESSED = false;
            this.cardsForm18.Location = new System.Drawing.Point(307, 410);
            this.cardsForm18.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm18.Name = "cardsForm18";
            this.cardsForm18.NameCards = "Name";
            this.cardsForm18.Power = 0;
            this.cardsForm18.Price = 0;
            this.cardsForm18.Size = new System.Drawing.Size(102, 153);
            this.cardsForm18.TabIndex = 18;
            this.cardsForm18.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm19
            // 
            this.cardsForm19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm19.BackgroundImage")));
            this.cardsForm19.Health = 0;
            this.cardsForm19.Image = null;
            this.cardsForm19.Index = 0;
            this.cardsForm19.ISPRESSED = false;
            this.cardsForm19.Location = new System.Drawing.Point(165, 410);
            this.cardsForm19.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm19.Name = "cardsForm19";
            this.cardsForm19.NameCards = "Name";
            this.cardsForm19.Power = 0;
            this.cardsForm19.Price = 0;
            this.cardsForm19.Size = new System.Drawing.Size(102, 153);
            this.cardsForm19.TabIndex = 17;
            this.cardsForm19.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm20
            // 
            this.cardsForm20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm20.BackgroundImage")));
            this.cardsForm20.Health = 0;
            this.cardsForm20.Image = null;
            this.cardsForm20.Index = 0;
            this.cardsForm20.ISPRESSED = false;
            this.cardsForm20.Location = new System.Drawing.Point(32, 410);
            this.cardsForm20.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm20.Name = "cardsForm20";
            this.cardsForm20.NameCards = "Name";
            this.cardsForm20.Power = 0;
            this.cardsForm20.Price = 0;
            this.cardsForm20.Size = new System.Drawing.Size(102, 153);
            this.cardsForm20.TabIndex = 16;
            this.cardsForm20.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm13
            // 
            this.cardsForm13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm13.BackgroundImage")));
            this.cardsForm13.Health = 0;
            this.cardsForm13.Image = null;
            this.cardsForm13.Index = 0;
            this.cardsForm13.ISPRESSED = false;
            this.cardsForm13.Location = new System.Drawing.Point(987, 206);
            this.cardsForm13.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm13.Name = "cardsForm13";
            this.cardsForm13.NameCards = "Name";
            this.cardsForm13.Power = 0;
            this.cardsForm13.Price = 0;
            this.cardsForm13.Size = new System.Drawing.Size(102, 153);
            this.cardsForm13.TabIndex = 15;
            this.cardsForm13.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm14
            // 
            this.cardsForm14.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm14.BackgroundImage")));
            this.cardsForm14.Health = 0;
            this.cardsForm14.Image = null;
            this.cardsForm14.Index = 0;
            this.cardsForm14.ISPRESSED = false;
            this.cardsForm14.Location = new System.Drawing.Point(853, 206);
            this.cardsForm14.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm14.Name = "cardsForm14";
            this.cardsForm14.NameCards = "Name";
            this.cardsForm14.Power = 0;
            this.cardsForm14.Price = 0;
            this.cardsForm14.Size = new System.Drawing.Size(102, 153);
            this.cardsForm14.TabIndex = 14;
            this.cardsForm14.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm15
            // 
            this.cardsForm15.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm15.BackgroundImage")));
            this.cardsForm15.Health = 0;
            this.cardsForm15.Image = null;
            this.cardsForm15.Index = 0;
            this.cardsForm15.ISPRESSED = false;
            this.cardsForm15.Location = new System.Drawing.Point(712, 206);
            this.cardsForm15.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm15.Name = "cardsForm15";
            this.cardsForm15.NameCards = "Name";
            this.cardsForm15.Power = 0;
            this.cardsForm15.Price = 0;
            this.cardsForm15.Size = new System.Drawing.Size(102, 153);
            this.cardsForm15.TabIndex = 13;
            this.cardsForm15.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm16
            // 
            this.cardsForm16.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm16.BackgroundImage")));
            this.cardsForm16.Health = 0;
            this.cardsForm16.Image = null;
            this.cardsForm16.Index = 0;
            this.cardsForm16.ISPRESSED = false;
            this.cardsForm16.Location = new System.Drawing.Point(579, 206);
            this.cardsForm16.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm16.Name = "cardsForm16";
            this.cardsForm16.NameCards = "Name";
            this.cardsForm16.Power = 0;
            this.cardsForm16.Price = 0;
            this.cardsForm16.Size = new System.Drawing.Size(102, 153);
            this.cardsForm16.TabIndex = 12;
            this.cardsForm16.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm9
            // 
            this.cardsForm9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm9.BackgroundImage")));
            this.cardsForm9.Health = 0;
            this.cardsForm9.Image = null;
            this.cardsForm9.Index = 0;
            this.cardsForm9.ISPRESSED = false;
            this.cardsForm9.Location = new System.Drawing.Point(440, 206);
            this.cardsForm9.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm9.Name = "cardsForm9";
            this.cardsForm9.NameCards = "Name";
            this.cardsForm9.Power = 0;
            this.cardsForm9.Price = 0;
            this.cardsForm9.Size = new System.Drawing.Size(102, 153);
            this.cardsForm9.TabIndex = 11;
            this.cardsForm9.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm10
            // 
            this.cardsForm10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm10.BackgroundImage")));
            this.cardsForm10.Health = 0;
            this.cardsForm10.Image = null;
            this.cardsForm10.Index = 0;
            this.cardsForm10.ISPRESSED = false;
            this.cardsForm10.Location = new System.Drawing.Point(307, 206);
            this.cardsForm10.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm10.Name = "cardsForm10";
            this.cardsForm10.NameCards = "Name";
            this.cardsForm10.Power = 0;
            this.cardsForm10.Price = 0;
            this.cardsForm10.Size = new System.Drawing.Size(102, 153);
            this.cardsForm10.TabIndex = 10;
            this.cardsForm10.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm11
            // 
            this.cardsForm11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm11.BackgroundImage")));
            this.cardsForm11.Health = 0;
            this.cardsForm11.Image = null;
            this.cardsForm11.Index = 0;
            this.cardsForm11.ISPRESSED = false;
            this.cardsForm11.Location = new System.Drawing.Point(165, 206);
            this.cardsForm11.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm11.Name = "cardsForm11";
            this.cardsForm11.NameCards = "Name";
            this.cardsForm11.Power = 0;
            this.cardsForm11.Price = 0;
            this.cardsForm11.Size = new System.Drawing.Size(102, 153);
            this.cardsForm11.TabIndex = 9;
            this.cardsForm11.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm12
            // 
            this.cardsForm12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm12.BackgroundImage")));
            this.cardsForm12.Health = 0;
            this.cardsForm12.Image = null;
            this.cardsForm12.Index = 0;
            this.cardsForm12.ISPRESSED = false;
            this.cardsForm12.Location = new System.Drawing.Point(32, 206);
            this.cardsForm12.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm12.Name = "cardsForm12";
            this.cardsForm12.NameCards = "Name";
            this.cardsForm12.Power = 0;
            this.cardsForm12.Price = 0;
            this.cardsForm12.Size = new System.Drawing.Size(102, 153);
            this.cardsForm12.TabIndex = 8;
            this.cardsForm12.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm5
            // 
            this.cardsForm5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm5.BackgroundImage")));
            this.cardsForm5.Health = 0;
            this.cardsForm5.Image = null;
            this.cardsForm5.Index = 0;
            this.cardsForm5.ISPRESSED = false;
            this.cardsForm5.Location = new System.Drawing.Point(987, 22);
            this.cardsForm5.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm5.Name = "cardsForm5";
            this.cardsForm5.NameCards = "Name";
            this.cardsForm5.Power = 0;
            this.cardsForm5.Price = 0;
            this.cardsForm5.Size = new System.Drawing.Size(102, 153);
            this.cardsForm5.TabIndex = 7;
            this.cardsForm5.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm6
            // 
            this.cardsForm6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm6.BackgroundImage")));
            this.cardsForm6.Health = 0;
            this.cardsForm6.Image = null;
            this.cardsForm6.Index = 0;
            this.cardsForm6.ISPRESSED = false;
            this.cardsForm6.Location = new System.Drawing.Point(853, 22);
            this.cardsForm6.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm6.Name = "cardsForm6";
            this.cardsForm6.NameCards = "Name";
            this.cardsForm6.Power = 0;
            this.cardsForm6.Price = 0;
            this.cardsForm6.Size = new System.Drawing.Size(102, 153);
            this.cardsForm6.TabIndex = 6;
            this.cardsForm6.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm7
            // 
            this.cardsForm7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm7.BackgroundImage")));
            this.cardsForm7.Health = 0;
            this.cardsForm7.Image = null;
            this.cardsForm7.Index = 0;
            this.cardsForm7.ISPRESSED = false;
            this.cardsForm7.Location = new System.Drawing.Point(712, 22);
            this.cardsForm7.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm7.Name = "cardsForm7";
            this.cardsForm7.NameCards = "Name";
            this.cardsForm7.Power = 0;
            this.cardsForm7.Price = 0;
            this.cardsForm7.Size = new System.Drawing.Size(102, 153);
            this.cardsForm7.TabIndex = 5;
            this.cardsForm7.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm8
            // 
            this.cardsForm8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm8.BackgroundImage")));
            this.cardsForm8.Health = 0;
            this.cardsForm8.Image = null;
            this.cardsForm8.Index = 0;
            this.cardsForm8.ISPRESSED = false;
            this.cardsForm8.Location = new System.Drawing.Point(579, 22);
            this.cardsForm8.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm8.Name = "cardsForm8";
            this.cardsForm8.NameCards = "Name";
            this.cardsForm8.Power = 0;
            this.cardsForm8.Price = 0;
            this.cardsForm8.Size = new System.Drawing.Size(102, 153);
            this.cardsForm8.TabIndex = 4;
            this.cardsForm8.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm3
            // 
            this.cardsForm3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm3.BackgroundImage")));
            this.cardsForm3.Health = 0;
            this.cardsForm3.Image = null;
            this.cardsForm3.Index = 0;
            this.cardsForm3.ISPRESSED = false;
            this.cardsForm3.Location = new System.Drawing.Point(440, 22);
            this.cardsForm3.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm3.Name = "cardsForm3";
            this.cardsForm3.NameCards = "Name";
            this.cardsForm3.Power = 0;
            this.cardsForm3.Price = 0;
            this.cardsForm3.Size = new System.Drawing.Size(102, 153);
            this.cardsForm3.TabIndex = 3;
            this.cardsForm3.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm4
            // 
            this.cardsForm4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm4.BackgroundImage")));
            this.cardsForm4.Health = 0;
            this.cardsForm4.Image = null;
            this.cardsForm4.Index = 0;
            this.cardsForm4.ISPRESSED = false;
            this.cardsForm4.Location = new System.Drawing.Point(307, 22);
            this.cardsForm4.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm4.Name = "cardsForm4";
            this.cardsForm4.NameCards = "Name";
            this.cardsForm4.Power = 0;
            this.cardsForm4.Price = 0;
            this.cardsForm4.Size = new System.Drawing.Size(102, 153);
            this.cardsForm4.TabIndex = 2;
            this.cardsForm4.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm2
            // 
            this.cardsForm2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm2.BackgroundImage")));
            this.cardsForm2.Health = 0;
            this.cardsForm2.Image = null;
            this.cardsForm2.Index = 0;
            this.cardsForm2.ISPRESSED = false;
            this.cardsForm2.Location = new System.Drawing.Point(165, 22);
            this.cardsForm2.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm2.Name = "cardsForm2";
            this.cardsForm2.NameCards = "Name";
            this.cardsForm2.Power = 0;
            this.cardsForm2.Price = 0;
            this.cardsForm2.Size = new System.Drawing.Size(102, 153);
            this.cardsForm2.TabIndex = 1;
            this.cardsForm2.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // cardsForm1
            // 
            this.cardsForm1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardsForm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardsForm1.BackgroundImage")));
            this.cardsForm1.Health = 0;
            this.cardsForm1.Image = null;
            this.cardsForm1.Index = 0;
            this.cardsForm1.ISPRESSED = false;
            this.cardsForm1.Location = new System.Drawing.Point(32, 22);
            this.cardsForm1.Margin = new System.Windows.Forms.Padding(5);
            this.cardsForm1.Name = "cardsForm1";
            this.cardsForm1.NameCards = "Name";
            this.cardsForm1.Power = 0;
            this.cardsForm1.Price = 0;
            this.cardsForm1.Size = new System.Drawing.Size(102, 153);
            this.cardsForm1.TabIndex = 0;
            this.cardsForm1.Click += new System.EventHandler(this.cardsFormCLick);
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Playbill", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(389, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(501, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите карты в колоду";
            // 
            // ChooseListOfYourCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Resource1.фон_игры;
            this.ClientSize = new System.Drawing.Size(1195, 722);
            this.Controls.Add(this.Cards);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ready);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChooseListOfYourCards";
            this.Text = "ChooseListOfYourCards";
            this.Resize += new System.EventHandler(this.ChooseListOfYourCards_Resize);
            this.Cards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ready;
        private System.Windows.Forms.GroupBox Cards;
        private System.Windows.Forms.Label label2;
        private CardsForm cardsForm22;
        private CardsForm cardsForm23;
        private CardsForm cardsForm24;
        private CardsForm cardsForm17;
        private CardsForm cardsForm18;
        private CardsForm cardsForm19;
        private CardsForm cardsForm20;
        private CardsForm cardsForm13;
        private CardsForm cardsForm14;
        private CardsForm cardsForm15;
        private CardsForm cardsForm16;
        private CardsForm cardsForm9;
        private CardsForm cardsForm10;
        private CardsForm cardsForm11;
        private CardsForm cardsForm12;
        private CardsForm cardsForm5;
        private CardsForm cardsForm6;
        private CardsForm cardsForm7;
        private CardsForm cardsForm8;
        private CardsForm cardsForm3;
        private CardsForm cardsForm4;
        private CardsForm cardsForm2;
        private CardsForm cardsForm1;
        private System.Windows.Forms.Label Wait;
    }
}