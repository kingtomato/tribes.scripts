// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Version	= "1.0";
$Script::Creator	= "KingTomato";
$Script::Description	= "Makes configuring a HUD much easier ;d";

//
// King::HUD::Default(%hud, %enabled, %x, %y, %w, %h)
// 
// Creates the default $King::HUD values with one call. Fill the neccesary
// variables, and leaves the rest empty. Also, only sets the value if it's not
// set, as to keep previous values.
//
function King::HUD::Default(%hud, %enabled, %valx, %valy, %valw, %valh)
{
	if ($King::HUD[%hud, On] == "")
		$King::HUD[%hud, On] = %enabled;

	%info = "X Y W H";
	for (%i = 0; (%what = getWord(%info, %i)) != -1; %i++)
		if (%val[%what] != "")
			if ($King::HUD[%hud, %what] == "")
				$King::HUD[%hud, %what] = %val[%what];
}