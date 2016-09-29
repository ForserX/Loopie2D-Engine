function start()
  Form:SetName("Нет имени")
  Form:SetText("В общем", "пацаны", "n всё снова пашет.")
  Form:SetBackImage("test.jpg", "JmbOLrpdZcs.jpg")
  Form:SetSound("MyMusic.mp3")
end

function start_2()
  Form:SetText("И сейчас пашет.")
  Form:SetName(IFS:GetPrivateString("..\\data\\configs\\test.ini", "1", "type"))
  Form:SetBackImage("test.jpg")
end