#include "stdafx.h"
#include "LoopFS.h"
#include "IParserSystem.h"

CLoopFS::CLoopFS()
{
	pPathList	  = new SPathList();
	pSystemParser = new config("../setting.ini");
	pLuaInter	  = new CVMLua();

	pPathList->Configs  = pSystemParser->get_value("global", "config");
	pPathList->Scripts  = pSystemParser->get_value("global", "scripts");
	pPathList->Img	    = pSystemParser->get_value("global", "img");
	pPathList->UserData = pSystemParser->get_value("global", "user");
	pPathList->Snd      = pSystemParser->get_value("global", "snd");

	pParser = new config(pPathList->Configs + "test.ini");
}

void CLoopFS::CallScript(const char* name, const char* func)
{
	pLuaInter->CallScript(pPathList->Scripts.c_str(), name, func);
}

CLoopFS::~CLoopFS()
{
	delete pPathList;
	delete pParser;
	delete pLuaInter;
}

System::String ^ CLoopFS::ClrStr(const char * str)
{
	return gcnew System::String(str);
}

System::String ^ CLoopFS::ClrStr(std::string str)
{
	return gcnew System::String(str.c_str());
}