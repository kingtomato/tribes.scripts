// ------------------------------------------------------------------------------------------------
// KingTomato Script
// --
//
// Summary:
//
// 	The idea of this is to make it so you can incorperate both client side, and server side
//	commands for you (and others) to use.  Basically, you use Command::Add for your commands
//	(that you press t or y to type in, and execute), or use BotCmd::Add for commands others in
//	the server can use.
//
//	The %command parameter in both, uses a Match::String() match type.  Which means you can use
//	wildcards. The limitation is you can only use one wildcard.  But, that wildcard you use will
//	have the matched value passed back through %parameters making it possible to parse such
//	commands.
//
// --
//
// Commands:
//
//	Command::Add(%command, %parameters);
//		Add command to user's input.
//		Ex:
//			Command::Add("!help", KingTomato::Help);
//			function KingTomato::Help(%cmd, %params)
//			{
//				say(0, "I just typed the !help command!");
//				return "mute"; // stop it from being said to server
//			}
//
//	BotCmd::Add(%command, %parameters);
//		Add a command to another client's text.  Can be used for having such things as
//		bots or global functions.
//		Ex:
//			BotCmd::Add("!say *", Bot::Say);
//			function Bot::Say(%client, %cmd, %parameters)
//			{
//				say(0, "Someone in the server wants me to say: " @ %parameters);
//			}
//
// ------------------------------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.3";
$Script::Description	= "This script allows the ability to attach bot command files and other "
			@ "input commands to a trigger.  The commands are attached, and searched "
			@ "for in messages.  If found, they will execute the function associated "
			@ "with the command.";

// Variables
$Command::Count		= 0;
$BotCmd::Count		= 0;
$BotCmd::IncludeMe	= false; // moved--only scripters need to change this anyways

// ------------------------------------------------------------------------------------------------
// Client Text (You typing it in chat box)

function Command::Add(%command, %function) {
	// Look for duplicate commands.  If one thats being added is already in the list,
	// update the function being called.
	%match = 0;
	for (%a = 1; %a <= $Command::Count; %a++) {
		if (Match::String($Command::List[%a, commd], %command, "`")) {
			%match = %a;
			$Command::List[%a, func] = %function;
			break;
		}
	}

	// No previous event was found, add a new one
	if (%match == 0) {
		$Command::Count++;
		$Command::List[$Command::Count, commd] = %command;
		$Command::List[$Command::Count, func] = %function;
	}
}

Event::Attach(eventClientInput, Command::Parse);
function Command::Parse(%team, %msg) {
	// Search for a matching command
	for (%a = 1; %a <= $Command::Count; %a++) {
		%cmd = $Command::List[%a, commd];
		%func = $Command::List[%a, func];
		// Matched Function
		if (Match::String(%msg, %cmd)) {
			// Call the function they want to call
			eval(%func @ "(\"" @ %cmd @ "\", \"" @ Match::Result(0) @ "\");");
			// don't say the command
			return "mute";
		}
	}
}

// ------------------------------------------------------------------------------------------------
// Client Input From Users In The Game

function BotCmd::Add(%command, %function) {
	// Look for duplicate commands.  If one thats being added is already in the list,
	// update the function being called.
	%match = 0;
	for (%a = 1; %a <= $BotCmd::Count; %a++) {
		if (Match::String($BotCmd::List[%a, commd], %command, "`")) {
			%match = %a;
			$BotCmd::List[%a, func] = %function;
			break;
		}
	}

	// No previous event was found, add a new one
	if (%match == 0) {
		$BotCmd::Count++;
		$BotCmd::List[$BotCmd::Count, commd] = %command;
		$BotCmd::List[$BotCmd::Count, func] = %function;
	}
}

Event::Attach(eventClientMessage, BotCmd::Parse);
function BotCmd::Parse(%client, %msg) {
	// we don't want us matching it unless we are allowed to.
	if ((%client == getManagerId()) && (!$BotCmd::IncludeMe))
		return;

	// Search for a matching command
	for (%a = 1; %a <= $BotCmd::Count; %a++) {
		%cmd = $BotCmd::List[%a, commd];
		%func = $BotCmd::List[%a, func];
		// Matched Function
		if (Match::String(%msg, %cmd))
			// Call the function they want to call
			eval(%func @ "(" @ %client @ ", \"" @ %cmd @ "\", \"" @ Match::Result(0) @ "\");");
	}
}