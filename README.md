# SBEX
NoBuddy's Streamer.Bot extensions

Base solution for general Streamer.bot extensions by NoBuddyIsPerfect

- FNSC - FridayNightSongChampionship

Includes a Dummy app to test without having to use Streamer.bot


INSTALLATION
Installation instructions for the Streamer.bot Song Chamionship extension:

- Close Streamer.bot
- Copy DLL's into Streamer.bots "dlls" folder
- Open Streamer.bot
- Goto Settings -> C# Compiler and add both dlls as "Common Reference"s
- Import OBS Scene and make sure the source paths are correct
- In Streamer.bot, import the actions and commands
- Enable the commands
- Goto the action "[SC] Arguments - CONFIGURE HERE", edit the paths and add your YouTube api key and Discord webhook url
- Goto the action "[SC] Handle Coin Flip Result" and copy the action id
- Goto the coinflip folder and open index.html. In line 25 insert the copied id

To start a championship simply trigger the "[SC] SongChampionship Main" action and the management form will open.


DLL's needed:
- SBEX.FNSC.dll
- RestSharp.dll

Additional files:
- ActionsAndCommands.sb -> Importstring for Streamer.Bot
- SourceCopy.json -> Import file for OBS when using SourceCopy plugin
- SceneCollection.json -> Import file for OBS when using default scene collection import
- Folder "SongChampionships"
  - 60.html -> HTML file for the 60 second countdown (copy and adjust for different countdowns)
  - championship.html -> Main file for displaying videos during championship
  - timer.wav -> Sound to play during the last 10 seconds of the countdown
  - end.mp3 -> Sound to play when the countdown is over
  - style.css -> Stylesheet
  - Folder "coinflip"
    - coin left.png and coin right.png -> Images of the coin
    - index.html -> HTML file to display the coinflip
    - script.js -> Script file that handles the callback to Streamer.Bot
    - style.css -> Stylesheet
