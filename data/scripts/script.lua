function start()
  Font["Name"] = "Arial"
  Font["Text"] = "Arial"
  Font["TextColor"] = "white"
  Font["NameColor"] = "red"
  ActorName = "FX"
  Text = "���������������� �����!"
	Scene["Images"] = 1
	Scene["Image0"] = "SceneBack.png"
end

function SvExample()
	Text = "���������!"
	ActorName = "�����"
	
	Scene["Images"] = 2
	Scene["Image1"] = "sv_sp_example.png"
	Scene["Image1Pos"] = "Center"
end