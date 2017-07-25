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
        private int sect, sect_next, sect_label, sect_lb_old, text_width = 115, lnum, inum;
        string heroname, ActorText_str = "", sect_old, sect_string, snd_old = "0";
        string [] ActorText;
        bool trygame, snd = false;
        LuaAPI lua = new LuaAPI();
        Graphics g;
        System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
        Color color_ = new Color();
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
            pictureBox2.MouseDown += new MouseEventHandler(_MouseDown);

            checkBox1.Parent = pictureBox1;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.CheckedChanged += new EventHandler(Fullscreen);

            panel1.BackColor = Color.Transparent;
            panel1.Parent = pictureBox1;

            label6.Parent = pictureBox1;
            label7.Parent = pictureBox1;
            //pictureBox2.Parent = pictureBox1;
            checkBox1.Parent = pictureBox1;
            pictureBox2.Image = (Image)new Bitmap(pictureBox2.Width, pictureBox2.Height);

            //this.Width = SystemInformation.VirtualScreen.Size.Width;
           // this.Height = SystemInformation.VirtualScreen.Size.Height;

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
            g = Graphics.FromImage(pictureBox2.Image);
            ifs = new INIManager();

            pictureBox2.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(@"../setting.ini", "interface", "TextImg"));
            ifs.WritePrivateStringA("param", "snd_old", "0", @"..\userdata\temp.ini");
          //  MessageBox.Show(Convert.ToString(ppos));

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
            }
            //Тут мы определяем секцию, костыльно и не интересно
            sect_string = Convert.ToString(sect);
            if (sect_next != 0)
                if (sect_lb_old != sect_label)
                {
                    sect_old += "_" + Convert.ToString(sect_next);
                    sect_string += sect_old;
                    sect_lb_old = sect_label;
                }
            ifs.WritePrivateStringA("param", "sect", sect.ToString(), lua.userdata + "temp.ini");
            ifs.WritePrivateStringA("param", "sect_string", sect_string, lua.userdata + "temp.ini");
            ifs.WritePrivateStringA("param", "sect_old", sect_old, lua.userdata + "temp.ini");

            //Load vars
            pictureBox2.Image = (Image)new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Graphics.FromImage(pictureBox2.Image);
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
                    label_text[i].Click += new System.EventHandler(this.label1_Click);
                    label_text[i].Parent = panel1;
                    label_text[i].Text = lua.GetLabelText(i);
                }
                Label_Helper(true, lnum);
                return;
            }
            heroname = lua.GetName();
            ActorText = lua.GetText().Split(' ');

            //Для отступов строк
            int old_y = 35,
                str = 0,
                num = 0;

            //Определяем цвет
            SetColor(lua.GetNameColor());

            //Music
            if (!snd || lua.GetSnd() != snd_old)
            {
                player.Open(new Uri(lua.snd + lua.GetSnd(), UriKind.Relative));
                player.Play();
                snd = true;
            }
            //Draw ActorName
            g.DrawString(heroname, new Font(lua.GetNameFont(), 10), new SolidBrush(color_), new Point(10, 9));

            //Считаем строки
            old_y -= 14;

            SetColor(lua.GetTextColor());
            for (var i = 0; i <= ActorText.Length; i++)
                if (str < text_width & i != ActorText.Length)
                {
                    str += ActorText[i].Length;
                    if (i != ActorText.Length - 1)
                        if (str + ActorText[i + 1].Length >= text_width)
                            str = 1116;
                }
                else
                {
                    for (int j = num + 1; j <= i; j++)
                        ActorText_str += ActorText[j - 1] + " ";

                    if (i != ActorText.Length)
                        str = ActorText[i].Length;

                    old_y += 14;
                    num = i;
                    g.DrawString(ActorText_str, new Font(lua.GetTextFont(), 10, FontStyle.Bold), new SolidBrush(color_), new Point(10, old_y));
                    ActorText_str = "";
                }
            // Drawing img
            {
                this.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
                pictureBox1.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
                ALeft.Visible = CLeft.Visible = Center.Visible = CRight.Visible = ARight.Visible = false;
                inum = lua.GetImgNum() - 1;
                if (inum > -1)
                {
                    //pictureBox1.Image = new Bitmap(lua.images + lua.GetImageText(1));
                    if (inum > 0)
                    {
                        for (int it = 1; it <= inum; it++)
                        {
                            int Pos = lua.GetImageTextPos(it);
                            if (Pos == 1)
                            {
                                ALeft.Visible = true;
                              //  ALeft.Height = new Bitmap(lua.images + lua.GetImageText(it)).Size.Height;
                                ALeft.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(it));
                            }
                            if(Pos == 2) 
                            {
                                CLeft.Visible = true;
                              //  CLeft.Height = new Bitmap(lua.images + lua.GetImageText(it)).Size.Height;
                                CLeft.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(it));
                            }
                            if(Pos == 3) 
                            {
                                Center.Visible = true;
                              //  Center.Height = new Bitmap(lua.images + lua.GetImageText(it)).Size.Height;
                                Center.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(it));
                            }
                            if(Pos == 4) 
                            {
                                CRight.Visible = true;
                               // CRight.Height = new Bitmap(lua.images + lua.GetImageText(it)).Size.Height;
                                CRight.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(it));
                            }
                            if(Pos == 5) 
                            {
                                ARight.Visible = true;
                              //  ARight.Height = new Bitmap(lua.images + lua.GetImageText(it)).Size.Height;
                                ARight.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(it));
                            }
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
                this.Height -= 40;
                this.Width -= 40;
                this.TopMost = true;
            }
            else
            {
                this.Height += 40;
                this.Width += 40;
                this.TopMost = false;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            LoadList.Visible = true;
            LoadList.Items.Clear();
            foreach(string file_name in Directory.GetFiles(lua.userdata))
                if(file_name != lua.userdata + "temp.ini")
                    LoadList.Items.Add(file_name.Substring(14));
        }
        private void Next_Click(object sender, EventArgs e)
        {
            MenuUpdate(false);
            NextScene(true);
        }
        private void _exit_Click(object sender, EventArgs e)
        {
            g.Dispose();
            this.Close();
        }
        private void Options_Click(object sender, EventArgs e)
        {
            MenuUpdate          (false);
            trygame             = false;
            pictureBox2.Visible = false;
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
                        if (pictureBox2.Visible)
                            pictureBox2.Visible = false;
                        else
                            pictureBox2.Visible = true;
        }
    
        private void label1_Click(object sender, EventArgs e)
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

        }
        private void SaveGame_Click(object sender, EventArgs e)
        {            
            inputBox();
        }

        private void LoadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = lua.userdata + LoadList.SelectedItem.ToString();
            MessageBox.Show(lua.userdata + LoadList.SelectedItem.ToString());

            sect = Convert.ToInt32(ifs.GetPrivateString         (path, "param", "sect"));
            sect_old =    ifs.GetPrivateString                  (path, "param", "sect_old");
            sect_string = ifs.GetPrivateString                  (path, "param", "sect_string");
            lua.lua["ActorName"] = ifs.GetPrivateString         (path, "param", "name");
            lua.lua["Text"] = ifs.GetPrivateString              (path, "param", "text");
            lua.lua.GetTable("Image")[0] = ifs.GetPrivateString (path, "param", "backImage");
            snd_old =  ifs.GetPrivateString                     (path, "param", "snd_old");
            lua.lua["ImageNum"] = ifs.GetPrivateString          (path, "param", "pic");
            lua.lua.GetTable("Color")[1] = ifs.GetPrivateString (path, "param", "name_c");
            lua.lua.GetTable("Color")[0] = ifs.GetPrivateString (path, "param", "text_c");
            if (lua.GetImgNum() > 1)
                for (int i = 1; i < lua.GetImgNum(); i++)
                   ifs.GetPrivateString(path, "param", "Image_" + Convert.ToString(i));

            LoadList.Visible = false;
            MenuUpdate(false);
            NextScene(true);
        }
        private void ago_Click(object sender, EventArgs e)
        {
            ago.Visible = false;
            MenuUpdate(true);
            checkBox1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this._exit_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
