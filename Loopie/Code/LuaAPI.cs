using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaInterface;

namespace Visual
{
    public class LuaAPI
    {
        public string cfg, userdata, scripts, images, snd;

        private INIManager ifs;
        public Lua lua;
        public LuaAPI()
        {
            ////////////////////////////////////////////////////////
            /// Interfaces/Classes setter
            ifs = new INIManager(@"..\\setting.ini");
            lua = new Lua();
            ////////////////////////////////////////////////////////
            /// CFG setter
            cfg      = ifs.GetPrivateString("global", "config");
            userdata = ifs.GetPrivateString("global", "user");
            scripts  = ifs.GetPrivateString("global", "scripts");
            images   = ifs.GetPrivateString("global", "img");
            snd      = ifs.GetPrivateString("global", "snd");
            ////////////////////////////////////////////////////////
            /// Lua namespace setter
            lua["IFS"]  = new INIManager();
            lua["Text"] = "";
            lua["ActorName"] = "";
            lua["Sound"] = "0";
            lua.NewTable("Font");
            lua.NewTable("Scene");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////                                          ООП Методы                                                //////
        public string GetSnd() => (string)lua["Sound"];
        public string GetName() => (string)lua["ActorName"];
        public string GetText() => (string)lua["Text"];
        public string GetTextColor() => (string)lua.GetTable("Font")["TextColor"];
        public string GetNameColor() => (string)lua.GetTable("Font")["NameColor"];
        public int GetLabelNum() => (int)(double)lua.GetTable("Scene")["Options"];
        public string GetImageText(int num) => (string)lua.GetTable("Scene")["Image" + Convert.ToString(num)];
        public int GetImgNum() => (int)(double)lua.GetTable("Scene")["Images"];
        public string GetLabelText(int num) => (string)lua.GetTable("Scene")["Option" + Convert.ToString(num)];
        public string GetTextFont() => (string)lua.GetTable("Font")["Text"];
        public string GetNameFont() => (string)lua.GetTable("Font")["Name"];
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GetImageTextPos(int num)
        {
            switch ((string)lua.GetTable("Scene")["Image" + Convert.ToString(num) + "Pos"])
            {
                case "ALeft": return 1;
                case "Left": return 2;
                case "Center": return 3;
                case "Right": return 4;
                case "ARight": return 5;
                default: return 3;
            }
        }

        public void LuaFunc(string file, string func)
        {
            try
            {
                lua.DoFile(scripts + file + ".lua");
                (lua[func] as LuaFunction).Call();
            }
            catch (LuaException ex)
            {
                MessageBox.Show(text: ex.Message);
            }
        }
    }
}
