#pragma once

namespace Loopie2DCLIPort {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Interface
	/// </summary>
	public ref class Interface : public System::Windows::Forms::Form
	{
	private:
		cli::array<System::Windows::Forms::Label^> ^label_text;

		int sect, sect_next, sect_label, sect_lb_old, text_width, lnum, inum;
		System::String^ heroname, ^ActorText_str, ^sect_old, ^sect_string, ^snd_old;
		// System::String^ ActorText[];
		bool trygame, snd;
	public:
		Interface(void);
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Interface()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::CheckBox^  flag_snd;
	protected:
	private: System::Windows::Forms::Label^  СancelButton;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  SaveButton;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Label^  mess_5;
	private: System::Windows::Forms::Label^  mess_4;
	private: System::Windows::Forms::Label^  mess_3;
	private: System::Windows::Forms::Label^  mess_2;
	private: System::Windows::Forms::Label^  mess_1;
	private: System::Windows::Forms::Label^  SpeakerName;
	private: System::Windows::Forms::PictureBox^  MessBox_5;
	private: System::Windows::Forms::PictureBox^  MessBox_4;
	private: System::Windows::Forms::PictureBox^  MessBox_3;
	private: System::Windows::Forms::PictureBox^  MessBox_2;
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::PictureBox^  MessBox_1;
	private: System::Windows::Forms::PictureBox^  ARight;
	private: System::Windows::Forms::PictureBox^  CRight;
	private: System::Windows::Forms::PictureBox^  Center;
	private: System::Windows::Forms::PictureBox^  CLeft;
	private: System::Windows::Forms::PictureBox^  ALeft;
	private: System::Windows::Forms::ListBox^  LoadList;
	private: System::Windows::Forms::CheckBox^  checkBox1;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  ago;
	private: System::Windows::Forms::Label^  SaveGame;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  Next;
	private: System::Windows::Forms::Label^  NewGame;
	private: System::Windows::Forms::Label^  Options;
	private: System::Windows::Forms::Label^  _exit;
	public: System::Windows::Forms::PictureBox^  pictureBox1;
	private:
		System::Void  _KeyDown(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e)
		{
			if (trygame)
			{
				if (e->KeyData == Keys::Enter);
					//	NextScene(false);
				else if (e->KeyData == Keys::Escape);
			//		MenuUpdate(!_exit->Visible);
			}
		}
		System::Void  _MouseDown(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e)
		{
			if (trygame)
			{
				if (e->Clicks == 1)
					if (e->Button == System::Windows::Forms::MouseButtons::Left);
					//	NextScene(false);
					else if (e->Button == System::Windows::Forms::MouseButtons::Right)
					{
						if (MessBox_1->Visible)
						{
							MessBox_1->Visible = false; MessBox_2->Visible = false; MessBox_3->Visible = false;
							MessBox_4->Visible = false; MessBox_5->Visible = false;
						}
						else
						{
							MessBox_1->Visible = true; MessBox_2->Visible = true; MessBox_3->Visible = true;
							MessBox_4->Visible = true; MessBox_5->Visible = true;
						}
					}
			}
		}
		void Fullscreen(System::Object^ sender, EventArgs^ e);
		void Label4_Click(System::Object^ sender, EventArgs^ e);
		void Next_Click(System::Object^ sender, EventArgs^ e); 
		void inputBox();
		void СancelButton_Click(System::Object ^ sender, EventArgs ^ e);
		void HideInputBox();
		Color SetColor(System::String ^ obj);
		void Label_Helper(bool q, int num);
		void MenuUpdate(bool q);
		void _exit_Click(System::Object^ sender, EventArgs e);
		void Options_Click(System::Object^ sender, EventArgs e);
		void Question_Click(System::Object^ sender, EventArgs e);
	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Interface::typeid));
			this->flag_snd = (gcnew System::Windows::Forms::CheckBox());
			this->СancelButton = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->SaveButton = (gcnew System::Windows::Forms::Label());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->mess_5 = (gcnew System::Windows::Forms::Label());
			this->mess_4 = (gcnew System::Windows::Forms::Label());
			this->mess_3 = (gcnew System::Windows::Forms::Label());
			this->mess_2 = (gcnew System::Windows::Forms::Label());
			this->mess_1 = (gcnew System::Windows::Forms::Label());
			this->SpeakerName = (gcnew System::Windows::Forms::Label());
			this->MessBox_5 = (gcnew System::Windows::Forms::PictureBox());
			this->MessBox_4 = (gcnew System::Windows::Forms::PictureBox());
			this->MessBox_3 = (gcnew System::Windows::Forms::PictureBox());
			this->MessBox_2 = (gcnew System::Windows::Forms::PictureBox());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->MessBox_1 = (gcnew System::Windows::Forms::PictureBox());
			this->ARight = (gcnew System::Windows::Forms::PictureBox());
			this->CRight = (gcnew System::Windows::Forms::PictureBox());
			this->Center = (gcnew System::Windows::Forms::PictureBox());
			this->CLeft = (gcnew System::Windows::Forms::PictureBox());
			this->ALeft = (gcnew System::Windows::Forms::PictureBox());
			this->LoadList = (gcnew System::Windows::Forms::ListBox());
			this->checkBox1 = (gcnew System::Windows::Forms::CheckBox());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->ago = (gcnew System::Windows::Forms::Label());
			this->SaveGame = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->Next = (gcnew System::Windows::Forms::Label());
			this->NewGame = (gcnew System::Windows::Forms::Label());
			this->Options = (gcnew System::Windows::Forms::Label());
			this->_exit = (gcnew System::Windows::Forms::Label());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_5))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_4))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_3))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_2))->BeginInit();
			this->panel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->ARight))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->CRight))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Center))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->CLeft))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->ALeft))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->SuspendLayout();
			// 
			// flag_snd
			// 
			this->flag_snd->AutoSize = true;
			this->flag_snd->BackColor = System::Drawing::Color::Transparent;
			this->flag_snd->Location = System::Drawing::Point(14, 44);
			this->flag_snd->Name = L"flag_snd";
			this->flag_snd->Size = System::Drawing::Size(66, 17);
			this->flag_snd->TabIndex = 68;
			this->flag_snd->Text = L"Музыка";
			this->flag_snd->UseVisualStyleBackColor = false;
			this->flag_snd->Visible = false;
			// 
			// СancelButton
			// 
			this->СancelButton->AutoSize = true;
			this->СancelButton->BackColor = System::Drawing::Color::Transparent;
			this->СancelButton->Location = System::Drawing::Point(121, 65);
			this->СancelButton->Name = L"СancelButton";
			this->СancelButton->Size = System::Drawing::Size(57, 13);
			this->СancelButton->TabIndex = 11;
			this->СancelButton->Text = L"Отменить";
			this->СancelButton->Visible = false;
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->BackColor = System::Drawing::Color::Transparent;
			this->label5->Location = System::Drawing::Point(46, 12);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(100, 13);
			this->label5->TabIndex = 10;
			this->label5->Text = L"Введите название";
			this->label5->Visible = false;
			// 
			// SaveButton
			// 
			this->SaveButton->AutoSize = true;
			this->SaveButton->BackColor = System::Drawing::Color::Transparent;
			this->SaveButton->Location = System::Drawing::Point(14, 65);
			this->SaveButton->Name = L"SaveButton";
			this->SaveButton->Size = System::Drawing::Size(60, 13);
			this->SaveButton->TabIndex = 8;
			this->SaveButton->Text = L"Сохранить";
			this->SaveButton->Visible = false;
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(38, 38);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(122, 20);
			this->textBox1->TabIndex = 7;
			this->textBox1->Visible = false;
			// 
			// mess_5
			// 
			this->mess_5->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->mess_5->AutoSize = true;
			this->mess_5->BackColor = System::Drawing::Color::Transparent;
			this->mess_5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->mess_5->Location = System::Drawing::Point(4, 31);
			this->mess_5->MaximumSize = System::Drawing::Size(200, 0);
			this->mess_5->Name = L"mess_5";
			this->mess_5->Size = System::Drawing::Size(0, 13);
			this->mess_5->TabIndex = 67;
			// 
			// mess_4
			// 
			this->mess_4->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->mess_4->AutoSize = true;
			this->mess_4->BackColor = System::Drawing::Color::Transparent;
			this->mess_4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->mess_4->Location = System::Drawing::Point(4, 31);
			this->mess_4->MaximumSize = System::Drawing::Size(200, 0);
			this->mess_4->Name = L"mess_4";
			this->mess_4->Size = System::Drawing::Size(0, 13);
			this->mess_4->TabIndex = 66;
			// 
			// mess_3
			// 
			this->mess_3->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->mess_3->AutoSize = true;
			this->mess_3->BackColor = System::Drawing::Color::Transparent;
			this->mess_3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->mess_3->Location = System::Drawing::Point(4, 31);
			this->mess_3->MaximumSize = System::Drawing::Size(200, 0);
			this->mess_3->Name = L"mess_3";
			this->mess_3->Size = System::Drawing::Size(0, 13);
			this->mess_3->TabIndex = 65;
			// 
			// mess_2
			// 
			this->mess_2->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->mess_2->AutoSize = true;
			this->mess_2->BackColor = System::Drawing::Color::Transparent;
			this->mess_2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->mess_2->Location = System::Drawing::Point(4, 31);
			this->mess_2->MaximumSize = System::Drawing::Size(200, 0);
			this->mess_2->Name = L"mess_2";
			this->mess_2->Size = System::Drawing::Size(0, 13);
			this->mess_2->TabIndex = 64;
			// 
			// mess_1
			// 
			this->mess_1->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->mess_1->AutoSize = true;
			this->mess_1->BackColor = System::Drawing::Color::Transparent;
			this->mess_1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->mess_1->Location = System::Drawing::Point(13, 31);
			this->mess_1->MaximumSize = System::Drawing::Size(190, 0);
			this->mess_1->Name = L"mess_1";
			this->mess_1->Size = System::Drawing::Size(0, 13);
			this->mess_1->TabIndex = 63;
			// 
			// SpeakerName
			// 
			this->SpeakerName->AutoSize = true;
			this->SpeakerName->BackColor = System::Drawing::Color::Transparent;
			this->SpeakerName->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->SpeakerName->Location = System::Drawing::Point(13, 15);
			this->SpeakerName->Name = L"SpeakerName";
			this->SpeakerName->Size = System::Drawing::Size(86, 13);
			this->SpeakerName->TabIndex = 62;
			this->SpeakerName->Text = L"SpeakerName";
			this->SpeakerName->Visible = false;
			// 
			// MessBox_5
			// 
			this->MessBox_5->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->MessBox_5->BackColor = System::Drawing::Color::Transparent;
			this->MessBox_5->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"MessBox_5.BackgroundImage")));
			this->MessBox_5->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->MessBox_5->Location = System::Drawing::Point(3, 327);
			this->MessBox_5->Name = L"MessBox_5";
			this->MessBox_5->Size = System::Drawing::Size(182, 134);
			this->MessBox_5->TabIndex = 61;
			this->MessBox_5->TabStop = false;
			this->MessBox_5->Visible = false;
			// 
			// MessBox_4
			// 
			this->MessBox_4->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->MessBox_4->BackColor = System::Drawing::Color::Transparent;
			this->MessBox_4->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"MessBox_4.BackgroundImage")));
			this->MessBox_4->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->MessBox_4->Location = System::Drawing::Point(4, 327);
			this->MessBox_4->Name = L"MessBox_4";
			this->MessBox_4->Size = System::Drawing::Size(195, 134);
			this->MessBox_4->TabIndex = 60;
			this->MessBox_4->TabStop = false;
			this->MessBox_4->Visible = false;
			// 
			// MessBox_3
			// 
			this->MessBox_3->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->MessBox_3->BackColor = System::Drawing::Color::Transparent;
			this->MessBox_3->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"MessBox_3.BackgroundImage")));
			this->MessBox_3->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->MessBox_3->Location = System::Drawing::Point(4, 327);
			this->MessBox_3->Name = L"MessBox_3";
			this->MessBox_3->Size = System::Drawing::Size(201, 134);
			this->MessBox_3->TabIndex = 59;
			this->MessBox_3->TabStop = false;
			this->MessBox_3->Visible = false;
			// 
			// MessBox_2
			// 
			this->MessBox_2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->MessBox_2->BackColor = System::Drawing::Color::Transparent;
			this->MessBox_2->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"MessBox_2.BackgroundImage")));
			this->MessBox_2->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->MessBox_2->Location = System::Drawing::Point(4, 327);
			this->MessBox_2->Name = L"MessBox_2";
			this->MessBox_2->Size = System::Drawing::Size(197, 134);
			this->MessBox_2->TabIndex = 58;
			this->MessBox_2->TabStop = false;
			this->MessBox_2->Visible = false;
			// 
			// panel1
			// 
			this->panel1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->panel1->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->panel1->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"panel1.BackgroundImage")));
			this->panel1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->panel1->Controls->Add(this->СancelButton);
			this->panel1->Controls->Add(this->label5);
			this->panel1->Controls->Add(this->SaveButton);
			this->panel1->Controls->Add(this->textBox1);
			this->panel1->Location = System::Drawing::Point(401, 153);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(190, 104);
			this->panel1->TabIndex = 57;
			this->panel1->Visible = false;
			// 
			// MessBox_1
			// 
			this->MessBox_1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->MessBox_1->BackColor = System::Drawing::Color::Transparent;
			this->MessBox_1->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"MessBox_1.BackgroundImage")));
			this->MessBox_1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->MessBox_1->Location = System::Drawing::Point(20, 327);
			this->MessBox_1->Name = L"MessBox_1";
			this->MessBox_1->Size = System::Drawing::Size(182, 134);
			this->MessBox_1->TabIndex = 56;
			this->MessBox_1->TabStop = false;
			this->MessBox_1->Visible = false;
			// 
			// ARight
			// 
			this->ARight->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->ARight->BackColor = System::Drawing::Color::Transparent;
			this->ARight->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->ARight->Location = System::Drawing::Point(786, 67);
			this->ARight->Name = L"ARight";
			this->ARight->Size = System::Drawing::Size(197, 467);
			this->ARight->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->ARight->TabIndex = 55;
			this->ARight->TabStop = false;
			// 
			// CRight
			// 
			this->CRight->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->CRight->BackColor = System::Drawing::Color::Transparent;
			this->CRight->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->CRight->Location = System::Drawing::Point(596, 67);
			this->CRight->Name = L"CRight";
			this->CRight->Size = System::Drawing::Size(195, 467);
			this->CRight->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->CRight->TabIndex = 54;
			this->CRight->TabStop = false;
			// 
			// Center
			// 
			this->Center->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->Center->BackColor = System::Drawing::Color::Transparent;
			this->Center->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->Center->Location = System::Drawing::Point(397, 67);
			this->Center->Name = L"Center";
			this->Center->Size = System::Drawing::Size(200, 467);
			this->Center->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->Center->TabIndex = 53;
			this->Center->TabStop = false;
			// 
			// CLeft
			// 
			this->CLeft->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->CLeft->BackColor = System::Drawing::Color::Transparent;
			this->CLeft->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->CLeft->Location = System::Drawing::Point(201, 67);
			this->CLeft->Name = L"CLeft";
			this->CLeft->Size = System::Drawing::Size(197, 467);
			this->CLeft->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->CLeft->TabIndex = 52;
			this->CLeft->TabStop = false;
			// 
			// ALeft
			// 
			this->ALeft->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->ALeft->BackColor = System::Drawing::Color::Transparent;
			this->ALeft->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
			this->ALeft->Location = System::Drawing::Point(4, 67);
			this->ALeft->Name = L"ALeft";
			this->ALeft->Size = System::Drawing::Size(198, 467);
			this->ALeft->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->ALeft->TabIndex = 51;
			this->ALeft->TabStop = false;
			// 
			// LoadList
			// 
			this->LoadList->FormattingEnabled = true;
			this->LoadList->Location = System::Drawing::Point(851, 25);
			this->LoadList->Name = L"LoadList";
			this->LoadList->Size = System::Drawing::Size(132, 511);
			this->LoadList->TabIndex = 50;
			this->LoadList->Visible = false;
			// 
			// checkBox1
			// 
			this->checkBox1->AutoSize = true;
			this->checkBox1->Location = System::Drawing::Point(14, 25);
			this->checkBox1->Name = L"checkBox1";
			this->checkBox1->Size = System::Drawing::Size(145, 17);
			this->checkBox1->TabIndex = 49;
			this->checkBox1->Text = L"Полноэкранный режим";
			this->checkBox1->UseVisualStyleBackColor = true;
			this->checkBox1->Visible = false;
			// 
			// label7
			// 
			this->label7->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->label7->AutoSize = true;
			this->label7->BackColor = System::Drawing::Color::Transparent;
			this->label7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label7->Location = System::Drawing::Point(951, 2);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(16, 17);
			this->label7->TabIndex = 48;
			this->label7->Text = L"_";
			// 
			// label6
			// 
			this->label6->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->label6->AutoSize = true;
			this->label6->BackColor = System::Drawing::Color::Transparent;
			this->label6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label6->Location = System::Drawing::Point(969, 5);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(14, 17);
			this->label6->TabIndex = 47;
			this->label6->Text = L"x";
			// 
			// ago
			// 
			this->ago->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->ago->AutoSize = true;
			this->ago->BackColor = System::Drawing::Color::Transparent;
			this->ago->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->ago->Location = System::Drawing::Point(16, 494);
			this->ago->Name = L"ago";
			this->ago->Size = System::Drawing::Size(63, 22);
			this->ago->TabIndex = 46;
			this->ago->Text = L"Назад";
			this->ago->Visible = false;
			// 
			// SaveGame
			// 
			this->SaveGame->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->SaveGame->AutoSize = true;
			this->SaveGame->BackColor = System::Drawing::Color::Transparent;
			this->SaveGame->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->SaveGame->Location = System::Drawing::Point(16, 396);
			this->SaveGame->Name = L"SaveGame";
			this->SaveGame->Size = System::Drawing::Size(143, 22);
			this->SaveGame->TabIndex = 45;
			this->SaveGame->Text = L"Сохранить Игру";
			this->SaveGame->Visible = false;
			// 
			// label4
			// 
			this->label4->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->label4->AutoSize = true;
			this->label4->BackColor = System::Drawing::Color::Transparent;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label4->Location = System::Drawing::Point(16, 430);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(134, 22);
			this->label4->TabIndex = 44;
			this->label4->Text = L"Загрузить игру";
			// 
			// Next
			// 
			this->Next->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->Next->AutoSize = true;
			this->Next->BackColor = System::Drawing::Color::Transparent;
			this->Next->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->Next->Location = System::Drawing::Point(16, 332);
			this->Next->Name = L"Next";
			this->Next->Size = System::Drawing::Size(115, 22);
			this->Next->TabIndex = 43;
			this->Next->Text = L"Продолжить";
			this->Next->Visible = false;
			// 
			// NewGame
			// 
			this->NewGame->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->NewGame->AutoSize = true;
			this->NewGame->BackColor = System::Drawing::Color::Transparent;
			this->NewGame->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->NewGame->Location = System::Drawing::Point(16, 363);
			this->NewGame->Name = L"NewGame";
			this->NewGame->Size = System::Drawing::Size(108, 22);
			this->NewGame->TabIndex = 42;
			this->NewGame->Text = L"Новая Игра";
			// 
			// Options
			// 
			this->Options->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->Options->AutoSize = true;
			this->Options->BackColor = System::Drawing::Color::Transparent;
			this->Options->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->Options->Location = System::Drawing::Point(16, 463);
			this->Options->Name = L"Options";
			this->Options->Size = System::Drawing::Size(99, 22);
			this->Options->TabIndex = 41;
			this->Options->Text = L"Настройки";
			// 
			// _exit
			// 
			this->_exit->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->_exit->AutoSize = true;
			this->_exit->BackColor = System::Drawing::Color::Transparent;
			this->_exit->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->_exit->Location = System::Drawing::Point(16, 494);
			this->_exit->Name = L"_exit";
			this->_exit->Size = System::Drawing::Size(65, 22);
			this->_exit->TabIndex = 40;
			this->_exit->Text = L"Выход";
			// 
			// pictureBox1
			// 
			this->pictureBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->pictureBox1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->pictureBox1->Location = System::Drawing::Point(4, 5);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(979, 529);
			this->pictureBox1->TabIndex = 39;
			this->pictureBox1->TabStop = false;
			// 
			// Interface
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(986, 538);
			this->Controls->Add(this->flag_snd);
			this->Controls->Add(this->mess_5);
			this->Controls->Add(this->mess_4);
			this->Controls->Add(this->mess_3);
			this->Controls->Add(this->mess_2);
			this->Controls->Add(this->mess_1);
			this->Controls->Add(this->SpeakerName);
			this->Controls->Add(this->MessBox_5);
			this->Controls->Add(this->MessBox_4);
			this->Controls->Add(this->MessBox_3);
			this->Controls->Add(this->MessBox_2);
			this->Controls->Add(this->panel1);
			this->Controls->Add(this->MessBox_1);
			this->Controls->Add(this->ARight);
			this->Controls->Add(this->CRight);
			this->Controls->Add(this->Center);
			this->Controls->Add(this->CLeft);
			this->Controls->Add(this->ALeft);
			this->Controls->Add(this->LoadList);
			this->Controls->Add(this->checkBox1);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->ago);
			this->Controls->Add(this->SaveGame);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->Next);
			this->Controls->Add(this->NewGame);
			this->Controls->Add(this->Options);
			this->Controls->Add(this->_exit);
			this->Controls->Add(this->pictureBox1);
			this->Name = L"Interface";
			this->Text = L"Interface";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_5))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_4))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_3))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_2))->EndInit();
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->MessBox_1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->ARight))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->CRight))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Center))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->CLeft))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->ALeft))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	};
}
