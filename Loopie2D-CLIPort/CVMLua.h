#pragma once
#include "Lua/lua.hpp"
#include "LuaBridge\LuaBridge.h"

class CVMLua
{
public:
	CVMLua();
	~CVMLua();

	void				CallScript(const char* Path, const char* file, const char* fun);
	int					GetImagesCount();
	int					GetImageTextPos(int num);
	int					GetLabelsCount();

	System::String^		GetName();
	System::String^		GetText();
	System::String^		GetSnd();
	System::String^		GetFontColor();
	System::String^		GetFontNameColor();
	System::String^		GetFontTextType();
	System::String^		GetFontNameType();
	System::String^		GetImageName(unsigned num);
	System::String^		GetCurrentOption(unsigned num);

private:
	lua_State* LuaVM;
	luabridge::LuaRef* FontTable;
	luabridge::LuaRef* SceneTable;
};

