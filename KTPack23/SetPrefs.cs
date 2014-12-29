// ------------------------------------------------------------------------------------------------
// KingTomato Script
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// File information
$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Loads the settings I personally prefer when I run tribes. These settings "
			@ "can also be undone, by simple settings the $KingPref::UseMySettings "
			@ "variable back to FALSE.  Additional tweaking can be done from this file "
			@ "(SetPrefs.cs) itself.";

// 
// This will read the old prefs, save them, and remove the file they were saved in
// 
function King::SetPrefs::Restore()
{
	exec("King_UserPrefs.cs");
	File::Delete("King_UserPrefs.cs");
}

// 
// Responsible for backing up current user preferences, and saving them to a file in
// the temp dir.
// 
function King::SetPrefs::Backup()
{
	%file = "config\\King_UserPrefs.cs";

	if (isFile(%file))
		File::Delete(%file);

	export("$pref::ConfirmQuit",		%file, false);
	export("$pref::filterBadWords",		%file, true);
	export("$pref::ignoreInternetWarning",	%file, true);
	export("$pref::LagTimeout",		%file, true);
	export("$pref::pingTimeoutTime",	%file, true);
	export("$pref::requestTimeoutTime",	%file, true);
	export("$pref::quickstart",		%file, true);
	export("$pref::shadowDetailMask",	%file, true);
	export("$pref::shadowDetailScale",	%file, true);
	export("$pref::skipIntro",		%file, true);
	export("$pref::SniperCrosshair",	%file, true);
	export("$pref::noEnterInvStation",	%file, true);
	export("$pref::OpenGL::NoAddFade",	%file, true);
}

if (KingPref::Enabled(UseMyPrefs))
{

	if (!isFile("temp\\King_UserPrefs.cs"))
		King::SetPrefs::Backup();

	// 
	// Confirm Quit
	// 
	// This will stop tribes from asking "Do you want to quit" when you click to exit. I personall
	// hate this. I've never had the occasion to "Accidentally" wonder to the top right corner and
	// click quit--have you?
	// 
	$pref::ConfirmQuit		= "FALSE";

	// 
	// Filter Bad Words
	// 
	// With this enabled, swears in the game become #$@#$ so you can't read them.  Yea, this is okay
	// if I'm 3, but definatly not cool now.  I think I'm grown up enough to swear, and be able to
	// read what I just typed. >:D
	// 
	$pref::filterBadWords		= "FALSE";

	// 
	// Ignore Internet Warning
	// 
	// This is that message that pops up when you click to refresh all. I'm intelligent enough to
	// know when I don't have internet. Maybe it's the servers not pinging, but somethign always
	// seems to give me the hint.
	// 
	$pref::ignoreInternetWarning	= "TRUE";

	// 
	// Lag Timeout Time
	// 
	// I like to give myself enough time t be able to decide if I want to wait it out, or have
	// tribes disconnect me.  With this set, you can do that.
	// 
	$pref::LagTimeout		= "2500";

	// 
	// Timeouts
	// 
	// The below timeouts are for when you are in the query list.  I hate sitting there and
	// waiting for the reply long, so I set these to a short timeout.  You may want them
	// longer.  The way I look at it, if it takes that long to ping the server, I'm not
	// sure I want to be on it.
	// 
	$pref::pingTimeoutTime		= "500";
	$pref::requestTimeoutTime	= "500";

	// 
	// Quick Start
	// 
	// This will force tribes to go right to the server list when you start the game up.
	// I actually like this, but the problem was it automatically queried the server too.
	// It's your decision to use it, but I don't like to query the game servers when I
	// startup, because it takes too long, and the majority of the time I have the ones
	// i frequent fav'd.
	// 
	$pref::quickstart		= "FALSE";

	// 
	// Player Shadowing
	//
	// This is a very cool feature that I found almost hidden in tribes.  All the demos you
	// saw when the game first came out had this enabled.  Thiscan be a framerate hog, but
	// I prefer it.  Additionally, for the first few days you think that the shadow on the
	// ground is a play, but you get used to it.
	// 
	$pref::shadowDetailMask		= "1";
	$pref::shadowDetailScale	= "1.000000";

	// 
	// Skip Intro
	// 
	// This will force tribes to immediatly start up, and not play the dynamix logo at
	// the beginning.  I know who the game is made by already, now will ya let me play
	// it? >:P
	// 
	$pref::skipIntro		= "TRUE";

	// 
	// Sniper Crosshair
	// 
	// This thing pisses me off really bad.  Anything that takes that mush visibility off
	// my screen has to go.
	// 
	$pref::SniperCrosshair		= "FALSE";

	//
	// Dont enter inventory
	//
	// This will make it so the inventory screen dos not appear when you enter the station.
	// Personally, I find it much nicer to be able to go in and out of the station in a
	// second or two, then to have to close the screen, then walk.
	//
	$pref::noEnterInvStation	= "TRUE";

	// 
	// Remove Cloaking on OpenGL
	//
	// Removed the ability of people being able to cloak, or objects being cloaked while in
	// openGL.
	//

	$pref::OpenGL::NoAddFade	= "TRUE";

}

// They dont want the prefs set
// Now we make sure there isn't a backed up version in the temp dir.  Basically,
// they might have set it true, decided they dont like it, then set it false. At
// this point we look for old prefs, set them, and then delete the file
else if (isFile("config\\King_UserPrefs.cs"))
	King::SetPrefs::Restore();