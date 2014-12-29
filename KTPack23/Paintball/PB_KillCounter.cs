// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

// To kill the gay counters out there, i am taking a new approach. Basically,
// when a player kills another player, that killer is muted for 1 second. My
// hopes are that in that 1 second time, their counter will have already typed
// its bullshit, and I will be able to enjoy the game. I was getting tired of
// tracking the 50 million different messages, and needed alternative.
// The way it works is, i can only assume that 1 second after a kill, that killer
// shouldn't have said a legitimate message. Don't know too many who can kill
// and type at the same time. ;d

// v1.2
// Adding mute to victims also. Too manu "Watch where you're shooting" messages
// coming from a person who dies.

// For my pack
$Script::Creator	= "KingTomato";
$Script::Version	= "1.2";
$Script::Description	= "This is a simple tid bit that will kill all those "
			@ "annoying sounds ppl use when they kill others. "
			@ "You, I'm sure, know the sounds. It gets annoying to "
			@ "frequently hear 'Oops' over and over again.";

// Settings
$King::KillCounter::Enabled	= true;	// Enable mute script
$King::KillCounter::Time	= "1.0";// Length of mute

Event::Attach(eventClientMessage, King::KillCounter::OnMsg);
function King::KillCounter::OnMsg(%client, %msg, %text)
{
	// Don't mute us		     Mute player     only server msg
	if (%client == getManagerId())
		return;

	// mute those who need it
	else if ($mute[%client])
		return mute;

	// Only server message
	else if (%client != 0)
		return;

	// Look for a server kill msg, and add the mute
	if (Match::String(%msg, "* caps *, *") || Match::String(%msg, "* caps *.") ||
	    Match::String(%msg, "* Splats *.") || Match::String(%msg, "* Painted *.") ||
	    Match::String(%msg, "* Covered *.") || Match::String(%msg, "* Marked *."))
	{
		%killer = Match::Result(0);
		%victim = Match::Result(1);
		%killerId = getClientByName(%killer);
		%victimId = getClientByName(%victim);

		$mute[%killerId] = true;
		schedule("$mute[" @ %killerId @ "] = \"\";", $King::KillCounter::Time);

		$mute[%victimId] = true;
		schedule("$mute[" @ %victimId @ "] = \"\";", $King::KillCounter::Time);
	}
}