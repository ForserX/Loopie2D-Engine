////////////////////////////////////////
// author: ForserX, 2017-2018 (C)
// class : IParser - ini files parser			
////////////////////////////////////////
#pragma once
////////////////////////////////////////
#include <string>
#include <string_view>
#include <unordered_map>
#include <list>
////////////////////////////////////////

class config
{
	using string = std::string;
	using string_view = std::string_view;
public:
	struct section
	{
		bool isParent;
		std::string name;
		std::string parent;
		std::unordered_map<std::string, std::string> keyvalues;
	};

public:
	config() { }
	config(const string_view filename, bool create = false);

	void WriteSect(const string_view filename, const string_view sectionname, const string_view keyname, const string_view key, const string_view parent = "");
	void WriteSect(const string_view sectionname, const string_view keyname, const string_view key, const string_view parent = "");

	section* get_section(const string& sectionname);
	inline std::list<section>& get_sections() { return sections; };

	int		get_number(const string& sectionname, const string& keyname);
	bool	get_logic (const string& sectionname, const string& keyname);
	string	get_value (const string& sectionname, const string& keyname);
	float	get_float (const string& sectionname, const string& keyname);

private:
	void parse(const std::string& filename, bool create);
private:
	std::list<section> sections;
	section currentsection;
	std::string path;
};