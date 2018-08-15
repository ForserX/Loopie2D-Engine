--ActorName = "nil"

function start()
	Font["Name"] = "Arial"
	Font["Text"] = "Arial"
	Font["TextColor"] = "white"
	Font["NameColor"] = "red"
--	trip()
	ActorName = "FX"
	Text = "Демонстрационный текст!"
	Scene["Images"] = 1
	Scene["Image0"] = "SceneBack.png"
end


function SvExample()
	Text = "Check the version 2.3!"
	ActorName = "Славя"
	
	Scene["Images"] = 2
	Scene["Image1"] = "sv_sp_example.png"
	Scene["Image1Pos"] = "Center"
end