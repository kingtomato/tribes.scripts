// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "This will watch the voting system, and vote in  your "
			@ "buddies favor. If your buddy is voting for a mission, "
			@ "you will vote for the change. If someone wants to "
			@ "kick your buddy, you will vote no.";

Event::Attach(eventBottomPrint, King::Friends::OnBP);
Event::Attach(eventClientMessage, King::Friends::OnMsg);

function King::Friends::OnBP(%msg, %timeout) {
	if (!KingPref::Enabled(Friends))
		return;

	if (Match::String(%msg, "<jc><f1>* <f0>initiated a vote to <f1>*")) {
		%player = Match::Result(0);
		%vote   = Match::Result(1);

		$King::Friends::LastVoter = %player;

		if (Match::String(%vote, "kick *"))
		{
			%victim = Match::Result(0);
			if (King::Friends::IsFriend(%victim))
			{
				voteNo();
				if (KingPref::Enabled(Friends_Say))
					say(0, "Vote No!~wno");
			}
			else if ((King::Friends::IsMe(%victim)) && (King::Enabled(Friends_Help)))
				say(0, "Please Vote No!~wno");
		}
		else if (King::Friends::IsFriend(%player))
		{
			voteYes();
			if (KingPref::Enabled(Friends_Say))
				say(0, "Vote Yes!~wno");
		}
	}
}

function King::Friends::OnMsg(%client, %msg)
{
	if (%client != 0)
		return;

	if (Match::String(%msg, "* was * from vote."))
	{
		%victim = Match::Result(0);
		%action = Match::Result(1);

		if ((%action == "kicked") || (%action == "banned"))
			if ((King::Friends::IsFriend(%victim)) && (King::Enabled(Friends_Rvng)))
			{
				%client = getClientByName($King::Friends::LastVoter);
				if (%client != 0)
				{
					remoteEval(2048, ScoresOn);
					schedule("clientmenuselect(\"vkick " @ %client @ "\");", 0.3);
				}
			}
	}
}

function King::Friends::IsFriend(%friend)
{
	for (%a = 1; $KingPref::Friends[%a] != ""; %a++)
	{
		%name = $KingPref::Friends[%a];
		if ((%name == %friend) || (%name@".1" == %friend))
			return true;
	}
}

function King::Friends::IsMe(%friend)
{
	for (%a = 0; $PCFG::Name[%a] != ""; %a++)
	{
		%name = $PCFG::Name[%a];
		if ((%name == %friend) || (%name@".1" == %friend))
			return true;
	}
	return false;
}