ImageNum = 1

function start()
  Font["Name"] = "Arial"
  Font["Text"] = "Arial"
  Font["TextColor"] = "blue"
  Font["NameColor"] = "red"
  Sound = "MyMusic.mp3"
  ActorName = "FX"
  Text = "Итак, господа, проверяем первую сцену."
  Image[0] = "test.jpg";
end

function question1()
	Scene["Options"] = 5
	Scene["Option2"] = "Не жми"
	Scene["Option1"] = "Жми"
	Scene["Option3"] = "Не жми"
	Scene["Option4"] = "Не жми"
	Scene["Option0"] = "Не жми"
end

function start_2()
  Text = "Итак, господа, проверяем вторую сцену."
end