```
	 _____________________________________________________________
	|_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
	|__@@__@@___|___|___|___|@@@@@@_|___|___|___|___|___@@__|___|_|
	|_|@@_|@@_@@__|___|___|__@@@@@@___|___|___|___|___|_@@|___|___|
	|__@@__@@___|___|___|___|__@@___|___|___|___|___|___@@__|___|_|
	|_|@@@@@__|___|___|___|___|@@_|___|___|___|___|___|@@@@___|___|
	|__@@@@@|_@@|@@@@@@_@@@@@@_@@_@@@@@@|@@@@@@@|_@@@@__@@_@@@@@@_|
	|_|@@_|@@_@@_@@__@@_@@|___|@@_@@__@@_@@_@_@@_@@__@@_@@|@@_|@@_|
	|__@@__@@_@@|@@_|@@_@@__@@_@@_@@|_@@|@@_|_@@|@@_|@@_@@_@@__@@_|
	|_|@@_|@@_@@_@@__@@_@@@@@@|@@_@@@@@@_@@___@@__@@@@@_@@|@@@@@@_|
	|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|_|
				  Script v2.3
			P a i n t B a l l   S t y l e
```

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Warning:
--------

Though all of my scripts have been self tested, please be careful when installing
this pack. I can not be held responsible for the result of any damage done by
this pack, or any supported ones. Though all scripts have been tested, varied
hardware and software configurations may play a part in installation.  Please, if
you feel it may be unsafe to run my script, don't.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Summary:
--------

The script provided is designed to aid both in the player aspect, as well as the
scripting aspect of tribes. All scripts are commented and very well documented.
The idea is to have a very easily customized script pack, like Presto's Amazing
Pack, thats easy to work with and customize--I hope that theory hold true.

I have attached new events that are to coincide with the Presto Events.cs, as
well as easy to use command attachments to the chat hud.  Creating in-game
commands trigger via the chat command has never been easier.  Please read through
the documentation carefully. I don't have enough time to walk everyone through
how to script, but the examples I have provided should be enough of a demo for
you to grasp certain ideas.

All files in the base KingTomato folder are designed to be system files. By that,
I mean files this script needs to run properly.  Containing folders contain addon
scripts that can be used along with the pack itself.  Please also note there is
no include line needed for each file in this directory, as it will be found and
executed automatically.  Should you want a script not to execute, please prefix
the extension with ".skip". For example, if I wanted the file myscript.cs to be
excluded, I could rename it to myscript.skip.cs

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Installation:
-------------

Seeing how it was so damn hard before for peopel to install this pack, here are
(what I see to be) better instructions.

http://www.kingtomato.org/install/ ([Mirror](../INSTALL))

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Trouble Shooting:
-----------------

### Pack won't work!

Should you have a problem with the script, please first run Tribes normally, then
after load press the tilde (~) key just below escape on the keyboard. I have some
error checking in the install file. Should a common error occur, the script will
describe the problem in the console.

### An addon someone gave me doesn't work!

If an addon someone gave you doesn't run please make sure that you have the file
in the KingTomato folder. Next, run tribes and open the console (~). There may be
a version failure. If so, a notice will be displayed.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Some Commands:
--------------

In the game, there are several commands that can be accessed by simply typing the
trigger into a global or team chat message.  Some commands might have parameters,
and others not.  These basic commands are as follows:

	`!acronym <on/off/style> [new_style]`

		This can toggle the acronyms, as well as set how they should look
		when they are said. Use on or off to toggle the script, and to
		change the appareance use !acronym style <new_appearance>.

		For example, to change the script from the default style, to
		/Acronym/, you could use:

		`!acronym style /<acro>/`

		Notice the same tag is required for when you set the new acronym.

	`!setsad <password>` or `!setsad`

		Sets up an auto-identify SAD() password for a server based on the
		Server's IP address. Though this is a nice feature, realise the
		passwords are saved in plain text, and also work for ALL usernames.
		This means if you have a sibling who whouldn't have admin on a
		server, they will get it.

		The first command will set the password based on what follows the
		command. The latter will open a nice little dialog for you to input
		the password into.

	`!juggle`

		A favorite of most, typing it will force you to look up, and start
		tossing your weapons into the air.  Likewise, typing it again will
		also turn the script off.  To make it even nicer, I removed the
		"You recieved a ___" message while juggling so you can even carry
		on a conversation while you show off!

	`!specs` or `!server`

		Both of these commands return different things about your own setup
		and about the server you are on.  Specs will advertise your current
		video mode, resolution, frames per second, and refresh rate. !server
		will announce what server you are on, version, map, and mod.

		Do note that on servers like porn with a length limitation, these
		may not work.  Porn server (like many others) has limited the chat
		message limit to something like 95 characters.  This is also the
		reason for varied X-Pack and 5150 pack messages being limited.
		
```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Scriptors:
----------

If you have found a better way of doing things, or have a script that is
supported very well by my pack, please send it to me. I'd be more than willing to
include it with my next release.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Feature Suggestions:
--------------------

If you have a script idea you want made, let me know. If its fairly simple or
useful, I might add it to the script pack also.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Bugs or Flaws:
--------------

Should you find a bug or flaw in this script, please report it to me imediatly.
I will do my best to remove any and all bugs in this script, and make it as smooth
running as possible.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Shouts:
-------

Thank you GTX for the superior bug testing! I couldn't have done it without you
bro! (v13) >:P

Also thanks to Darkrealmlord and Skaara for finding a couple bugs with settings
saving and vote hud.

Paintball community for enjoying my pack, and giving me feed back.

And another shout to vill for his mad debug skillz. You is teh r0x0rs :D

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
KingTomato								      '04
```
