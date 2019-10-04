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

        string TableReader(string Table, string Key)
        {
            string Ret = "";
            using (LuaTable tabx = lua.GetTable(Table))
            {
                Ret = (string)tabx[Key];
            }
            return Ret;
        }

        int TableReaderI(string Table, string Key)
        {
            int Ret = -1;
            using (LuaTable tabx = lua.GetTable(Table))
            {
                Ret = (int)(double)tabx[Key];
            }
            return Ret;
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
        public string GetSnd()              { return (string)lua["Sound"]; }
        public string GetName()             { return (string)lua["ActorName"]; }
        public string GetText()             { return (string)lua["Text"]; }
        public string GetTextColor()        { return TableReader("Font", "TextColor"); }
        public string GetNameColor()        { return TableReader("Font", "NameColor"); }
        public string GetTextFont()         { return TableReader("Font", "Text"); }
        public string GetNameFont()         { return TableReader("Font", "Name"); }
        public string GetImageText(int num) { return TableReader("Scene", "Image" + Convert.ToString(num)); }
        public string GetLabelText(int num) { return TableReader("Scene", "Option" + Convert.ToString(num)); }

        public int GetImgNum()      { return TableReaderI("Scene", "Images"); }
        public int GetLabelNum()    { return TableReaderI("Scene", "Options"); }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int GetImageTextPos(int num)
        {
            return TableReaderI("Scene", "Image" + Convert.ToString(num) + "Pos");
        }
        public float GetImageScale(int num)
        {
            double Size = 0;
            try
            {
                Size = TableReaderI("Scene", "Image" + Convert.ToString(num) + "Scale");
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
