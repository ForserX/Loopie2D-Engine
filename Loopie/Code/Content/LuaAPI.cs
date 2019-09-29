using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaInterface;
using Loopie;

namespace Visual
{
    public class LuaAPI
    {
        public string cfg, userdata, scripts, images, snd;
        private string LoaderHookName;
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
            cfg      = ifs.GetString("global", "config");
            userdata = ifs.GetString("global", "user");
            scripts  = ifs.GetString("global", "scripts");
            images   = ifs.GetString("global", "img");
            snd      = ifs.GetString("global", "snd");
            ////////////////////////////////////////////////////////
            /// Lua namespace setter
            lua["IFS"]  = new INIManager();
            lua["Text"] = "";
            lua["ActorName"] = "";
            lua["Sound"] = "0";
            lua.NewTable("Font");
            lua.NewTable("Scene");

            lua.RegisterFunction("AddLoaderHook", this, typeof(LuaAPI).GetMethod("SetHook"));
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Loader hooks
        public void SetHook(string HookName)
        {
            LoaderHookName = HookName;
        }
        public string GetHook()
        {
            return LoaderHookName;
        }
        public void CallHook()
        {
            LuaFunc("Loader", LoaderHookName);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Tables
        public string GetSnd() { return (string)lua["Sound"]; }
        public string GetName() { return (string)lua["ActorName"]; }
        public string GetText() { return (string)lua["Text"]; }
        public string GetTextColor() { return (string)lua.GetTable("Font")["TextColor"]; }
        public string GetNameColor() { return (string)lua.GetTable("Font")["NameColor"]; }
        public int GetLabelNum() { return (int)(double)lua.GetTable("Scene")["Options"]; }
        public string GetImageText(int num) { return (string)lua.GetTable("Scene")["Image" + Convert.ToString(num)]; }
        public int GetImgNum() { return (int)(double)lua.GetTable("Scene")["Images"]; }
        public string GetLabelText(int num) { return (string)lua.GetTable("Scene")["Option" + Convert.ToString(num)]; }
        public string GetTextFont() { return (string)lua.GetTable("Font")["Text"]; }
        public string GetNameFont() { return (string)lua.GetTable("Font")["Name"]; }
        public bool GetFreeMove() { return (bool)lua["FreeMove"]; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GetImageTextPos(int num)
        {
            return (int)(double)lua.GetTable("Scene")["Image" + Convert.ToString(num) + "Pos"];
        }
        public float GetImageScale(int num)
        {
            double Size = 0;
            try
            {
                Size = (double)lua.GetTable("Scene")["Image" + Convert.ToString(num) + "Scale"];
            }
            catch (Exception ex)
            {
                Size = 2;
            }
            return Convert.ToSingle(Size);
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
