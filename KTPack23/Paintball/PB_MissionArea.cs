// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Tired of the mission area beep? Kill it with this "
			@ "simple script!";

$MissionArea::Text = "";

Event::Attach(eventExtendedClientMessage, MissionArea::onMessage);
function MissionArea::onMessage(%client, %msg, %text)
{
	if (%client != 0)
		return;

	if (KingPref::Enabled(SilentOOB))
	{
		if (String::findSubStr(%msg, "wLeftMissionArea") != -1)
		{
			MissionArea::ShowOOB();
			return mute;
		}
	}
}

function MissionArea::ShowOOB()
{
	if ($MissionArea::Text != "")
		return;

	%screenSize	= Presto::screenSize();
	%screen[Width]	= getWord(%screenSize, 0);
	%screen[Height]	= getWord(%screenSize, 1);

	%text[X] = 10;
	%text[Y] = floor(%screen[Height] / 3);

	$MissionArea::Text = newObject("OutOfBoundsText", FearGuiFormattedText, %text[X], %text[Y], %screen[Width], 15);
	addToSet("playGui", $MissionArea::Text);

	Control::setValue("OutOfBoundsText", "<jc><f2>You are out of bounds.");

	schedule("MissionArea::HideOOB();", 5);
}

function MissionArea::HideOOB()
{
	if (!isObjecT($MissionArea::Text))
		return;

	deleteObject($MissionArea::Text);
	$MissionArea::Text = "";
}

// So simple, yet so much appreciated ;d