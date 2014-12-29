// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Uses the uber elite patch by Andrew and gives us a "
			@ "timestamp on the screen. Very Nify.";

// ----------------------------------------------------------------------------
// HUD

function King::TimeDate::Make()
{
	HUD::New(timeDate, King::TimeDate::Update, $KingPref::TimeHud_Pos @ " 125 15");
	HUD::Display(timeDate, true);
}

function King::TimeDate::Update(%hud)
{
	// yyyy/mm/dd hh:mm:ss.nn
	%time = String::getSubStr(timestamp(), 11, 8);

	if (!KingPref::Enabled(TimeHud_Military))
	{
		%time[0] = String::getSubStr(%time, 0, 2);
		%time[1] = String::getSubStr(%time, 2, 6);

		%ampm = "am";
		if (%time[0] > 12)
		{
			%ampm = "pm";
			%time[0] -= 12;
		}

		%time = %time[0] @ %time[1] @ %ampm;
	}

	HUD::AddTextLine(%hud, "<jc><f1>Time:<f0> " @ %time);

	return 1.0;
}

if (KingPref::Enabled(TimeHud))
	King::TimeDate::Make();