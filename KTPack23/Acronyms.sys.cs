// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
// Changes normal text with acronyms such as "lol", "brb", etc into their actual meanings (Laughing
// Out Loud, Be Right Back, etc).  Very easy to use, and simple to add words.
// ------------------------------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.35";
$Script::Description	= "Changes normal text with acronyms such as \"lol\", \"brb\", etc into "
			@ "their actual meanings (Laughing Out Loud, Be Right Back, etc).  Very "
			@ "easy to use, and simple to add words.";

// ------------------------------------------------------------------------------------------------
// Variables

if ($Acronym::Count == "")
	$Acronym::Count = 0;

// Look at bottom of file to edit list of acronyms

// ------------------------------------------------------------------------------------------------
// Here we set up the "engine" that wil manage acronyms

function Acronym::Add(%acro, %meaning) {
	if ($Acronym::List[%acro] == "")
	{
		$Acronym::List[%acro] = %meaning;
		$Acronym::List::[$Acronym::Count++] = %acro;
	}
	else
		$Acronym::List[%acro] = %meaning;
}

function Acronym::Remove(%acro)
{
	deleteVariables("$Acronym::List[" @ %acro @ "]");
	for (%a = 1; $Acronym::List::[%a] != ""; %a++)
		if ($Acronym::List::[%a] == %acro)
			for (%b = %a; %b <= $Acronym::Count; %b++)
				$Acronym::List::[%b] = $Acronym::List::[%b+1];
	$Acronym::Count--;
}

function Acronym::Find(%n)
{
	if (%n == 0)
		return $Acronym::Count;
	return $Acronym::List::[%n];
}

function Acronym::Get(%acro) {
	return $Acronym::List[%acro];
}

function Acronym::Style(%acro) {
	return String::Replace($KingPref::Acronyms_Style, "<acro>", %acro);
}

// ------------------------------------------------------------------------------------------------
// Replace Words

function Acronym::Replace(%message) {
	if (KingPref::Enabled(Acronyms))
	{
		for (%w = 0; %w < String::getWordCount(%message); %w++)
		{
			%word = getWord(%message, %w);
			%acro = Acronym::Get(%word);

			if (%w != 0)
				%msg = %msg @ " ";

			if (%acro != "")
				%msg = %msg @ Acronym::Style(%acro);
			else
				%msg = %msg @ %word;
		}
		return %msg;
	}
	else
		return %message;
}

// ------------------------------------------------------------------------------------------------
// Toggle For Commands

Command::Add("!acronym *", Command::Acronym);
function Command::Acronym(%cmd, %params)
{
	if (%params == "on")
	{
		$KingPref::Acronyms = True;
		remoteBP(2048, "<jc><f1>Acronyms are now <f0>Enabled", 10);
	}
	else if (%params == "off")
	{
		$KingPref::Acronyms = False;
		remoteBP(2048, "<jc><f1>Acronyms are now <f0>Disabled", 10);
	}
	else if (Match::String(%params, "style *"))
	{
		$KingPref::Acronyms_Style = Match::Result(0);
		%style = String::Replace($KingPref::Acronyms_Style, "<ACRO>", "<f2>Acronym<f0>");
		remoteBP(2048, "<jc><f1>Acronyms style set to <f0>" @ %style, 10);
	}
}

// ------------------------------------------------------------------------------------------------
// Settings Export

King::Settings::Export("$Acronym::*");

// ------------------------------------------------------------------------------------------------
// Create List

Acronym::Add("afaik",	"As Far As I Know");
Acronym::Add("afk",	"Away From Keyboard");
Acronym::Add("aka",	"Also Known As");
Acronym::Add("bak",	"Back At Keyboard");
Acronym::Add("bbiab",	"Be Back In A Bit");
Acronym::Add("bbiaf",	"Be Back In A Few");
Acronym::Add("bbl",	"Be Back Later");
Acronym::Add("bk",	"Base Killer");
Acronym::Add("brb",	"Be Right Back");
Acronym::Add("bs",	"Bull Shit");
Acronym::Add("btw",	"By The Way");
Acronym::Add("dd",	"Designated Decoy");
Acronym::Add("ff",	"Force Field");
Acronym::Add("fyi",	"For Your Information");
Acronym::Add("gf",	"Good Fight");
Acronym::Add("gfu",	"Good For You");
Acronym::Add("gfy",	"Go Fuck Yourself");
Acronym::Add("gg",	"Good Game");
Acronym::Add("gn",	"Good Night");
Acronym::Add("gtg",	"Got To Go");
Acronym::Add("gth",	"Go To Hell");
Acronym::Add("hm",	"Happy Mod");
Acronym::Add("hmer",	"Happy Modder");
Acronym::Add("ho",	"Hold On");
Acronym::Add("hs",	"Head Shot");
Acronym::Add("htf",	"How The Fuck?");
Acronym::Add("idk",	"I Don't Know");
Acronym::Add("irl",	"In Real Life");
Acronym::Add("jc",	"just Checking");
Acronym::Add("jk",	"Just Kidding");
Acronym::Add("jp",	"Just Playing");
Acronym::Add("kt",	"KingTomato");
Acronym::Add("ktorg",	"www.KingTomato.org");
Acronym::Add("lmao",	"Laughing My Ass Off");
Acronym::Add("lmfao",	"Laughing My Fucking Ass Off");
Acronym::Add("lol",	"Laughing Out Loud");
Acronym::Add("n2b",	"Not Too Bad");
Acronym::Add("nb",	"Not Bad");
Acronym::Add("ng",	"No Good");
Acronym::Add("nm",	"Not Much");
Acronym::Add("nn",	"Nice 'Nade");
Acronym::Add("np",	"No Problem");
Acronym::Add("nr",	"Non Registering Hit");
Acronym::Add("ns",	"Nice Shot");
Acronym::Add("nt",	"No Thanks");
Acronym::Add("nvm",	"Never Mind");
Acronym::Add("omg",	"Oh My God");
Acronym::Add("phs",	"Pistol Head Shot");
Acronym::Add("pk",	"Pistol Kill");
Acronym::Add("pos",	"Piece Of Shit");
Acronym::Add("rofl",	"Rolling On Floor Laughing");
Acronym::Add("roflmao",	"Rolling On Floor Laughing my Add Off");
Acronym::Add("rtfm",	"Read the Fucking Manual");
Acronym::Add("rtm",	"Read the Manual");
Acronym::Add("sk",	"Spawn Kill");
Acronym::Add("sob",	"Son Of A Bitch");
Acronym::Add("sol",	"Shit Out of Luck");
Acronym::Add("stfu",	"Shut The Fuck Up");
Acronym::Add("tk",	"Team Kill");
Acronym::Add("ttyl",	"Talk To You Later");
Acronym::Add("ty",	"Thank You");
Acronym::Add("wb",	"Welcome Back");
Acronym::Add("wtf",	"What The Fuck?");
Acronym::Add("wtg",	"Way To Go");
Acronym::Add("wth",	"What The Hell");
Acronym::Add("wtmi",	"Way To Much Information");
Acronym::Add("yw",	"Your Welcome");
//Acronym::Add("",	"");