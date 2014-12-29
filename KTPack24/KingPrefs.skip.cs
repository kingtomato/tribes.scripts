// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
// The makings of this file has been changed a little bit. Basically, most of the script now
// revolves around NewOpts pages in the game itself. To modify values, goto options, click the
// scripts button on left, and then select the pages marked KingTomato.
// The other things that aren't in the NewOpts pages are listed below.
// ------------------------------------------------------------------------------------------------

//
// My Personal Prefs
//
// Too many people didn't know what my prefs did, so by default I am making it disabled.
// Please do enable though if you liked my settings
//
$KingPref::UseMyPrefs = false;

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
$KingPref::CrashProtectNotice	= false;	// Advertise to the whole server someone
						// is trying a crash
$KingPref::CrashProtectCount	= 15;		// number of tags that triggers a 'crash'

//
// Counter Script
//
// Counts paintball kills, HeadShots, and gives life stats on deaths.
//
$KingPref::Counter		= true;		// Enable Counter
$KingPref::Counter_Advertise	= true;		// Advertise kill stats
$KingPref::Counter_KeepTotals	= true;		// Keep kill totals past mission end
$KingPref::Counter_Sounds	= true;		// use sounds on kills?
$KingPref::Counter_SayNS	= false;	// Compliment someone on their HeadShot
$KingPref::Counter_SayHS	= true;		// Announce when you get HeadShot

// 
// Time HUD
// 
// Use military time or not? I personally like Military time (24 hours, not 12), but if
// you want 1-12am and 1-12pm, you can disable it.
// 
$KingPref::TimeHUD_Military	= true;