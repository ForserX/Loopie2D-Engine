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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.СancelButton = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ARight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.ALeft.Visible = false;
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
            this.CLeft.Visible = false;
            // 
            // Center
            // 
            this.Center.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Center.BackColor = System.Drawing.Color.Transparent;
            this.Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Center.Location = new System.Drawing.Point(393, 64);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(200, 464);
            this.Center.TabIndex = 22;
            this.Center.TabStop = false;
            // 
            // CRight
            // 
            this.CRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CRight.BackColor = System.Drawing.Color.Transparent;
            this.CRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CRight.Location = new System.Drawing.Point(593, 61);
            this.CRight.Name = "CRight";
            this.CRight.Size = new System.Drawing.Size(193, 467);
            this.CRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CRight.TabIndex = 23;
            this.CRight.TabStop = false;
            this.CRight.Visible = false;
            // 
            // ARight
            // 
            this.ARight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ARight.BackColor = System.Drawing.Color.Transparent;
            this.ARight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ARight.Location = new System.Drawing.Point(782, 61);
            this.ARight.Name = "ARight";
            this.ARight.Size = new System.Drawing.Size(197, 467);
            this.ARight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ARight.TabIndex = 24;
            this.ARight.TabStop = false;
            this.ARight.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(16, 382);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(947, 134);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 528);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private PictureBox pictureBox2;
        private Label СancelButton;
        private Label SaveButton;
        private TextBox textBox1;
        private Label label5;
        private Panel panel1;
    }
}

