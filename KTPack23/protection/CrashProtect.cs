// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.1";
$Script::Description	= "Prevents lame crash attempts such as hex, tab and cr.";

if (KingPref::Enabled(CrashProtect))
	Event::Attach(eventExtendedClientMessage, King::CrashProtect::OnMsg);

function King::CrashProtect::OnMsg(%client, %msg, %txt) {

	if ((%client == 0) || (%client == getManagerId()))
		return;

	%cName = Client::GetName(%client);
	echo("MSG: " @ %cName @ ": " @ escapeString(%msg));

	%count[Tab] = 0;
	%count[Cr]  = 0;
	%count[Hex] = 0;

	//
	// Tab Crash & Carrage Return
	//

	for (%a = 0; %a < String::Len(%msg); %a++) {
		%sec2 = String::GetSubStr(%msg, %a, 2);

		// Tab
		if (String::GetSubStr(%msg, %a, 1) == "\t")
			%count[Tab]++;

		// New Line
		if (String::GetSubStr(%msg, %a, 1) == "\n")
			%count[Cr]++;
	}

	if (%count[Tab] >= $KingPref::CrashProtectCount)
	{
		King::CrashProtect::Catch(%client, "TAB Crash");
		return "mute";
	}
	else if (%count[Cr] >= $KingPref::CrashProtectCount)
	{
		King::CrashProtect::Catch(%client, "Carrage Return Crash");
		return "mute";
	}

	//
	// Hex Crash
	//

	%msg_ = escapeString(%msg);
	for (%a = 0; %a < String::Len(%msg_); %a++) {
		if (String::getSubStr(%msg_, %a, 2) == "\\x")
			%count[Hex]++;
	}

	if (%count[Hex] >= $KingPref::CrashProtectCount)
	{
		King::CrashProtect::Catch(%client, "HEX Crash");
	}
}

function King::CrashProtect::Catch(%client, %attack)
{
	if ((KingPref::Enabled(CrashProtectNotice)) && (Flood::Protect("Crash", 5)))
		say(0, "[CRASH PROTECTION] Threat: " @ Client::getName(%client) @ " Attack: " @ %attack);

	// Check for allowing to kick
	if ((KingPref::Enabled(CrashProtectKick)) && (Flood::Protect("crashkick", 5)))
	{
		// Open Tab
		remoteEval(2049, scoresOn);
		schedule("clientmenuselect(\"kick " @ %client @ "\");", 0.4);
		schedule("clientmenuselect(\"yes " @ %client @ "\");", 0.8);

		// Assuming that didn't work, start a vote
		schedule("King::CrashProtect::Vote(" @ %client @ ");", 1.2);

	}
}

function King::CrashProtect::Vote(%client)
{
	if (Client::getName(%client) != "")
	{
		remoteEval(2048, scoresOn);
		schedule("clientmenuselect(\"vkick " @ %client @ "\");", 0.4);		
		schedule("say(0, \"Vote Yes! Trying To Crash Us!\");", 0.8);
	}
}