using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Loopie2D
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label[] label_text;
        private Loopie.Code.Content.ClickableObj[] UsableObjects;

        Bitmap SpriteListPic;
        private int LablesCount;

        private void MainMenuInit()
        {
            lua.LuaFunc("MainMenu", GameStarted ? "Started" : "PreStart");
            this.pictureBox1.BackgroundImage = new Bitmap(LuaAPI.images + lua.GetMenuTbl("Background"));

            // Exit button
            this.ExitButton.Text = lua.GetMenuTbl("ExitText");
            this.ExitButton.ForeColor = SetColor(lua.GetMenuTbl("ExitColor"));
            this.ExitButton.Location = lua.GetMenuButtonLocation("Exit");
            this.ExitButton.Font = new System.Drawing.Font(lua.GetMenuTbl("ExitFont"), 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            // New game button
            this.NewGame.Text = lua.GetMenuTbl("NewGameText");
            this.NewGame.ForeColor = SetColor(lua.GetMenuTbl("NewGameColor"));
            this.NewGame.Location = lua.GetMenuButtonLocation("NewGame");
            this.NewGame.Font = new System.Drawing.Font(lua.GetMenuTbl("NewGameFont"), 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            // Options button
            this.Options.Text = lua.GetMenuTbl("OptionsText");
            this.Options.ForeColor = SetColor(lua.GetMenuTbl("OptionsColor"));
            this.Options.Location = lua.GetMenuButtonLocation("Options");
            this.Options.Font = new System.Drawing.Font(lua.GetMenuTbl("OptionsFont"), 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            // Load Game button
            this.LoadGameButton.Text = lua.GetMenuTbl("LoadText");
            this.LoadGameButton.ForeColor = SetColor(lua.GetMenuTbl("LoadColor"));
            this.LoadGameButton.Location = lua.GetMenuButtonLocation("Load");
            this.LoadGameButton.Font = new System.Drawing.Font(lua.GetMenuTbl("LoadFont"), 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            // Save Game button
            if (GameStarted)
            {
                this.SaveGameButton.Text = lua.GetMenuTbl("SaveText");
                this.SaveGameButton.ForeColor = SetColor(lua.GetMenuTbl("SaveColor"));
                this.SaveGameButton.Location = lua.GetMenuButtonLocation("Save");
                this.SaveGameButton.Font = new System.Drawing.Font(lua.GetMenuTbl("SaveFont"), 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                // Continue button
                this.Next.Text = lua.GetMenuTbl("NextText");
                this.Next.ForeColor = SetColor(lua.GetMenuTbl("NextColor"));
                this.Next.Location = lua.GetMenuButtonLocation("Next");
                this.Next.Font = new System.Drawing.Font(lua.GetMenuTbl("NextFont"), 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }

        void inputBox()
        {
            UniversalPanel.Width = 190;
            InputNameLable.Visible = true;
            textBox1.Visible = true;
            UniversalPanel.Location = new System.Drawing.Point((this.Width - UniversalPanel.Width) / 2, UniversalPanel.Location.Y);
            UniversalPanel.Height = 85;
            UniversalPanel.Visible = true;
            СancelButton.Visible = true;
            SaveButton.Visible = true;
        }
        private void СancelButton_Click(object sender, EventArgs e)
        {
            HideInputBox();
        }

        void HideInputBox()
        {
            InputNameLable.Visible      = false;
            textBox1.Visible    = false;
            UniversalPanel.Visible      = false;
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
            Label_Helper(false, LablesCount);

            MessBox_1.Visible = true;
            LoadList.Visible = false;
            
            if (ifs.GetString(LuaAPI.cfg + GameScenarioFile, "header", "mode") == "VisualNovel")
                NextScene(false);
            else
                ;// Soon

            GameStarted = true;
        }

        private void Question_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            sect_next = Convert.ToInt32(lab.Name);
            Label_Helper(false, LablesCount);
        }

        private void SpriteBoxesHolder(Image FreeMovePicture, int posX, int posY, float Scale = 2)
        {
            using (Graphics SpGr = Graphics.FromImage(SpriteListPic))
            {
                float TryPosY = 0;
                if(SpriteListPic.Size.Height < FreeMovePicture.Size.Height)
                {
                    float DeltPos = (float)((double)FreeMovePicture.Size.Height / (double)SpriteListPic.Size.Height);
                    Scale = Scale < 1.01 ? Scale : Scale - DeltPos;

                    if (FreeMovePicture.Size.Height * Scale <= SpriteListPic.Size.Height)
                        TryPosY = SpriteListPic.Size.Height - FreeMovePicture.Size.Height * Scale;
                }

                SpGr.DrawImage(FreeMovePicture, posX, TryPosY, FreeMovePicture.Size.Width * Scale, FreeMovePicture.Size.Height * Scale);
            }
            ALeft.Image = SpriteListPic;
        }
    
        private void Label_Helper(bool q, int num)
        {
            if (q)
			{
				this.ALeft.Image = null;
				MessBox_1.Visible = false;

				UniversalPanel.Location = new System.Drawing.Point((this.Width - UniversalPanel.Width) / 2, UniversalPanel.Location.Y);
				UniversalPanel.Width = 150;

				for (int j = 0; j < num; j++)
                {
                    this.UniversalPanel.Controls.Add(this.label_text[j]);

                    if (label_text[j].Width >= UniversalPanel.Width)
						UniversalPanel.Width = label_text[j].Width + 15;

                    label_text[j].Location = new System.Drawing.Point(10, label_text[j].Location.Y - 15 + j);
                }

                UniversalPanel.Height = 10 + 15 * num;
                UniversalPanel.Visible = true;

                sect_label += 1;
            }
            else
            {
                for (int j = 0; j < num; j++)
                    label_text[j].Dispose();

				MessBox_1.Visible = true;
				UniversalPanel.Visible = false;
                NextScene(false);
            }
        }
        void MenuUpdate(bool q)
        {
            MainMenuInit();

            if (!q)
            {
                NewGame.Visible  =
                Options.Visible  = 
                ExitButton.Visible    = 
                Next.Visible     = 
                SaveGameButton.Visible =
                LoadGameButton.Visible   =  false;

				TryGame = true;
                MessBox_1.Visible = true;
            }
            else
            {
                NewGame.Visible  = 
                Options.Visible  = 
                LoadGameButton.Visible   = 
                ExitButton.Visible    = true;

                if (sect != 0)
                    Next.Visible = true;

				TryGame = false;
                MessBox_1.Visible = false;
				this.ALeft.Image = null;
                SaveGameButton.Visible = GameStarted;
            }

            Focus();
        }
    }
}
