// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Description = "Loads general GUI";

// ----------------------------------------------------------------------------
// General Options Gui
// ----------------------------------------------------------------------------

NewOpts::register(
	"KingTomato - General",
	"KingTomato\\gui\\KTGeneral.gui",
	"King::Gui::Init(General);",
	"King::Gui::Close(General);",
	true
);

NewOpts::registerHelp(
	"KingTomato - General",
	"General Help",
	"Thank you for using KingTomato Pack!\n\n" @
	"This NewOpts page is designed to make customizing the pack easier on " @
	"the end user (you). Using the blow checkboxes, select which items you " @
	"would like enabled or not. Please note that some options may require " @
	"tribes to restart for the changes to take effect. These items are noted " @
	"with (requires restart) next to them."
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Advertisement Message",
	"Since I am such a nice guy, I am giving you the ability to customize what " @
	"you would like to have in your advertisement message, or even if you want " @
	"to advertise. The advertisement message is simple, and basically follows a " @
	"template. Within the advertisement, you can use a serious of replacers. " @
	"These replacers (when used in text) will be changed with their real meaning " @
	"when you advertise. Below are a list of those replacers, and their meanings"
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Replacers",
	"%1 - Current Nickname\n" @
	"%2 - Pack Version (example: 2.4)\n" @
	"%3 - Tribes version (example: 1.11)\n" @
	"%4 - Web site advertisment\n" @
	"%5 - Returns \"Tribes\" or \"LastHope\" (depending on which you are running)\n\n" @
	"That's it! I might add more later, but until then, that's what you have to " @
	" work with."
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Automatic SAD Login",
	"This will enable you to automatically login with your SAD password apon joining a " @
	"server. To set it, type \"!setsad\" followed by your password.
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Nude Walls",
	"This will enable and disable the use of nude walls. The bug of it not toggling should " @
	"be fixed. Unfortunatly, Tribes still requires you to restart the game between enabling " @
	"and disabling the feature."
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Red Force Fields",
	"Changes force fields to a red tink, rather than the traditional blue. A new look and " @
	"feel is nice. This however also requires Tribes to be restarted before changes take " @
	"effect."
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Prevent Out Of Bounds (OOB) Beep",
	"This will remove the three OOB beeps, and give you no wanring at all. You can also " @
	"enable the feature just below that will make the words \"You have left the mission area.\" " @
	"appear on your screen in white letters. Just remember, they don't disappear when you reenter."
);

NewOpts::registerHelp(
	"KingTomato - General",
	"Enable Console Logging",
	"Warning: Files can get large\n" @
	"This will enable console logging to a file named console.log in your tribes directory. " @
	"This can be helpful if you want to remember a conversation, or Tribes keeps crashing " @
	"before you can open the console, and you want to see what went wrong."
);