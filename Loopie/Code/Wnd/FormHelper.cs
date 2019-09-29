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
        Bitmap SpriteListPic;

        void inputBox()
        {
            panel1.Width = 190;
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

        Color SetColor(string obj)
        {
            switch (obj)
            {
                case "white": return Color.White;
                case "red": return Color.Red;
                case "blue": return Color.Blue;
                default: return Color.Black;
            }
        }

        private void GameScenarioSelected(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            var DefName = GameList[Convert.ToInt32(lab.Name) - 1].Split('\\');

            GameScenarioFile = DefName.Last();
            Label_Helper(false, lnum);

            MessBox_1.Visible = true;
            LoadList.Visible = false;
            MenuUpdate(false);

            GameStarted = true;
        }

        private void Question_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            sect_next = Convert.ToInt32(lab.Name);
            Label_Helper(false, lnum);
        }

        private void SpriteBoxesHolder(Image FreeMovePicture, int posX, int posY, float Scale = 2)
        {
            Graphics SpGr = Graphics.FromImage(SpriteListPic);
            SpGr.DrawImage(FreeMovePicture, posX * 2, posY * 2, FreeMovePicture.Size.Width / Scale, FreeMovePicture.Size.Height / Scale);
            ALeft.Image = SpriteListPic;
        }
    
        private void Label_Helper(bool q, int num)
        {
            if (q)
			{
				this.ALeft.Image = null;
				MessBox_1.Visible = false;

				panel1.Location = new System.Drawing.Point((this.Width - panel1.Width) / 2, panel1.Location.Y);
				panel1.Width = 150;

				for (int j = 0; j < num; j++)
                {
                    this.panel1.Controls.Add(this.label_text[j]);

                    if (label_text[j].Width >= panel1.Width)
						panel1.Width = label_text[j].Width + 15;

                    label_text[j].Location = new System.Drawing.Point(10, label_text[j].Location.Y - 15 + j);
                }

                panel1.Height = 10 + 15 * num;
                panel1.Visible = true;

                sect_label += 1;
            }
            else
            {
                for (int j = 0; j < num; j++)
                    label_text[j].Dispose();

				MessBox_1.Visible = true;
				panel1.Visible = false;
                NextScene(false);
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

				trygame = true;
                MessBox_1.Visible = true;
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

				trygame = false;
                MessBox_1.Visible = false;
				this.ALeft.Image = null;
				pictureBox1.BackgroundImage = new Bitmap(lua.images + "MainFormBack.jpg");
            }

            Focus();
        }
    }
}
