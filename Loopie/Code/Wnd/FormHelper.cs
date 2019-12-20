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

        Bitmap SpriteListPic;
        private int LablesCount;

        private void MainMenuInit()
        {
            lua.LuaFunc("MainMenu", GameStarted ? "Started" : "PreStart");
            this.BackgroundImage = new Bitmap(LuaAPI.images + lua.GetMenuTbl("Background"));

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

            MenuUpdate(false);
            Label_Helper(false, LablesCount, ref GlobalSection);

            MessBox_1.Visible = true;
            LoadList.Visible = false;

            GameStarted = true;

            isVisualNovel = ifs.GetString(LuaAPI.cfg + GameScenarioFile, "header", "mode") == "VisualNovel";
            if (!isVisualNovel)
                InitObjectsList();
        }

        private void Question_Click(object sender, EventArgs e)
        {
            // Warn! Global section only for Visual Novel type! 
            Label lab = (Label)sender;
            GlobalSection.SectionNext = Convert.ToInt32(lab.Name);
            Label_Helper(false, LablesCount, ref GlobalSection);
        }

        private void SpriteBoxesHolder(Image FreeMovePicture, int posX, int posY, float Scale = 2)
        {
            using (Graphics SpGr = Graphics.FromImage(SpriteListPic))
            {
                SpGr.DrawImage(this.BackgroundImage, 0, 0, this.Size.Width, this.Size.Height);

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
            this.BackgroundImage = SpriteListPic;
        }
    
        private void Label_Helper(bool q, int num, ref SectionEditon CurrSection)
        {
            if (q)
			{
				//this.BackgroundImage = null;
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

                CurrSection.SectionLabel++;
            }
            else
            {
                for (int j = 0; j < num; j++)
                    label_text[j].Dispose();

				MessBox_1.Visible = true;
				UniversalPanel.Visible = false;
                NextScene(false, ref CurrSection);
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

                if (LastSection.Section != 0)
                    Next.Visible = true;

				TryGame = false;
                MessBox_1.Visible = false;
                //this.BackgroundImage = null;
                SaveGameButton.Visible = GameStarted;
            }

            Focus();
        }
    }
}
