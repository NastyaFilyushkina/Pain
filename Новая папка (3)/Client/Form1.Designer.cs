﻿namespace Client
{
    partial class MainMenu
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameUserLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SignINBut = new System.Windows.Forms.Button();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.StartGameBUT = new System.Windows.Forms.Button();
            this.EscapeBUT = new System.Windows.Forms.Button();
            this.SettingsBUT = new System.Windows.Forms.Button();
            this.ListOfPlayers = new System.Windows.Forms.ListBox();
            this.Title = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.groupChoose = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.RandomEnemyBUT = new System.Windows.Forms.Button();
            this.ChooseEnemyBUT = new System.Windows.Forms.Button();
            this.Title2 = new System.Windows.Forms.Label();
            this.ListOfReadyPlayer = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupChoose.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameUserLabel
            // 
            this.NameUserLabel.AutoSize = true;
            this.NameUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameUserLabel.Location = new System.Drawing.Point(279, 396);
            this.NameUserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameUserLabel.Name = "NameUserLabel";
            this.NameUserLabel.Size = new System.Drawing.Size(120, 20);
            this.NameUserLabel.TabIndex = 0;
            this.NameUserLabel.Text = "Введите имя";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.Location = new System.Drawing.Point(423, 396);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(187, 26);
            this.NameTextBox.TabIndex = 1;
            // 
            // SignINBut
            // 
            this.SignINBut.BackgroundImage = global::Client.Resource1.ФОН_КНОПКИ;
            this.SignINBut.Font = new System.Drawing.Font("Papyrus", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignINBut.Location = new System.Drawing.Point(346, 442);
            this.SignINBut.Margin = new System.Windows.Forms.Padding(2);
            this.SignINBut.Name = "SignINBut";
            this.SignINBut.Size = new System.Drawing.Size(225, 50);
            this.SignINBut.TabIndex = 2;
            this.SignINBut.Text = "Регистрация";
            this.SignINBut.UseVisualStyleBackColor = true;
            this.SignINBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.Location = new System.Drawing.Point(169, 140);
            this.ErrorMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.ErrorMessage.TabIndex = 3;
            // 
            // StartGameBUT
            // 
            this.StartGameBUT.BackgroundImage = global::Client.Resource1.ФОН_НАЧАТЬ;
            this.StartGameBUT.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameBUT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StartGameBUT.Location = new System.Drawing.Point(346, 78);
            this.StartGameBUT.Margin = new System.Windows.Forms.Padding(2);
            this.StartGameBUT.Name = "StartGameBUT";
            this.StartGameBUT.Size = new System.Drawing.Size(185, 81);
            this.StartGameBUT.TabIndex = 4;
            this.StartGameBUT.Text = "Начать Игру";
            this.StartGameBUT.UseVisualStyleBackColor = true;
            this.StartGameBUT.Visible = false;
            this.StartGameBUT.Click += new System.EventHandler(this.StartGameBUT_Click);
            // 
            // EscapeBUT
            // 
            this.EscapeBUT.BackgroundImage = global::Client.Resource1.ФОН_НАЧАТЬ;
            this.EscapeBUT.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EscapeBUT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EscapeBUT.Location = new System.Drawing.Point(346, 287);
            this.EscapeBUT.Margin = new System.Windows.Forms.Padding(2);
            this.EscapeBUT.Name = "EscapeBUT";
            this.EscapeBUT.Size = new System.Drawing.Size(185, 81);
            this.EscapeBUT.TabIndex = 5;
            this.EscapeBUT.Text = "Выход";
            this.EscapeBUT.UseVisualStyleBackColor = true;
            this.EscapeBUT.Visible = false;
            // 
            // SettingsBUT
            // 
            this.SettingsBUT.BackgroundImage = global::Client.Resource1.ФОН_НАЧАТЬ;
            this.SettingsBUT.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBUT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SettingsBUT.Location = new System.Drawing.Point(346, 182);
            this.SettingsBUT.Margin = new System.Windows.Forms.Padding(2);
            this.SettingsBUT.Name = "SettingsBUT";
            this.SettingsBUT.Size = new System.Drawing.Size(185, 81);
            this.SettingsBUT.TabIndex = 6;
            this.SettingsBUT.Text = "Настройки";
            this.SettingsBUT.UseVisualStyleBackColor = true;
            this.SettingsBUT.Visible = false;
            // 
            // ListOfPlayers
            // 
            this.ListOfPlayers.BackColor = System.Drawing.Color.BurlyWood;
            this.ListOfPlayers.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfPlayers.FormattingEnabled = true;
            this.ListOfPlayers.ItemHeight = 21;
            this.ListOfPlayers.Location = new System.Drawing.Point(331, 63);
            this.ListOfPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.ListOfPlayers.Name = "ListOfPlayers";
            this.ListOfPlayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListOfPlayers.Size = new System.Drawing.Size(234, 172);
            this.ListOfPlayers.TabIndex = 7;
            this.ListOfPlayers.Visible = false;
            this.ListOfPlayers.SelectedIndexChanged += new System.EventHandler(this.ListOfPlayers_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Coral;
            this.Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Title.Font = new System.Drawing.Font("Snap ITC", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Image = global::Client.Resource1.ФОН_КНОПКИ;
            this.Title.Location = new System.Drawing.Point(318, 20);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(260, 29);
            this.Title.TabIndex = 8;
            this.Title.Text = "Список игроков";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.UseCompatibleTextRendering = true;
            this.Title.Visible = false;
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.Coral;
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status.Font = new System.Drawing.Font("Snap ITC", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Image = global::Client.Resource1.ФОН_КНОПКИ;
            this.Status.Location = new System.Drawing.Point(42, 20);
            this.Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(233, 29);
            this.Status.TabIndex = 9;
            this.Status.Text = "Мой статус";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Status.UseCompatibleTextRendering = true;
            this.Status.Visible = false;
            // 
            // groupChoose
            // 
            this.groupChoose.BackgroundImage = global::Client.Resource1.ФОН_ЛИСТА;
            this.groupChoose.Controls.Add(this.radioButton2);
            this.groupChoose.Controls.Add(this.radioButton1);
            this.groupChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupChoose.Location = new System.Drawing.Point(62, 63);
            this.groupChoose.Margin = new System.Windows.Forms.Padding(2);
            this.groupChoose.Name = "groupChoose";
            this.groupChoose.Padding = new System.Windows.Forms.Padding(2);
            this.groupChoose.Size = new System.Drawing.Size(200, 173);
            this.groupChoose.TabIndex = 10;
            this.groupChoose.TabStop = false;
            this.groupChoose.Text = "СТАТУС";
            this.groupChoose.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(32, 104);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 28);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Перерыв";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 54);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(137, 28);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Хочу играть";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RandomEnemyBUT
            // 
            this.RandomEnemyBUT.BackgroundImage = global::Client.Resource1.ФОН_ЛИСТА;
            this.RandomEnemyBUT.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomEnemyBUT.Location = new System.Drawing.Point(82, 266);
            this.RandomEnemyBUT.Margin = new System.Windows.Forms.Padding(2);
            this.RandomEnemyBUT.Name = "RandomEnemyBUT";
            this.RandomEnemyBUT.Size = new System.Drawing.Size(152, 69);
            this.RandomEnemyBUT.TabIndex = 11;
            this.RandomEnemyBUT.Text = "Случайный противник";
            this.RandomEnemyBUT.UseVisualStyleBackColor = true;
            this.RandomEnemyBUT.Visible = false;
            this.RandomEnemyBUT.Click += new System.EventHandler(this.RandomEnemyBUT_Click);
            // 
            // ChooseEnemyBUT
            // 
            this.ChooseEnemyBUT.BackgroundImage = global::Client.Resource1.ФОН_ЛИСТА;
            this.ChooseEnemyBUT.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseEnemyBUT.Location = new System.Drawing.Point(82, 360);
            this.ChooseEnemyBUT.Margin = new System.Windows.Forms.Padding(2);
            this.ChooseEnemyBUT.Name = "ChooseEnemyBUT";
            this.ChooseEnemyBUT.Size = new System.Drawing.Size(152, 68);
            this.ChooseEnemyBUT.TabIndex = 12;
            this.ChooseEnemyBUT.Text = "Выбрать противника";
            this.ChooseEnemyBUT.UseVisualStyleBackColor = true;
            this.ChooseEnemyBUT.Visible = false;
            this.ChooseEnemyBUT.Click += new System.EventHandler(this.ChooseEnemyBUT_Click);
            // 
            // Title2
            // 
            this.Title2.BackColor = System.Drawing.Color.Coral;
            this.Title2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Title2.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2.Image = global::Client.Resource1.ФОН_КНОПКИ;
            this.Title2.Location = new System.Drawing.Point(311, 256);
            this.Title2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(260, 51);
            this.Title2.TabIndex = 16;
            this.Title2.Text = "Список игроков  готовых к игре";
            this.Title2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title2.UseCompatibleTextRendering = true;
            this.Title2.Visible = false;
            // 
            // ListOfReadyPlayer
            // 
            this.ListOfReadyPlayer.BackColor = System.Drawing.Color.BurlyWood;
            this.ListOfReadyPlayer.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfReadyPlayer.FormattingEnabled = true;
            this.ListOfReadyPlayer.ItemHeight = 21;
            this.ListOfReadyPlayer.Location = new System.Drawing.Point(324, 329);
            this.ListOfReadyPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.ListOfReadyPlayer.Name = "ListOfReadyPlayer";
            this.ListOfReadyPlayer.Size = new System.Drawing.Size(234, 151);
            this.ListOfReadyPlayer.TabIndex = 15;
            this.ListOfReadyPlayer.Visible = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Client.Resource1.ФОН_НАЧАТЬ;
            this.button1.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(339, 428);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 81);
            this.button1.TabIndex = 14;
            this.button1.Text = "Настройки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Client.Resource1.ФОН_НАЧАТЬ;
            this.button2.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(339, 324);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 81);
            this.button2.TabIndex = 13;
            this.button2.Text = "Начать Игру";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Resource1.ФОН;
            this.ClientSize = new System.Drawing.Size(874, 516);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.ListOfReadyPlayer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ChooseEnemyBUT);
            this.Controls.Add(this.RandomEnemyBUT);
            this.Controls.Add(this.groupChoose);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ListOfPlayers);
            this.Controls.Add(this.SettingsBUT);
            this.Controls.Add(this.EscapeBUT);
            this.Controls.Add(this.StartGameBUT);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.SignINBut);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameUserLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Resize += new System.EventHandler(this.MainMenu_Resize);
            this.groupChoose.ResumeLayout(false);
            this.groupChoose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameUserLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button SignINBut;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Button StartGameBUT;
        private System.Windows.Forms.Button EscapeBUT;
        private System.Windows.Forms.Button SettingsBUT;
        private System.Windows.Forms.ListBox ListOfPlayers;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.GroupBox groupChoose;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button RandomEnemyBUT;
        private System.Windows.Forms.Button ChooseEnemyBUT;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.ListBox ListOfReadyPlayer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

