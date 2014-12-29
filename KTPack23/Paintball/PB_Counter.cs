// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// Requirements:
//	Presto Pack 0.93 (http://www.planettribes.com/presto/)
//	KTPack 2.2 or later (http://www.kingtomato.org)
//
// Installation:
//	Put this file into your KingTomato directory where the KTPack is
//	installed to, and run tribes. You can also create a directory in that
//	folder (like I have) called Paintball to keep things organized. :D
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "0.2b";
$Script::Description	= "Painball counters. Counts Kills, HeadShots, and gives "
			@ "statistics on death.";
$Script::MinVersion	= "2.2";

$King::PB::Advertise	= KingPref::Enabled(Counter_Advertise);
$King::PB::Kills	= 0;		// Kills per round
$King::PB::SKRatio	= $KingPref::Counter_SKRatio;
$King::PB::SKAdvertise	= $KingPref::Counter_SKAdvertise;
$King::PB::KeepTotals	= KingPref::Enabled(Counter_KeepTotals);

if (($King::PB::HeadShot == "") || (!$King::PB::KeepTotals))
	$King::PB::HeadShot = 0;
if (($King::PB::TotalKills == "") || (!$King::PB::KeepTotals))
	$King::PB::TotalKills = 0;

// ----------------------------------------------------------------------------
// Events

Event::Attach(eventBottomPrint, King::PB::BottomPrint);
Event::Attach(eventClientMessage, King::PB::ClientMessage);
Event::Attach(eventChangeMission, King::PB::Mission);
Event::Attach(eventExit, "King::PB::Bind(false);");

function King::PB::BottomPrint(%msg, %t)
{
	if (!KingPref::Enabled(Counter))
		return;

	if (Match::String(%msg, "<f0><jc>You Shot<f1>* In The Mask!") || Match::String(%msg, "<jc><f2>You shot * in the mask! *"))
	{
		$King::PB::HeadShot++;
		if ($King::PB::Advertise)
		{
			say(0, "Head Shot! #" @ $King::PB::HeadShot);
			if (version() == "1.14b")
				Sound("whshot.wav");
			else
				remoteEval(2048, lmsg, hshot);	// thank me for this one
								// I made a deal with Lokie. He kills
								// his oops, I kill my cheer. >:D
		}
	}
	else if (Match::String(%msg, "<f0><jc>You Got Shot In The Mask by <f1> *!"))
	{
		if (($King::PB::Advertise) && ($King::PB::SayNS))
			say(0, "Nice shot, " @ Match::Result(0) @ "!");
	}
}

function King::PB::ClientMessage(%client, %msg)
{
	if (!KingPref::Enabled(Counter))
		return;

	if (%client != 0)
		return;

	if     (Match::String(%msg, "* caps *, *") || Match::String(%msg, "* caps *.") ||
		Match::String(%msg, "* Splats *.") || Match::String(%msg, "* Painted *.") ||
		Match::String(%msg, "* Covered *.") || Match::String(%msg, "* Marked *."))
	{
		King::PB::Kill(Match::Result(0), Match::Result(1));
	}
	// This is kind of an oddball, cause it reverses the order of the killer and the victim. Needs its own
	// condition
	else if (Match::String(%msg, "* gets capped by *'s grenade."))
	{
		King::PB::Kill(Match::Result(1), Match::Result(0));
	}
	else if (Match::String(%msg, "* dies.") || Match::String(%msg, "* thought the hopper was empty.") ||
		 Match::String(%msg, "* commits suicide!") || Match::String(%msg, "* Is an IDIOT.") ||
		 Match::String(%msg, "* could not take the heat of the battle so * caps * own self.") ||
		 Match::String(%msg, "* didn't expect that last jump.") ||
		 Match::String(%msg, "* forgot the elevator moves."))
	{
		King::PB::Kill(-1, Match::Result(0));
	}
}

function King::PB::Kill(%killer, %victim)
{
	%me = Client::getName(getManagerId());

	if (%killer == %me)
	{
		if (%victim != %me)
		{
			$King::PB::Kills++;
			$King::PB::TotalKills++;
			if (version() == "1.14b")
				Sound("whittarget.wav");
			else
				remoteEval(2048, lmsg, hittarget);
		}
	}
	else if (%victim == %me)
	{
		if (($King::PB::Kills > 0) && ($King::PB::Advertise))
			say(0, "Kills last round: " @ $King::PB::Kills @ "; Total: " @ $King::PB::TotalKills);
		$King::PB::Kills = 0;
	}
	else if ($King::PB::SKAdvertise)
	{
		%kills = getWord($King::PB::SKRatio, 0);
		%time = getWord($King::PB::SKRatio, 0);

		$King::PB::Kills[%client]++;
		schedule("$King::PB::Kills[" @ %client @ "]--;", %time);

		if (($King::PB::Kills[%client] > %kills) && ($King::PB::Advertise) && (Flood::Protect("pb_sk", 10)))
			say(0, "*sigh* Looks like " @ %killer @ " is spawn killing (" @ %kills @ " kills, " @ %time @ " seconds)...");
	}
}

function King::PB::Mission(%mission)
{
	if (!$King::PB::KeepTotals)
	{
		$King::PB::KeepTotals = 0;
		$King::PB::HeadShot = 0;
	}
	$King::PB::Kills = 0;
}

King::Settings::Export("$King::PB::HeadShot");
King::Settings::Export("$King::PB::TotalKills");