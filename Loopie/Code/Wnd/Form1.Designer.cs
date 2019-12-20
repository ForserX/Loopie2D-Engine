using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Loopie2D
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
            this.ExitButton = new System.Windows.Forms.Label();
            this.Options = new System.Windows.Forms.Label();
            this.NewGame = new System.Windows.Forms.Label();
            this.Next = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Label();
            this.SaveGameButton = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Label();
            this.CloseEngineButton = new System.Windows.Forms.Label();
            this.HideWindowsButton = new System.Windows.Forms.Label();
            this.FullscreenCheckBox = new System.Windows.Forms.CheckBox();
            this.LoadList = new System.Windows.Forms.ListBox();
            this.MessBox_1 = new System.Windows.Forms.PictureBox();
            this.СancelButton = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InputNameLable = new System.Windows.Forms.Label();
            this.UniversalPanel = new System.Windows.Forms.Panel();
            this.SpeakerName = new System.Windows.Forms.Label();
            this.SoundFlagCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_1)).BeginInit();
            this.UniversalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitButton.AutoSize = true;
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Location = new System.Drawing.Point(0, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(0, 13);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Click += new System.EventHandler(this.ExitClickHandle);
            // 
            // Options
            // 
            this.Options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Options.AutoSize = true;
            this.Options.BackColor = System.Drawing.Color.Transparent;
            this.Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Options.Location = new System.Drawing.Point(12, 457);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(99, 22);
            this.Options.TabIndex = 7;
            this.Options.Text = "Настройки";
            this.Options.Click += new System.EventHandler(this.OptionsClickHandle);
            // 
            // NewGame
            // 
            this.NewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewGame.AutoSize = true;
            this.NewGame.BackColor = System.Drawing.Color.Transparent;
            this.NewGame.Location = new System.Drawing.Point(0, 0);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(0, 13);
            this.NewGame.TabIndex = 8;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Next
            // 
            this.Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Next.AutoSize = true;
            this.Next.BackColor = System.Drawing.Color.Transparent;
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.Location = new System.Drawing.Point(12, 326);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(115, 22);
            this.Next.TabIndex = 9;
            this.Next.Text = "Продолжить";
            this.Next.Visible = false;
            this.Next.Click += new System.EventHandler(this.NextClickHandle);
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadGameButton.AutoSize = true;
            this.LoadGameButton.BackColor = System.Drawing.Color.Transparent;
            this.LoadGameButton.Location = new System.Drawing.Point(0, 0);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(0, 13);
            this.LoadGameButton.TabIndex = 10;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameClickHandle);
            // 
            // SaveGameButton
            // 
            this.SaveGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveGameButton.AutoSize = true;
            this.SaveGameButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveGameButton.Location = new System.Drawing.Point(0, 0);
            this.SaveGameButton.Name = "SaveGameButton";
            this.SaveGameButton.Size = new System.Drawing.Size(0, 13);
            this.SaveGameButton.TabIndex = 11;
            this.SaveGameButton.Visible = false;
            this.SaveGameButton.Click += new System.EventHandler(this.SaveGameClickHandle);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.AutoSize = true;
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(12, 488);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(63, 22);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Назад";
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackClickHandle);
            // 
            // CloseEngineButton
            // 
            this.CloseEngineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseEngineButton.AutoSize = true;
            this.CloseEngineButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseEngineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseEngineButton.Location = new System.Drawing.Point(965, -1);
            this.CloseEngineButton.Name = "CloseEngineButton";
            this.CloseEngineButton.Size = new System.Drawing.Size(14, 17);
            this.CloseEngineButton.TabIndex = 15;
            this.CloseEngineButton.Text = "x";
            this.CloseEngineButton.Click += new System.EventHandler(this.CloseEngineClickHandle);
            // 
            // HideWindowsButton
            // 
            this.HideWindowsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideWindowsButton.AutoSize = true;
            this.HideWindowsButton.BackColor = System.Drawing.Color.Transparent;
            this.HideWindowsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HideWindowsButton.Location = new System.Drawing.Point(947, -4);
            this.HideWindowsButton.Name = "HideWindowsButton";
            this.HideWindowsButton.Size = new System.Drawing.Size(16, 17);
            this.HideWindowsButton.TabIndex = 16;
            this.HideWindowsButton.Text = "_";
            this.HideWindowsButton.Click += new System.EventHandler(this.HideWindowsClick);
            // 
            // FullscreenCheckBox
            // 
            this.FullscreenCheckBox.AutoSize = true;
            this.FullscreenCheckBox.Location = new System.Drawing.Point(10, 19);
            this.FullscreenCheckBox.Name = "FullscreenCheckBox";
            this.FullscreenCheckBox.Size = new System.Drawing.Size(145, 17);
            this.FullscreenCheckBox.TabIndex = 17;
            this.FullscreenCheckBox.Text = "Полноэкранный режим";
            this.FullscreenCheckBox.UseVisualStyleBackColor = true;
            this.FullscreenCheckBox.Visible = false;
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
            // MessBox_1
            // 
            this.MessBox_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessBox_1.BackColor = System.Drawing.Color.Transparent;
            this.MessBox_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MessBox_1.BackgroundImage")));
            this.MessBox_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MessBox_1.Location = new System.Drawing.Point(0, 345);
            this.MessBox_1.Name = "MessBox_1";
            this.MessBox_1.Size = new System.Drawing.Size(979, 134);
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
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClickHandle);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // InputNameLable
            // 
            this.InputNameLable.AutoSize = true;
            this.InputNameLable.BackColor = System.Drawing.Color.Transparent;
            this.InputNameLable.Location = new System.Drawing.Point(46, 12);
            this.InputNameLable.Name = "InputNameLable";
            this.InputNameLable.Size = new System.Drawing.Size(100, 13);
            this.InputNameLable.TabIndex = 10;
            this.InputNameLable.Text = "Введите название";
            this.InputNameLable.Visible = false;
            // 
            // UniversalPanel
            // 
            this.UniversalPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UniversalPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UniversalPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UniversalPanel.BackgroundImage")));
            this.UniversalPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UniversalPanel.Controls.Add(this.СancelButton);
            this.UniversalPanel.Controls.Add(this.InputNameLable);
            this.UniversalPanel.Controls.Add(this.SaveButton);
            this.UniversalPanel.Controls.Add(this.textBox1);
            this.UniversalPanel.Location = new System.Drawing.Point(397, 147);
            this.UniversalPanel.Name = "UniversalPanel";
            this.UniversalPanel.Size = new System.Drawing.Size(190, 104);
            this.UniversalPanel.TabIndex = 27;
            this.UniversalPanel.Visible = false;
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
            // SoundFlagCheck
            // 
            this.SoundFlagCheck.AutoSize = true;
            this.SoundFlagCheck.BackColor = System.Drawing.Color.Transparent;
            this.SoundFlagCheck.Location = new System.Drawing.Point(10, 38);
            this.SoundFlagCheck.Name = "SoundFlagCheck";
            this.SoundFlagCheck.Size = new System.Drawing.Size(66, 17);
            this.SoundFlagCheck.TabIndex = 38;
            this.SoundFlagCheck.Text = "Музыка";
            this.SoundFlagCheck.UseVisualStyleBackColor = false;
            this.SoundFlagCheck.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 528);
            this.ControlBox = false;
            this.Controls.Add(this.SoundFlagCheck);
            this.Controls.Add(this.SpeakerName);
            this.Controls.Add(this.UniversalPanel);
            this.Controls.Add(this.MessBox_1);
            this.Controls.Add(this.LoadList);
            this.Controls.Add(this.FullscreenCheckBox);
            this.Controls.Add(this.HideWindowsButton);
            this.Controls.Add(this.CloseEngineButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveGameButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.ExitButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MessBox_1)).EndInit();
            this.UniversalPanel.ResumeLayout(false);
            this.UniversalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label ExitButton;
        private System.Windows.Forms.Label Options;
        private System.Windows.Forms.Label NewGame;
        private System.Windows.Forms.Label Next;
        private System.Windows.Forms.Label LoadGameButton;
        private System.Windows.Forms.Label SaveGameButton;
        private System.Windows.Forms.Label BackButton;
        private System.Windows.Forms.Label CloseEngineButton;
        private System.Windows.Forms.Label HideWindowsButton;
        private System.Windows.Forms.CheckBox FullscreenCheckBox;
        private ListBox LoadList;
        private Label СancelButton;
        private Label SaveButton;
        private TextBox textBox1;
        private Label InputNameLable;
        private Panel UniversalPanel;
        private Label SpeakerName;
        private PictureBox MessBox_1;
        private CheckBox SoundFlagCheck;
    }
}

