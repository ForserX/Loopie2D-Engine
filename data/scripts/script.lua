function start()
  Font["Name"] = "Arial"
  Font["Text"] = "Arial"
  Font["TextColor"] = "white"
  Font["NameColor"] = "red"
  Sound = "MyMusic.mp3"
  ActorName = "FX"
  Text = "Итак, господа, проверяем первую сцену."
	Scene["Images"] = 3
	Scene["Image0"] = "ext_bus_driver.jpg"
	Scene["Image1"] = "sl.png"
	Scene["Image1Pos"] = "ARight"
	Scene["Image2"] = "alice.png"
	Scene["Image2Pos"] = "ALeft"
end

function question1()
	Scene["Options"] = 2
	Scene["Option0"] = "Жми"
	Scene["Option1"] = "Не жми"
end

function question2()
	Scene["Options"] = 1
	Scene["Option0"] = "Жми"
end

function start_2()
	Scene["Images"] = 1
	Scene["Image0"] = "test.jpg"
	ActorName = "FX"
  Text = "Итак, господа, проверяем вторую сцену."
end