using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;

namespace Orianna___Toy
{
    internal class Menus
    {
        private static Menu OriMenu, ComboMenu, LaneMenu, JungleMenu, KilMenu, HarassMenu, Flee, Protection;
        private static Slider ManaManeger, Aly, Enemy;
        private static ComboBox Prediction;
        internal static void Iniciar()
        {
            //Menu Original
            OriMenu = MainMenu.AddMenu("OriToy", "OriToy");
            //Menu Combo
            ComboMenu = OriMenu.AddSubMenu("ToyCombo");
            ComboMenu.Add("ComboQ", new CheckBox("Toy Combo (Q)"));
            ComboMenu.Add("ComboW", new CheckBox("Toy Combo (W)"));
            ComboMenu.Add("ComboR", new CheckBox("Toy Combo (R)"));
            ComboMenu.AddLabel("Config R");
            Enemy = ComboMenu.Add("UtiEnemy", new Slider("How Many Enemies ={0}", 2, 1, 5));
            Aly = ComboMenu.Add("Life", new Slider("Use Spell only with HP ={0}", 45,70,100));
            ComboMenu.AddLabel("Config E");
            ComboMenu.Add("UseE", new CheckBox("Use E Aly"));
            ComboMenu.Add("UseMyHero", new CheckBox("Use E Toy Combo?"));
            ComboMenu.AddLabel("Config Prediction");
            Prediction = ComboMenu.Add("Pre1", new ComboBox("HitChance", 1, "Low", "Medium", "High"));

        }
    }
}