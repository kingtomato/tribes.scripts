// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Uses the uber elite patch by Andrew and gives us a "
			@ "timestamp on the screen. Very Nify.";

// ----------------------------------------------------------------------------
// HUD Information
// -- 
// Don't change this, use the NewOpts page

King::HUD::Default(Time, true, 120, 75, 100);

// ----------------------------------------------------------------------------
// HUD

function King::Time::Make()
{
	%hud = kt_Time;
	%xywh = sprintf("%1 %2 %3 15", $King::HUD[Time, X], $King::HUD[Time, Y], $King::HUD[Time, W]);
	HUD::New(%hud, King::Time::Update, %xywh);

	if ($King::HUD[Time, On])
		HUD::Display(%hud, true);
}

function King::Time::Update(%hud)
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

	if (!King::LastHope())
		HUD::AddTextLine(%hud, "<jc><f1>Time:<f2> Bad Ver");
	else
		HUD::AddTextLine(%hud, "<jc><f1>Time:<f0> " @ %time);

	return 1.0;
}

King::Time::Make();