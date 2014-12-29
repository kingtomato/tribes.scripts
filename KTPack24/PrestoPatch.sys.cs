// ----------------------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------------------

// Makes it so that you can see kick reason when you are kicked from a server.

// ----------------------------------------------------------------------------------------
// eventConnectionAccepted
// eventConnectionRejected(%reason)
// eventConnectionLost
// eventConnectionTimeout
// ----------------------------------------------------------------------------------------
function onConnection(%message)
{
	echo("Connection ", %message);
	$dataFinished = false;
	if(%message == "Accepted")
	{
		resetSimTime();
		//execute the custom script
		if ($PCFG::Script != "")
			exec($PCFG::Script);

		resetPlayDelegate();
		remoteEval(2048, "SetCLInfo", $PCFG::SkinBase, $PCFG::RealName, $PCFG::EMail, $PCFG::Tribe, $PCFG::URL, $PCFG::Info, $pref::autoWaypoint, $pref::noEnterInvStation, $pref::messageMask);

		if ($Pref::PlayGameMode == "JOIN")
		{
			cursorOn(MainWindow);
			GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
			renderCanvas(MainWindow);
		}
		Event::Trigger(eventConnectionAccepted);
	}
	else if(%message == "Rejected")
	{
		Quickstart();
		$errorString = "Connection to server rejected:\n" @ $errorString;
		GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
		schedule("Control::setValue(MessageDialogTextFormat, $errorString);", 0);
		Event::Trigger(eventConnectionRejected);
	}
	else
	{
		//startMainMenuScreen();
		Quickstart();

		if(%message == "dropped")	// Spelling Fix - KingTomato 01-07-03
		{
			if($errorString == "")
				$errorString = "Connection to server lost:\nServer went down.";
			else
				$errorString = "Connection to server lost:\n" @ $errorString;

			GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
			schedule("Control::setValue(MessageDialogTextFormat, $errorString);", 0);

			Event::Trigger(eventConnectionLost, $errorString);	// Moved Down Below GuiPush - KingTomato 01-07-03
		}
		else if(%message == "TimedOut")
		{
			$errorString = "Connection to server timed out.";
			GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
			schedule("Control::setValue(MessageDialogTextFormat, $errorString);", 0);
			Event::Trigger(eventConnectionTimeout);
		}
	}
}