using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Visual
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._exit = new System.Windows.Forms.Label();
            this.Options = new System.Windows.Forms.Label();
            this.NewGame = new System.Windows.Forms.Label();
            this.Next = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveGame = new System.Windows.Forms.Label();
            this.ago = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LoadList = new System.Windows.Forms.ListBox();
            this.ALeft = new System.Windows.Forms.PictureBox();
            this.CLeft = new System.Windows.Forms.PictureBox();
            this.Center = new System.Windows.Forms.PictureBox();
            this.CRight = new System.Windows.Forms.PictureBox();
            this.ARight = new System.Windows.Forms.PictureBox();
            this.MessBox_1 = new System.Windows.Forms.PictureBox();
            this.СancelButton = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MessBox_2 = new System.Windows.Forms.PictureBox();
            this.MessBox_3 = new System.Windows.Forms.PictureBox();
            this.MessBox_4 = new System.Windows.Forms.PictureBox();
            this.MessBox_5 = new System.Windows.Forms.PictureBox();
            this.SpeakerName = new System.Windows.Forms.Label();
            this.mess_1 = new System.Windows.Forms.Label();
            this.mess_2 = new System.Windows.Forms.Label();
            this.mess_3 = new System.Windows.Forms.Label();
            this.mess_4 = new System.Windows.Forms.Label();
            this.mess_5 = new System.Windows.Forms.Label();
            this.flag_snd = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(979, 529);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // _exit
            // 
            this._exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._exit.AutoSize = true;
            this._exit.BackColor = System.Drawing.Color.White;
            this._exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._exit.Location = new System.Drawing.Point(12, 488);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(65, 22);
            this._exit.TabIndex = 6;
            this._exit.Text = "Выход";
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // Options
            // 
            this.Options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Options.AutoSize = true;
            this.Options.BackColor = System.Drawing.Color.White;
            this.Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Options.Location = new System.Drawing.Point(12, 457);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(99, 22);
            this.Options.TabIndex = 7;
            this.Options.Text = "Настройки";
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // NewGame
            // 
            this.NewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewGame.AutoSize = true;
            this.NewGame.BackColor = System.Drawing.Color.White;
            this.NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame.Location = new System.Drawing.Point(12, 357);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(108, 22);
            this.NewGame.TabIndex = 8;
            this.NewGame.Text = "Новая Игра";
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Next
            // 
            this.Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Next.AutoSize = true;
            this.Next.BackColor = System.Drawing.Color.White;
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.Location = new System.Drawing.Point(12, 326);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(115, 22);
            this.Next.TabIndex = 9;
            this.Next.Text = "Продолжить";
            this.Next.Visible = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Загрузить игру";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // SaveGame
            // 
            this.SaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveGame.AutoSize = true;
            this.SaveGame.BackColor = System.Drawing.Color.White;
            this.SaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveGame.Location = new System.Drawing.Point(12, 390);
            this.SaveGame.Name = "SaveGame";
            this.SaveGame.Size = new System.Drawing.Size(143, 22);
            this.SaveGame.TabIndex = 11;
            this.SaveGame.Text = "Сохранить Игру";
            this.SaveGame.Click += new System.EventHandler(this.SaveGame_Click);
            // 
            // ago
            // 
            this.ago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ago.AutoSize = true;
            this.ago.BackColor = System.Drawing.Color.White;
            this.ago.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ago.Location = new System.Drawing.Point(12, 488);
            this.ago.Name = "ago";
            this.ago.Size = new System.Drawing.Size(63, 22);
            this.ago.TabIndex = 14;
            this.ago.Text = "Назад";
            this.ago.Visible = false;
            this.ago.Click += new System.EventHandler(this.ago_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(965, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "x";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(947, -4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "_";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Полноэкранный режим";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // LoadList
            // 
            this.LoadList.FormattingEnabled = true;
            this.LoadList.Location = new System.Drawing.Point(847, 19);
            this.LoadList.Name = "LoadList";
            this.LoadList.Size = new System.Drawing.Size(132, 511);
            this.LoadList.TabIndex = 18;
            this.LoadList.Visible = false;
            this.LoadList.SelectedIndexChanged += new System.EventHandler(this.LoadList_SelectedIndexChanged);
            // 
            // ALeft
            // 
            this.ALeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ALeft.BackColor = System.Drawing.Color.Transparent;
            this.ALeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ALeft.Location = new System.Drawing.Point(0, 61);
            this.ALeft.Name = "ALeft";
            this.ALeft.Size = new System.Drawing.Size(198, 467);
            this.ALeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ALeft.TabIndex = 20;
            this.ALeft.TabStop = false;
            // 
            // CLeft
            // 
            this.CLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CLeft.BackColor = System.Drawing.Color.Transparent;
            this.CLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CLeft.Location = new System.Drawing.Point(197, 61);
            this.CLeft.Name = "CLeft";
            this.CLeft.Size = new System.Drawing.Size(197, 467);
            this.CLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CLeft.TabIndex = 21;
            this.CLeft.TabStop = false;
            // 
            // Center
            // 
            this.Center.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Center.BackColor = System.Drawing.Color.Transparent;
            this.Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Center.Location = new System.Drawing.Point(393, 61);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(200, 467);
            this.Center.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Center.TabIndex = 22;
            this.Center.TabStop = false;
            // 
            // CRight
            // 
            this.CRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CRight.BackColor = System.Drawing.Color.Transparent;
            this.CRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CRight.Location = new System.Drawing.Point(592, 61);
            this.CRight.Name = "CRight";
            this.CRight.Size = new System.Drawing.Size(195, 467);
            this.CRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CRight.TabIndex = 23;
            this.CRight.TabStop = false;
            // 
            // ARight
            // 
            this.ARight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ARight.BackColor = System.Drawing.Color.Transparent;
            this.ARight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ARight.Location = new System.Drawing.Point(782, 61);
            this.ARight.Name = "ARight";
            this.ARight.Size = new System.Drawing.Size(197, 467);
            this.ARight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ARight.TabIndex = 24;
            this.ARight.TabStop = false;
            // 
            // MessBox_1
            // 
            this.MessBox_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessBox_1.BackColor = System.Drawing.Color.Transparent;
            this.MessBox_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MessBox_1.BackgroundImage")));
            this.MessBox_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessBox_1.Location = new System.Drawing.Point(16, 321);
            this.MessBox_1.Name = "MessBox_1";
            this.MessBox_1.Size = new System.Drawing.Size(182, 134);
            this.MessBox_1.TabIndex = 25;
            this.MessBox_1.TabStop = false;
            this.MessBox_1.Visible = false;
            // 
            // СancelButton
            // 
            this.СancelButton.AutoSize = true;
            this.СancelButton.BackColor = System.Drawing.Color.Transparent;
            this.СancelButton.Location = new System.Drawing.Point(121, 65);
            this.СancelButton.Name = "СancelButton";
            this.СancelButton.Size = new System.Drawing.Size(57, 13);
            this.СancelButton.TabIndex = 11;
            this.СancelButton.Text = "Отменить";
            this.СancelButton.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.Location = new System.Drawing.Point(14, 65);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(60, 13);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(46, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Введите название";
            this.label5.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.СancelButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(397, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 104);
            this.panel1.TabIndex = 27;
            this.panel1.Visible = false;
            // 
            // MessBox_2
            // 
            this.MessBox_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessBox_2.BackColor = System.Drawing.Color.Transparent;
            this.MessBox_2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MessBox_2.BackgroundImage")));
            this.MessBox_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessBox_2.Location = new System.Drawing.Point(0, 321);
            this.MessBox_2.Name = "MessBox_2";
            this.MessBox_2.Size = new System.Drawing.Size(197, 134);
            this.MessBox_2.TabIndex = 28;
            this.MessBox_2.TabStop = false;
            this.MessBox_2.Visible = false;
            // 
            // MessBox_3
            // 
            this.MessBox_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessBox_3.BackColor = System.Drawing.Color.Transparent;
            this.MessBox_3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MessBox_3.BackgroundImage")));
            this.MessBox_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessBox_3.Location = new System.Drawing.Point(0, 321);
            this.MessBox_3.Name = "MessBox_3";
            this.MessBox_3.Size = new System.Drawing.Size(201, 134);
            this.MessBox_3.TabIndex = 29;
            this.MessBox_3.TabStop = false;
            this.MessBox_3.Visible = false;
            // 
            // MessBox_4
            // 
            this.MessBox_4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessBox_4.BackColor = System.Drawing.Color.Transparent;
            this.MessBox_4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MessBox_4.BackgroundImage")));
            this.MessBox_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessBox_4.Location = new System.Drawing.Point(0, 321);
            this.MessBox_4.Name = "MessBox_4";
            this.MessBox_4.Size = new System.Drawing.Size(195, 134);
            this.MessBox_4.TabIndex = 30;
            this.MessBox_4.TabStop = false;
            this.MessBox_4.Visible = false;
            // 
            // MessBox_5
            // 
            this.MessBox_5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessBox_5.BackColor = System.Drawing.Color.Transparent;
            this.MessBox_5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MessBox_5.BackgroundImage")));
            this.MessBox_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessBox_5.Location = new System.Drawing.Point(-1, 321);
            this.MessBox_5.Name = "MessBox_5";
            this.MessBox_5.Size = new System.Drawing.Size(182, 134);
            this.MessBox_5.TabIndex = 31;
            this.MessBox_5.TabStop = false;
            this.MessBox_5.Visible = false;
            // 
            // SpeakerName
            // 
            this.SpeakerName.AutoSize = true;
            this.SpeakerName.BackColor = System.Drawing.Color.Transparent;
            this.SpeakerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeakerName.Location = new System.Drawing.Point(9, 9);
            this.SpeakerName.Name = "SpeakerName";
            this.SpeakerName.Size = new System.Drawing.Size(86, 13);
            this.SpeakerName.TabIndex = 32;
            this.SpeakerName.Text = "SpeakerName";
            this.SpeakerName.Visible = false;
            // 
            // mess_1
            // 
            this.mess_1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mess_1.AutoSize = true;
            this.mess_1.BackColor = System.Drawing.Color.Transparent;
            this.mess_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mess_1.Location = new System.Drawing.Point(9, 25);
            this.mess_1.MaximumSize = new System.Drawing.Size(190, 0);
            this.mess_1.Name = "mess_1";
            this.mess_1.Size = new System.Drawing.Size(0, 13);
            this.mess_1.TabIndex = 33;
            // 
            // mess_2
            // 
            this.mess_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mess_2.AutoSize = true;
            this.mess_2.BackColor = System.Drawing.Color.Transparent;
            this.mess_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mess_2.Location = new System.Drawing.Point(0, 25);
            this.mess_2.MaximumSize = new System.Drawing.Size(200, 0);
            this.mess_2.Name = "mess_2";
            this.mess_2.Size = new System.Drawing.Size(0, 13);
            this.mess_2.TabIndex = 34;
            // 
            // mess_3
            // 
            this.mess_3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mess_3.AutoSize = true;
            this.mess_3.BackColor = System.Drawing.Color.Transparent;
            this.mess_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mess_3.Location = new System.Drawing.Point(0, 25);
            this.mess_3.MaximumSize = new System.Drawing.Size(200, 0);
            this.mess_3.Name = "mess_3";
            this.mess_3.Size = new System.Drawing.Size(0, 13);
            this.mess_3.TabIndex = 35;
            // 
            // mess_4
            // 
            this.mess_4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mess_4.AutoSize = true;
            this.mess_4.BackColor = System.Drawing.Color.Transparent;
            this.mess_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mess_4.Location = new System.Drawing.Point(0, 25);
            this.mess_4.MaximumSize = new System.Drawing.Size(200, 0);
            this.mess_4.Name = "mess_4";
            this.mess_4.Size = new System.Drawing.Size(0, 13);
            this.mess_4.TabIndex = 36;
            // 
            // mess_5
            // 
            this.mess_5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mess_5.AutoSize = true;
            this.mess_5.BackColor = System.Drawing.Color.Transparent;
            this.mess_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mess_5.Location = new System.Drawing.Point(0, 25);
            this.mess_5.MaximumSize = new System.Drawing.Size(200, 0);
            this.mess_5.Name = "mess_5";
            this.mess_5.Size = new System.Drawing.Size(0, 13);
            this.mess_5.TabIndex = 37;
            // 
            // flag_snd
            // 
            this.flag_snd.AutoSize = true;
            this.flag_snd.BackColor = System.Drawing.Color.Transparent;
            this.flag_snd.Location = new System.Drawing.Point(10, 38);
            this.flag_snd.Name = "flag_snd";
            this.flag_snd.Size = new System.Drawing.Size(66, 17);
            this.flag_snd.TabIndex = 38;
            this.flag_snd.Text = "Музыка";
            this.flag_snd.UseVisualStyleBackColor = false;
            this.flag_snd.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 528);
            this.ControlBox = false;
            this.Controls.Add(this.flag_snd);
            this.Controls.Add(this.mess_5);
            this.Controls.Add(this.mess_4);
            this.Controls.Add(this.mess_3);
            this.Controls.Add(this.mess_2);
            this.Controls.Add(this.mess_1);
            this.Controls.Add(this.SpeakerName);
            this.Controls.Add(this.MessBox_5);
            this.Controls.Add(this.MessBox_4);
            this.Controls.Add(this.MessBox_3);
            this.Controls.Add(this.MessBox_2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MessBox_1);
            this.Controls.Add(this.ARight);
            this.Controls.Add(this.CRight);
            this.Controls.Add(this.Center);
            this.Controls.Add(this.CLeft);
            this.Controls.Add(this.ALeft);
            this.Controls.Add(this.LoadList);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ago);
            this.Controls.Add(this.SaveGame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.Options);
            this.Controls.Add(this._exit);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label _exit;
        private System.Windows.Forms.Label Options;
        private System.Windows.Forms.Label NewGame;
        private System.Windows.Forms.Label Next;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SaveGame;
        private System.Windows.Forms.Label ago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private ListBox LoadList;
        private PictureBox ALeft;
        private PictureBox CLeft;
        private PictureBox Center;
        private PictureBox CRight;
        private PictureBox ARight;
        private Label СancelButton;
        private Label SaveButton;
        private TextBox textBox1;
        private Label label5;
        private Panel panel1;
        private Label SpeakerName;
        private Label mess_1;
        private Label mess_2;
        private Label mess_3;
        private Label mess_4;
        private Label mess_5;
        private PictureBox MessBox_1;
        private PictureBox MessBox_2;
        private PictureBox MessBox_3;
        private PictureBox MessBox_4;
        private PictureBox MessBox_5;
        private CheckBox flag_snd;
    }
}

