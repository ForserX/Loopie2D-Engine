ImageNum = 1

function start()
  Font["Name"] = "Arial"
  Font["Text"] = "Arial"
  Font["TextColor"] = "blue"
  Font["NameColor"] = "red"
  Sound = "MyMusic.mp3"
  ActorName = "FX"
  Text = "����, �������, ��������� ������ �����."
  Image[0] = "test.jpg";
end

function question1()
	Scene["Options"] = 5
	Scene["Option2"] = "�� ���"
	Scene["Option1"] = "���"
	Scene["Option3"] = "�� ���"
	Scene["Option4"] = "�� ���"
	Scene["Option0"] = "�� ���"
end

function start_2()
  Text = "����, �������, ��������� ������ �����."
end