// ----------------------------------------------------------------------------
// KingTomato Scripts
// --
// Read PB_Counter.cs for installation instructions.
// ----------------------------------------------------------------------------

$Script::Version	= "1.0";
$Script::Creator	= "KingTomato";
$Script::Description	= "This is a nice little HUD to go along with the counter "
			@ "I made for PB. Just shows kills, headshots, and your "
			@ "percentile.";

// ----------------------------------------------------------------------------
// HUD Size and toggles

King::HUD::Default(Counter, true, 120, 0);

// ----------------------------------------------------------------------------
// Create HUD

function King::CounterHUD::Make()
{
	%hud = kt_Counter;
	%xywh = sprintf("%1 %2 100 75", $King::HUD[Counter, X], $King::HUD[Counter, Y]);

	HUD::New(%hud, King::CounterHUD::Update, %xywh);

	if ($King::HUD[Counter, On])
		HUD::Display(%hud, true);
}

// ----------------------------------------------------------------------------
// Update

function King::CounterHUD::Update(%hud)
{
	if ((!$King::PB::HeadShot) || (!$King::PB::TotalKills))
		%avg = "0.00";
	else
		%avg = ($King::PB::HeadShot / $King::PB::TotalKills) * 100;
	%dec = String::findSubStr(%avg, ".");
	%avg = String::getSubStr(%avg, 0, %dec + 2);

	HUD::AddTextLine(%hud, "<jc><f2>PB Counter Stats");
	HUD::AddTextLine(%hud, "<jl><f1> HS's: <jr><f0>" @ $King::PB::Headshot @ "  ");
	HUD::AddTextLine(%hud, "<jl><f1> Kills: <jr><f0>" @ $King::PB::TotalKills @ "  ");
	HUD::AddTextLine(%hud, "<jl><f1> Avg: <jr><f0>" @ %avg @ "%  ");
	return 1;
}

King::CounterHUD::Make();