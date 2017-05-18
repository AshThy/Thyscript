using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;

namespace Ziggs___Beta
{
    internal class Campeão
    {
        private static readonly AIHeroClient Ziggs = ObjectManager.Player;

        internal static void Iniciar()
        {
            if (Player.Instance.ChampionName != "Ziggs")
            {
                return;
            }
        }
    }
}