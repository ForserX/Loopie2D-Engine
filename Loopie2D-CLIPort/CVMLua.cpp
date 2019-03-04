#include "stdafx.h"
#include "CVMLua.h"

#include <fstream>
#include <string>

std::string readFile(const std::string& fileName) 
{
	std::ifstream f(fileName);
	std::stringstream ss;
	ss << f.rdbuf();
	return ss.str();
}

CVMLua::CVMLua()
{
	LuaVM = luaL_newstate();
	luaL_openlibs(LuaVM);

	lua_settop(LuaVM, 0);
}


CVMLua::~CVMLua()
{
	lua_close(LuaVM);
}

int sag(lua_State*)
{
	DebugBreak();
	return 0;
}

void CVMLua::CallScript(const char * Path, const char * file, const char* func)
{
	lua_register(LuaVM, "trip", sag);
	std::string fullpath = Path + std::string(file) + ".lua";
	
	std::string NewBuffer = readFile(fullpath);
	NewBuffer += "\n"; NewBuffer += func; NewBuffer += "()";
	luaL_dostring(LuaVM, NewBuffer.c_str());
	//lua_pcall(LuaVM, 0, 1, 0);

	//luaL_dofile(LuaVM, fullpath.c_str());
//	FontTable = luabridge::getGlobal(LuaVM, "Font");
//	SceneTable = luabridge::getGlobal(LuaVM, "Scene");
}

System::String^ CVMLua::GetName()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "ActorName");
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetText()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Text");
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetSnd()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Sound");
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontColor()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "FontTextColor");
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontNameColor()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "FontNameColor");
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontTextType()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "FontText");
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontNameType()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "FontName");
	return gcnew System::String(s.cast<const char*>());
}

int CVMLua::GetImagesCount()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "SceneImages");
	return s.cast<int>();
}

int CVMLua::GetLabelsCount()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "SceneOptions");
	return s.cast<int>();
}

System::String^ CVMLua::GetCurrentOption(unsigned num)
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, ("SceneOption" + std::to_string(num)).c_str());
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetImageName(unsigned num)
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, ("SceneImage" + std::to_string(num)).c_str());
	return gcnew System::String(s.cast<const char*>());
}

int CVMLua::GetImageTextPos(int num)
{
	std::string CurrentPos = ("Image" + std::to_string(num) + "Pos");
	CurrentPos = luabridge::getGlobal(LuaVM, ("Scene" + CurrentPos).c_str()).cast<std::string>();
	
	if(CurrentPos == "ALeft") return 1;
	else if (CurrentPos == "Left") return 2;
	else if (CurrentPos == "Center") return 3;
	else if (CurrentPos == "Right") return 4;
	else return 5;
}