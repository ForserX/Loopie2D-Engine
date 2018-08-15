#include "stdafx.h"
#include "Interface.h"
#include "LoopFS.h"

CLoopFS ObjectFS;

using namespace Loopie2DCLIPort;

Interface::Interface(void)
{
	InitializeComponent();
	int ppos = this->Width / 5;
	this->DoubleBuffered = true;
	/////////////////////////////////////////////////////////////////////
	/// ETC setter
//	lua = gcnew LuaAPI();

	this->_exit->Parent = pictureBox1;
	this->Options->Parent = pictureBox1;
	this->NewGame->Parent = pictureBox1;
	this->Next->Parent = pictureBox1;
	this->label4->Parent = pictureBox1;
	this->flag_snd->Parent = pictureBox1;
	this->SaveButton->Parent = pictureBox1;
	this->SaveGame->Parent = pictureBox1;
	this->ago->Parent = pictureBox1;
	//this->TopMost = true;

	this->pictureBox1->BackgroundImage = gcnew System::Drawing::Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img + "MainFormBack.jpg"));

	this->panel1->Parent = pictureBox1; label6->Parent = pictureBox1;
	label7->Parent = pictureBox1; checkBox1->Parent = pictureBox1;

	this->KeyDown += gcnew KeyEventHandler(this, &Interface::_KeyDown);
	this->pictureBox1->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->checkBox1->CheckedChanged += gcnew EventHandler(this, &Interface::Fullscreen);
	this->label4->Click += gcnew EventHandler(this, &Interface::Label4_Click);
	this->Next->Click += gcnew EventHandler(this, &Interface::Next_Click);
	this->NewGame->Click += gcnew EventHandler(this, &Interface::NewGame_Click);

	this->checkBox1->BackColor = Color::Transparent;
	this->panel1->BackColor = Color::Transparent;

	this->SpeakerName->Parent = MessBox_1;
	/////////////////////////////////////////////////////////////////////
	/// Mess setter
	this->MessBox_1->Parent = ALeft;
	this->MessBox_2->Parent = CLeft;
	this->MessBox_3->Parent = Center;
	this->MessBox_4->Parent = CRight;
	this->MessBox_5->Parent = ARight;

	this->mess_1->Parent = MessBox_1;
	this->mess_2->Parent = MessBox_2;
	this->mess_3->Parent = MessBox_3;
	this->mess_4->Parent = MessBox_4;
	this->mess_5->Parent = MessBox_5;

	this->MessBox_1->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->MessBox_2->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->MessBox_3->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->MessBox_4->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->MessBox_5->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	/////////////////////////////////////////////////////////////////////
	/// PictPositions setter
	this->ALeft->Parent = pictureBox1; CLeft->Parent = pictureBox1; CRight->Parent = pictureBox1; 
	Center->Parent = pictureBox1; ARight->Parent = pictureBox1;

	this->ALeft->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->CLeft->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->Center->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->CRight->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->ARight->Size = System::Drawing::Size(ppos, ALeft->Size.Height);

	this->ALeft->Location = System::Drawing::Point(0, ALeft->Location.Y);
	this->CLeft->Location = System::Drawing::Point(ppos, CLeft->Location.Y);
	this->Center->Location = System::Drawing::Point(ppos * 2, Center->Location.Y);
	this->CRight->Location = System::Drawing::Point(ppos * 3, CRight->Location.Y);
	this->ARight->Location = System::Drawing::Point(ppos * 4, ARight->Location.Y);

	this->ALeft->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->CLeft->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->Center->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->CRight->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	this->ARight->MouseDown += gcnew MouseEventHandler(this, &Interface::_MouseDown);
	/////////////////////////////////////////////////////////////////////
	/// Vars setter
	//player = gcnew System.Windows.Media.MediaPlayer();
	ActorText_str = L"";
	snd_old = L"0";
	text_width = 27;
	snd = false;
}

void Interface::Fullscreen(System::Object^ sender, EventArgs^ e)
{
	if (checkBox1->Checked)
	{
		this->Height = SystemInformation::VirtualScreen.Size.Height;
		this->Width = SystemInformation::VirtualScreen.Size.Width;
		this->TopMost = true;
		text_width += 9;
		mess_1->MaximumSize = System::Drawing::Size(260, 120); mess_2->MaximumSize = System::Drawing::Size(260, 120); 
		mess_3->MaximumSize = System::Drawing::Size(260, 120); mess_4->MaximumSize = System::Drawing::Size(260, 120); 
		mess_5->MaximumSize = System::Drawing::Size(260, 120);
	}
	else
	{
		this->Height = 528;
		this->Width = 979;
		this->TopMost = false;
		text_width = 27;
		mess_1->MaximumSize = System::Drawing::Size(200, 120); mess_2->MaximumSize = System::Drawing::Size(200, 120); 
		mess_3->MaximumSize = System::Drawing::Size(200, 120); mess_4->MaximumSize = System::Drawing::Size(200, 120); 
		mess_5->MaximumSize = System::Drawing::Size(200, 120);

	}
	int ppos = this->Width / 5;
	this->ALeft->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->CLeft->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->Center->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->CRight->Size = System::Drawing::Size(ppos, ALeft->Size.Height);
	this->ARight->Size = System::Drawing::Size(ppos, ALeft->Size.Height);

	this->ALeft->Location = System::Drawing::Point(0, ALeft->Location.Y);
	this->CLeft->Location = System::Drawing::Point(ppos, CLeft->Location.Y);
	this->Center->Location = System::Drawing::Point(ppos * 2, Center->Location.Y);
	this->CRight->Location = System::Drawing::Point(ppos * 3, CRight->Location.Y);
	this->ARight->Location = System::Drawing::Point(ppos * 4, ARight->Location.Y);
}

void Interface::Label4_Click(System::Object^ sender, EventArgs^ e)
{
	LoadList->Visible = true;
	LoadList->Items->Clear();

	for each (System::String^ file_name in System::IO::Directory::GetFiles(ObjectFS.ClrStr(ObjectFS.pPathList->UserData)))
	{
		LoadList->Items->Add(file_name->Substring(ObjectFS.pPathList->UserData.length()));
	}
}

void Interface::Next_Click(System::Object^ sender, EventArgs^ e)
{
	MenuUpdate(false);
	NextScene(true);
	MessBox_4->Visible = true; MessBox_5->Visible = true; MessBox_3->Visible = true; 
	MessBox_2->Visible = true; MessBox_1->Visible = true;
}

void Interface::inputBox()
{
	SaveButton->Parent = panel1;
	panel1->Width = 170;
	label5->Visible = true;
	textBox1->Visible = true;
	panel1->Location = System::Drawing::Point((this->Width - panel1->Width) / 2, panel1->Location.Y);
	panel1->Height = 85;
	panel1->Visible = true;
	ÑancelButton->Visible = true;
	SaveButton->Visible = true;
}

void Interface::ÑancelButton_Click(System::Object^ sender, EventArgs^ e)
{
	HideInputBox();
}

void Interface::HideInputBox()
{
	label5->Visible = false;
	textBox1->Visible = false;
	panel1->Visible = false;
	ÑancelButton->Visible = false;
	SaveButton->Visible = false;
}

Color Interface::SetColor(System::String^ obj)
{
	if (obj->Equals("white")) return Color::White;
	else if (obj->Equals("red")) return Color::Red;
	else if (obj->Equals("blue")) return Color::Blue;
	else return Color::Black;
}

void Interface::Label_Helper(bool q, int num)
{
	if (q)
	{
		this->ALeft->Image = nullptr; CLeft->Image = nullptr; Center->Image = nullptr;
		CRight->Image = nullptr; ARight->Image = nullptr;

		MessBox_1->Visible = false; MessBox_2->Visible = false; MessBox_3->Visible = false;
		MessBox_4->Visible = false; MessBox_5->Visible = false;

		panel1->Location = System::Drawing::Point((this->Width - panel1->Width) / 2, panel1->Location.Y);
		panel1->Width = 150;

		for (int j = 0; j < num; j++)
		{
			this->panel1->Controls->Add(this->label_text[j]);

			if (label_text[j]->Width >= panel1->Width)
				panel1->Width = label_text[j]->Width + 15;

			label_text[j]->Location = System::Drawing::Point((panel1->Width - label_text[j]->Width) / 2, label_text[j]->Location.Y - 15 + j);
		}

		panel1->Height = 10 + 15 * num;
		panel1->Visible = true;

		sect_label += 1;
	}
	else
	{
		for (int j = 0; j < num; j++)
			label_text[j]->~Label();

		MessBox_1->Visible = true; MessBox_2->Visible = true; MessBox_3->Visible = true; 
		MessBox_4->Visible = true; MessBox_5->Visible = true;
		panel1->Visible = false;
		NextScene(false);
	}
}

void Interface::MenuUpdate(bool q)
{
	if (!q)
	{
		NewGame->Visible = false;
		Options->Visible = false;
		_exit->Visible = false;
		Next->Visible = false;
		label4->Visible = false;
		SaveGame->Visible = false;

		trygame = true;
		MessBox_1->Visible = true; MessBox_2->Visible = true; MessBox_3->Visible = true;
		MessBox_4->Visible = true; MessBox_5->Visible = true;
	}
	else
	{
		NewGame->Visible = true;
			Options->Visible = true;
			label4->Visible = true;
			_exit->Visible = true;
			SaveGame->Visible = true;

		if (sect != 0)
			Next->Visible = true;

		trygame = false;
		MessBox_1->Visible = false; MessBox_2->Visible = false; MessBox_3->Visible = false;
		MessBox_4->Visible = false; MessBox_5->Visible = false;

		ALeft->Image = nullptr; CLeft->Image = nullptr; Center->Image = nullptr;
		CRight->Image = nullptr; ARight->Image = nullptr;
		pictureBox1->BackgroundImage = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img + "MainFormBack.jpg"));
	}

	Focus();
}

void Interface::_exit_Click(System::Object^ sender, EventArgs^ e)
{
	this->Close();
}

void Interface::Options_Click(System::Object^ sender, EventArgs^ e)
{
	MenuUpdate(false);
	trygame = false;

	MessBox_1->Visible = false; MessBox_2->Visible = false; MessBox_3->Visible = false;
	MessBox_4->Visible = false; MessBox_5->Visible = false;

	flag_snd->Visible = true;
	ago->Visible = true;
	checkBox1->Visible = true;
}

void Interface::Question_Click(System::Object^ sender, EventArgs^ e)
{
	Label^ lab = safe_cast<Label^>(sender);
	sect_next = Convert::ToInt32(lab->Name);
	Label_Helper(false, lnum);
	NextScene(false);
}

void Interface::NewGame_Click(System::Object^  sender, EventArgs^ e)
{
	sect = 0;
	MenuUpdate(false);
	NextScene(false);
	MessBox_1->Visible = true; MessBox_2->Visible = true; MessBox_3->Visible = true;
	MessBox_4->Visible = true; MessBox_5->Visible = true;
}

void Interface::SaveGame_Click(System::Object^  sender, EventArgs^ e)
{
	inputBox();
}

#include <msclr/marshal_cppstd.h>
using namespace msclr::interop;

void Interface::LoadList_SelectedIndexChanged(System::Object^  sender, EventArgs^ e)
{
	System::String^ path = ObjectFS.ClrStr(ObjectFS.pPathList->UserData.c_str()) + LoadList->SelectedItem->ToString();
	config ObjectParser(marshal_as<std::string>(path));

	sect = ObjectParser.get_number("param", "sect");
	sect_old = ObjectFS.ClrStr(ObjectParser.get_value("param", "sect_old"));
	sect_string = ObjectFS.ClrStr(ObjectParser.get_value("param", "sect_string"));
	sect_label = ObjectParser.get_number("param", "sect_label");
	LoadList->Visible = false;
	MenuUpdate(false);
	NextScene(true);
	MessBox_1->Visible = true; MessBox_2->Visible = true; MessBox_3->Visible = true;
	MessBox_4->Visible = true; MessBox_5->Visible = true;
}

void Interface::Ago_Click(System::Object^  sender, EventArgs^ e)
{
	ago->Visible = false; checkBox1->Visible = false; flag_snd->Visible = false;
	MenuUpdate(true);
}

void Interface::Label6_Click(System::Object^ sender, EventArgs^ e)
{
	this->_exit_Click(sender, e);
}

void Interface::Label7_Click(System::Object^  sender, EventArgs^ e)
{
	this->WindowState = FormWindowState::Minimized;
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////
void Interface::SaveButton_Click(System::Object^  sender, EventArgs^ e)
{
	if (textBox1->Text != "")
	{
		msclr::interop::marshal_context^ marshal = gcnew msclr::interop::marshal_context();
		config ObjectParser;
		System::String^ path = ObjectFS.ClrStr(ObjectFS.pPathList->UserData.c_str()) + textBox1->Text + ".ini";
		WritePrivateProfileString("param", "sect", std::to_string(sect).c_str(), marshal->marshal_as<const char*>(path));
		WritePrivateProfileString("param", "sect_string", marshal->marshal_as<const char*>(sect_string), marshal->marshal_as<const char*>(path));
		WritePrivateProfileString("param", "sect_old", marshal->marshal_as<const char*>(sect_old), marshal->marshal_as<const char*>(path));
		WritePrivateProfileString("param", "sect_label", std::to_string(sect_label).c_str(), marshal->marshal_as<const char*>(path));

		HideInputBox();
		delete marshal;
	}
	else
		MessageBox::Show("Error", "Ââåäèòå íàçâàíèå!", MessageBoxButtons::OK);
}

void Interface::NextScene(bool load)
{
	//lua.lua.Pop();

	//Ôëàæîê äëÿ ëîàäåðà
	if (!load)
	{
		snd_old = ObjectFS.pLuaInter->GetSnd();
		++sect;
		//Òóò ìû îïðåäåëÿåì ñåêöèþ, êîñòûëüíî è íå èíòåðåñíî
		sect_string = (sect_label == 0) ? Convert::ToString(sect) : Convert::ToString(sect) + sect_old;
		if (sect_next != 0 && sect_lb_old != sect_label)
		{
			sect_old += "_" + Convert::ToString(sect_next);
			sect_string = Convert::ToString(sect) + sect_old;
			sect_lb_old = sect_label;
		}
	}

	//Load vars
	msclr::interop::marshal_context^ marshal = gcnew msclr::interop::marshal_context();
	System::String^ TypeCurrentScene = ObjectFS.ClrStr(ObjectFS.pParser->get_value(marshal->marshal_as<const char*>(sect_string), "type"));
	std::string ScriptFileName = ObjectFS.pParser->get_value(marshal->marshal_as<const char*>(sect_string), "name");

	if (TypeCurrentScene == "None" || ScriptFileName == "")
		return;

	ObjectFS.CallScript(ScriptFileName.c_str(), ObjectFS.pParser->get_value(marshal->marshal_as<const char*>(sect_string), "func").c_str());
	if (TypeCurrentScene == "Question")
	{
		lnum = ObjectFS.pLuaInter->GetLabelsCount();
		label_text = gcnew  cli::array<System::Windows::Forms::Label^>(lnum);
		
		//label_text->Resize(12)// = gcnew Label[lnum]; // Set size
		for (int it = 0; it < lnum; it++)
		{
			label_text[it] = gcnew System::Windows::Forms::Label();
			{
				label_text[it]->AutoSize = true;
				label_text[it]->Name = Convert::ToString(it + 1);
				label_text[it]->BackColor = System::Drawing::Color::Transparent;
				label_text[it]->Location = System::Drawing::Point(80, 22 + 10 * it);
				label_text[it]->Visible = true;
				label_text[it]->Text = ObjectFS.pLuaInter->GetCurrentOption(it);
				label_text[it]->Parent = panel1;
			};
			label_text[it]->Click += gcnew System::EventHandler(this, &Interface::Question_Click);
		}
		Label_Helper(true, lnum);
		return;
	}
	heroname = ObjectFS.pLuaInter->GetName();
	ActorText = ObjectFS.pLuaInter->GetText()->Split(' ');

	//Music
	if (flag_snd->Checked && (!snd || ObjectFS.pLuaInter->GetSnd() != snd_old))
	{
		//player->Open(gcnew Uri(lua.snd + lua.GetSnd(), UriKind::Relative));
		//player->Play();
		snd = true;
	}
	//Draw ActorName
	SpeakerName->Visible = true;
	SpeakerName->ForeColor = SetColor(ObjectFS.pLuaInter->GetFontNameColor());
	SpeakerName->Text = heroname;

	//Äëÿ îòñòóïîâ ñòðîê
	int str = 0, lb = 0, num = 0;
	System::String^ ActorText_tstr = "";

	mess_1->ForeColor = SetColor(ObjectFS.pLuaInter->GetFontColor()); mess_2->ForeColor = SetColor(ObjectFS.pLuaInter->GetFontColor());
	mess_3->ForeColor = SetColor(ObjectFS.pLuaInter->GetFontColor()); mess_4->ForeColor = SetColor(ObjectFS.pLuaInter->GetFontColor());
	mess_5->ForeColor = SetColor(ObjectFS.pLuaInter->GetFontColor());

	//Ñ÷èòàåì ñòðîêè
	mess_1->Text = ""; mess_2->Text = ""; mess_3->Text = ""; mess_4->Text = ""; mess_5->Text = "";
	for (int it = 0; it <= ActorText->Length; it++)
	{
		if (it != ActorText->Length)
		{
			str += strlen(marshal->marshal_as<const char*>(ActorText[it])) + 1;
			if (str < text_width)
			{
				if (ActorText_tstr != "")
				{
					ActorText_str += ActorText_tstr + " ";
					ActorText_tstr = "";
				}
				ActorText_str += ActorText[it] + " ";
				continue;
			}
			else if (str > text_width)
			{
				num = str - text_width;
				ActorText_str += ActorText[it]->Substring(0, strlen(marshal->marshal_as<const char*>(ActorText[it])) - num);
				ActorText_tstr = ActorText[it]->Substring(strlen(marshal->marshal_as<const char*>(ActorText[it])) - num);
			}
			else ActorText_str += ActorText[it];
		}
		lb++;
		switch (lb)
		{
		case 1: mess_1->Text += ActorText_str->Clone(); text_width -= checkBox1->Checked ? 0 : 2; break;
		case 2: mess_2->Text += ActorText_str->Clone(); text_width -= 2; break;
		case 3: mess_3->Text += ActorText_str->Clone(); break;
		case 4: mess_4->Text += ActorText_str->Clone(); break;
		case 5: mess_5->Text += ActorText_str->Clone(); lb = 0; text_width += 4; break;
		}
		ActorText_str = "";
		str = 0;
	}
	text_width = checkBox1->Checked ? 36 : 27;
	// Drawing img
//	this->BackgroundImage = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(0));
	this->pictureBox1->BackgroundImage = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(0));
	this->ALeft->Image = nullptr; CLeft->Image = nullptr; Center->Image = nullptr;
	this->CRight->Image = nullptr; ARight->Image = nullptr;

	inum = ObjectFS.pLuaInter->GetImagesCount() - 1;

	if (inum > 0)
	{
		for (int it = 1; it <= inum; it++)
		{
			switch (ObjectFS.pLuaInter->GetImageTextPos(it))
			{
			case 1: this->ALeft->Image = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(it)); break;
			case 2: this->CLeft->Image = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(it)); break;
			case 3: this->Center->Image = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(it)); break;
			case 4: this->CRight->Image = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(it)); break;
			case 5: this->ARight->Image = gcnew Bitmap(ObjectFS.ClrStr(ObjectFS.pPathList->Img) + ObjectFS.pLuaInter->GetImageName(it)); break;
			}
		}
	}
	delete marshal;
}