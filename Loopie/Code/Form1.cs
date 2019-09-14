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

namespace Visual
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

        //Code
        public Form1()
        {
            /// Init
            InitializeComponent();
			this.DoubleBuffered = true;
			/////////////////////////////////////////////////////////////////////
			/// ETC setter
			ifs = new INIManager();
			lua = new LuaAPI();

			this._exit.Parent = pictureBox1;
			this.Options.Parent = pictureBox1;
			this.NewGame.Parent = pictureBox1;
			this.Next.Parent = pictureBox1;
			this.label4.Parent = pictureBox1;
			this.flag_snd.Parent = pictureBox1;
			this.SaveButton.Parent = panel1;
			this.SaveGame.Parent = pictureBox1;
			this.ago.Parent = pictureBox1;
			//this.TopMost = true;

			this.pictureBox1.BackgroundImage = new Bitmap(lua.images + "MainFormBack.jpg");
            this.MessBox_1.BackgroundImage = new Bitmap(lua.images + "box.png");
			this.panel1.Parent = label6.Parent = label7.Parent = checkBox1.Parent = pictureBox1;

            this.KeyDown			      += new KeyEventHandler(_KeyDown);
			this.pictureBox1.MouseDown    += new MouseEventHandler(_MouseDown);
            this.checkBox1.CheckedChanged += new EventHandler(Fullscreen);

			this.checkBox1.BackColor = Color.Transparent;
			this.panel1.BackColor    = Color.Transparent;

			this.SpeakerName.Parent   = MessBox_1;
            /////////////////////////////////////////////////////////////////////
            /// Mess setter
            this.MessBox_1.Parent = ALeft;
            this.MessBox_1.MouseDown += new MouseEventHandler(_MouseDown);
			/////////////////////////////////////////////////////////////////////
			/// PictPositions setter
			this.ALeft.Parent = pictureBox1;
            this.ALeft.Size = new System.Drawing.Size(this.Width, ALeft.Size.Height);
            this.ALeft.MouseDown += new MouseEventHandler(_MouseDown);
            /////////////////////////////////////////////////////////////////////
            /// Vars setter
            player               = new System.Windows.Media.MediaPlayer();
            ActorText_str        = "";
            snd_old              = "0";
            text_width           = 27 * 5;
            snd                  = false;

            SpriteListPic = new Bitmap(ALeft.Size.Width, ALeft.Size.Height);

            try
            {
                checkBox1.Checked = Convert.ToBoolean(ifs.GetString(@"..\\setting.ini", "settings", "fullscreen"));
                flag_snd.Checked = Convert.ToBoolean(ifs.GetString(@"..\\setting.ini", "settings", "sound"));
            }
            catch (Exception e) { };
            GameStarted = false;
        }

        // Load: Game
        void Fullscreen(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Height = SystemInformation.VirtualScreen.Size.Height;
                this.Width = SystemInformation.VirtualScreen.Size.Width;
                this.TopMost = true; 
                text_width += 9;
            }
            else
            {
                this.Height = 528;
                this.Width = 979;
                this.TopMost = false;
                text_width = 27;
             }
            int ppos = this.Width / 5;
            this.ALeft.Size = new System.Drawing.Size(this.Width, ALeft.Size.Height);
            this.ALeft.Location = new System.Drawing.Point(0, ALeft.Location.Y);

            text_width *= 5;
        }
        private void Label4_Click(object sender, EventArgs e)
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
        private void Next_Click(object sender, EventArgs e)
        {
            MenuUpdate(false);
            NextScene(true);
            MessBox_1.Visible = true;
        }
        private void _exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Options_Click(object sender, EventArgs e)
        {
            MenuUpdate          (false);
            trygame             = false;
			
			MessBox_1.Visible =  false;

            flag_snd.Visible    = true;
            ago.Visible         = true;
            checkBox1.Visible   = true;
        }
		void _KeyDown(object sender, KeyEventArgs e)
		{
			if (trygame)
			{
				if (e.KeyData == Keys.Enter)
					NextScene(false);
				else if (e.KeyData == Keys.Escape)
					MenuUpdate(!_exit.Visible);
			}
		}
        void _MouseDown(object sender, MouseEventArgs e)
        {
			if (trygame)
			{
                if (e.Clicks == 1 & GameStarted)
                {
                    if (e.Button == MouseButtons.Left)
                        NextScene(false);
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (MessBox_1.Visible)
                            MessBox_1.Visible = false;
                        else
                            MessBox_1.Visible = true;
                    }
                }
			}
        }

        private void SaveGame_Click(object sender, EventArgs e)
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
        private void Ago_Click(object sender, EventArgs e)
        {
            ago.Visible = checkBox1.Visible = flag_snd.Visible = false;

            ifs.WritePrivateStringA("settings", "fullscreen", checkBox1.Checked.ToString(), @"..\\setting.ini");
            ifs.WritePrivateStringA("settings", "sound", flag_snd.Checked.ToString(), @"..\\setting.ini");  
            MenuUpdate(true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Label6_Click(object sender, EventArgs e) { this._exit_Click(sender, e);}
        private void Label7_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SaveButton_Click(object sender, EventArgs e)
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
