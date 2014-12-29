// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Description = "Loads friends GUI";

// ----------------------------------------------------------------------------
// Friends Gui
// ----------------------------------------------------------------------------

NewOpts::register(
	"KingTomato - Friends",
	"KingTomato\\gui\\KTFriends.gui",
	"King::Gui::Init(Friends);",
	"King::Gui::Close(Friends);",
	true
);

NewOpts::registerHelp(
	"KingTomato - Friends",
	"Overview",
	"This is a cool friend tracker that does some of the \"friendly\" tasks you " @
	"might do. For instance, if a friend is voting for something, you would vote " @
	"for it automatically. Likewise, if they are the victim of a vote to kick, you " @
	"vote against it. I Find it handy, as it keeps me from having to look at the " @
	"votes so I can keep my mind on the game."
);

NewOpts::registerHelp(
	"KingTomato - Friends",
	"Adding Friends",
	"To add a friend to your list, enter their name into the blank field, then press " @
	"the add button. Their name will then be added to the dropdown to show it has been " @
	"successful."
);

NewOpts::registerHelp(
	"KingTomato - Friends",
	"Removing Friends",
	"To remove a friend, click their name from the drop down menu, and press the delete " @
	"button."
);
