// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Simple Frames Per Second HUD designed to just give you a less memory "
			@ "intensive version that showFPS();";

// ----------------------------------------------------------------------------
// HUD Information
// -- 
// Don't change this, use the NewOpts page

King::HUD::Default(FPS, true, 220, 0, 50);

// ----------------------------------------------------------------------------
// FPS Hud

function King::FPS::Make() {
	%hud = kt_FPS;
	%xywh = sprintf("%1 %2 %3 15", $King::Hud[FPS, X], $King::Hud[FPS, Y], $King::Hud[FPS, W]);
	HUD::New(%hud, King::FPS::Update, %xywh);

	if ($King::HUD[FPS, On])
		HUD::Display(%hud, true);
}

function King::FPS::Update(%hud) {
	HUD::AddTextLine(%hud, "<f1><jl>" @ floor($ConsoleWorld::FrameRate) @ "<f0>fps" );
	return 0.5;
}

King::FPS::Make();