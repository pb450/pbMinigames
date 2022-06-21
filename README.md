# pbMinigames
FiveM script handling minigames written in HTML/JS/CSS

This script allows you to create and handle minigames in FiveM (Just like in NoPixel)

#Installation and usage
Download lastest release and put it into resources folder. Remember to start script in server.cfg.
Example games with code are included in release
#Usage
### In FiveM scripts
In order to use this script in your own all you have to do is to use simple TriggerEvent functions, like this:
C#
```csharp
TriggerEvent("pbMinigames:startGame", gameName, new Action<bool>((tx) =>
{
	 //Here goes rest of your script
	//tx has type of boolean
}));
```
Lua
```lua
TriggerEvent('pbMinigames:startGame', gameName, function(t)
		--Here goes rest of your script--
		--t has type of boolean--
	end)
```
### Creating your own game
If you want to create your own minigame head to html/pages folder in resource folder and create new folder with name of your game. Only neccesary file to create is index.html which is main game screen - rest is up to you
If you want to return result of your game to this script you have to use window.parent.postMessage function as follows:
```javascript
window.parent.postMessage({source:"html", status:/*"yes" or "no"*/}, "*");
``` 
where source must not be touched, and status has to be string, either "yes" for success, or "no" for losing the game. This will cause to closing the script NUI and passing result to game 
