// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Description = "Loads Acronyms GUi";

// ----------------------------------------------------------------------------
// Acronyms Gui
// ----------------------------------------------------------------------------

NewOpts::register(
	"KingTomato - Acronyms",
	"KingTomato\\gui\\KTAcronyms.gui",
	"King::Gui::Init(Acronyms);",
	"King::Gui::Close(Acronyms);",
	true
);

NewOpts::registerHelp(
	"KingTomato - Acronyms",
	"General Help",
	"Use this page to set various aspects of your acronym script. The first " @
	"checkbox enables you to toggle the script itself. The text field below it " @ 
	"allows you to alter the style of the replaces acronym. For help on how to " @
	"change the style, see \"Style Help\" below. The last section of the dialog " @
	"is to make it easier for you to add/remove acronyms from the script."
);
NewOpts::registerHelp(
	"KingTomato - Acronyms",
	"Style Help",
	"The style field is to change how your acronym appears when it is displayed. " @
	"use the tag <<ACRO> in place of the replaced acronym, and put any other " @
	"character(s) around it."
);
NewOpts::registerHelp(
	"KingTomato - Acronyms",
	"Adding Acronyms",
	"To add an acronym, just fill in the acronym and meaning field, then press add. " @
	"The list of acronyms will then update itself and add your new acronym to the list."
);
