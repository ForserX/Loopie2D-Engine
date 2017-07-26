function start()
  Font["Name"] = "Arial"
  Font["Text"] = "Arial"
  Font["TextColor"] = "white"
  Font["NameColor"] = "red"
  Sound = "MyMusic.mp3"
  ActorName = "FX"
  Text = "Итак, господа, проверяем первую сцену."
	Scene["Images"] = 4
	Scene["Image0"] = "ext_bus_driver.jpg"
	Scene["Image1"] = "test.gif"
	Scene["Image1Gif"] = true
	Scene["Image1Pos"] = "ARight"
	Scene["Image2"] = "alice.png"
	Scene["Image2Gif"] = false
	Scene["Image2Pos"] = "ALeft"
	Scene["Image3"] = "sl.png"
	Scene["Image3Pos"] = "Center"
	Scene["Image3Gif"] = false
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