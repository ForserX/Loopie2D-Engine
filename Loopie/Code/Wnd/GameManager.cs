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
    struct SectionEditon 
    {
        public int Idx;
        public int Section;
        public int SectionNext;
        public int SectionLabel;
        public int SectionLabelOld;

        public string SectionString;
        public string SectionStringOld;

        public void Save(ref INIManager ifs, string path)
        {
            ifs.WritePrivateStringA("param", Idx.ToString() + "sect", Convert.ToString(Section), path);
            ifs.WritePrivateStringA("param", Idx.ToString() + "sect_string", SectionString, path);
            ifs.WritePrivateStringA("param", Idx.ToString() + "sect_old", SectionStringOld, path);
            ifs.WritePrivateStringA("param", Idx.ToString() + "sect_label", Convert.ToString(SectionLabel), path);
        }

        public void Load(ref INIManager ifs, string path, int NewIdx)
        {
            Idx = NewIdx;

            Section = Convert.ToInt32(ifs.GetString(path, "param", Idx.ToString() + "sect"));
            SectionStringOld = ifs.GetString(path, "param", Idx.ToString() + "sect_old");
            SectionString = ifs.GetString(path, "param", Idx.ToString() + "sect_string");
            SectionLabel = Convert.ToInt32(ifs.GetString(path, "param", Idx.ToString() + "sect_label"));
        }
    };

    public partial class Form1 : Form
    {
        bool isVisualNovel;

        //Прокомментирую, а то уже забыл, что к чему...
        void NextScene(bool load, ref SectionEditon CurrSection)
        {
            // Remove old frame data
            SpriteListPic.Dispose();
            SpriteListPic = new Bitmap(this.Size.Width, this.Size.Height);
            lua.lua.Pop();

            //Флажок для лоадера
            if (!load || bActionState)
            {
                SoundOldName = lua.GetSoundActive();
                CurrSection.Section++;

                //Тут мы определяем секцию, костыльно и не интересно
                CurrSection.SectionString = (CurrSection.SectionLabel == 0) ?
                    Convert.ToString(CurrSection.Section) : Convert.ToString(CurrSection.Section) + CurrSection.SectionStringOld;

                if (CurrSection.SectionNext != 0 && CurrSection.SectionLabelOld != CurrSection.SectionLabel)
                {
                    CurrSection.SectionStringOld += "_" + Convert.ToString(CurrSection.SectionNext);
                    CurrSection.SectionString = Convert.ToString(CurrSection.Section) + CurrSection.SectionStringOld;
                    CurrSection.SectionLabelOld = CurrSection.SectionLabel;
                }
            }

            //Load vars
            string TypeCurrentScene = ifs.GetString(LuaAPI.cfg + GameScenarioFile, CurrSection.SectionString, "type");
            string ScriptFileName = ifs.GetString(LuaAPI.cfg + GameScenarioFile, CurrSection.SectionString, "name");

            switch (TypeCurrentScene)
            {
                case "SceneDropper":
                    {
                        CurrSection.SectionString = ifs.GetString(LuaAPI.cfg + GameScenarioFile, CurrSection.SectionString, "id");
                        var SplitedSect = CurrSection.SectionString.Split('_');
                        CurrSection.Section = Convert.ToInt32(SplitedSect[0]);
                        CurrSection.SectionStringOld = CurrSection.SectionString.Substring(SplitedSect[0].Length, CurrSection.SectionString.Length - SplitedSect[0].Length);
                        NextScene(true, ref CurrSection);
                        return;
                    }
                case "None":
                    {
                        return;
                    }
                case "LuaScript":
                    {
                        lua.LuaFunc(ScriptFileName, ifs.GetString(LuaAPI.cfg + GameScenarioFile, CurrSection.SectionString, "func"));
                        break;
                    }
                case "Question":
                    {
                        lua.LuaFunc(ScriptFileName, ifs.GetString(LuaAPI.cfg + GameScenarioFile, CurrSection.SectionString, "func"));
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
                        Label_Helper(true, LablesCount, ref CurrSection);
                        return;
                    }
                default:
                    {
                        if (isVisualNovel)
                            MessageBox.Show("Error: Unknown scene type!");
                        else
                            bActionState = false;

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
            this.BackgroundImage = new Bitmap(LuaAPI.images + lua.GetImageText(0));
            int inum = lua.GetImgNum() - 1;

            if (inum > 0)
            {
                for (int it = 1; it <= inum; it++)
                {
                    SpriteBoxesHolder(new Bitmap(LuaAPI.images + lua.GetImageText(it)), lua.GetImageTextPos(it), 0, lua.GetImageScale(it));
                }
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            GameList = new string[50];

            // Mod supporter
            string[] GameFilesList = Directory.GetFiles(LuaAPI.cfg);
            if (GameFilesList.Length > 1)
            {
                uint Iterator = 0;
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
                Label_Helper(true, (int)Iterator, ref UsSectList[SectionID]);
            }
            else
            {
                MessBox_1.Visible = true;
                LoadList.Visible = false;

                GameScenarioFile = GameFilesList[0].Split('\\').Last();
                MenuUpdate(false);

                isVisualNovel = ifs.GetString(LuaAPI.cfg + GameScenarioFile, "header", "mode") == "VisualNovel";
                if (!isVisualNovel)
                    InitObjectsList();

                NextScene(false, ref UsSectList[SectionID]);
                GameStarted = true;
            }
        }
    }
}