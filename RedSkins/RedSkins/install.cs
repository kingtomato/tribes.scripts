// ----------------------------------------------------------------------------
// installation:
//
// You should just be able to extract this to your config directory, and have
// it work out fine. Make sure that when you do so, you are left with a new
// folder called "RedSkins" in C:\Dynamix\Tribes\Config (or whatever your
// directory for tribes\config is). Then, add the following line to the bottom
// of the autoexec.cs found in tribes\config:
//
// Include("RedSkins\\install.cs");
// ----------------------------------------------------------------------------

// just adds them to the volume set
// If you do not want one of the following, add "//" before the 
// line just as these comments are shown. That will prevent that from loading.
newObject(GreenSkin,	SimVolume,	"RedSkins\\greenskin.vol");
newObject(BlueSkin,	SimVolume,	"RedSkins\\blueskin.vol");
newObject(FriendFoe,	SimVolume,	"RedSkins\\friendfoe.vol");

// ----------------------------------------------------------------------------
// EOF - KingTomato