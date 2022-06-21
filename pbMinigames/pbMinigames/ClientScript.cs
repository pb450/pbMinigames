using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core.Native;

namespace pbMinigames
{
    internal class ClientScript : BaseScript
    {

        public bool gameInProgress;
        public string result = "";

        public ClientScript()
        {
            EventHandlers["pbMinigames:startGame"] += new Action<string, CallbackDelegate>(StartGame);
            EventHandlers["pbgameresult"] += new Action<string>(UpdateStatus);
        }

        private void UpdateStatus(string obj)
        {
            result = obj;
            gameInProgress = false;
        }

        public async void StartGame(string name, CallbackDelegate ncd)
        {
            var jsonMessage = "{\"source\":\"fivem\",\"gamename\":\"{0}\"}";

            var filled = jsonMessage.Replace("{0}", name);

            API.SendNuiMessage(filled);
            API.SetNuiFocus(true, true);

            gameInProgress = true;
            while (gameInProgress)
            {
                await BaseScript.Delay(80);
            }

            API.SetNuiFocus(false, false);
            ncd.Invoke(result == "yes");
        }
    }
}
