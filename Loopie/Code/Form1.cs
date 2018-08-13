using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string heroname, ActorText_str, sect_old, sect_string, snd_old;
        private string [] ActorText;
        private bool trygame, snd;

        //Code
        public Form1()
        {
            /// Init
            InitializeComponent();
            int ppos = this.Width / 5;
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
			this.SaveButton.Parent = pictureBox1;
			this.SaveGame.Parent = pictureBox1;
			this.ago.Parent = pictureBox1;
			//this.TopMost = true;

			this.pictureBox1.BackgroundImage = new Bitmap(lua.images + "MainFormBack.jpg");

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
            this.MessBox_2.Parent = CLeft;
            this.MessBox_3.Parent = Center;
            this.MessBox_4.Parent = CRight;
			this.MessBox_5.Parent = ARight;

            this.mess_1.Parent = MessBox_1;
            this.mess_2.Parent = MessBox_2;
            this.mess_3.Parent = MessBox_3;
            this.mess_4.Parent = MessBox_4;
			this.mess_5.Parent = MessBox_5;

            this.MessBox_1.MouseDown += new MouseEventHandler(_MouseDown);
            this.MessBox_2.MouseDown += new MouseEventHandler(_MouseDown);
            this.MessBox_3.MouseDown += new MouseEventHandler(_MouseDown);
            this.MessBox_4.MouseDown += new MouseEventHandler(_MouseDown);
			this.MessBox_5.MouseDown += new MouseEventHandler(_MouseDown);
			/////////////////////////////////////////////////////////////////////
			/// PictPositions setter
			this.ALeft.Parent = CLeft.Parent = CRight.Parent = Center.Parent = ARight.Parent = pictureBox1;

            this.ALeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            this.CLeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            this.Center.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            this.CRight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
			this.ARight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);

            this.ALeft.Location = new System.Drawing.Point(0, ALeft.Location.Y);
            this.CLeft.Location = new System.Drawing.Point(ppos, CLeft.Location.Y);
            this.Center.Location = new System.Drawing.Point(ppos * 2, Center.Location.Y);
            this.CRight.Location = new System.Drawing.Point(ppos * 3, CRight.Location.Y);
			this.ARight.Location = new System.Drawing.Point(ppos * 4, ARight.Location.Y);

            this.ALeft.MouseDown += new MouseEventHandler(_MouseDown);
            this.CLeft.MouseDown += new MouseEventHandler(_MouseDown);
            this.Center.MouseDown += new MouseEventHandler(_MouseDown);
            this.CRight.MouseDown += new MouseEventHandler(_MouseDown);
			this.ARight.MouseDown += new MouseEventHandler(_MouseDown);
            /////////////////////////////////////////////////////////////////////
            /// Vars setter
            player               = new System.Windows.Media.MediaPlayer();
            ActorText_str        = "";
            snd_old              = "0";
            text_width           = 27;
            snd                  = false;
        }
        //Прокомментирую, а то уже забыл, что к чему...
        void NextScene(bool load)
        {
            lua.lua.Pop();

            //Флажок для лоадера
            if (!load)
            {
                snd_old = lua.GetSnd();
                ++sect;
                //Тут мы определяем секцию, костыльно и не интересно
                sect_string = (sect_label == 0) ? Convert.ToString(sect) : Convert.ToString(sect) + sect_old;
                if (sect_next != 0 && sect_lb_old != sect_label)
                {
                    sect_old += "_" + Convert.ToString(sect_next);
                    sect_string = Convert.ToString(sect) + sect_old;
                    sect_lb_old = sect_label;
                }
            }

			//Load vars
			string TypeCurrentScene = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "type");
			string ScriptFileName = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "name");

			if (TypeCurrentScene == "None" | ScriptFileName == "")
				return;

			lua.LuaFunc(ScriptFileName, ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "func"));
            if (TypeCurrentScene == "Question")
            {
                lnum = lua.GetLabelNum();
                label_text = new Label[lnum]; // Set size
                for (int it = 0; it < lnum; it++)
                {
                    label_text[it] = new System.Windows.Forms.Label
                    {
                        AutoSize = true,
                        Name = Convert.ToString(it + 1),
                        BackColor = System.Drawing.Color.Transparent,
                        Location = new System.Drawing.Point(80, 22 + 10 * it),
                        Visible = true,
                        Text = lua.GetLabelText(it),
                        Parent = panel1
                    };
                    label_text[it].Click += new System.EventHandler(this.Question_Click);
                }
                Label_Helper(true, lnum);
                return;
            }
            heroname = lua.GetName();
            ActorText = lua.GetText().Split(' ');

            //Music
            if (flag_snd.Checked && (!snd || lua.GetSnd() != snd_old))
            {
                player.Open(new Uri(lua.snd + lua.GetSnd(), UriKind.Relative));
                player.Play();
                snd = true;
            }
            //Draw ActorName
            SpeakerName.Visible = true;
            SpeakerName.ForeColor = SetColor(lua.GetNameColor());
            SpeakerName.Text = heroname;

            //Для отступов строк
            int str = 0, lb = 0, num = 0;
            string ActorText_tstr = "";

            mess_1.ForeColor = mess_2.ForeColor = mess_3.ForeColor = mess_4.ForeColor = mess_5.ForeColor = SetColor(lua.GetTextColor());

            //Считаем строки
            mess_1.Text = mess_2.Text = mess_3.Text = mess_4.Text = mess_5.Text = "";
            for (int it = 0; it <= ActorText.Length; it++)
            {
                if (it != ActorText.Length)
                {
                    str += ActorText[it].Length + 1;
                    if (str < text_width)
                    {
                        if (ActorText_tstr != "")
                        {
                            ActorText_str += ActorText_tstr + " ";
                            ActorText_tstr = "";
                        }
                        ActorText_str += ActorText[it] + " ";
                        continue;
                    }
                    else if (str > text_width)
                    {
                        num = str - text_width;
                        ActorText_str += ActorText[it].Substring(0, ActorText[it].Length - num);
                        ActorText_tstr = ActorText[it].Substring(ActorText[it].Length - num);
                    }
                    else ActorText_str += ActorText[it];
                }
                lb++;
                switch (lb)
                {
                    case 1: mess_1.Text += ActorText_str; text_width -= checkBox1.Checked ? 0 : 2; break;
                    case 2: mess_2.Text += ActorText_str; text_width -= 2; break;
                    case 3: mess_3.Text += ActorText_str; break;
                    case 4: mess_4.Text += ActorText_str; break;
                    case 5: mess_5.Text += ActorText_str; lb = 0; text_width += 4; break;
                }
                ActorText_str = "";
                str = 0;
            }
            text_width = checkBox1.Checked ? 36 : 27;
            // Drawing img
            this.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
			this.pictureBox1.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
			this.ALeft.Image = CLeft.Image = Center.Image = CRight.Image = ARight.Image = null;
            inum = lua.GetImgNum() - 1;

			if (inum > 0)
			{
				for (int it = 1; it <= inum; it++)
				{
					switch (lua.GetImageTextPos(it))
					{
						case 1: this.ALeft.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
						case 2: this.CLeft.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
						case 3: this.Center.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
						case 4: this.CRight.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
						case 5: this.ARight.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
					}
				}
			}
        }
        //Load: Game
        void Fullscreen(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Height = SystemInformation.VirtualScreen.Size.Height;
                this.Width = SystemInformation.VirtualScreen.Size.Width;
                this.TopMost = true; 
                text_width += 9;
                mess_1.MaximumSize = mess_2.MaximumSize = mess_3.MaximumSize = mess_4.MaximumSize = mess_5.MaximumSize = new Size(260, 120);
            }
            else
            {
                this.Height = 528;
                this.Width = 979;
                this.TopMost = false;
                text_width = 27;
                mess_1.MaximumSize = mess_2.MaximumSize = mess_3.MaximumSize = mess_4.MaximumSize = mess_5.MaximumSize = new Size(200, 120);
            
            }
            int ppos = this.Width / 5;
            this.ALeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            this.CLeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            this.Center.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            this.CRight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
			this.ARight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);

            this.ALeft.Location = new System.Drawing.Point(0, ALeft.Location.Y);
            this.CLeft.Location = new System.Drawing.Point(ppos, CLeft.Location.Y);
            this.Center.Location = new System.Drawing.Point(ppos * 2, Center.Location.Y);
            this.CRight.Location = new System.Drawing.Point(ppos * 3, CRight.Location.Y);
			this.ARight.Location = new System.Drawing.Point(ppos * 4, ARight.Location.Y);
        }
        private void Label4_Click(object sender, EventArgs e)
        {
            LoadList.Visible = true;
            LoadList.Items.Clear();

            foreach(string file_name in Directory.GetFiles(lua.userdata))
                LoadList.Items.Add(file_name.Substring(lua.userdata.Length));
        }
        private void Next_Click(object sender, EventArgs e)
        {
            MenuUpdate(false);
            NextScene(true);
            MessBox_4.Visible = MessBox_5.Visible = MessBox_3.Visible = MessBox_2.Visible = MessBox_1.Visible = true;
        }
        private void _exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Options_Click(object sender, EventArgs e)
        {
            MenuUpdate          (false);
            trygame             = false;
			
			MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible =  false;

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
				if (e.Clicks == 1)
					if (e.Button == MouseButtons.Left)
						NextScene(false);
					else if (e.Button == MouseButtons.Right)
						if (MessBox_1.Visible)
							MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = false;
						else
							MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = true;
			}
        }
    
        private void Question_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            sect_next = Convert.ToInt32(lab.Name);
            Label_Helper(false, lnum);
            //NextScene(false);
        }
        private void NewGame_Click(object sender, EventArgs e)
        {
            sect = 0;
            MenuUpdate(false);
            NextScene(false);
            MessBox_4.Visible = MessBox_5.Visible = MessBox_3.Visible = MessBox_2.Visible = MessBox_1.Visible = true;
        }
        private void SaveGame_Click(object sender, EventArgs e)
        {            
            inputBox();
        }
        private void LoadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = lua.userdata + LoadList.SelectedItem.ToString();

            sect = Convert.ToInt32(ifs.GetPrivateString         (path, "param", "sect"));
            sect_old    = ifs.GetPrivateString                  (path, "param", "sect_old");
            sect_string = ifs.GetPrivateString                  (path, "param", "sect_string");
            sect_label  = Convert.ToInt32(ifs.GetPrivateString  (path, "param", "sect_label"));
            LoadList.Visible = false;
            MenuUpdate(false);
            NextScene(true);
            MessBox_4.Visible = MessBox_5.Visible = MessBox_3.Visible = MessBox_2.Visible = MessBox_1.Visible = true;
        }
        private void Ago_Click(object sender, EventArgs e)
        {
            ago.Visible = checkBox1.Visible = flag_snd.Visible = false;
            MenuUpdate(true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Label6_Click(object sender, EventArgs e) => this._exit_Click(sender, e);
        private void Label7_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
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
              
                HideInputBox();
            }
            else
                MessageBox.Show("Error", "Введите название!", MessageBoxButtons.OK);
        }
    }
}
