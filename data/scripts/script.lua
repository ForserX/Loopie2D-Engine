ActorName = "nil"
FreeMove = false;

function start()
	--// Registed hook
	AddLoaderHook("LoaderHead")
	
	Font["Name"] = "Arial"
	Font["Text"] = "Arial"
	Font["TextColor"] = "white"
	Font["NameColor"] = "red"
	ActorName = "FX"
	Text = "Демонстрационный текст!"
	Scene["Images"] = 1
	Scene["Image0"] = "SceneBack.png"
	
end

function SvExample()
	Text = "Переключи!"
	ActorName = "Славя"
	
	Scene["Images"] = 3
	Scene["Image1"] = "sv_sp_example.png"
	Scene["Image1Pos"] = 220
	Scene["Image1Scale"] = 0.33
	
	Scene["Image2Pos"] = 50
	Scene["Image2"] = "sl_sprite.png"
	Scene["Image2Scale"] = 0.33
	
end

function SvExample2()
	Text = "Отойди!"
	ActorName = "Славя"
	
	Scene["Images"] = 3
	Scene["Image1"] = "sv_sp_example.png"
	Scene["Image1Scale"] = 0.63
	Scene["Image2Pos"] = 50
	Scene["Image2Scale"] = 0.63
	Scene["Image2"] = "sl_sprite.png"
	Scene["Image1Pos"] = 220
end