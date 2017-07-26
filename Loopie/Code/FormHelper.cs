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
