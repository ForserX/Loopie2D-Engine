using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Visual
{
    public partial class Form1 : Form
    {
        void inputBox()
        {
            panel1.Width = 170;
            label5.Visible = true;
            textBox1.Visible = true;
            panel1.Location = new System.Drawing.Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
            panel1.Height = 85;
            panel1.Visible = true;
            СancelButton.Visible = true;
            SaveButton.Visible = true;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string path = lua.userdata + textBox1.Text + ".ini";
                ifs.WritePrivateStringA("param", "sect",        Convert.ToString(sect),         path);
                ifs.WritePrivateStringA("param", "sect_string", sect_string,                    path);
                ifs.WritePrivateStringA("param", "name",        lua.GetName(),                  path);
                ifs.WritePrivateStringA("param", "name_c",      lua.GetNameColor(),             path);
                ifs.WritePrivateStringA("param", "text",        lua.GetText(),                  path);
                ifs.WritePrivateStringA("param", "text_c",      lua.GetTextColor(),             path);
                ifs.WritePrivateStringA("param", "backImage",   lua.GetImage(0),                path);
                ifs.WritePrivateStringA("param", "sect_old",    sect_old,                       path);
                ifs.WritePrivateStringA("param", "snd_old",     lua.GetSnd(),                   path);
                ifs.WritePrivateStringA("param", "pic",         Convert.ToString(lua.GetImgNum()), path);
                for (int i = 1; i < lua.GetImgNum(); i++)
                    ifs.WritePrivateStringA("param", "Image_" + Convert.ToString(i), lua.GetImage(i), textBox1.Text+ ".ini");

                HideInputBox();
            }
            else
                MessageBox.Show("Error", "Введите название!", MessageBoxButtons.OK);
       
        }
        private void СancelButton_Click(object sender, EventArgs e)
        {
            HideInputBox();
        }
        void HideInputBox()
        {
            label5.Visible      = false;
            textBox1.Visible    = false;
            panel1.Visible      = false;
            СancelButton.Visible= false;
            SaveButton.Visible  = false;
        }
        void SetColor(string obj)
        {
            switch (obj)
            {
                case "white": color_ = Color.White; break;
                case "red": color_ = Color.Red; break;
                case "blue": color_ = Color.Blue; break;
                default: color_ = Color.Black; break;
            }
        }
        private void Label_Helper(bool q, int num)
        {
            if (q)
            {
                ALeft.Visible = CLeft.Visible = Center.Visible = CRight.Visible = ARight.Visible = false;
                panel1.Location = new System.Drawing.Point((this.Width - panel1.Width) / 2, panel1.Location.Y);

                for (int j = 0; j < num; j++)
                {
                    this.panel1.Controls.Add(this.label_text[j]);
                    if (label_text[j].Width >= panel1.Width) panel1.Width = label_text[j].Width + 10;
                    else panel1.Width = 150;

                    label_text[j].Location = new System.Drawing.Point((panel1.Width - label_text[j].Width) / 2, label_text[j].Location.Y);
                }

                panel1.Height = 30 + 15 * num;
                panel1.Visible = true;

                sect_label += 1;
            }
            else
            {
                for (int j = 0; j < num; j++)
                    label_text[j].Dispose();

                panel1.Visible = false;
                sect++;
                ALeft.Visible = CLeft.Visible = Center.Visible = CRight.Visible = ARight.Visible = true;
                NextScene(true);
            }
        }
        void MenuUpdate(bool q)
        {
            if (!q)
            {
                NewGame.Visible  =
                Options.Visible  = 
                _exit.Visible    = 
                Next.Visible     = 
                label4.Visible   = 
                SaveGame.Visible = false;

                trygame =
                ALeft.Visible = CLeft.Visible = Center.Visible = CRight.Visible = ARight.Visible =
                MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = true;
            }
            else
            {
                NewGame.Visible  = 
                Options.Visible  = 
                label4.Visible   = 
                _exit.Visible    = 
                SaveGame.Visible = true;

                if (sect != 0)
                    Next.Visible = true;

                trygame =
                ALeft.Visible = CLeft.Visible = Center.Visible = CRight.Visible = ARight.Visible =
                MessBox_1.Visible = MessBox_2.Visible = MessBox_3.Visible = MessBox_4.Visible = MessBox_5.Visible = false;
                pictureBox1.BackgroundImage = new Bitmap(lua.images + "logo.gif");
            }

            Focus();
        }
    }
}
