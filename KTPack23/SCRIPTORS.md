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

This should be a fairly decent amount of documentation on how my pack works. If
you need clearification on something, please contct me and I will see if I can
write more on the subject

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

File Names:
-----------

The way I have this script setup is divided into two major parts, the system files
and the script files.  To make it easier on the client, I have all scripts from
this directory automatically execute apon startup. Based on extenstions, execution
order can vary.

For example, a file ending in .vol will execute before all files (just as tribes
does).  The reason for this is the ability to override scripts external to the vol,
just as the game does. i.e. putting a file named h_reticle.bmp in your base folder
of tribes will override what the default reticle appears as.

Additionally, there is a file type .sys.cs that will be executed before any other
script will.  Though this is designed primarily for the pack itself, should you
have a script that should be executed first, you can use this extention.

Next, any file extention of .cs will execute. The only exception to this rule, is
a file with the extention .skip.cs This extention will signify to 'skip' (ignore)
this file.  This may be a good idea for files holding settings, or perhaps an
older version of a script you are working on.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

File Headers:
-------------

With the multitude of files that can be present in this folder, i have designed
an easy way to track files, versions, and what they do.  To do this, I have created
the ability to put three variables in each file.  These variables (apon execution
of the file) will be stored and outputted on the pack's startup.  These variables
are as follows:

```
	$Script::Creator	- Creator of the script
	$Script::Version	- Version of the script (Use quotes, ex: "1.11")
	$Script::Description	- *Brief* description of the file
	$Script::MinVersion	- The earliest version of the pack a user can
				  be running to use this addon. For example,
				  new events were added in 2.2. A script using
				  these events would set MinVersion to 2.2
```

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Events:
-------

To provide more control, I have added a few more events for you to play with. 
These events include catching Bottom/Top/Center Print, Client input (from chat
hud), inventory text, and tab menu text.  The tab menu is so that on a mod
you don't have access to, you can see what command is being sent via the command
`clientmenuselect()` when an item is selected.  My implimentation was for a nappy
manipulation menu. I knew `exec <client>`, `strip <client>`, `gag <client>`, but
couldn't figure out the last one. Might also be handy for doing automatic triggers
on menu open.

The actual events, and their parameters are outlined in KingEvents.sys.cs Please
check that file out if you wish to use an event.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Bot/Input Commands:
-------------------

With the abundace of scripts, and the lack of bind keys *grin* I decided to add a
new method of triggering scripts.  With this, you can attach functions to input
typed both my the client themself, or others in the server.  The general idea is
to allow you to both execute commands on input, and perhaps even add the ability
to filter text.

Check out the file `Commands.sys.cs` for more information.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
```

Saving Settings:
----------------

Me, being the neat freak I am, have gotten tired of seeing 50 million files in
my tribes folder containing settings for all the scripts I have installed.  To
put a damper on this, I have devised a plan. The plan is to make all scripts
using this pack to save to one file.

The benefit? Well, for starters, it's faster loading. On startup, only one setting
file will need to be executed to save the settings of several. In addition to
that, there is one file replacing what could be several files containing just a
few lines.

Though i did devise this, there is one script that doesn't follow this pattern,
sorry.  This file is `DuelStats.cs` The reason being is that this script was more 
an 'import' than a tried and true 'addition' to the pack.  I didn't feel the need
to go through a huge file and replace file variable and such, and the way it handled
thing just for the decrease of one in the file count.  If you wish to change it
for me, I would be most gracious to add it to my pack, and give you credit!

Anyways, the `Settings.sys.cs` file has more information on the topic. I hope you
find it useful.

```
---------------------------------------------------------------------------------
|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|
KingTomato								      '04
```