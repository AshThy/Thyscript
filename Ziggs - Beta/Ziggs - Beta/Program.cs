using System;
using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Events;

namespace Ziggs___Beta
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += JogoCompleto;
        }

        private static void JogoCompleto(EventArgs args)
        {
            Menus.Iniciar();
            Campeão.Iniciar();
            

        }
    }
}
