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
        private int sect, sect_next, sect_label, sect_lb_old, text_width = 115;
        string heroname, ActorText_str = "", sect_old, sect_string, snd_old = "0";
        string [] ActorText;
        bool trygame, snd = false;
        LuaAPI lua = new LuaAPI();
        Graphics g;
        System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
        System.Windows.Forms.PictureBox pictureBox3, pictureBox4;
        Color color_ = new Color();
        Sound msound = new Sound(); // Added 16.01.2017 Lord Wolf
        public Form1()
        {

            InitializeComponent();

            this.KeyDown += new KeyEventHandler(_KeyDown);

            pictureBox4 =  pictureBox3 = pictureBox1;

            pictureBox1.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox3.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox2.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox4.MouseDown -= new MouseEventHandler(_MouseDown);

            checkBox1.Parent = pictureBox4;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.CheckedChanged += new EventHandler(Fullscreen);

            panel1.BackColor = Color.Transparent;
            panel1.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            label1.Parent = panel1;
            label2.Parent = panel1;
            label3.Parent = panel1;
            label6.Parent = pictureBox4;
            label7.Parent = pictureBox4;

            pictureBox2.Image = (Image)new Bitmap(pictureBox2.Width, pictureBox2.Height);

            //Пока определим тут
            g = Graphics.FromImage(pictureBox2.Image);
            ifs = new INIManager();
            
            pictureBox2.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(@"../setting.ini", "interface", "TextImg"));
            ifs.WritePrivateStringA("param", "snd_old", "0", @"..\userdata\temp.ini");

            this.Width = SystemInformation.VirtualScreen.Size.Width;
            this.Height = SystemInformation.VirtualScreen.Size.Height;
            msound.SetSound("shadowofchernobyl.ogg");
            msound.play();
        }
        //Прокомментирую, а то уже забыл, что к чему...
        void NextScene(bool load)
        {
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
            
            //Подгружаем значения 
            pictureBox2.Image = (Image)new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Graphics.FromImage(pictureBox2.Image);
            if (ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "type") == "LuaScript")
                lua.LuaFunc(ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "name"), ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "func"));
            else if (ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "type") == "Question")
            {
                label1.Text = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "q1");
                label2.Text = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "q2");
                label3.Text = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "q3");
                Label_Helper(true);
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
            g.DrawString(heroname, new Font("Comic Sans ms", 10), new SolidBrush(color_), new Point(10, 9));

            //Считаем строки
            old_y -= 14;

            SetColor(lua.GetTextColor());
            for (int i = 0; i <= ActorText.Length; i++)
                if (str < text_width & i != ActorText.Length)
                {
                    str += ActorText[i].Length;
                    if (i != ActorText.Length -1)
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
                    g.DrawString(ActorText_str, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(color_), new Point(10, old_y));
                    ActorText_str = "";
                }
            DrawHelper();
        }
        //Load: Game
        void Fullscreen(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Height -= 40;
                this.Width -= 40;
                TopMost = true;
            }
            else
            {
                this.Height += 40;
                this.Width += 40;
                TopMost = false;
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
            DrawHelper();
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
            msound.SetSound("GEG.ogg");
            msound.play();
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
            sect_next = 1;
            Label_Helper(false);
            NextScene(false);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            sect_next = 2;
            Label_Helper(false);
            NextScene(false);
        }
        private void label3_Click(object sender, EventArgs e)
        {
            sect_next = 3;
            Label_Helper(false);
            NextScene(false);
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
            if (lua.GetImageNum() > 1)
                for (int i = 1; i < lua.GetImageNum(); i++)
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
