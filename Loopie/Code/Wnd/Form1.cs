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
        private readonly LuaAPI lua;
        private readonly System.Windows.Media.MediaPlayer player;

        //Vars
        private uint SectionID;
        private SectionEditon[] UsSectList;
        private int TextWidth;
        private string SpeakerTextString, SoundOldName, GameScenarioFile;
        private string[] GameList;
        private bool TryGame, SoundActive, GameStarted;
        Loopie.Code.Content.ContextBox Context;

        public void MakeContextBox(string Img, string Text, int X, int Y)
        {
            Context.Location = new System.Drawing.Point(X, Y);
            Context.FastInit(LuaAPI.images + Img, Text);
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
            Context.BackColor = Color.Transparent;
            this.Controls.Add(this.Context);
            Context.Visible = false;
            SectionID = 0;
            UsSectList = new SectionEditon[1];
            /////////////////////////////////////////////////////////////////////
            /// ETC setter
            ifs = new INIManager();
            lua = new LuaAPI();

            /// /// General
            InitializeComponent();
            MainMenuInit();

			this.SaveButton.Parent = UniversalPanel;
			//this.TopMost = true;

            this.MessBox_1.BackgroundImage     = new Bitmap(LuaAPI.images + "box.png");

            this.KeyDown      += KeyDownHandle;
			this.MouseDown    += MouseDownHandle;

            this.FullscreenCheckBox.CheckedChanged += FullscreenHandle;
			this.FullscreenCheckBox.BackColor = Color.Transparent;

			this.UniversalPanel.BackColor    = Color.Transparent;

			this.SpeakerName.Parent   = MessBox_1;
            /////////////////////////////////////////////////////////////////////
            /// Mess setter
            this.MessBox_1.MouseDown += MouseDownHandle;
            /////////////////////////////////////////////////////////////////////
            /// Vars setter
            player               = new System.Windows.Media.MediaPlayer();
            SpeakerTextString        = "";
            SoundOldName              = "0";
            TextWidth           = MessBox_1.Width / 11;
            SoundActive                  = false;

            SpriteListPic = new Bitmap(this.Size.Width, this.Size.Height);

            try
            {
                FullscreenCheckBox.Checked = Convert.ToBoolean(ifs.GetString(@"..\\setting.ini", "settings", "fullscreen"));
                SoundFlagCheck.Checked = Convert.ToBoolean(ifs.GetString(@"..\\setting.ini", "settings", "sound"));
            }
            finally
            {
                SoundFlagCheck.Checked = true;
                FullscreenCheckBox.Checked = false;
            }

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
                //TextWidth += 5;
            }
            else
            {
                this.Height = 528;
                this.Width = 979;
                this.TopMost = false;
            }

            TextWidth = MessBox_1.Width / 11;
        }
        private void LoadGameClickHandle(object sender, EventArgs e)
        {
            LoadList.Visible = true;
            LoadList.Items.Clear();

            if (Directory.Exists(LuaAPI.userdata))
            {
                var FilesList = Directory.GetFiles(LuaAPI.userdata);

                if (FilesList != null && FilesList.Length > 0)
                {
                    foreach (string file_name in Directory.GetFiles(LuaAPI.userdata))
                        LoadList.Items.Add(file_name.Substring(LuaAPI.userdata.Length));
                }
            }
        }
        private void NextClickHandle(object sender, EventArgs e)
        {
            MenuUpdate(false);
            NextScene(true, ref UsSectList[SectionID]);
            MessBox_1.Visible = true;
        }
        private void ExitClickHandle(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OptionsClickHandle(object sender, EventArgs e)
        {
            MenuUpdate(false);
            TryGame = false;

            MessBox_1.Visible = false;

            SoundFlagCheck.Visible = true;
            BackButton.Visible = true;
            FullscreenCheckBox.Visible = true;
        }

		void KeyDownHandle(object sender, KeyEventArgs e)
		{
            if (TryGame)
			{
                if (e.KeyData == Keys.Enter)
                {
                    if (isVisualNovel)
                        NextScene(false, ref UsSectList[0]);
                    else
                        NextAction();
                }
				else if (e.KeyData == Keys.Escape)
					MenuUpdate(!ExitButton.Visible);
			}
		}

        void MouseDownHandle(object sender, MouseEventArgs e)
        {
			if (GameStarted && TryGame)
			{
                if (e.Clicks == 1 && GameStarted)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (isVisualNovel)
                            NextScene(false, ref UsSectList[0]);
                        else
                            NextAction();
                    }
                    else if (e.Button == MouseButtons.Right)
                        MessBox_1.Visible = !MessBox_1.Visible;
                }
			}
        }

        private void SaveGameClickHandle(object sender, EventArgs e)
        {            
            inputBox();
        }

        private void LoadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = LuaAPI.userdata + LoadList.SelectedItem.ToString();

            isVisualNovel = ifs.GetString(path, "param", "mode") == "VisualNovel";
            GameScenarioFile = ifs.GetString(path, "param", "game");


            if (!isVisualNovel)
            {
                InitObjectsList();

                for (int Iter = 0; Iter < UsSectList.Length; Iter++)
                    UsSectList[Iter].Load(ref ifs, path, Iter);
            }
            else
            {
                UsSectList = new SectionEditon[1];
            }

            UsSectList[0] = new SectionEditon
            {
                Idx = 0,
                Section = 0,
                SectionNext = 0,
                SectionLabel = 0,
                SectionLabelOld = 0,

                SectionString = "",
                SectionStringOld = ""
            };
            UsSectList[0].Load(ref ifs, path, 0);

            // Restored LuaTables 
            int LayerCount = Convert.ToInt32(ifs.GetString(path, "layer", "count"));
            lua.lua.GetTable("Scene")["Images"] = LayerCount;

            for (int Iter = 0; Iter < LayerCount; Iter++)
                lua.lua.GetTable("Scene")["Image" + Iter.ToString()] = ifs.GetString(path, "layer", "layer" + Iter.ToString());

            lua.SetHook(ifs.GetString(path, "layer", "hook"));
            lua.CallHook();

            LoadList.Visible = false;
            MenuUpdate(false);

            if (isVisualNovel)
                NextScene(true, ref UsSectList[0]);

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
                string path = LuaAPI.userdata + textBox1.Text + ".ini";

                ifs.WritePrivateStringA("param", "game", GameScenarioFile, path);
                ifs.WritePrivateStringA("param", "mode", isVisualNovel ? "VisualNovel" : "Action", path);

                UsSectList[0].Save(ref ifs, path);
                if (!isVisualNovel)
                {
                    for (int Iter = 1; Iter < UsSectList.Length; Iter++)
                        UsSectList[Iter].Save(ref ifs, path);
                }

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
