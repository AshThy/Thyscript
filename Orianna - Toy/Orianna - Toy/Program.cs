using System;
using EloBuddy.SDK.Events;
using EloBuddy;

namespace Orianna___Toy
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoad;
        }

        private static void OnLoad(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Orianna)
            {
                Chat.Print("Welcome to my First Addon < font color='#FFFFFF'>" + Player.Instance.ChampionName + "</font>");
                return;

                Menus.Iniciar();
                Spells.Iniciar();
            }

        }
    }
}
