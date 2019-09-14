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

namespace Visual
{
    public partial class Form1 : Form
    {

        //Прокомментирую, а то уже забыл, что к чему...
        void NextScene(bool load)
        {
            // Remove old frame data
            SpriteListPic = new Bitmap(ALeft.Size.Width, ALeft.Size.Height);
            lua.lua.Pop();

            //Флажок для лоадера
            if (!load)
            {
                snd_old = lua.GetSnd();
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
            string TypeCurrentScene = ifs.GetString(lua.cfg + GameScenarioFile, sect_string, "type");
            string ScriptFileName = ifs.GetString(lua.cfg + GameScenarioFile, sect_string, "name");

            switch (TypeCurrentScene)
            {
                case "SceneDropper":
                    {
                        sect_string = ifs.GetString(lua.cfg + GameScenarioFile, sect_string, "id");
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
                        lua.LuaFunc(ScriptFileName, ifs.GetString(lua.cfg + GameScenarioFile, sect_string, "func"));
                        break;
                    }
                case "Question":
                    {
                        lua.LuaFunc(ScriptFileName, ifs.GetString(lua.cfg + GameScenarioFile, sect_string, "func"));
                        lnum = lua.GetLabelNum();
                        label_text = new Label[lnum]; // Set size
                        for (int it = 0; it < lnum; it++)
                        {
                            label_text[it] = new System.Windows.Forms.Label
                            {
                                AutoSize = true,
                                Name = Convert.ToString(it + 1),
                                BackColor = System.Drawing.Color.Transparent,
                                Location = new System.Drawing.Point(10, 22 + 14 * it),
                                Visible = true,
                                Text = lua.GetLabelText(it),
                                Parent = panel1
                            };
                            label_text[it].Click += new System.EventHandler(this.Question_Click);
                        }
                        Label_Helper(true, lnum);
                        return;
                    }
                default:
                    {
                        MessageBox.Show("Error: Unknown scene type!");
                        return;
                    }
            }

            heroname = lua.GetName();
            ActorText = lua.GetText().Split(' ');

            // Music
            if (flag_snd.Checked && (!snd || lua.GetSnd() != snd_old))
            {
                player.Open(new Uri(lua.snd + lua.GetSnd(), UriKind.Relative));
                player.Play();
                snd = true;
            }

            // Draw ActorName
            SpeakerName.Visible = true;
            SpeakerName.ForeColor = SetColor(lua.GetNameColor());
            SpeakerName.Text = heroname;

            // Для отступов строк
            int old_y = 35, str = 0, num = 0;
            MessBox_1.Image = (Image)new Bitmap(MessBox_1.Width, MessBox_1.Height);
            Graphics g = Graphics.FromImage(MessBox_1.Image);

            // Считаем строки
            old_y -= 14;
            for (var i = 0; i <= ActorText.Length; i++)
            {
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
                    g.DrawString(ActorText_str, new Font(lua.GetTextFont(), 10, FontStyle.Bold), new SolidBrush(SetColor(lua.GetTextColor())), new Point(10, old_y));
                    ActorText_str = "";
                }
            }
            text_width = 5 * (checkBox1.Checked ? 36 : 27);
            g.Dispose();

            // Drawing img
            this.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
            this.pictureBox1.BackgroundImage = new Bitmap(lua.images + lua.GetImageText(0));
            this.ALeft.Image = null;
            inum = lua.GetImgNum() - 1;

            if (inum > 0)
            {
                for (int it = 1; it <= inum; it++)
                {
                    SpriteBoxesHolder(new Bitmap(lua.images + lua.GetImageText(it)), lua.GetImageTextPos(it), 0, lua.GetImageScale(it));
                }
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            GameList = new string[50];
            uint Iterator = 0;

            // Mod supporter
            var GameFilesList = Directory.GetFiles(lua.cfg);
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
                        Parent = panel1
                    };
                    label_text[it].Click += new System.EventHandler(this.GameScenarioSelected);
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

            // Disable old sections data
            sect = 0;
            sect_next = 0;
            sect_lb_old = 0;
            sect_label = 0;
            sect_string = "";
            sect_old = "";
        }
    }
}