// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.1";
$Script::Description	= "Provides a few stats on your computer. Commands are "
			@ "!specs and !server on any server. Some servers may "
			@ "also disallow these messages strictly due to length.";

Command::Add("!specs", KingTomato::Command::Specs);
function KingTomato::Command::Specs(%cmd,  %param) {
	if ($Pref::videoFullScreen)
		%full = "Full Screen";
	else
		%full = "Windowed";

	%driver = $Pref::videoFullScreenDriver @ " driver";
	%res = $pref::VideoFullScreenRes;
	%fps = floor($ConsoleWorld::FrameRate);
	%refresh = $ConsoleWorld::msecsPerFrame @ "ms";

	say(0, "I am currently running " @ %driver @ " in " @ %full @ " mode. "
		@ "My resolution is " @ %res @ " running at " @ %fps @ " frames "
		@ "per second with a refresh time of " @ %refresh @ " per frame.");
}

Command::Add("!server", KingTomato::Command::ServSpecs);
function KingTomato::Command::ServSpecs(%cmd,  %param) {
	say(0, "I am currently connected to server \"" @ $ServerName @ "\" running "
		@ "Tribes (v" @ $ServerVersion @ ") modification \"" @ $ServerMod @ "\". "
		@ "The current map is \"" @ $ServerMission @ " (" @ $ServerMissionType @ ")\"");
}