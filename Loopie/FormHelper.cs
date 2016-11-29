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
                try
                {
                    // Will not overwrite if the destination file already exists.
                    File.Copy(Path.Combine(lua.userdata, "temp.ini"), Path.Combine(lua.userdata, textBox1.Text + ".ini"));
                }
                // Catch exception if the file was already copied.
                catch (IOException copyError)
                {
                    MessageBox.Show(copyError.Message, "56", MessageBoxButtons.OK);
                }
            else
                MessageBox.Show("Error", "Введите название!", MessageBoxButtons.OK);
       
            HideInputBox();
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
        public void DrawHelper()
        {
            //Попробуем сделать многоуровневую отрисовку
            pictureBox1.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "backImage"));
            int str = Convert.ToInt32(ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "pic"));
            switch (str)
            {
                case 1:
                    pictureBox1.Image = pictureBox1.BackgroundImage;
                    pictureBox3.BackgroundImage = pictureBox1.BackgroundImage;
                    pictureBox3.Image = pictureBox1.Image;
                    break;
                case 2:
                    pictureBox1.Image = new Bitmap(lua.images + ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "Image_1"));
                    pictureBox3.BackgroundImage = pictureBox1.BackgroundImage;
                    pictureBox3.Image = pictureBox1.Image;
                    break;
                case 3:
                    pictureBox1.Image = new Bitmap(lua.images + ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "Image_1"));
                    pictureBox3.BackgroundImage = new Bitmap(lua.images + ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "Image_2"));
                break;
                case 4:
                    pictureBox3.Image = new Bitmap(lua.images + ifs.GetPrivateString(lua.userdata + "temp.ini", "param", "Image_3"));
                break;
            }
        }
        private void Label_Helper(bool q)
        {
            if (q)
            {
                panel1.Location = new System.Drawing.Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
                if (label1.Width >= panel1.Width)
                    panel1.Width = label1.Width + 10;
                else if (label2.Width >= panel1.Width)
                    panel1.Width = label2.Width + 10;
                else if (label3.Width >= panel1.Width)
                    panel1.Width = label3.Width + 10;


                label1.Location = new System.Drawing.Point((panel1.Width - label1.Width) / 2, label1.Location.Y);
                label2.Location = new System.Drawing.Point((panel1.Width - label2.Width) / 2, label2.Location.Y);
                label3.Location = new System.Drawing.Point((panel1.Width - label3.Width) / 2, label3.Location.Y);
                panel1.Height = 104;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                panel1.Visible = true;

                sect_label += 1;
            }
            else
            {

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                panel1.Visible = false;
            }
        }
        void MenuUpdate(bool q)
        {
            if (!q)
            {
                NewGame.Visible = false;
                Options.Visible = false;
                _exit.Visible = false;
                Next.Visible = false;
                label4.Visible = false;
                SaveGame.Visible = false;
                trygame = true;
                pictureBox2.Visible = true;
            }
            else
            {
                NewGame.Visible = true;
                Options.Visible = true;
                label4.Visible = true;
                _exit.Visible = true;
                SaveGame.Visible = true;

                if (sect != 0)
                    Next.Visible = true;

                trygame = false;
                pictureBox2.Visible = false;
                pictureBox4.Image = new Bitmap(lua.images + "logo.gif");
            }

            Focus();
        }
    }
}
