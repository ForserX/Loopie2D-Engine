using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaInterface;

namespace Visual
{
    public class FormAPIForLua
    {

    }
    public class LuaAPI
    {
        public string cfg, userdata, scripts, images, snd;

        private INIManager ifs;
        public Lua lua = new Lua();
        public LuaAPI()
        {
            ifs = new INIManager(@"..\\setting.ini");

            cfg      = ifs.GetPrivateString("global", "config");
            userdata = ifs.GetPrivateString("global", "user");
            scripts  = ifs.GetPrivateString("global", "scripts");
            images   = ifs.GetPrivateString("global", "img");
            snd      = ifs.GetPrivateString("global", "snd");

            //lua["Form"] = new FormAPIForLua();
            lua["IFS"]  = new INIManager();
            lua["Text"] = "";
            lua["ActorName"] = "";
            lua["Sound"] = "0";
            lua["ImageNum"] = 1;
            lua.NewTable("Color");
            lua.NewTable("Image");

            for (int i = 0; i < 10; i++)
                lua.GetTable("Image")[i] = "";
        }
        public int GetImageNum()
        {
            return Convert.ToInt32(lua["ImageNum"]);
        }
        public string GetSnd()
        {
            return (string)lua["Sound"];
        }
        public string GetName()
        {
            return (string)lua["ActorName"];
        }
        public string GetText()
        {
            return (string)lua["Text"];
        }
        public string GetTextColor()
        {
            return (string)lua.GetTable("Color")[0];
        }
        public string GetNameColor()
        {
            return (string)lua.GetTable("Color")[1];
        }

        public string GetImage(int num)
        {
            return (string)lua.GetTable("Image")[num];
        }
        public void LuaFunc(string file, string func)
        {
            try
            {
                lua.DoFile(scripts + file + ".lua");
                LuaFunction function = lua[func] as LuaFunction;
                function.Call();
            }
            catch (LuaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
