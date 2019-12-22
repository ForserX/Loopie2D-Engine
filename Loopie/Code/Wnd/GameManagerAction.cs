using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loopie2D
{
    public partial class Form1 : Form
    {
        private bool bActionState = false;
        private PictureBox[] UsableObjects;
        private string[] UsObjScen;
        private string OldScenario;

        private void ObjectClicked(object sender, EventArgs e)
        {
            PictureBox CurrentObj = (PictureBox)sender;
            CurrentObj.Focus();
        }

        private void InitObjectsList()
        {
            int ObjCount = Convert.ToInt32(ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", "count")) + 1;
            UsableObjects = new PictureBox[ObjCount];
            UsObjScen = new string[ObjCount];
            UsSectList = new SectionEditon[ObjCount];

            for (int Iter = 1; Iter < ObjCount; Iter++)
            {
                string ValidIter = (Iter - 1).ToString();
                string CurrObject = ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", ValidIter + "_scene");
                string CurrObjectImage = LuaAPI.images + ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", ValidIter + "_image");

                int SizeH = Convert.ToInt32(ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", ValidIter + "_image_h"));
                int SizeW = Convert.ToInt32(ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", ValidIter + "_image_w"));

                int PosX = Convert.ToInt32(ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", ValidIter + "_image_x"));
                int PosY = Convert.ToInt32(ifs.GetString(LuaAPI.cfg + GameScenarioFile, "objects", ValidIter + "_image_y"));

                // Make object picture
                UsableObjects[Iter] = new PictureBox
                {
                    AutoSize = true,
                    Size = new System.Drawing.Size(3 * SizeW, 3 * SizeH),
                    Name = Convert.ToString(Iter + 1),
                    BackColor = System.Drawing.Color.Transparent,
                    Location = new System.Drawing.Point(PosX, PosY),
                    Visible = true,
                    Parent = this,
                };

                UsableObjects[Iter].MouseClick += ObjectClicked;
                UsableObjects[Iter].BackgroundImage = new System.Drawing.Bitmap(CurrObjectImage);
                UsableObjects[Iter].BackgroundImageLayout = ImageLayout.Stretch;
                UsObjScen[Iter] = CurrObject;

                this.Controls.Add(UsableObjects[Iter]);

                // Make object scenarion
                UsSectList[Iter] = new SectionEditon
                {
                    Idx = Iter, // 0 - Global
                    Section = 0,
                    SectionNext = 0,
                    SectionLabel = 0,
                    SectionLabelOld = 0,

                    SectionString = "",
                    SectionStringOld = ""
                };
            }

            OldScenario = GameScenarioFile;
        }

        private void NextAction()
        {
            for (uint Iter = 1; Iter < UsableObjects.Length; Iter++)
            {
                if (UsableObjects[Iter].Focused)
                {
                    bActionState = true;
                    GameScenarioFile = LuaAPI.cfg + UsObjScen[Iter];
                    NextScene(false, ref UsSectList[Iter]);
                    this.Focus();
                    SectionID = Iter;
                    break;
                }
            }

            if (!bActionState)
            {
                GameScenarioFile = OldScenario;
                SectionID = 0;
            }
        }
    }
}
