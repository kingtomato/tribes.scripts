// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Description = "Loads Counter Configurations GUI";

// ----------------------------------------------------------------------------
// Acronyms Gui
// ----------------------------------------------------------------------------

NewOpts::register(
	"KingTomato - Settings",
	"KingTomato\\gui\\KTSettings.gui",
	"King::Gui::Init(Settings);",
	"King::Gui::Close(Settings);",
	true
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"General Help",
	"Here are some general settings you can play with to customize " @
	"your game. Please see the below headings for more information on " @
	"what each setting will do."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Confirm quit",
	"Asks you if you are sure you want to quit tribes before leaving."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Filter out swears",
	"Transforms swear words into #@$$@ in game."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Ignore no internet warning.",
	"When refreshing the master servers without internet access, a wanring " @
	"will appear. This option suppresses this warning."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Quick start",
	"Skip the main menu, and enter play mode."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Skip intor movie",
	"Skips the beginning Dynamix animation."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Do not enter inventory",
	"Handy if you want to go in and out of inventory and just buy favs. I " @
	"tend to play with this on, and use the key 'i' when I need to enter " @
	"the inventory."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Do not cloak items",
	"Removed OpenGL's ability to cloak (make invisible) items. Handy on the " @
	"Hybrid mod when enemies spawn invisible."
);

NewOpts::registerHelp(
	"KingTomato - Settings",
	"Enable player shadows",
	"Enabled the shadow of players in the game."
);

