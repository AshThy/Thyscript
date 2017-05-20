using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace Riven___Exilada
{
    class Riven
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnGameComplete;
        }

        private static void OnGameComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Riven")
            {
                return;
            }

        }
    }
}
