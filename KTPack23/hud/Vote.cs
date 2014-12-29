// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
// Vote Watch
// 
// I hate when i miss a vote topic on the bottom of the screen while changin weapons, so i made
// this.  It puts the current vote topic in a hud at the top right of the screen, so you can see
// who and what is being voted. >:F
// ------------------------------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.02";
$Script::Description	= "This is a just a small hud that monitors currents votes by users. "
			@ "Simply put, it makes it so when the bottom text with the vote topic "
			@ "appears, it doesnt 'disappear' on a weapon change for instance when a "
			@ "new bottom print message is displayed.";

$King::Vote::NoVote	= "No vote in progress";
$King::Vote::Vote	= $King::Vote::NoVote;
$King::Vote::Voter	= "";

Event::Attach(eventBottomPrint, King::Vote::OnBP);
Event::Attach(eventClientMessage, King::Vote::OnMsg);

function King::Vote::OnBP(%msg, %timeout) {
	if (Match::ParamString(%msg, "<jc><f1>%p <f0>initiated a vote to <f1>%v")) {
		$King::Vote::Voter = Match::Result(p);
		$King::Vote::Vote = Match::Result(v);
	}
}

function King::Vote::OnMsg(%client, %msg) {
	if (%client != 0)
		return;
	if ((Match::String(%msg, "Vote to *: * to * with *")) || (Match::String(%msg, "Vote * cancel*")) || (Match::String(%msg, "* canceled the vote.")))
	{
		$King::Vote::Voter = "";
		$King::Vote::Vote = $King::Vote::NoVote;
	}
	else if (Match::String(%msg, "* has forced the current vote to fail."))
	{
		$King::Vote::Voter = "";
		$King::Vote::Vote = $King::Vote::NoVote;
	}
}

function King::Vote::voteHUD() {
	HUD::New(voteHUD, King::Vote::HUDupdate, $KingPref::VoteHUD_Pos @ " " @ $KingPref::VoteHUd_Width @ " 15");
	HUD::Display(voteHUD);
}

function King::Vote::HUDupdate(%hud) {
	if (Match::String($King::Vote::Vote, $King::Vote::NoVote))
		HUD::AddTextLine(%hud, "<f1>Vote: <f0>" @ $King::Vote::Vote);
	else	
		HUD::AddTextLine(%hud, "<f1>Vote: <f2>" @ $King::Vote::Voter @ " <f0>wants to <f2>" @ $King::Vote::Vote);
	return 1;
}

if (KingPref::Enabled(VoteHUD))
	King::Vote::voteHud();