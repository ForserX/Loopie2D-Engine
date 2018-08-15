#include "stdafx.h"
#include "LoopFS.h"
#include "IParserSystem.h"

CLoopFS::CLoopFS()
{
	pPathList	= new SPathList();
	pParser		= new config("../setting.ini");
	pLuaInter	= new CVMLua();

	pPathList->Configs  = pParser->get_value("global", "config");
	pPathList->Scripts  = pParser->get_value("global", "scripts");
	pPathList->Img	    = pParser->get_value("global", "img");
	pPathList->UserData = pParser->get_value("global", "user");
	pPathList->Snd      = pParser->get_value("global", "snd");
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