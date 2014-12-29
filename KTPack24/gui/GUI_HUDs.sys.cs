// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Description = "Loads HUD mvoer GUI";

// ----------------------------------------------------------------------------
// General Options Gui
// ----------------------------------------------------------------------------

NewOpts::register(
	"KingTomato - HUDs",
	"KingTomato\\gui\\KTHuds.gui",
	"King::Gui::Init(HUDs);",
	"King::Gui::Close(HUDs);",
	true
);

NewOpts::registerHelp(
	"KingTomato - HUDs",
	"General Help",
	"The objective of this page is jsut to give you a nice clean interface " @
	"from which you may alter the postition and size of your HUDs. Here you " @
	"can make a change, apply it, then see the alteration in action immediatly. " @
	"Now you don't have to guestimate your position, close tribes, make a " @
	"change, reopen it, and check if it's right."
);
