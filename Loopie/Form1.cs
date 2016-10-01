using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class Form1 : Form
    {

        private INIManager ifs;
        private int sect, sect_next, sect_label, sect_lb_old;
        string heroname, ActorText, sect_old, sect_string; 
        bool trygame, snd = false;
        LuaAPI lua = new LuaAPI();
        Graphics g;
        System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
        System.Windows.Forms.PictureBox pictureBox3;
        System.Windows.Forms.PictureBox pictureBox4;

        public Form1()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(_KeyDown);
            pictureBox3 = pictureBox1;
            pictureBox4 = pictureBox3;
            pictureBox1.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox3.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox2.MouseDown += new MouseEventHandler(_MouseDown);
            pictureBox4.MouseDown -= new MouseEventHandler(_MouseDown);

            panel1.BackColor = Color.Transparent;
            panel1.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            label1.Parent = panel1;
            label2.Parent = panel1;
            label3.Parent = panel1;

            pictureBox2.Image = (Image)new Bitmap(pictureBox2.Width, pictureBox2.Height);
            //Пока определим тут
            g = Graphics.FromImage(pictureBox2.Image);
            ifs = new INIManager();

            pictureBox2.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(@"../setting.ini", "interface", "TextImg"));
            ifs.WritePrivateStringA("param", "snd_old", "0", @"..\userdata\temp.ini");
        }
        //Прокомментирую, а то уже забыл, что к чему...
        void NextScene(bool load)
        {
            //Флажок для лоадера
            if (!load)
                ++sect;
            //Тут мы определяем секцию, костыльно и не интересно
            sect_string = Convert.ToString(sect);
            if (sect_next != 0)
                if (sect_lb_old != sect_label)
                {
                    sect_old += "_" + Convert.ToString(sect_next);
                    sect_string += sect_old;
                    sect_lb_old = sect_label;
                }
            //Подгружаем значения 
            pictureBox2.Image = (Image)new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Graphics.FromImage(pictureBox2.Image);
            if (ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "type") == "LuaScript")
                lua.LuaFunc(lua.scripts + ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "name"), ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "func"));
            else if (ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "type") == "Question")
            {
                label1.Text = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "q1");
                label2.Text = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "q2");
                label3.Text = ifs.GetPrivateString(lua.cfg + "test.ini", sect_string, "q3");
                Label_Helper(true);
            }
            heroname = ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "name");
            ActorText = ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "text");
            int old_y = 35; //Для отступов строк

            //Music
            if (!snd || ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "snd_old") != ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "snd"))
            {
                player.Open(new Uri(lua.snd + ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "snd"), UriKind.Relative));
                player.Play();
                snd = true;
            }
            //Отрисовка акторнейма и первой строки 
            g.DrawString(heroname, new Font("Comic Sans ms", 10), new SolidBrush(Color.Black), new Point(10, 9));
            g.DrawString(ActorText, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.White), new Point(10, old_y));
            int str = Convert.ToInt32(ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "string"));

            //Считаем строки
            old_y -= 14;
            if (str > 1)
                for (int i = 0; str >= i; i++)
                {
                    ActorText = ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "text" + Convert.ToString(i));
                    g.DrawString(ActorText, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.White), new Point(10, old_y));
                    old_y += 14;
                }
            DrawHelper();
        }
        //Load: Game
        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                sect = Convert.ToInt32(ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "sect"));
                sect_string = ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "sect_string");
                heroname = ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "name");
                ActorText = ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "text");
                MenuUpdate(false);
                NextScene(true);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка");
            }
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
            comboBox1.Visible = true;
            MenuUpdate(false);
            pictureBox2.Visible = false;
            ago.Visible = true;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "979x525")
            {
                this.Width = 979;
                this.Height = 525;
                pictureBox2.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(@"../setting.ini", "interface", "TextImg"));
            } 
            else if (comboBox1.SelectedItem.ToString() == "1024x551")
            {
                this.Width = 1024;
                this.Height = 551;
                pictureBox2.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(@"../setting.ini", "interface", "TextImg_mid"));
            }
            else if (comboBox1.SelectedItem.ToString() == "1375x730")
            {
                this.Width = 1375;
                this.Height = 730;
                pictureBox2.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(@"../setting.ini", "interface", "TextImg_big"));
            }
        }
        private void ago_Click(object sender, EventArgs e)
        {
            ago.Visible = false;
            comboBox1.Visible = false;
            MenuUpdate(true);

        }
    }
}
