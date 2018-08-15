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
	//NextScene(true);
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
		//NextScene(false);
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

void Interface::_exit_Click(System::Object^ sender, EventArgs e)
{
	this->Close();
}

void Interface::Options_Click(System::Object^ sender, EventArgs e)
{
	MenuUpdate(false);
	trygame = false;

	MessBox_1->Visible = false; MessBox_2->Visible = false; MessBox_3->Visible = false;
	MessBox_4->Visible = false; MessBox_5->Visible = false;

	flag_snd->Visible = true;
	ago->Visible = true;
	checkBox1->Visible = true;
}

void Interface::Question_Click(System::Object^ sender, EventArgs e)
{
	Label^ lab = safe_cast<Label^>(sender);
	sect_next = Convert::ToInt32(lab->Name);
	Label_Helper(false, lnum);
	//NextScene(false);
}

private void NewGame_Click(object sender, EventArgs e)
{
	sect = 0;
	MenuUpdate(false);
	NextScene(false);
	MessBox_4.Visible = MessBox_5.Visible = MessBox_3.Visible = MessBox_2.Visible = MessBox_1.Visible = true;
}
private void SaveGame_Click(object sender, EventArgs e)
{
	inputBox();
}

private void LoadList_SelectedIndexChanged(object sender, EventArgs e)
{
	string path = lua.userdata + LoadList.SelectedItem.ToString();

	sect = Convert.ToInt32(ifs.GetPrivateString(path, "param", "sect"));
	sect_old = ifs.GetPrivateString(path, "param", "sect_old");
	sect_string = ifs.GetPrivateString(path, "param", "sect_string");
	sect_label = Convert.ToInt32(ifs.GetPrivateString(path, "param", "sect_label"));
	LoadList.Visible = false;
	MenuUpdate(false);
	NextScene(true);
	MessBox_4.Visible = MessBox_5.Visible = MessBox_3.Visible = MessBox_2.Visible = MessBox_1.Visible = true;
}
private void Ago_Click(object sender, EventArgs e)
{
	ago.Visible = checkBox1.Visible = flag_snd.Visible = false;
	MenuUpdate(true);
}