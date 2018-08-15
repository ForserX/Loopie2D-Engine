#pragma once
#include <string>
#include "CVMLua.h"
#include "IParserSystem.h"

struct SPathList
{
	std::string Configs;
	std::string Scripts;
	std::string Img;
	std::string Snd;
	std::string UserData;
};

class CLoopFS
{
public:
	CLoopFS();
	~CLoopFS();

	System::String^ ClrStr(const char* str);
	System::String^ ClrStr(std::string str);

	void CallScript(const char * name, const char* fun);
public:
	SPathList*	pPathList;
	CVMLua*		pLuaInter;
	config*		pParser;

public:
	config*		pSystemParser;
};