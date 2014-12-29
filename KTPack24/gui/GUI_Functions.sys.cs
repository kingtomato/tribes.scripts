// ----------------------------------------------------------------------------
// KingTomato Scripts
// ----------------------------------------------------------------------------

$Script::Description = "Handles GUI events for NewOpts pages.";

function King::GUI::Init(%gui)
{
	if ($GUI::Building)
	{
		echo("GUI::Init -> Builder mode enabled, exiting");
		if (!$GUI::Screen)
		{
			setScript($GUI::Dialog);
			guiTools();
			$GUI::Screen = true;
		}
		return;
	}

	// General options
	if (%gui == General)
	{
	}

	// Settings
	else if (%gui == Settings)
	{
		if ($pref::shadowDetailMask)
			Control::setValue(KTSettings::Shadows, true);
		else
			Control::setValue(KTSettings::Shadows, false);			
	}

	// Acronyms
	else if (%gui == Acronyms)
	{
		%combo   = "KTAcronyms::AcronymList";
		%acronym = "KTAcronyms::Acronym";
		%meaning = "KTAcronyms::Meaning";

		// Load Acronyms List
		FGCombo::Clear(%combo);
		for (%a = 1; (%acro = $Acronym::List::[%a]) != ""; %a++)
		{
			%means = $Acronym::List[%acro];

			FGCombo::addEntry(%combo, %acro @ " - " @ %means, %a);

			if (%a == 1)
				FGCombo::setSelected(%combo, %a);
		}
		King::GUI::Combo(%gui, %combo);
	}

	// Friends List
	else if (%gui == Friends)
	{
		%combo = "KTFriends::FriendsList";
		%name = "KTFriends::Name";

		// Load friends
		FGCombo::Clear(%combo);
		for (%f = 1; (%friend = $KingPref::Friends[%f]) != ""; %f++)
		{
			FGCombo::addEntry(%combo, %friend, %f);

			if (%f == 1)
				FGCombo::setSelected(%combo, 1);
		}

		Control::setText(%name, "");
	}

	// HUDs
	else if (%gui == HUDs)
	{
		%combo = "KTHuds::HudList";
		%x = "KTHuds::PositionX";
		%y = "KTHuds::PositionY";
		%width = "KTHuds::SizeWidth";
		%huds = 0;

		// Load list of _my_ huds
		FGCombo::Clear(%combo);
		for (%h = 0; %h < $HUD::numHUDs; %h++)
		{
			%hud = $HUD::Name[%h];

			// a hud associated with my pack
			if (String::findSubStr(%hud, "kt_") == 0)
			{
				%name = String::getSubStr(%hud, 3, 99);
				FGCombo::addEntry(%combo, %name @ " Hud", %h);

				if (%huds++ == 1)
					FGCombo::setSelected(%combo, %h);
			}
		}
		King::GUI::Combo(%gui, %combo);		
	}
}

function King::GUI::Button(%gui, %button)
{
	if ($GUI::Building)
	{
		echo("GUI::Button -> Builder mode enabled, exiting");
		return;
	}

	// General options
	if (%gui == General)
	{
	}

	// Acronyms
	else if (%gui == Acronyms)
	{
		%combo = "KTAcronyms::AcronymList";
		%help = "KTAcronyms::HelpText";
		%update = false;

		Control::setText(%help,"");

		// Add/Update Button
		if (%button == Update)
		{
			if ($GUI::Acronym::Text == "")
				Control::setText(%help,
					"Missing Field: Acronym");
			else if ($GUI::Acronym::Meaning == "")
				Control::setText(%help,
					"Missing Field: Meaning");
			else
			{
				Acronym::Add($GUI::Acronym::Text, $GUI::Acronym::Meaning);
				%update = true;
			}

			$GUI::Acronym::LastClick = -1;
		}

		// Delete Button
		else if (%button == Delete)
		{
			%sel = FGCombo::getSelected(%combo);

			if (%sel != -1)
			{
				if ($GUI::Acronym::LastClick == %sel)
				{
					%acro = $Acronym::List::[%sel];

					Acronym::Remove(%acro);
					%update = true;

					$GUI::Acronym::LastClick = -1;
				}
				else
				{
					Control::setText(%help,
						"Delete this acronym? (click again to confirm)");
					$GUI::Acronym::LastClick = %sel;
				}
			}
			else
				Control::setText(%help,
					"There is no entry to delete.");
		}

		if (%update)
			King::GUI::Init(Acronyms);
	}

	// Friends List
	else if (%gui == Friends)
	{
		%combo = "KTFriends::FriendsList";
		%help = "KTFriends::HelpText";
		%name = "KTFriends::Name";
		%update = false;

		Control::setValue(%help,"");

		// Add button
		if (%button == Add)
		{
			if ($GUI::Friends::Name != "")
			{
				%found = false;
				for (%f = 1; (%friend = $KingPref::Friends[%f]) != ""; %f++)
					if (%friend == $GUI::Friends::Name)
					{
						%friend = true;
						break;
					}

				if (!%found)
				{
					$KingPref::Friends[%f] = $GUI::Friends::Name;
					Control::setText(%name, "");
					%update = true;
				}
				else
					Control::setValue(%help,
						"<f1>That person is already in your friend list.");
			}
			else
				Control::setValue(%help,
					"<f1>Fill in the name field.");

			$GUI::Friends::LastClick = -1;
		}

		// delete button
		else if (%button == Delete)
		{
			%sel = FGCombo::getSelected(%combo);

			if (%sel != -1)
			{
				if ($GUI::Friends::LastClick == %sel)
				{
					for (%n = %sel; $KingPref::Friends[%n] != ""; %n++)
						$KingPref::Friends[%n] = $KingPref::Friends[(%n+1)];

					%update = true;

					$GUI::Friends::LastClick = -1;
				}
				else
				{
					Control::setValue(%help,
						"<f1>Delete this acronym?\n(click again to confirm)");
					$GUI::Friends::LastClick = %sel;
				}
			}
			else
				Control::setValue(%help,
					"<f1>There is no entry to delete.");
		}

		if (%update)
			King::GUI::Init(Friends);
	}

	// HUDs
	else if (%gui == HUDs)
	{
		%combo = "KTHuds::HudList";
		%x = "KTHuds::PositionX";
		%y = "KTHuds::PositionY";
		%w = "KTHuds::SizeWidth";

		// Make Changes
		if (%button == Apply)
		{

			%sel = FGCombo::getSelected(%combo);
			if (%sel != -1)
			{
				%hud = $HUD::Name[%sel];
				%name = String::GetSubStr(%hud, 3, 99);

				$King::HUD[%name, X]  = $GUI::HUDs::PosX;
				$King::HUD[%name, Y]  = $GUI::HUDs::PosY;
				$King::HUD[%name, W]  = $GUI::HUDs::Width;
				$King::HUD[%name, On] = $GUI::HUDs::HUDEnabled;

				%newPos = sprintf("%1 %2 %3 %4", $King::HUD[%name, X], $King::HUD[%name, Y], $King::HUD[%name, W], HUD::Height(%hud));
				HUD::Move(%hud, %newPos);
				HUD::Display(%hud, $King::HUD[%name, On]);
			}
		}

		// Revert hud settings back to default
		else if (%button == Undo)
		{
			King::HUI::Combo(%gui, %combo);
		}
	}
}

function King::GUI::Combo(%gui, %combo)
{
	if ($GUI::Building)
	{
		echo("GUI::Close -> Builder mode enabled, exiting");
		return;
	}

	// General options
	if (%gui == General)
	{
	}

	// Acronyms
	else if (%gui == Acronyms)
	{
		%acronym = "KTAcronyms::Acronym";
		%meaning = "KTAcronyms::Meaning";

		%sel = FGCombo::getSelected(%combo);
		if (%sel != -1)
		{
			%acro = $Acronym::List::[%sel];
			%means = $Acronym::List[%acro];
		}

		$GUI::Acronym::Text = %acro;
		$GUI::Acronym::Meaning = %means;

		Control::setText(%acronym, %acro);
		Control::setText(%meaning, %means);
	}

	// Friends List
	else if (%gui == Friends)
	{
	}

	// HUDs
	else if (%gui == HUDs)
	{
		%e = "KTHuds::HUDEnabled";
		%x = "KTHuds::PositionX";
		%y = "KTHuds::PositionY";
		%w = "KTHuds::SizeWidth";

		%sel = FGCombo::getSelected(%combo);
		if (%sel != -1)
		{
			%hud = $HUD::Name[%sel];
			%name = String::GetSubStr(%hud, 3, 99);

			%enabled = $King::HUD[%name, On];
			%left = $King::HUD[%name, X];
			%top = $King::HUD[%name, Y];
			%width = $King::HUD[%name, W];
		}
		else
			%enabled = false;

		Control::SetVisible(KTHuds::SizeText, (%width != ""));
		Control::SetVisible(KTHuds::SizeWidthText, (%width != ""));
		Control::SetVisible(KTHuds::SizeWidth, (%width != ""));

		$GUI::HUDs::PosX = %left;
		$GUI::HUDs::PosY = %top;
		$GUI::HUDs::Width = %width;
		$GUI::HUDs::HUDEnabled = %enabled;

		Control::setValue(%x, %left);
		Control::setValue(%y, %top);
		Control::setValue(%w, %width);
		Control::setValue(%e, %enabled);
	}
}

function King::GUI::Close(%gui)
{
	if ($GUI::Building)
	{
		echo("GUI::Close -> Builder mode enabled, exiting");
		return;
	}

	// General options
	if (%gui == General)
	{
		if ($KingPref::Logging)
			$Console::LogMode = 1;
		else
			$Console::LogMode = 0;
	}

	// Settings
	else if (%gui == Settings)
	{
		if (Control::getValue(KTSettings::Shadows))
		{
			$pref::shadowDetailMask = "1";
			$pref::shadowDetailScale = "1.000000";
		}
		else
		{
			$pref::shadowDetailMask = "0";
			$pref::shadowDetailScale = "0.000000";
		}
	}

	// Acronyms
	else if (%gui == Acronyms)
	{
	}

	// Friends List
	else if (%gui == Friends)
	{
	}

	// HUDs
	else if (%gui == HUDs)
	{
	}
}