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
        private INIManager ifs;
        private int sect, sect_next, sect_label, sect_lb_old, text_width = 27, lnum, inum;
        string heroname, ActorText_str = "", sect_old, sect_string, snd_old = "0";
        string [] ActorText;
        bool trygame, snd = false;
        LuaAPI lua = new LuaAPI();
        System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
        private System.Windows.Forms.Label[] label_text;

        public Form1()
        {
            InitializeComponent();
            int ppos = this.Width / 5;
            this.BackgroundImage = new Bitmap(lua.images + "logo.gif");
            this.KeyDown += new KeyEventHandler(_KeyDown);
            ALeft.Parent = CLeft.Parent = CRight.Parent = Center.Parent = ARight.Parent = pictureBox1;
            ALeft.MouseDown += new MouseEventHandler(_MouseDown);
            CLeft.MouseDown += new MouseEventHandler(_MouseDown);
            Center.MouseDown += new MouseEventHandler(_MouseDown);
            CRight.MouseDown += new MouseEventHandler(_MouseDown);
            ARight.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox1.MouseDown += new MouseEventHandler(_MouseDown);
            MessBox_1.MouseDown += new MouseEventHandler(_MouseDown);
            MessBox_2.MouseDown += new MouseEventHandler(_MouseDown);
            MessBox_3.MouseDown += new MouseEventHandler(_MouseDown);
            MessBox_4.MouseDown += new MouseEventHandler(_MouseDown);
            MessBox_5.MouseDown += new MouseEventHandler(_MouseDown);

            checkBox1.Parent = pictureBox1;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.CheckedChanged += new EventHandler(Fullscreen);

            panel1.BackColor = Color.Transparent;
            panel1.Parent = pictureBox1;

            label6.Parent = pictureBox1;
            label7.Parent = pictureBox1;
            SpeakerName.Parent = MessBox_1;
            checkBox1.Parent = pictureBox1;
            MessBox_1.Parent = ALeft;
            MessBox_2.Parent = CLeft;
            MessBox_3.Parent = Center;
            MessBox_4.Parent = CRight;
            MessBox_5.Parent = ARight;

            mess_1.Parent = MessBox_1;
            mess_2.Parent = MessBox_2;
            mess_3.Parent = MessBox_3;
            mess_4.Parent = MessBox_4;
            mess_5.Parent = MessBox_5;


            ALeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            CLeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            Center.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            CRight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            ARight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);

            ALeft.Location = new System.Drawing.Point(0, ALeft.Location.Y);
            CLeft.Location = new System.Drawing.Point(ppos, CLeft.Location.Y);
            Center.Location = new System.Drawing.Point(ppos * 2, Center.Location.Y);
            CRight.Location = new System.Drawing.Point(ppos * 3, CRight.Location.Y);
            ARight.Location = new System.Drawing.Point(ppos * 4, ARight.Location.Y);

            //Пока определим тут
            ifs = new INIManager();
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
                if (sect_next != 0)
                    if (sect_lb_old != sect_label)
                    {
                        sect_old += "_" + Convert.ToString(sect_next);
                        sect_string = Convert.ToString(sect) + sect_old;
                        sect_lb_old = sect_label;
                    }
            }

            //Load vars
            lua.LuaFunc(ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "name"), ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "func"));
            if (ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "type") == "Question")
            {
                lnum = lua.GetLabelNum();
                label_text = new System.Windows.Forms.Label[lnum]; // Set size
                for (int i = 0; i < lnum; i++)
                {
                    label_text[i] = new System.Windows.Forms.Label();
                    label_text[i].AutoSize = true;
                    label_text[i].Name = Convert.ToString(i + 1);
                    label_text[i].BackColor = System.Drawing.Color.Transparent;
                    label_text[i].Location = new System.Drawing.Point(80, 22 + 10 * i);
                    label_text[i].TabIndex = 3 + i;
                    label_text[i].Visible = true;
                    label_text[i].Click += new System.EventHandler(this.Question_Click);
                    label_text[i].Parent = panel1;
                    label_text[i].Text = lua.GetLabelText(i);
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
            pictureBox1.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
            ALeft.Image = CLeft.Image = Center.Image = CRight.Image = ARight.Image = null;
            inum = lua.GetImgNum() - 1;
            if (inum > -1)
            {
                //pictureBox1.Image = new Bitmap(lua.images + lua.GetImageText(1));
                if (inum > 0)
                {
                    for (int it = 1; it <= inum; it++)
                    {
                        switch (lua.GetImageTextPos(it))
                        {
                            case 1: ALeft.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
                            case 2: CLeft.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
                            case 3: Center.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
                            case 4: CRight.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
                            case 5: ARight.Image = new Bitmap(lua.images + lua.GetImageText(it)); break;
                        }
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
            ALeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            CLeft.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            Center.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            CRight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);
            ARight.Size = new System.Drawing.Size(ppos, ALeft.Size.Height);

            ALeft.Location = new System.Drawing.Point(0, ALeft.Location.Y);
            CLeft.Location = new System.Drawing.Point(ppos, CLeft.Location.Y);
            Center.Location = new System.Drawing.Point(ppos * 2, Center.Location.Y);
            CRight.Location = new System.Drawing.Point(ppos * 3, CRight.Location.Y);
            ARight.Location = new System.Drawing.Point(ppos * 4, ARight.Location.Y);
        }
        private void label4_Click(object sender, EventArgs e)
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
            MessBox_1.Visible   = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = false;
            flag_snd.Visible    = true;
            ago.Visible         = true;
            checkBox1.Visible   = true;
        }
        void _KeyDown(object sender, KeyEventArgs e)
        {
            if (trygame)
                if (e.KeyData == Keys.Enter)
                    NextScene(false);
                else if (e.KeyData == Keys.Escape)
                    if(_exit.Visible)
                        MenuUpdate(false);
                    else
                        MenuUpdate(true);
        }
        void _MouseDown(object sender, MouseEventArgs e)
        {
            if (trygame)
                if (e.Clicks == 1)
                    if (e.Button == MouseButtons.Left)
                        NextScene(false);
                    else if (e.Button == MouseButtons.Right)
                        if (MessBox_1.Visible)
                            MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = false;
                        else
                            MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = true;
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
        //    MessageBox.Show(lua.userdata + LoadList.SelectedItem.ToString());

            sect = Convert.ToInt32(ifs.GetPrivateString         (path, "param", "sect"));
            sect_old    = ifs.GetPrivateString                  (path, "param", "sect_old");
            sect_string = ifs.GetPrivateString                  (path, "param", "sect_string");
            sect_label  = Convert.ToInt32(ifs.GetPrivateString  (path, "param", "sect_label"));
            LoadList.Visible = false;
            MenuUpdate(false);
            NextScene(true);
            MessBox_4.Visible = MessBox_5.Visible = MessBox_3.Visible = MessBox_2.Visible = MessBox_1.Visible = true;
        }
        private void ago_Click(object sender, EventArgs e)
        {
            ago.Visible = checkBox1.Visible = flag_snd.Visible = false;
            MenuUpdate(true);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            this._exit_Click(sender, e);
        }
        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
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
