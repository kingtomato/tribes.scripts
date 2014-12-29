// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.2";
$Script::Description	= "Apon joining a server, this script will automatically "
			@ "type in your SAD password for you.  The password is "
			@ "based on the sevrer's IP address, so should the IP of "
			@ "the server change, your auto-login will not run.";

Event::Attach(eventConnectionAccepted, King::AutoSad::OnConnect);

function King::AutoSad::OnConnect() {
	if (!KingPref::Enabled(AutoSAD))
		return;

	%ip = String::Replace($Server::Address, ".", "");
	%pass = $King::AutoSad::Pass[%ip];
	if (%pass != "") {
		echo("Attempting auto-identify with saved SAD password");
		sad(%pass);
	}
}

// 
// In game command
// 
// this will respond to commands that are typed in global or team chat, making
// the addition of a password very easy. Should you want to change a apassword,
// just use the command over again.
//
Command::Add("!setsad *", King::AutoSAD::Command);
Command::Add("!setsad", King::AutoSAD::Command);
Command::Add("!remsad", King::AutoSAD::Command);
function King::AutoSAD::Command(%cmd, %param) {
	if (%cmd == "!setsad *")
	{
		%ip = String::Replace($Server::Address, ".", "");
		$King::AutoSad::Pass[%ip] = %param;
		remoteBP(2048, "<jc><f1>Server SAD Password Set\n"
			@ "<f0>Password '<f2>" @ %param @ "<f0>' has been added to the "
			@ "auto-identify list for server:<f2>\n" @ $ServerName, 5);
		sad(%param);
	}
	else if (%cmd == "!remsad")
	{
		%ip = String::Replace($Server::Address, ".", "");
		$King::AutoSad::Pass[%ip] = "";
		remoteBP(2048, "<jc><f1>Server SAD Password Set\n"
			@ "<f0>Password has been <f2>removed<f0> for server:<f2>\n" @ $ServerName, 5);
	}
	else
	{
		King::AutoSAD::Make();
	}
}


function King::AutoSAD::Make() {
	%hud = autosadHUD;
	%obj = 1;

	HUD::newFrame(%hud, "", "50% 50% 310 100");
	HUD::Display(%hud, True);

	%set	= nameToId("playGui/HUD::"@%hud);

	//  ___________________________________________
	// |                                           |
	// | _________________________________________ |
	// |                                           |
	// | End SAD Password Information     ________ |
	// | current Password: sdfsdfsdfsdfs |__Okay__||
	// |___________________________________________|

	%frame	= newObject("HUD::"@%hud@"::"@%obj++,	FearGui::FearGuiBox,		2,	2,	HUD::Width(%hud)-4,	HUD::Height(%hud)-4);
	%ebox	= newObject("HUD::"@%hud@"::"@%obj++,	FearGui::TestEdit,		10,	15,	290,			15,			True,	"", True);
	%curr	= newObject("HUD::"@%hud@"::"@%obj++,	FearGuiFormattedText,		15,	35,	100,			15);
	%about	= newObject("HUD::"@%hud@"::"@%obj++,	FearGuiFormattedText,		15,	45,	100,			15);
	%b1Bdr	= newObject("HUD::"@%hud@"::"@%obj++,	FearGui::FearGuiBox,		245,	40,	50,			25);
	%b1Txt	= newObject("HUD::"@%hud@"::"@%obj++,	FearGuiFormattedText,		247,	42,	50,			25);
	%b1Btn	= newObject("HUD::"@%hud@"::"@%obj++,	FearGui::FGUniversalButton,	245,	40,	50,			25,			"",	"King::AutoSAD::Okay();");

	addToSet(%set, %frame);
	addToSet(%set, %ebox);
	addToSet(%set, %about);
	addToSet(%set, %b1Bdr);
	addToSet(%set, %b1Txt);
	addToSet(%set, %b1Btn);

	%ip = String::Replace($Server::Address, ".", "");
	if ($King::AutoSad::Pass[%ip] != "")
		%pass = $King::AutoSad::Pass[%ip];
	else
		%pass = "(No Password Set)";

	Control::SetValue(Object::GetName(%ebox),	"");
	Control::SetValue(Object::GetName(%curr),	"Current SAD Pass: " @ %pass);
	Control::SetValue(Object::GetName(%about),	"Enter SAD Password Information");
	Control::SetValue(Object::GetName(%b1Txt),	" Okay");

	$King::AutoSAD::Editbox = Object::GetName(%ebox);

	cursorOn(MainWindow);
}

function King::AutoSAD::Okay() {
	%value = Control::getValue($King::AutoSAD::Editbox);
	if (%value != "")
	{
		%ip = String::Replace($Server::Address, ".", "");
		$King::AutoSad::Pass[%ip] = %value;
		remoteBP(2048, "<jc><f1>Server SAD Password Set\n"
			@ "<f0>Password '<f2>" @ %value @ "<f0>' has been added to the "
			@ "auto-identify list for server:<f2>\n" @ $ServerName, 5);
		sad(%value);
	}
	else
	{
		deleteVariables("$King::AutoSad::Pass" @ %ip);
	}
	HUD::Delete(autosadHUD);
	cursorOff(MainWindow);
}

King::Settings::Export("$King::AutoSad::Pass*");