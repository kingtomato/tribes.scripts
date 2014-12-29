// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "limit images from being displayed in a *print message, "
			@ "and crashing your game. Very handy for if a player "
			@ "joins the game using a name of a bitmap, or if the "
			@ "server sends a crash (like some mods I know) to kill "
			@ "your computer.";

function PrintProtect::Clean(%msg)
{
	%tag_open = String::findSubStr(%msg, "<B");

	while (%tag_open != -1)
	{
		%tag_close = String::findSubStr(%msg, ".bmp>");

		%msg	= String::getSubStr(%msg, 0, %tag_open)
			@ "[Removed]"
			@ String::getSubStr(%msg, %tag_close + 5, 255);

		%tag_open = String::findSubStr(%msg, "<B");
	}

	return %msg;
}