#include "stdafx.h"
#include "CVMLua.h"
#include "LuaBridge\LuaBridge.h"

#include <string>

CVMLua::CVMLua()
{
	LuaVM = luaL_newstate();
	luaL_openlibs(LuaVM);

//	lua_setglobal(LuaVM, "ActorName");
}

#include <fstream>

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
	lua_settop(LuaVM, 0);
	lua_register(LuaVM, "trip", sag);
	std::string fullpath = Path + std::string(file) + ".lua";
	
	std::ifstream fin(fullpath);
	// get pointer to associated buffer object
	std::filebuf* pbuf = fin.rdbuf();
	// get file size using buffer's members
	std::size_t size = pbuf->pubseekoff(0, fin.end, fin.in);
	pbuf->pubseekpos(0, fin.in);
	// allocate memory to contain file data
	char* buffer = new char[size];
	// get file data
	pbuf->sgetn(buffer, size);
	fin.close();

	std::string NewBuffer = buffer;
	NewBuffer += "\n "; NewBuffer += func; NewBuffer += "()";
	luaL_dostring(LuaVM, NewBuffer.c_str());
	lua_pcall(LuaVM, 0, 1, 0);
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
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Font")["TextColor"];
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontNameColor()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Font")["NameColor"];
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontTextType()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Font")["Text"];
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetFontNameType()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Font")["Name"];
	return gcnew System::String(s.cast<const char*>());
}

int CVMLua::GetImagesCount()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Scene")["Images"];
	return s.cast<int>();
}

int CVMLua::GetLabelsCount()
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Scene")["Options"];
	return s.cast<int>();
}

System::String^ CVMLua::GetCurrentOption(unsigned num)
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Scene")[("Option" + std::to_string(num)).c_str()];
	return gcnew System::String(s.cast<const char*>());
}

System::String^ CVMLua::GetImageName(unsigned num)
{
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Scene")[("Image" + std::to_string(num)).c_str()];
	return gcnew System::String(s.cast<const char*>());
}

int CVMLua::GetImageTextPos(int num)
{
	std::string CurrentPos = ("Image" + std::to_string(num) + "Pos");
	luabridge::LuaRef s = luabridge::getGlobal(LuaVM, "Scene")[CurrentPos.c_str()];
	
	if(CurrentPos == "ALeft") return 1;
	else if (CurrentPos == "Left") return 2;
	else if (CurrentPos == "Center") return 3;
	else if (CurrentPos == "Right") return 4;
	else return 5;
}