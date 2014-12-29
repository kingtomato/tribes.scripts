// ----------------------------------------------------------------------------
// KingTomato Script
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Simple juggler script, to show off. You can also type "
			@ "and juggle!";

Command::Add("!juggle", KingTomato::Command::Juggle);
function KingTomato::Command::Juggle(%cmd, %param) {
	$KingTomato::Juggle = !$KingTomato::Juggle;
	if ($KingTomato::Juggle)
		KingTomato::Juggle();
}

Command::Add("!repjuggle", KingTomato::Command::RepJuggle);
function KingTomato::Command::RepJuggle(%command, %param) {
	$KingTomato::JuggleRep = !$KingTomato::JuggleRep;
}

// -----------------------------------
// Wepaon\Ammo Juggle
// -----------------------------------

$KingTomato::Juggle	= False;
$KingTomato::lookingUp	= False;
function KingTomato::Juggle() {
	if ($KingTomato::Juggle) {
		if (!$KingTomato::lookingUp) {
			postAction(2048, IDACTION_LOOKUP, 5.0);
			schedule("postAction(2048, IDACTION_LOOKUP, 0.0);", 0.2);
			schedule("KingTomato::juggle();", 0.3);
			$KingTomato::lookingUp = true;
		}
		else {
			nextWeapon();
			schedule("drop(Ammo);", 0.1);
			schedule("drop(Weapon);", 0.2);
			schedule("drop(Grenade);", 0.3);
			schedule("KingTomato::juggle();", 0.4);
		}
	}
	else
		$KingTomato::lookingUp = false;
}

Event::Attach(eventClientMessage, KingTomato::JuggleMsg);
function KingTomato::JuggleMsg(%client, %msg) {
	if (%client != 0)
		return;

	if ((Match::String(%msg, "You received *")) && ($KingTomato::Juggle))
		return "mute";
}

// ------------------------------------
// Repair Pack Version
// ------------------------------------

Event::Attach(eventClientMessage, KingTomato::JuggleRep);
function KingTomato::JuggleRep(%client, %msg) {
	if (($KingTomato::JuggleRep) && (%client == 0)) {
		if (%msg == "You received a RepairPack backpack")
			drop("Repair Pack");
		return "mute";
	}
}