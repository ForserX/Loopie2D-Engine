using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SoundSystem;

namespace Loopie2D
{
    public partial class Form1 : Form
    {

        //Прокомментирую, а то уже забыл, что к чему...
        void NextScene(bool load)
        {
            // Remove old frame data
            SpriteListPic.Dispose();
            SpriteListPic = new Bitmap(ALeft.Size.Width, ALeft.Size.Height);
            lua.lua.Pop();

            //Флажок для лоадера
            if (!load)
            {
                SoundOldName = lua.GetSoundActive();
                ++sect;

                //Тут мы определяем секцию, костыльно и не интересно
                sect_string = (sect_label == 0) ? Convert.ToString(sect) : Convert.ToString(sect) + sect_old;
                if (sect_next != 0 && sect_lb_old != sect_label)
                {
                    sect_old += "_" + Convert.ToString(sect_next);
                    sect_string = Convert.ToString(sect) + sect_old;
                    sect_lb_old = sect_label;
                }
            }

            //Load vars
            string TypeCurrentScene = ifs.GetString(LuaAPI.cfg + GameScenarioFile, sect_string, "type");
            string ScriptFileName = ifs.GetString(LuaAPI.cfg + GameScenarioFile, sect_string, "name");

            switch (TypeCurrentScene)
            {
                case "SceneDropper":
                    {
                        sect_string = ifs.GetString(LuaAPI.cfg + GameScenarioFile, sect_string, "id");
                        var SplitedSect = sect_string.Split('_');
                        sect = Convert.ToInt32(SplitedSect[0]);
                        sect_old = sect_string.Substring(SplitedSect[0].Length, sect_string.Length - SplitedSect[0].Length);
                        NextScene(true);
                        return;
                    }
                case "None":
                    {
                        return;
                    }
                case "LuaScript":
                    {
                        lua.LuaFunc(ScriptFileName, ifs.GetString(LuaAPI.cfg + GameScenarioFile, sect_string, "func"));
                        break;
                    }
                case "Question":
                    {
                        lua.LuaFunc(ScriptFileName, ifs.GetString(LuaAPI.cfg + GameScenarioFile, sect_string, "func"));
                        LablesCount = lua.GetLabelNum();
                        label_text = new Label[LablesCount]; // Set size
                        for (int it = 0; it < LablesCount; it++)
                        {
                            label_text[it] = new System.Windows.Forms.Label
                            {
                                AutoSize = true,
                                Name = Convert.ToString(it + 1),
                                BackColor = System.Drawing.Color.Transparent,
                                Location = new System.Drawing.Point(10, 22 + 14 * it),
                                Visible = true,
                                Text = lua.GetLabelText(it),
                                Parent = UniversalPanel
                            };
                            label_text[it].Click += this.Question_Click;
                        }
                        Label_Helper(true, LablesCount);
                        return;
                    }
                default:
                    {
                        MessageBox.Show("Error: Unknown scene type!");
                        return;
                    }
            }

            string[] ActorText = lua.GetText().Split(' ');

            // Music
            if (SoundFlagCheck.Checked && (!SoundActive || lua.GetSoundActive() != SoundOldName))
            {
                player.Open(new Uri(LuaAPI.snd + lua.GetSoundActive(), UriKind.Relative));
                player.Play();
                SoundActive = true;
            }

            // Draw ActorName
            SpeakerName.Visible = true;
            SpeakerName.ForeColor = SetColor(lua.GetNameColor());
            SpeakerName.Text = lua.GetName();

            // Для отступов строк
            int old_y = 35, StrSize = 0, StrEndl = 0;
            MessBox_1.Image = (Image)new Bitmap(MessBox_1.Width, MessBox_1.Height);

            using (Graphics g = Graphics.FromImage(MessBox_1.Image))
            {
                // Считаем строки
                old_y -= 14;
                for (var i = 0; i <= ActorText.Length; i++)
                {
                    if (StrSize < TextWidth && i != ActorText.Length)
                    {
                        StrSize += ActorText[i].Length;
                        if (i != ActorText.Length - 1)
                        {
                            if (StrSize + ActorText[i + 1].Length >= TextWidth)
                                StrSize = TextWidth + 12;
                        }
                    }
                    else
                    {
                        for (int CreatLineIter = StrEndl; CreatLineIter < i; CreatLineIter++)
                            SpeakerTextString += ActorText[CreatLineIter] + " ";

                        // Set endl pos
                        StrEndl = i;

                        if (i != ActorText.Length)
                            StrSize = ActorText[i].Length;

                        old_y += 14;
                        g.DrawString(SpeakerTextString, new Font(lua.GetTextFont(), 10, FontStyle.Bold), new SolidBrush(SetColor(lua.GetTextColor())), new Point(10, old_y));
                        SpeakerTextString = "";
                    }
                }
            }

            // Drawing img
            this.ALeft.Image = null;
            int inum = lua.GetImgNum() - 1;

            if (inum > 0)
            {
                for (int it = 1; it <= inum; it++)
                {
                    SpriteBoxesHolder(new Bitmap(LuaAPI.images + lua.GetImageText(it)), lua.GetImageTextPos(it), 0, lua.GetImageScale(it));
                }
            }
            this.pictureBox1.BackgroundImage = new Bitmap(LuaAPI.images + lua.GetImageText(0));
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            GameList = new string[50];
            uint Iterator = 0;

            // Disable old sections data
            sect = 0;
            sect_next = 0;
            sect_lb_old = 0;
            sect_label = 0;
            sect_string = "";
            sect_old = "";

            // Mod supporter
            string[] GameFilesList = Directory.GetFiles(LuaAPI.cfg);
            if (GameFilesList.Length > 1)
            {
                foreach (string file_name in GameFilesList)
                {
                    GameList[Iterator] = file_name;
                    Iterator++;
                }

                label_text = new Label[Iterator]; // Set size
                for (int it = 0; it < Iterator; it++)
                {
                    label_text[it] = new System.Windows.Forms.Label
                    {
                        AutoSize = true,
                        Name = Convert.ToString(it + 1),
                        BackColor = System.Drawing.Color.Transparent,
                        Location = new System.Drawing.Point(10, 22 + 14 * it),
                        Visible = true,
                        Text = ifs.GetString(GameList[it], "header", "name"),
                        Parent = UniversalPanel
                    };
                    label_text[it].Click += this.GameScenarioSelected;
                }
                Label_Helper(true, (int)Iterator);
            }
            else
            {
                MessBox_1.Visible = true;
                LoadList.Visible = false;

                GameScenarioFile = GameFilesList[0].Split('\\').Last();
                MenuUpdate(false);
                NextScene(false);

                GameStarted = true;
            }
        }
    }
}