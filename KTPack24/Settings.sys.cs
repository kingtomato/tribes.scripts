// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
//
// Summary:
//
//	With the ability to change settings right from the game now a days, and the need for
//	them to be saved to a file to stick, I added this feature.  I don't know about you, but
//	hate messy folders.  Usually, with a lot of scrips loaded, you have "Seomconfig.cs",
//	"SomeotherCfg.cs", "SetitngsForThis.cs", etc in your tribes directory. By the time you
//	are done, you have 50 .cs files just for settings alone.
//
//	Well, i got tired of that.  What I did was added the ability to export all of your
//	variables (executed through this script) into one file.  Easy to load, easy to back up,
//	and most of all--organized.  All you do is, in your script file add the following:
//
//	King::Settings::Export("$MyVariables*");
//
//	Viola! All your variables with that prefix are not only going to be saved for this session,
//	but automatically executed when tribes reloads the scripts.  So simple, it puts AOL out
//	of business (Although, you shouldn't even need me to help such a definite process).
//
// ------------------------------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Simple varibale exportation system that allows for saving multiple script "
			@ "configuration settings, all into one file. Easy to back up, easy to store "
			@ " and organized.";

// ------------------------------------------------------------------------------------------------
// Scripts (Definitive) to be backed up

%exports = 0;
$King::Settings::Export[%exports++]	= "$KingPref::*";
$King::Settings::Export[%exports++]	= "$King::HUD*";
$King::Settings::Export[%exports++]	= "";

// ------------------------------------------------------------------------------------------------
// Export System

function King::Settings::Export(%var)
{
	// We don't need a complex system here, but something that has a little bit
	// of, well, debugging would be nice.
	for (%a = 1; $King::Settings::Export[%a] != ""; %a++)
	{
		if ($King::Settings::Export[%a] == %var)
			return;
	}

	$King::Settings::Export[%a] = %var;
}

// ------------------------------------------------------------------------------------------------
// Closing Save

Event::Attach(eventExit, King::Settings::ExportSave);

function King::Settings::ExportSave()
{
	%logfile = "config\\King_Settings.cs";

	$log = "Exporting settings..."; export("$log",%logFile,false);

	for (%a = 1; (%var = $King::Settings::Export[%a]) != ""; %a++)
		export(%var, %logfile, true);
}

function King::Settings::Import()
{
	// Check For Previous Settings
	if (isFile("config\\King_Settings.cs"))
	{
		exec("King_Settings.cs");
		echo("KingTomato Preferences Read");
	}

	echo("Settings Loaded");
}