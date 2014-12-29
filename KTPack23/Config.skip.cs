// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "0.01";
$Script::Description	= "My attempt at making a customizable config from in "
			@ "the game. I hope it works!";

// ------------------------------------------------------------------------------------------------
// Overload Presto's Command

function HUD::AddObject(%hud, %class, %x,%y, %width, %height, %prop1, %prop2, %prop3)
{
	%num = HUD::GetGuiObjectCount(%hud);
	%obj = newObject("HUD::"@ %hud @"::"@ %num, %class, %x,%y, %width,%height,%prop1,%prop2,%prop3);
	if (%obj != 0)
	{
		%frame = HUD::GetGuiObject(%hud, frame);
		addToSet(%frame, %obj);
		HUD::SetGuiObject(%hud, %num, %obj);
		HUD::SetGuiObjectCount(%hud, %num + 1);
	}
	return %obj;
}

// ------------------------------------------------------------------------------------------------
// Settings

$King::Config::Dialog 	= "ktConfig";
$King::Config::Object	= "PlayGui/HUD::" @ $King::Config::Dialog;

// ------------------------------------------------------------------------------------------------
// Command To Open It

Command::Add("!config", King::Config::Command);
function King::Config::Command(%cmd, %param)
{
	King::Config::Dialog();
}

// ------------------------------------------------------------------------------------------------
// Code

function King::Config::Dialog()
{
	%sWidth  = getWord(Presto::ScreenSize(), 0);
	%sHeight = getWord(Presto::ScreenSize(), 1);

	%dWidth  = 200;
	%dHeight = 250;

	%hud = $King::Config::Dialog;

	// Create the HUD
	HUD::NewFrame(%hud, "", floor((%sWidth / 2) - (%dWidth / 2)), floor((%sHeight / 2) - (%dHeight / 2)), %dWidth, %dHeight);
	HUD::Display(%hud);

	%o = 0;

	// Title Text
	%obj[%o++] = HUD::AddObject(%hud, FearGuiFormattedText, 5, 5, %dWidth - 10, 10);
	Control::SetValue(Object::GetName(%obj[%o]), "<jc><f2>Acronyms Configuration");

	// Divider
	%obj[%o++] = HUD::AddObject(%hud, FearGuiFormattedText, 5, 15, %dWidth - 10, 10);
	Control::SetValue(Object::GetName(%obj[%o]), "<jc><f2>-------------------------");

	// Acronym Selecter
	%obj[%o++] = HUD::AddObject(%hud, FearGui::FGStandardComboBox, 5, 25, %dWidth - 10, 20);
	for (%a = 1; Acronym::Find(%a) != ""; %a++)
		FGCombo::addEntry(Object::GetName(%obj[%o]), Acronym::Find(%a), Acronym::Find(%a));
	FGCombo::selectNext(Object::GetName(%obj[%o]));

	// Close Button
	%obj[%o++] = HUD::AddObject(%hud, FearGui::FearGuiBox, 5, %dHeight - 30, %dWidth - 10, 20);
	%obj[%o++] = HUD::AddObject(%hud, FearGuiFormattedText, 5, %dHeight - 30, %dWidth - 10, 20);
	Control::setValue(Object::GetName(%obj[%o]), "<jc>Close Acronyms Editor");
	%obj[%o++] = HUD::AddObject(%hud, FearGui::FGUniversalButton, 5, %dHeight - 30, %dWidth - 10, 20, "King::Config::Close();", "King::Config::Close();");

	cursorOn(MainWindow);
}

function King::Config::Close()
{
	HUD::Delete(ktConfig);
	cursorOff(MainWindow);
}