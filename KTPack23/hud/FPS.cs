// ------------------------------------------------------------------------------------------------
// Show Frames Per Second
// ------------------------------------------------------------------------------------------------

$Script::Creator	= "KingTomato";
$Script::Version	= "1.0";
$Script::Description	= "Simple Frames Per Second HUD designed to just give you a less memory "
			@ "intensive version that showFPS();";

function King::FPS::Update(%hud) {
	HUD::AddTextLine(%hud, "<f1><jl>" @ floor($ConsoleWorld::FrameRate) @ "<f0>fps" );
	return 0.5;
}

function King::FPS::Init() {
	%hud = ktFPSHud;
	HUD::New(%hud, King::FPS::Update, $KingPref::FPSHud_Pos @ " 50 15");
	HUD::Display(%hud, true);
}

if (KingPref::Enabled(FPSHud))
	King::FPS::Init();