How To Install KingTomato Pack
==============================

Files
- [Presto Pack](./Presto0_93.zip)
- [NewOpts](./NewOpts966.zip)

Introduction
------------

Since there is an abundance of "How do I install the KingTomato Pack" questions, I thought I would save everyone the trouble of having to type out and help people once and for all. Don't get me wrong, I appreciate all those who continued to help despite me saying "I am no longer supporting the pack", it's just I know you're getting frustrated too.

So any ways, below is a list of (Detailed) instructions on how to install my pack. Now, should this STILL not help you, I think we can all say you're on your own. There is only so much stupidity one can handle.

Preparation
-----------

Now, before you can install my pack you will need two major things for tribes. One is the Presto pack, and the other is NewOpts. For your convenience, I have included both these files on the left hand side. Just under the files heading, you will notice the two links. If you do not have either of them, please download them and follow me. If you do have them, please click here.

Installing Presto Pack
----------------------

First thing you are going to need to do is install Presto. To do this, extract the zip file somewhere. In XP, just right click the file, and select "Extract all...". Click the next button twice, then finish. You will now have a new window with the Presto Pack's contents in front of you. If you do not have XP, right click on the file, and there should be an "Extract to /PrestoPack0_93" option. Select that, then open the folder.

Now that we have the files, lets get down to business. Open a new folder to your tribes config directory (C:\Dynamix\Tribes\Config). Now go back to your presto window, and you should see two things, readme and a folder named presto. Select the presto folder, then right click on it, and select copy. Now, go back to tribes config folder, and choose paste from the edit menu at the top. You should now have something like this:

[!sshot_01.png](./sshot_01.png)

Okay, now open the presto folder you just copied, and locate the autoexec.cs file. Right click on it, and select copy, then go back to config directory and choose paste once more from the edit menu at the top. Congratulations, you now have the Presto Pack installed!

Now I recommend going back into the presto folder, and opening **PrestoPrefs.cs** with notepad, and going through and customizing the scripts. Some things you may want, and others you may not.

Installing NewOpts
------------------

Now that you have PrestoPack installed, you still need to install NewOpts. Again, the link to the file is on the left if you haven't gotten it already. Additionally, you will also need to unzip this file just as we did the presto pack.

Now, once you have it open, you will see three files. Copy these files into your tribes\config folder. once you have done that, open autoexec.cs (the one you just copied from presto) with notepad, and add the following immediately after the line `exec("presto\\install.cs");`

```
Include("autoload.cs");
```

Your file should now look like this:

[!sshot_02.png](./sshot_02.png)

Viola! Now you have both the Presto Pack and NewOpts installed. That wasn't so hard, was it?

Installing KingTomato Pack

Now comes the part you are actually trying to accomplish, the KingTomato pack. Because of the fact that I update my site for the pack and not necessarily update this install page, i have not included the pack on this page. instead, quickly go visit this site quickly and get the pack if you haven't already.

Now that you have the pack, let's continue. Open the pack again just as you have done Presto and NewOpts. unzip it to a folder. Now before we touch this, open your config folder up. Now that you have Presto and NewOpts, it should look something like this:

[!sshot_03.png](./sshot_03.png)

Now what you do it make a new folder called KingTomato. To do this, go to the file menu, and select New >> Folder. Now, rename that folder to KingTomato (cAsE SenNStiVe; kingtomato isn't the same as KingTomato). Now open that folder, and it should be nice and clean.

Okay, now go back to the zip file you opened and select all the files (either `ctrl+a`, or from the edit menu, select all). Now copy those file to the KingTomato folder you just made. Now return to the config directory, and open **autoexec.cs** file. At the bottom of the file, add the following:

```
Include("KingTomato\\Install.cs");
```

That's it. Now, you may want to go into the folder, and open `KingPrefs.skip.cs` in notepad before you run the pack. There are some things you may want changed. On the other hand, the default install may be good for you.

The only other thing you may want is the LastHope patch, because there is a time hud that uses that patch to generate the clock off of. The patch can be located on www.lasthope.us. All it is is a matter of taking the Tribes.exe in the file you download and replacing it with your current exe in tribes.

Conclusion
----------

I hope this helps a lot of people, and answers a lot of questions about the pack. Also, I am definitely not supporting this pack any more as far as installation is concerned. This file was written with a complete idiot in mind, and should be more than enough for the common gamer. If You still however have troubles, please use the forums.
