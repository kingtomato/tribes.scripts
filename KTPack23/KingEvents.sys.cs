// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
//
// Summary:
//
//	Because I didn't have ALL *grin* the events I wanted to have with presto pack, I added a
//	few more. You can find the syntax to use them below. These events include some like
//	eventBottomPrint, eventTopPrint, eventCenterPrint, (All useful to retrieve a current
//	weapon).  Additionally, you can catch menu text (as in TAB menu).  Very cool for things
//	like hacking admin :P
// 
// Events:
// 	eventCenterPrint(%msg, %timeout);
//	eventBottomPrint(%msg, %timeout);
//	eventTopPrint(%msg, %timeout);
//		Returns the print message with the message and the time to be shown for.
//	eventClientInput(%team, %msg);
//		This event triggers when the user types something into the chat or team chat box. You
//		can then parse the message how ever you want, inclusing returning mute to stop the
//		displaying of the message.
//	eventNewMenu(%menuTitle)
//		Triggers when the tab menu is either opened, or the menu changes (due to item
//		selection, or what ever)
//	eventAddMenuItem(%menuItem, %menuCommand)
//		Triggers when an item is added to the menu. Each 5menuItem will be in the form of
//		something like "1Change Teams Observer" with a %menuCommand of something like
//		"changeteams"
//	eventInfoLine(%line, %text)
//		Triggers when a line in the bottom right box of the tab menu is set or updated
//	eventVote(%vote)
//		Triggers when the user votes one way or the other. %vote will be passed as either
//		yes or no.
//	eventModInfo(%version, %name, %mod, %info, %favKey)
//		Triggers on a connection, and will return the information sent from the server
//		about itself. Will pass the following information:
//		%version - Version of server (ex: 1.11)
//		%name    - Server name
//		%mod     - Server mod
//		%info    - Server Info
//		%favKey  - Name of the key used to mark favorites.
//	eventTime(%seconds)
//		This will trigger every time the server sends an "update time" message to
//		the client. This usually occurs every 20 seconds on a map with a time limit,
//		and will return a negative number (negative sybmolising time left).
//		%seconds - Number of seconds on map.
//
// -----------------------------------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.4";
$Script::Description = 	"Extended events library designed to include bottomPrint, topPrint, centerPrint, "
			@ "Input Commands, Bot Commands, and more! Please read file for more information";

// -----------------------------------------------------------------------------------------------------
// 	eventCenterPrint(%msg, %timeout);
//	eventBottomPrint(%msg, %timeout);
//	eventTopPrint(%msg, %timeout);
//		Returns the print message with the message and the time to be shown for.
// -----------------------------------------------------------------------------------------------------

function remoteCP(%manager, %msg, %timeout) {
	if (%manager == 2048) {
		$centerPrintId++;
		if (%timeout)
			schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
		Client::centerPrint(%msg, 0);

		Event::Trigger(eventcenterPrint, String::DoubleSlashes(%msg), %timeout);
	}
}

function remoteBP(%manager, %msg, %timeout) {
	if (%manager == 2048) {
		$centerPrintId++;
		if (%timeout)
			schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
		Client::centerPrint(%msg, 1);

		Event::Trigger(eventBottomPrint, String::DoubleSlashes(%msg), %timeout);
	}
}

function remoteTP(%manager, %msg, %timeout) {
	if (%manager == 2048) {
		$centerPrintId++;
		if (%timeout)
			schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
		Client::centerPrint(%msg, 2);

		Event::Trigger(eventTopPrint, String::DoubleSlashes(%msg), %timeout);
	}
}

// ------------------------------------------------------------------------------------------------
//	eventClientInput(%team, %message)
//		This event triggers when the user types something into the chat or team chat box. You
//		can then parse the message how ever you want, inclusing returning mute to stop the
//		displaying of the message.
// ------------------------------------------------------------------------------------------------

function say(%team, %msg) {
	%returns = Event::Trigger(eventClientInput, %team, %msg);

	if (Event::Returned(%returns, mute))
		return;

	%msg = Acronym::Replace(%msg);

	// Flood Protect Addition
	if ($FloodProtect::Enabled)
	{
		%timeNow = getIntegerTime(false) >> 5;
		%delta = $FloodProtect::Time - %timeNow;
		remoteBP(2048, "<jc><f2>-Flood Protection Enabled-\n"
				@"To prevent further delay, your message "
				@"has been stopped until the flood limit is reached.\n\n"
				@"Time up in <f0>" @ %delta @ "<f2> seconds", 10);
		return;
	}
	// End Flood Protect Addition

	remoteEval(2048, say, %team, %msg);
}

// ------------------------------------------------------------------------------------------------
//	eventInventoryText(%text)
//		When the inventory text is altered
// ------------------------------------------------------------------------------------------------

function remoteITXT(%manager, %msg) {
	if(%manager == 2048)
		Control::setValue(EnergyDisplayText, %msg);
}

// ------------------------------------------------------------------------------------------------
//	eventNewMenu(%menuTitle)
//		Triggers when the tab menu is either opened, or the menu changes (due to item
//		selection, or what ever)
// ------------------------------------------------------------------------------------------------

function remoteNewMenu(%server, %title)
{
	if(%server != 2048)
		return;

	if(isObject(CurServerMenu))
		deleteObject(CurServerMenu);

	newObject(CurServerMenu, ChatMenu, %title);
	setCMMode(PlayChatMenu, 0);
	setCMMode(CurServerMenu, 1);

	Event::Trigger(eventNewMenu, %title);
}

// ------------------------------------------------------------------------------------------------
//	eventAddMenuItem(%menuItem, %menuCommand)
//		Triggers when an item is added to the menu. Each 5menuItem will be in the form of
//		something like "1Change Teams Observer" with a %menuCommand of something like
//		"changeteams"
// ------------------------------------------------------------------------------------------------

function remoteAddMenuItem(%server, %title, %code)
{
	if(%server != 2048)
		return;

	addCMCommand(CurServerMenu, %title, clientMenuSelect, %code);

	Event::Trigger(eventAddMenuItem, %title, %code);
}

// ------------------------------------------------------------------------------------------------
//	eventInfoLine(%line, %text)
//		Triggers when a line in the bottom right box of the tab menu is set or updated
// ------------------------------------------------------------------------------------------------

function remoteSetInfoLine(%mgr, %lineNum, %text)
{
	if(%mgr != 2048)
		return;

	if (%lineNum == 1)
	{
		if (%text == "")
			Control::setVisible(InfoCtrlBox, FALSE);
		else
			Control::setVisible(InfoCtrlBox, TRUE);
	}

	Control::setText("InfoCtrlLine" @ %lineNum, %text);

	Event::Trigger(eventInfoLine, %lineNum, %text);
}

// ------------------------------------------------------------------------------------------------
//	eventVote(%vote)
//		Triggers when the user votes one way or the other. %vote will be passed as either
//		yes or no.
// ------------------------------------------------------------------------------------------------

function voteYes()
{
	remoteEval(2048, VoteYes);
	Event::Trigger(eventVote, yes);
}

function voteNo()
{
	remoteEval(2048, VoteNo);
	Event::Trigger(eventVote, no);
}

// ------------------------------------------------------------------------------------------------
//	eventModInfo(%version, %name, %mod, %info, %favKey)
//		Triggers on a connection, and will return the information sent from the server
//		about itself. Will pass the following information:
//		%version - Version of server (ex: 1.11)
//		%name    - Server name
//		%mod     - Server mod
//		%info    - Server Info
//		%favKey  - Name of the key used to mark favorites.
// ------------------------------------------------------------------------------------------------
function remoteSVInfo(%server, %version, %hostname, %mod, %info, %favKey)
{
	if(%server == 2048)
	{
		$ServerVersion = %version;
		$ServerName = %hostname;
		$modList = %mod;
		$ServerMod = $modList;
		$ServerInfo = %info;
		$ServerFavoritesKey = %favKey;
		EvalSearchPath();

		Event::Trigger(eventModInfo, %version, %name, %mod, %info, %favKey);
	}
}

// ------------------------------------------------------------------------------------------------
//	eventTime(%seconds)
//		This will trigger every time the server sends an "update time" message to
//		the client. This usually occurs every 20 seconds on a map with a time limit,
//		and will return a negative number (negative sybmolising time left).
//		%seconds - Number of seconds on map.
// ------------------------------------------------------------------------------------------------

function remoteSetTime(%server, %time)
{
	if(%server == 2048)
	{
		setHudTimer(%time);
		Event::Trigger(eventTime, %time);
	}
}