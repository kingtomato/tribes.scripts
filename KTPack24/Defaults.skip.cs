// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "This file sets all the variables to a default value "
			@ "so the user doesn't run into any bugs. Its only (for "
			@ "the msot part) used on a new installation, or when "
			@ "the client switches versions (New values are added, "
			@ "or names of items changed).";

// ----------------------------------------------------------------------------
// Don't touch settings in this file, just use the NewOpts screens to change
// your config

// My Personal Prefs
if ($KingPref::UseMyPrefs == "")
	$KingPref::UseMyPrefs = false;

// Acronym Replacer
if ($KingPref::Acronyms == "")
{
	$KingPref::Acronyms       = true;
	$KingPref::Acronyms_Style = "-(<acro>)-";
}

// Advertise This Script
if ($KingPref::Advertise == "")
	$KingPref::Advertise = true;

// Advertisment message
if ($KingPref::AdMessage == "")
	$KingPref::AdMessage = "I am using KingTomato Pack v%2 (Tribes v%3)! %4";

// Auto SAD Login
if ($KingPref::AutoSad == "")
	$KingPref::AutoSAD = true;

// Nude Walls
if ($KingPref::NudeWalls == "")
	$KingPref::NudeWalls = false;

// Red Force Fields
if ($KingPref::RedWalls == "")
	$KingPref::RedWalls = true;

// Silent Out Of Bounds Warning
if ($KingPref::SilentOOB == "")
{
	$KingPref::SilentOOB	= true;
	$KingPref::OOBBanner	= true;
}

// Friends List
if ($KingPref::Friends == "")
{
	$KingPref::Friends	= true;
	$KingPref::Friends_Say	= false;
	$KingPref::Friends_Rvng	= false;
	$KingPref::Friends_Help	= true;
}

// Logging
if ($KingPref::Logging == "")
	$KingPref::Logging = false;