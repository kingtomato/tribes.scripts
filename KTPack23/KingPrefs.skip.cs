// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
// Configure this file to adapt to the settings you wish to have.  Everything is explained, and
// should be easy to configure. I have also included some settings that I personally prefer, that
// I feel others might also.  If you should apply my settings, then want to go back, I have also
// included an "undo" feature. All original settings are saved before they are modified.
// ------------------------------------------------------------------------------------------------

//
// My Personal Prefs
//
// Too many people didn't know what my prefs did, so by default I am making it disabled.
// Please do enable though if you liked my settings
//
$KingPref::UseMyPrefs = false;

// 
// Acronym Replacer
// 
// Replaces things like LOL with Laughing Out Loud. Choose your own style also below.
//
$KingPref::Acronyms       = true;		// Enable Replacer
$KingPref::Acronyms_Style = "-(<acro>)-";	// Style that the acronym will take once
						// replaced with meaning. use the keyword
						// <acro> to symbolise position of acronym

// 
// Advertise This Script
// 
// If you don't mind advertising this script (one time, on join) then you can keep this
// variable. Otherwise, just remove it and that's all there is to it. Honest ;P
// 
$KingPref::Advertise = true;

// 
// Auto SAD Login
// 
// This script will give you the ability to store passwords for logging into a server. The
// password is based off the server's ip address. When you join a server, it looks for a
// password that matches that ip. When found, it will auto-identify you.
//
// To enter your password, type "!setsad <password>" in the server. Though the script should
// work, I would advise using "!setsad test" first, and make sure the script recognises it
// as a command.  If it does, proceed to use "!setsad <password>"
//
$KingPref::AutoSAD = true;

// 
// Bot Commands
//
// This script has the ability to create commands that other in the server can respond to.
// Though none are included in this script, the possibility to exists. Additionally, by default
// its setup so that you cannot trigger these commands. I.E. If the command was !hi, and someone
// in the server typed !hi, the script would respond. If you typed the same thing, and the below
// value was false, you would not trigger the script.
//
// To change that, set the below value to true, and you will be able to trigger scripts of your
// own.
// 
$KingPref::IncludeSelf = false;

// 
// Crash Protection
// 
// This will prevent lamers from crashing you via the old \t or \x<hex> crash in the game.
// Basically, it prevents the crash, then makes a model of them.  It will also, assuming the
// option is enabled, kick the user.  The only problem with this is it uses the TAB menu.
// This means if you are in the middle of a game, your tab menu will popup, and you'll most
// likely get killed. ;\
// 
$KingPref::CrashProtect		= true;		// Enable Protection?
$KingPref::CrashProtectKick	= false;	// Kick them?
$KingPref::CrashProtectNotice	= true;		// Advertise to the whole server someone
						// is trying a crash
$KingPref::CrashProtectCount	= 15;		// number of tags that triggers a 'crash'

//
// Counter Script
//
// Counts paintball kills, HeadShots, and gives life stats on deaths.
//

$KingPref::Counter		= true;		// Enable Counter
$KingPref::Counter_Advertise	= true;		// Advertise kill stats
$KingPref::Counter_SKRatio	= "15 10";	// Ratio of kills to time in seconds for a suspected spawn killer
$KingPref::Counter_SKAdvertise	= false;	// Say something about a suspected spawn killer
$KingPref::Counter_KeepTotals	= true;		// Keep kill totals past mission end

//
// Counter HUD
//
// Shows Paintball coutner stats on the top left corner of screen.
//

$KingPref::CounterHUD		= true;		// Enable HUD
$KingPref::CounterHUD_Pos	= "120 0";	// X Y

// 
// Frames Per Second (FPS) HUD
// 
// This is just a simple hud (very small) that gives you your current FPS count. I made this
// because showFPS(); (IMO) is a memory hog--and the fact its forcing tribes to spam your
// console isn't that great either).  This way, it updates every second, and gives you an
// accurate FPS Count.
// 
$KingPref::FPSHud	= true;		// Enabled
$KingPref::FPSHud_Pos	= "425 0";	// Position

//
// Friends List
// 
// This is a cool little script that will vote for you in your buddies favor. For example,
// if your buddy wants to change the mission, you vote yes. If they are being voted to kick,
// you will vote no. Additionally, if a vote is against you, you will say to the server to
// vote no. You can't vote no yourself, as the server doesn't count the victim's vote, but
// you can try to convince others to think no. >:P
//
$KingPref::Friends	= true;		// Enable Friends Voting
$KingPref::Friends_Say	= false;	// Advertise tot he server what your vote is?
$KingPref::Friends_Rvng	= true;		// If a friend is kicked by vote, would you like to
					// vote the kicker (One that made vote)?
$KingPref::Friends_Help	= true;		// This has to do with do you want to say "vote no"
					// when the vote is against you?

// List your friends below, incrementing the number between []'s
$KingPref::Friends[1]	= "KingTomato";
$KingPref::Friends[2]	= "";
$KingPref::Friends[3]	= "";
$KingPref::Friends[4]	= "";

// 
// Logging
// 
// With this feature enabled, all text form your console will be logged to console.log in
// your tribes directory.  Watch out though, as this file can get large.
//
$KingPref::Logging = false;

// 
// Nude Walls
// 
// This will set the following objects to have either pictured of women in bikinies, or
// in some cases nude. I have this disabled just as common curtesy to the women, but
// I'm sure the guy will want it. >:D
//
// Nude/Bikini Items:
//	- Blast Walls
//	- Panels
//	- Elevator
//	- Platform (Deployable and Medium)
// 
$KingPref::NudeWalls = true;

//
// Red Force Fields
// 
// Gives the cool appearance of red force fields. A nice little change from the normal.
//
$KingPref::RedWalls = true;

//
// Silent Out Of Bounds Warning
//
// Kills the *beep beep beep* when you go out of bounds. Makes a more pleasing on screen
// message. Set this to true of you do not want to hear "beep beep beep".
//
$KingPref::SilentOOB = true;

// 
// Time HUD
// 
// Becuase most mods like to display the weapon on the bottom of the screen, I devised a
// HUD to show me the last vote in progress.  This way I can keep my eyes on the screen,
// and vote when I decide to.
// 
$KingPref::TimeHud		= true;		// Enable HUD
$KingPref::TimeHud_Pos		= "1101 0";	// Position
$KingPref::TimeHUD_Military	= true;		// I personally like military time (24hrs,
						// where 0-12am, 13-24pm) but if you want
						// 12 hours, disable this

// 
// Vote HUD
// 
// Becuase most mods like to display the weapon on the bottom of the screen, I devised a
// HUD to show me the last vote in progress.  This way I can keep my eyes on the screen,
// and vote when I decide to.
// 
$KingPref::VoteHud	 = true;	// Enable HUD
$KingPref::VoteHud_Pos	 = "475 0";	// Position
$KingPref::VoteHud_Width = "625";	// Width of HUD