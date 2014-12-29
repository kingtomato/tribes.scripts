// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

// Use the file to export the size and postion of all your HUDs. Very handy
// for people who are using kt pack v2.3 or earlier, and want to change to
// version 2.4 Now you can save your HUD info, then put it back in the
// newOpts screen and get all your info back.

// Directions:
// 1. Put this in your tribes\config directory.
// 2. Open tribes
// 3. Join a server (wait until you can see the HUDs)
// 4. Open console ( ~ )
// 5. Type: exec(ExportHUDPos);
// 6. Close tribes
// 7. Open tribes\config\HUD_Settings.cs

// Now you can either print this file out (so you can reference it with
// the NewOps page easier), alt+tab back and forth in tribes and fill
// in the values, or get a pen and paper and repeat the info on to paper
// so you can simulate the first idea. Your choice. I'd personally prefer
// the first option. ;)

function exportHUDInfo()
{
	// Prep the settings file
	%setting_file = "config\\HUD_Info.txt";
	newObject(HUDSettings, FearGuiFormattedText, 0, 0, 0, 0);
	flushExportText();
	addExportText("// ^^ Ignore above lines");
	addExportText("");

	addExportText("// -----------------------------------------------");
	addExportText("// HUD Settings - Exported By KingTomato");
	addExportText("// --");
	addExportText("// Below are a list of every HUD installed that is");
	addExportText("// visible from the playing screen. Use the below");
	addExportText("// numbers to configure your HUDs from the NewOpts");
	addExportText("// page in KT Pack v2.4");
	addExportText("// -----------------------------------------------");
	addExportText("");

	// Go through the list of HUDS
	for (%h = 0; (%hud = $HUD::Name[%h]) != ""; %h++)
	{
		%info = HUD::GEtPosition(%hud);

		addExportText("// -----------------------------------------------");
		addExportText("HUD #" @ %h @ ": " @ %hud);
		ADDeXPORTtEXT("  Displayed?: " @ HUD::GetDisplayed(%hud));
		addExportText("  Position (X, Y): " @ getWord(%info,0) @ ", " @ getWord(%info,1));
		addExportText("  Size (Width, Height): " @ getWord(%info,2) @ ", " @ getWord(%info,3));
		addExportText("");
	}

	// Finish file
	exportObjectToScript(HUDSettings, "config\\HUD_Settings.cs", true);

	// Remove object
	deleteObject(nameToID(HUDSettings));
	flushExportText();

	echo("Settings saved to tribes\\config\\HUD_Settings.cs");
}

exportHUDInfo();