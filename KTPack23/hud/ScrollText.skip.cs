// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "This is designed to be a cool lil no-background hud "
			@ "that has the ability to scroll text. I basically made "
			@ "it as a gag, but figure you could use it for useful "
			@ "things such as scrolling notices >:P";

// ----------------------------------------------------------------------------

// Message To Scroll
$King::ScrollText::Text	= "Thank you for using KingTomato Scripts v" @ $King::Version;
$King::ScrollText::Pos	= 0;

// ----------------------------------------------------------------------------

//
// Create HUD
// 
//Event::Attach(eventConnectionAccepted, King::Scrolltext::Make);
function King::ScrollText::Make()
{
	if (!isObject($King::ScrollText::HUD))
	{
		%screen = Presto::ScreenSize();
		%width  = getWord(%screen, 0);
		%height = getWord(%screen, 1);
		echo("Height: " @ %height @ " Width: " @ %width);

		$King::ScrollText::HUD = newObject("ScrollTextHUD", FearGuiFormattedText, 0,floor(%height / 3), %width,20);
		addToSet(playGui, $King::ScrollText::HUD);
		King::Scrolltext::Update();
	}
}

//
// Destroy the HUD
// 
//Event::Attach(eventConnectionLost, King::ScrollText::Destroy);
function King::ScrollText::Destroy()
{
	if (isObject($King::ScrollText::HUD))
		deleteObject($King::ScrollText::HUD);
}

// 
// Update HUD
//
function King::ScrollText::Update()
{
	if (isObject($King::ScrollText::HUD))
	{
		%hud = $King::ScrollText::HUD;		

		Control::setValue(Object::getName(%hud), "<jc><f2>" @ King::ScrollText::Segment());

		schedule("King::Scrolltext::Update();", 0.4);
	}
}

//
// Get next segment of text
function King::ScrollText::Segment()
{
	%buf = "";
	for (%a = 0; String::getSubStr(%text, %a, 1) != ""; %a++)
		%buf = %buf @ " ";
	%text = $King::ScrollText::Text @ %buf;

	$King::ScrollText::Pos++;
	if ($King::ScrollText::Pos >= String::Len(%text))
		$King::ScrollText::Pos = 0;

	%pos = $King::ScrollText::Pos;

	return String::getSubStr(%text, %pos, 999) @ String::getSubStr(%text, 0, (%pos - 1));
}