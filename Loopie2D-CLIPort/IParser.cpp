////////////////////////////////////////
// author: ForserX, 2017-2018 (C)
// class : IParser - ini files parser			
////////////////////////////////////////
#include "stdafx.h"
#include "IParserSystem.h"
////////////////////////////////////////
#include <fstream>
#include <iostream>
#include <algorithm>
////////////////////////////////////////

// Trim leading white-spaces
inline std::string_view ltrim(std::string_view s)
{
	const size_t startpos = s.find_first_not_of(" \t\r\n\v\f");
	if (std::string::npos != startpos)
		s = s.substr(startpos);
	return s;
}

// Trim trailing white-spaces
inline std::string_view rtrim(std::string_view s)
{
	const size_t endpos = s.find_last_not_of(" \t\r\n\v\f");
	if (std::string::npos != endpos)
		s = s.substr(0, endpos + 1);
	return s;
}

// Getting and founding sects
inline std::list<config::section>::iterator get_found(const std::string& sectname, std::list<config::section>& sects)
{
	return std::find_if(sects.begin(), sects.end(), [sectname](const config::section& sect) { return sect.name.compare(sectname) == 0; });
}

// Config to parse
config::config(const string_view filename, bool create)
{
	currentsection.isParent = false;
	string new_file = "";
	bool isPath = false;
	for (unsigned it = 0; it < filename.length(); it++)
	{
		if (filename[it] == '/' && filename[it + 1] != '/' && !isPath)
		{
			isPath = true;
			new_file += "//";
		}
		else
		{
			isPath = false;
			new_file += filename[it];
		}
	}
	path = new_file;
	parse(new_file, create);
}

/// <summary>
/// Writing the section
/// </summary>
void config::WriteSect(const std::string_view filename, const std::string_view sectionname, const std::string_view keyname, const std::string_view key, const std::string_view parent)
{
	std::ofstream inp(filename.data(), std::ios::in);

	if (!inp)
	{
		std::ofstream ofs(filename.data());
		ofs.close();
		inp.open(filename.data());
		if (!inp)
		{
			throw std::invalid_argument(std::string(filename) + " could not be opened");
		}
	}
	inp << "[" << sectionname << "]";
	if (parent != "")
	{
		inp << ":" << parent;
	}
	inp << std::endl << keyname << " = " << key;
	inp.close();
};

// Getting the section
config::section* config::get_section(const string& sectionname)
{
	std::list<config::section>::iterator found = get_found(sectionname, sections);
	if (found != sections.end())
	{
		return &*found;
	}
	return 0;
}

// Get value of sector
std::string config::get_value(const string& sectionname, const string& keyname)
{
	const section* sect = get_section(sectionname);
	if (sect)
	{
		auto it = sect->keyvalues.find(keyname);
		auto newsect = [] (std::string sect) {if (sect[0] == ' ') sect = sect.erase(0, 1); return sect; };
		if (it != sect->keyvalues.end())
		{
			return newsect(it->second);
		}
		else if ((it = sect->keyvalues.find(keyname + ' ')) != sect->keyvalues.end())
		{
			return newsect(it->second);
		}
		else if ((currentsection.parent[0] != '#') && !currentsection.isParent)
		{
			currentsection.isParent = true;
			string val = get_value(currentsection.parent, keyname);
			currentsection.isParent = false;
			return val;
		}
	}
	return "Error reading! Section: " + sectionname + " Key: " + keyname;
}

// Parse method
void config::parse(const string& filename, bool create)
{
	std::ifstream fstrm(filename.data());

	if (!fstrm)
	{
		if (create)
		{
			std::ofstream ofs(filename.data());
			ofs.close();
			fstrm.open(filename.data());
			if (!fstrm)
			{
				throw std::invalid_argument(filename + " could not be opened");
			}
		}
		else throw std::invalid_argument(filename + " could not be opened");
	}
	for (string line; std::getline(fstrm, line);)
	{
		// if a comment
		if (!line.empty() && (line[0] == ';' || line[0] == '#'))
		{
			// allow both ; and # comments at the start of a line
		}
		else if (line[0] == '[') /* A "[section]" line */
		{
			const size_t end = line.find_first_of(']');

			// Setter parent section
			if (line.find_first_of(':') != string::npos)
			{
				string line_dub = line;
				currentsection.parent = line_dub.erase(0, end + 2);
				line.erase(end + 1, line.length() - 1);
			}
			else
			{
				currentsection.parent = "#";
			}
			if (end != string::npos)
			{
				// this is a new section so if we have a current section populated, add it to list
				if (!currentsection.name.empty()) {
					sections.push_back(currentsection);  // copy
					currentsection.name.clear();  // clear section for re-use
					currentsection.keyvalues.clear();
				}
				currentsection.name = line.substr(1, end - 1);
			}
		}
		else if (!line.empty())
		{
			/* Not a comment, must be a name[=:]value pair */
			const size_t end = line.find_first_of("=");
			if (end != string::npos)
			{
				const string name = line.substr(0, end);
				const string value = line.substr(end + 1);
				ltrim(rtrim(name));
				ltrim(rtrim(value));

				currentsection.keyvalues[name] = value;
			}
		}
	}

	  // if we are out of loop we add last section
	  // this is a new section so if we have a current section populated, add it to list
	if (!currentsection.name.empty())
	{
		sections.push_back(currentsection);  // copy
		currentsection.name = "";
		currentsection.keyvalues.clear();
	}
};

////////////////////////////////////////
#include <locale>
////////////////////////////////////////


// Getting the string
bool config::get_logic(const string& sectionname, const string& keyname)
{
	string val = get_value(sectionname, keyname);
	std::transform(val.begin(), val.end(), val.begin(), ::tolower);
	return val == "true";
}


// Getting the int
int config::get_number(const string& sectionname, const string& keyname)
{
	const std::string &val = this->get_value(sectionname, keyname);
	return std::stoi(val);
}


// Getting the float
float config::get_float(const string& sectionname, const string& keyname)
{
	const std::string &val = this->get_value(sectionname, keyname);
	return std::stof(val);
}


//[FX]: Пока так, не хочу сейчас писать десятки строк ради одной записи
////////////////////////////////////////
#include <Windows.h>
////////////////////////////////////////

/// <summary>
/// Writting the sectors
/// </summary>
void config::WriteSect(const std::string_view sectionname, const std::string_view keyname, const std::string_view key, const std::string_view parent)
{
	WritePrivateProfileStringA(sectionname.data(), keyname.data(), key.data(), path.data());
};
