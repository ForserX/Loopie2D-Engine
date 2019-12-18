--/////////////////////////////////
--// Main Menu General File
--/////////////////////////////////
--// Use general menu table - MainMenu[]

local YPosConstant = 357
local YPosDumb = 32
	
function PreStart()
	--// Background image
	MainMenu["Background"] = "MainFormBack.jpg"
	
	--// New game button
	MainMenu["NewGameText"] = "Новая Игра"
	MainMenu["NewGameFont"] = "Microsoft Sans Serif"
	MainMenu["NewGameColor"] = "black"
	
	MainMenu["NewGamePosX"] = 12
	MainMenu["NewGamePosY"] = YPosConstant + YPosDumb
	
	--// Load button
	MainMenu["LoadText"] = "Загрузить игру"
	MainMenu["LoadFont"] = "Microsoft Sans Serif"
	MainMenu["LoadColor"] = "black"
	
	MainMenu["LoadPosX"] = 12
	MainMenu["LoadPosY"] = YPosConstant + YPosDumb * 2
	
	--// Options button
	MainMenu["OptionsText"] = "Настройки"
	MainMenu["OptionsFont"] = "Microsoft Sans Serif"
	MainMenu["OptionsColor"] = "black"
	
	MainMenu["OptionsPosX"] = 12
	MainMenu["OptionsPosY"] = YPosConstant + YPosDumb * 3
	
	--// Exit button
	MainMenu["ExitText"] = "Выйти"
	MainMenu["ExitFont"] = "Microsoft Sans Serif"
	MainMenu["ExitColor"] = "black"
	
	MainMenu["ExitPosX"] = 12
	MainMenu["ExitPosY"] = YPosConstant + YPosDumb * 4
end

function Started()
	--// Background image
	MainMenu["Background"] = "MainFormBack.jpg"
	
	--// Continue button
	MainMenu["NextText"] = "Продолжить"
	MainMenu["NextFont"] = "Microsoft Sans Serif"
	MainMenu["NextColor"] = "black"
	              
	MainMenu["NextPosX"] = 12
	MainMenu["NextPosY"] = YPosConstant - YPosDumb
	
	--// New game button
	MainMenu["NewGameText"] = "Новая Игра"
	MainMenu["NewGameFont"] = "Microsoft Sans Serif"
	MainMenu["NewGameColor"] = "black"
	
	MainMenu["NewGamePosX"] = 12
	MainMenu["NewGamePosY"] = YPosConstant 
	
	--// Save button
	MainMenu["SaveText"] = "Сохранить игру"
	MainMenu["SaveFont"] = "Microsoft Sans Serif"
	MainMenu["SaveColor"] = "black"
	
	MainMenu["SavePosX"] = 12
	MainMenu["SavePosY"] = YPosConstant + YPosDumb
	
	--// Load button
	MainMenu["LoadText"] = "Загрузить игру"
	MainMenu["LoadFont"] = "Microsoft Sans Serif"
	MainMenu["LoadColor"] = "black"
	
	MainMenu["LoadPosX"] = 12
	MainMenu["LoadPosY"] = YPosConstant + YPosDumb * 2
	
	--// Options button
	MainMenu["OptionsText"] = "Настройки"
	MainMenu["OptionsFont"] = "Microsoft Sans Serif"
	MainMenu["OptionsColor"] = "black"
	
	MainMenu["OptionsPosX"] = 12
	MainMenu["OptionsPosY"] = YPosConstant + YPosDumb * 3
	
	--// Exit button
	MainMenu["ExitText"] = "Выйти"
	MainMenu["ExitFont"] = "Microsoft Sans Serif"
	MainMenu["ExitColor"] = "black"
	
	MainMenu["ExitPosX"] = 12
	MainMenu["ExitPosY"] = YPosConstant + YPosDumb * 4
end