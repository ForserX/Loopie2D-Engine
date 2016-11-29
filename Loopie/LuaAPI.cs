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
        INIManager ifs = new INIManager();
        public void SetName(string n)
        {
            ifs.WritePrivateStringA("param", "name", n, @"..\userdata\temp.ini");
        }
        public void SetName(string n, string color)
        {
            ifs.WritePrivateStringA("param", "name", n, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "name_c", color, @"..\userdata\temp.ini");
        }
        public void SetText(string n)
        {
            ifs.WritePrivateStringA("param", "text", n, @"..\userdata\temp.ini");
        }
        //.
        public void SetBackImage(string n, string n2)
        {
            ifs.WritePrivateStringA("param", "backImage", n, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "pic", "2", @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "Image_1", n2, @"..\userdata\temp.ini");
        }
        public void SetBackImage(string n, string n2, string n3)
        {
            ifs.WritePrivateStringA("param", "backImage", n, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "pic", "3", @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "Image_1", n2, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "Image_2", n3, @"..\userdata\temp.ini");
        }
        public void SetBackImage(string n, string n2, string n3, string n4)
        {
            ifs.WritePrivateStringA("param", "backImage", n, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "pic", "3", @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "Image_1", n2, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "Image_2", n3, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "Image_", n4, @"..\userdata\temp.ini");
        }
        public void SetBackImage(string n)
        {
            ifs.WritePrivateStringA("param", "backImage", n, @"..\userdata\temp.ini");
            ifs.WritePrivateStringA("param", "pic", "1", @"..\userdata\temp.ini");
        }
        public void SetSound(string n)
        {
            if (ifs.GetPrivateString(@"..\userdata\temp.ini", "param", "snd_old") == "0")
                ifs.WritePrivateStringA("param", "snd_old", ifs.GetPrivateString(@"..\userdata\temp.ini", "param", "snd"), @"..\userdata\temp.ini");
            
            ifs.WritePrivateStringA("param", "snd", n, @"..\userdata\temp.ini");
        }
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

            lua["Form"] = new FormAPIForLua();
            lua["IFS"]  = new INIManager();

         //   lua.RegisterFunction("Name", this, typeof(LuaAPI).GetMethod("SetName"));
         //   lua.RegisterFunction("Text", this, typeof(LuaAPI).GetMethod("SetText"));
        }
        public void LuaFunc(string file, string func)
        {
            try
            {
                lua.DoFile(file + ".lua");
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
