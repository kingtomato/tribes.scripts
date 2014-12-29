// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "This should help prevent you from getting kicked on "
			@ "server with flood protection.  It basically disallows "
			@ "you from talking until your flood limit is up.  Kind "
			@ "of nifty for places like Nappy Porn, where your "
			@ "disallow times increments if you talk to early.";

$FloodProtect::Enabled	= False;
$FloodProtect::Time	= 0;

Event::Attach(eventClientMessage, King::FloodProtect::Msg);
function King::FloodProtect::Msg(%client, %msg)
{
	if (%client != 0)
		return;

	if (Match::String(%msg, "FLOOD! SHUT THE FUCK UP FOR *s."))
	{
		%time = Match::Result(0) + 1;
		%timeNow = getIntegerTime(false) >> 5;
		$FloodProtect::Enabled	= True;
		$FloodProtect::Time	= %timeNow + %time;
		schedule("$FloodProtect::Enabled = False;", %time);
	}
	else if (Match::String(%msg, "FLOOD! You cannot talk for * seconds."))
	{
		%time = Match::Result(0) + 1;
		%timeNow = getIntegerTime(false) >> 5;
		$FloodProtect::Enabled	= True;
		$FloodProtect::Time	= %timeNow + %time;
		schedule("$FloodProtect::Enabled = False;", %time);
	}
}

Event::Attach(eventClientInput, King::FloodProtect::OnInput);
function King::FloodProtect::OnInput(%team, %message)
{
	%curTime = getIntegerTime(false) >> 5;

	if ($FloodProtect::Time >= %curTime)
	{
	 	%delta = ($FloodProtect::Time - %curTime) + 1;

		remoteBP(2048, "<jc><f2>-Flood Protection Enabled-\n"
			@ "<f1>You have <f0>" @ %delta @ "<f1> seconds remaining.", 10);

		return "mute";
	}
}