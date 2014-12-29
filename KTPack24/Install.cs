// ------------------------------------------------------------------------------------------------
// KingTomato Script
// ------------------------------------------------------------------------------------------------

$King::Version			 = "2.4";
$KT::Debug			 = false;	// dont worry bout this

// Presto Resolutions Missing
$Presto::screenSize["720x480"]   = "720 480";
$Presto::screenSize["720x576"]   = "720 576";
$Presto::screenSize["848x480"]   = "848 480";
$Presto::screenSize["1152x864"]  = "1152 864";
$Presto::screenSize["1280x720"]  = "1280 720";
$Presto::screenSize["1280x768"]  = "1280 768";
$Presto::screenSize["1280x960"]  = "1280 960";
$Presto::screenSize["1280x1024"] = "1280 1024";
$Presto::screenSize["1360x768"]  = "1360 768";
$Presto::screenSize["1600x900"]  = "1600 900";
$Presto::screenSize["1600x1024"] = "1600 1024";
$Presto::screenSize["1600x1200"] = "1600 1200";

$King::Beta			 = false;	// No need to change this, won't give
						// you special features or anything

// ------------------------------------------------------------------------------------------------
// Preferences

// 
// This will handle callbacks to the prefs I have set. If its null, or filled with something
// other than false, assume true. >:P
// 
function KingPref::Enabled(%setting)
{
	if ($KingPref::[%setting] == "")
		$KingPref::[%option] = false;
	if ($KingPref::[%setting] != false)
		return true;
	return false;
}

// ------------------------------------------------------------------------------------------------
// Last Hope Checker

function King::LastHope()
{
	return (getWord(timestamp(),3) != "2000");
}

// ------------------------------------------------------------------------------------------------
// Auto Loader

//
// Loads the file in the kingtomato directory, according to the order of their presidence.
// please read SCRIPTORS.TXT under the "File Names" heading for more information.
//
function King::Install::Install()
{
	// Load Settings
	if (isFile("config\\King_Settings.cs"))
		exec("King_Settings.cs");

	// Load up preferences file
	exec("KingTomato\\KingPrefs.skip.cs");	// Moved down to avoid the prefs bug

	// Load default values
	exec("KingTomato\\Defaults.skip.cs");

	if (KingPref::Enabled(Logging))
		$Console::LogMode = 1;

	if ((KingPref::Enabled(NudeWalls)) && (!isObject("WallsVolume")))
		newObject(WallsVolume, SimVolume, "KingTomato\\vols\\NudeWalls.vol");
	else if ((!KingPref::Enabled(NudeWalls)) && (isObject("WallsVolume")))
		deleteObject("WallsVolume");

	if ((KingPref::Enabled(RedWalls)) && (!isObject("CounterVolume")))
		newObject(ForceFieldVolume, SimVolume, "KingTomato\\vols\\RedForceFields.vol");
	else if ((!KingPref::Enabled(RedWalls)) && (isObject("RedForceFields")))
		deleteObject("RedForceFields");

	$King::Install::Count[System]	= 0;
	$King::Install::Count[Scripts]	= 0;

	// This File
	%this = "KingTomato\\*nstall.cs";

	if ($KT::Debug)
		echo("Loading Volumes");

	// Volumes
	for (%file = File::FindFirst("KingTomato\\*.vol"); %file != ""; %file = File::FindNext("KingTomato\\*.vol"))
	{
		// Add To List
		$KingTomato::Load::Volume[%vol++] = %file;

		// Register Volume
		%base = File::getBase(File::getBase(%file));
		EvalSearchPath::addVol(%base, %file);
		newObject(%base, SimVolume, %file);

		// Increse Counter
		%count[Volume]++;
	}

	if ($KT::Debug)
		echo("Loading .sys.cs");

	// System Files
	for (%file = File::FindFirst("KingTomato\\*.sys.cs"); %file != ""; %file = File::FindNext("KingTomato\\*.sys.cs"))
	{
		exec(%file);

		King::Install::AddFile(%file, System, $Script::Creator, $Script::Version, $Script::Description, $Script::MinVersion);

		deleteVariables("$Script::*");
	}

	if ($KT::Debug)
		echo("Loading .cs");

	// Other Scripts
	for (%file = File::FindFirst("KingTomato\\*.cs"); %file != ""; %file = File::FindNext("KingTomato\\*.cs"))
	{
		// To avoid an infinite loop, and loading files both already loaded, and
		// never to be loaded, we will check what kind of file we have. By testing
		// its not this file, we avoid an infitie loop, and stop the program from
		// Loading this file, which loads itself again, and again, etc.  Also,
		// We make sure its not an already loaded sys file, or isn't intended to be
		// skipped (.skip.cs).
		if (!Match::String(%file, %this) && !Match::String(%file, "*.sys.cs") && !Match::String(%file, "*.skip.cs"))
		{
			// Load File
			exec(%file);

			King::Install::AddFile(%file, Script, $Script::Creator, $Script::Version, $Script::Description, $Script::MinVersion);

			deleteVariables("$Script::*");	
		}
	}

	King::Install::Output();

	deleteVariables("$King::Install*");
}

//
// Add files to array
//
function King::Install::AddFile(%file, %type, %creator, %version, %description, %minVer)
{
	%count = $King::Install::count[%type]++;

	// Check for empty values, and fill them
	if (%creator == "") %creator = "unknown Author";
	if (%version == "") %version = "?.??";
	if (%description == "") %description = "No description given for this item";

	$King::Install::File[%count, file]        = %file;
	$King::Install::File[%count, creator]     = %creator;
	$King::Install::File[%count, version]     = %version;
	$King::Install::File[%count, description] = %description;

	if ((%minVer != "") && (%minVer > $King::Version))
		$King::Install::File[%count, fail] = %minVer;

	if ($KT::Debug)
		echo("Adding File: " @ %file @ " to load list");
}

// 
// Output Installed Scripts
// 
function King::Install::Output()
{
	%failed = "";

	if (!$KT::Debug)
		cls();

	echo("// --------------------------------------------------------------------------------");
	echo("// KingTomato Script");
	echo("// Version " @ $King::Version);
	echo("// --");
	echo("// Presto... Detected (" @ $Presto::Version @ ")");
	echo("// NewOpts... Detected (" @ $NewOpts::Version @ ")");
	echo("// --");
	echo("// Script Files Installed: " @ $King::Install::count[Script]);
	echo("// --------------------------------------------------------------------------------");
	echo("//");

	for (%a = 1; $King::Install::File[%a, file] != ""; %a++)
	{
		%file    = $King::Install::File[%a, file];
		%creator = $King::Install::File[%a, creator];
		%version = $King::Install::File[%a, version];
		%desc    = $King::Install::File[%a, description];
		%minVer  = $King::Install::File[%a, fail];

		if (%minVer != "")
			%failed = %failed @ %a @ " ";

		echo("// " @ File::getBase(%file) @ " (By: " @ %creator @ ", v" @ %version @ ")");

		%words	= "";
		for (%b = 0; %b < String::GetWordCount(%desc); %b++) {
			%word = getWord(%desc, %b);
			%temp = %words @ %word @ " ";
			if (String::Len(%temp) <= 85)
				%words = %words @ %word @ " ";
			else {
				echo("//    " @ %words);
				%words = %word;
			}
		}
		echo("//    " @ %words);
		echo("//");
	}

	if (%failed != "")
	{
		echo("// --------------------------------------------------------------------------------");
		echo("// Warning:");
		echo("//    Some files did not load correctly.");
		echo("//    These files include:");
		echo("// --------------------------------------------------------------------------------");
		echo("//");

		for (%a = 0; (%i = getWord(%failed, %a)) != -1; %a++)
		{
			%file    = $King::Install::File[%i, file];
			%minVer  = $King::Install::File[%i, fail];

			echo("// " @ File::getBase(%file));
			echo("//    File requires KingTomato Pack v" @ %minVer @ " or later");
			echo("//");
		}
		
	}


	echo("// --------------------------------------------------------------------------------");
	echo("// Installation Complete");
	echo("// --------------------------------------------------------------------------------");	
}

if (($Presto::Version != "0.93") || ($NewOpts::version != "0.966"))
{
	echo ("KingTomato Script Pack Error");
	echo ("-");
	echo ("Presto Pack missing or invalid version");
	echo ("NewOpts missing or invalid version");
	echo ("");
	echo ("Please be sure you have Presto Pack 0.93 & NewOpts 0.966");
	echo ("");
	echo ("Preso Version: " @ $Presto::Version);
	echo ("newOpts Version: " @ $newOpts::Version);
}
else
{
	King::Install::Install();

	Event::Attach(eventConnectionAccepted, King::Install::Advertise);
}

function King::Install::Advertise()
{
	//	%1 - Player Name
	//	%2 - version number
	//	%3 - current tribes ver
	//	%4 - advertisement
	//	%5 - "LastHope"/"Tribes"

	if ((%msg = $KingPref::AdMessage) == "")
		%msg = "I am using KingTomato Pack v%2.%3! %4";

	if (KingPref::Enabled(Advertise))
	{
		if ($King::Beta)
			%ad = "Coming soon to www.KingTomato.org";
		else
			%ad = "Get yours at www.KingTomato.org";

		if (King::LastHope())
			%five = "LastHope";
		else
			%five = "Tribes";

		%msg = sprintf(%msg, $PCFG::Name, $King::Version, version(), %ad, %five);

		say(0, %msg);
	}
}