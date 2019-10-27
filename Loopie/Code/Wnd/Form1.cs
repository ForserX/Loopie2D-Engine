using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SoundSystem;

namespace Loopie2D
{
    public partial class Form1 : Form
    {
        // Interfaces/classes
        private INIManager ifs;
        private LuaAPI lua;
        private System.Windows.Media.MediaPlayer player;
        private System.Windows.Forms.Label[] label_text;

        //Vars
        private int sect, sect_next, sect_label, sect_lb_old, text_width, lnum, inum;
        private string heroname, ActorText_str, sect_old, sect_string, snd_old, GameScenarioFile;
        private string [] ActorText, GameList;
        private bool trygame, snd, GameStarted;
        Loopie.Code.Content.ContextBox Context;

        public void MakeContextBox(string Img, string Text, int X, int Y)
        {
            Context.Location = new System.Drawing.Point(X, Y);
            Context.FastInit(lua.images + Img, Text);
            Context.Visible = true;
        }

        public void ClosedContextBox()
        {
            Context.Visible = false;
        }
        //Code
        public Form1()
        {
            /// Init
            /// /// ContextBox
            Context = new Loopie.Code.Content.ContextBox();
            Context.Parent = pictureBox1;
            Context.BackColor = Color.Transparent;
            this.Controls.Add(this.Context);
            Context.Visible = false;

            /// /// General
            InitializeComponent();
			this.DoubleBuffered = true;
			/////////////////////////////////////////////////////////////////////
			/// ETC setter
			ifs = new INIManager();
			lua = new LuaAPI();

			this.ExitButton.Parent = pictureBox1;
			this.Options.Parent = pictureBox1;
			this.NewGame.Parent = pictureBox1;
			this.Next.Parent = pictureBox1;
			this.LoadGameButton.Parent = pictureBox1;
			this.SoundFlagCheck.Parent = pictureBox1;
			this.SaveButton.Parent = UniversalPanel;
			this.SaveGameButton.Parent = pictureBox1;
			this.BackButton.Parent = pictureBox1;
			//this.TopMost = true;

			this.pictureBox1.BackgroundImage   = new Bitmap(lua.images + "MainFormBack.jpg");
            this.MessBox_1.BackgroundImage     = new Bitmap(lua.images + "box.png");
			this.UniversalPanel.Parent = CloseEngineButton.Parent = HideWindowsButton.Parent = FullscreenCheckBox.Parent = pictureBox1;

            this.KeyDown			      += new KeyEventHandler(KeyDownHandle);
			this.pictureBox1.MouseDown    += new MouseEventHandler(MouseDownHandle);

            this.FullscreenCheckBox.CheckedChanged += new EventHandler(FullscreenHandle);
			this.FullscreenCheckBox.BackColor = Color.Transparent;

			this.UniversalPanel.BackColor    = Color.Transparent;

			this.SpeakerName.Parent   = MessBox_1;
            /////////////////////////////////////////////////////////////////////
            /// Mess setter
            this.MessBox_1.Parent = ALeft;
            this.MessBox_1.MouseDown += new MouseEventHandler(MouseDownHandle);
			/////////////////////////////////////////////////////////////////////
			/// PictPositions setter
			this.ALeft.Parent = pictureBox1;
            this.ALeft.Size = new System.Drawing.Size(this.Width, ALeft.Size.Height);
            this.ALeft.MouseDown += new MouseEventHandler(MouseDownHandle);
            /////////////////////////////////////////////////////////////////////
            /// Vars setter
            player               = new System.Windows.Media.MediaPlayer();
            ActorText_str        = "";
            snd_old              = "0";
            text_width           = MessBox_1.Width / 11;
            snd                  = false;

            SpriteListPic = new Bitmap(ALeft.Size.Width, ALeft.Size.Height);

            try
            {
                FullscreenCheckBox.Checked = Convert.ToBoolean(ifs.GetString(@"..\\setting.ini", "settings", "fullscreen"));
                SoundFlagCheck.Checked = Convert.ToBoolean(ifs.GetString(@"..\\setting.ini", "settings", "sound"));
            }
            catch (Exception e) { };
            GameStarted = false;
            lua.lua.RegisterFunction("AddContextBox", this, typeof(Form1).GetMethod("MakeContextBox"));
            lua.lua.RegisterFunction("RemoveContextBox", this, typeof(Form1).GetMethod("ClosedContextBox"));
        }

        // Load: Game
        void FullscreenHandle(object sender, EventArgs e)
        {
            if (FullscreenCheckBox.Checked)
            {
                this.Height = SystemInformation.VirtualScreen.Size.Height;
                this.Width = SystemInformation.VirtualScreen.Size.Width;
                this.TopMost = true; 
                //text_width += 5;
            }
            else
            {
                this.Height = 528;
                this.Width = 979;
                this.TopMost = false;
                //text_width = 24;
             }
            int ppos = this.Width / 5;
            this.ALeft.Size = new System.Drawing.Size(this.Width, ALeft.Size.Height);
            this.ALeft.Location = new System.Drawing.Point(0, ALeft.Location.Y);

            //text_width *= 4;
            text_width = MessBox_1.Width / 11;
        }
        private void LoadGameClickHandle(object sender, EventArgs e)
        {
            LoadList.Visible = true;
            LoadList.Items.Clear();

            if (Directory.Exists(lua.userdata))
            {
                var FilesList = Directory.GetFiles(lua.userdata);

                if (FilesList != null & FilesList.Length > 0)
                {
                    foreach (string file_name in Directory.GetFiles(lua.userdata))
                        LoadList.Items.Add(file_name.Substring(lua.userdata.Length));
                }
            }
        }
        private void NextClickHandle(object sender, EventArgs e)
        {
            MenuUpdate(false);
            NextScene(true);
            MessBox_1.Visible = true;
        }
        private void ExitClickHandle(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OptionsClickHandle(object sender, EventArgs e)
        {
            MenuUpdate(false);
            trygame = false;

            MessBox_1.Visible = false;

            SoundFlagCheck.Visible = true;
            BackButton.Visible = true;
            FullscreenCheckBox.Visible = true;
        }

		void KeyDownHandle(object sender, KeyEventArgs e)
		{
			if (trygame)
			{
				if (e.KeyData == Keys.Enter)
					NextScene(false);
				else if (e.KeyData == Keys.Escape)
					MenuUpdate(!ExitButton.Visible);
			}
		}

        void MouseDownHandle(object sender, MouseEventArgs e)
        {
			if (trygame)
			{
                if (e.Clicks == 1 & GameStarted)
                {
                    if (e.Button == MouseButtons.Left)
                        NextScene(false);
                    else if (e.Button == MouseButtons.Right)
                    {
                        MessBox_1.Visible = !MessBox_1.Visible;
                    }
                }
			}
        }

        private void SaveGameClickHandle(object sender, EventArgs e)
        {            
            inputBox();
        }

        private void LoadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = lua.userdata + LoadList.SelectedItem.ToString();

            GameScenarioFile = ifs.GetString(path, "param", "game");
            sect = Convert.ToInt32(ifs.GetString         (path, "param", "sect"));
            sect_old    = ifs.GetString                  (path, "param", "sect_old");
            sect_string = ifs.GetString                  (path, "param", "sect_string");
            sect_label  = Convert.ToInt32(ifs.GetString  (path, "param", "sect_label"));

            // Restored LuaTables 
            int LayerCount = Convert.ToInt32(ifs.GetString(path, "layer", "count"));
            lua.lua.GetTable("Scene")["Images"] = LayerCount;

            for (int Iter = 0; Iter < LayerCount; Iter++)
                lua.lua.GetTable("Scene")["Image" + Iter.ToString()] = ifs.GetString(path, "layer", "layer" + Iter.ToString());

            lua.SetHook(ifs.GetString(path, "layer", "hook"));
            lua.CallHook();

            LoadList.Visible = false;
            MenuUpdate(false);
            NextScene(true);
            MessBox_1.Visible = true;
        }
        private void BackClickHandle(object sender, EventArgs e)
        {
            BackButton.Visible = FullscreenCheckBox.Visible = SoundFlagCheck.Visible = false;

            ifs.WritePrivateStringA("settings", "fullscreen", FullscreenCheckBox.Checked.ToString(), @"..\\setting.ini");
            ifs.WritePrivateStringA("settings", "sound", SoundFlagCheck.Checked.ToString(), @"..\\setting.ini");  
            MenuUpdate(true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void CloseEngineClickHandle(object sender, EventArgs e) { this.ExitClickHandle(sender, e);}
        private void HideWindowsClick(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SaveButtonClickHandle(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string path = lua.userdata + textBox1.Text + ".ini";
                ifs.WritePrivateStringA("param", "sect", Convert.ToString(sect), path);
                ifs.WritePrivateStringA("param", "sect_string", sect_string, path);
                ifs.WritePrivateStringA("param", "sect_old", sect_old, path);
                ifs.WritePrivateStringA("param", "sect_label", Convert.ToString(sect_label), path);
                ifs.WritePrivateStringA("param", "game", GameScenarioFile, path);

                // Save Sprites
                for (int Iter = 0; Iter < lua.GetImgNum(); Iter++)
                    ifs.WritePrivateStringA("layer", "layer" + Iter.ToString(), lua.GetImageText(Iter), path);

                ifs.WritePrivateStringA("layer", "count", lua.GetImgNum().ToString(), path);
                ifs.WritePrivateStringA("layer", "hook", lua.GetHook(), path);

                HideInputBox();
            }
            else
                MessageBox.Show("Error", "Введите название!", MessageBoxButtons.OK);
        }
    }
}
