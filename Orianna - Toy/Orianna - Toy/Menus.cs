using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using EloBuddy.SDK;
using EloBuddy;

namespace Orianna___Toy
{
    internal class Menus
    {
        private static Menu OriMenu, ComboMenu, LaneMenu, JungleMenu, KilMenu, HarassMenu, Flee, Misc, Draws;
        private static Slider ManaManeger, Aly, Mini, Enemy;
        private static ComboBox Prediction;
        //BOOL
        public static AIHeroClient meuheroi { get { return ObjectManager.Player; } }
        internal static void Iniciar()
        {
            //Menu Original
            OriMenu = MainMenu.AddMenu("OriToy", "OriToy");
            //Menu Combo
            ComboMenu = OriMenu.AddSubMenu("Combo");
            ComboMenu.AddLabel("Settings Combo");
            ComboMenu.AddSeparator();
            ComboMenu.Add("ComboQ", new CheckBox("Toy Combo (Q)"));
            ComboMenu.Add("ComboW", new CheckBox("Toy Combo (W)"));
            ComboMenu.Add("ComboR", new CheckBox("Toy Combo (R)"));
            ComboMenu.AddLabel("Settings R");
            Enemy = ComboMenu.Add("UtiEnemy", new Slider("How Many Enemies = {0}", 2, 1, 5));
            Aly = ComboMenu.Add("Life", new Slider("Use Spell only with HP = {0}", 45,70,100));
            ComboMenu.AddLabel("Settings E");
            ComboMenu.Add("UseE", new CheckBox("Use E Aly"));
            ComboMenu.Add("UseMyHero", new CheckBox("Use E Toy Combo?", false));
            ComboMenu.AddLabel("Settings Prediction");
            Prediction = ComboMenu.Add("Pre1", new ComboBox("HitChance", 1, "Low", "Medium", "High"));
            //Harass
            HarassMenu = OriMenu.AddSubMenu("Harass");
            HarassMenu.AddLabel("Settings Harass");
            HarassMenu.AddSeparator();
            HarassMenu.Add("H1Q", new CheckBox("Harass Toy (Q)"));
            HarassMenu.Add("H2W", new CheckBox("Harass Toy (W)"));
            HarassMenu.Add("H3E", new CheckBox("Harass Toy (E)"));
            HarassMenu.AddLabel("Settings Mana");
            ManaManeger = HarassMenu.Add("Minimo", new Slider("Finish Harass = {0}", 45,75,100));
            //Lane
            LaneMenu = OriMenu.AddSubMenu("LaneClear");
            LaneMenu.AddLabel("Settings Lane");
            LaneMenu.AddSeparator();
            LaneMenu.Add("L1Q", new CheckBox("Use Toy (Q)"));
            LaneMenu.Add("LW2", new CheckBox("Use Toy (W)"));
            LaneMenu.AddLabel("Settings");
            Mini = LaneMenu.Add("Minions", new Slider("Use Spell (Q) Mini = {0}", 3, 1, 10));
            Mini = LaneMenu.Add("Minions2", new Slider("Use Spell (W) Mini = {0}", 3, 1, 10));
            //Jungle
            JungleMenu = OriMenu.AddSubMenu("JungleClear");
            JungleMenu.AddLabel("Settings Jungle");
            JungleMenu.AddSeparator();
            JungleMenu.Add("J1Q", new CheckBox("Spell (Q)"));
            JungleMenu.Add("J1W", new CheckBox("Spell (W)"));
            JungleMenu.AddLabel("Spell Smite");
            JungleMenu.Add("SmiteSpell", new CheckBox("Smite?", false));
            //KilSteal
            KilMenu = OriMenu.AddSubMenu("KilSteal");
            KilMenu.AddLabel("Sttings KillSteal");
            KilMenu.AddSeparator();
            KilMenu.Add("Kil1", new CheckBox("Steal Spell (R)"));
            KilMenu.Add("Kil2", new CheckBox("Steal Spell (W)"));
            //Flee
            Flee = OriMenu.AddSubMenu("Flee");
            Flee.AddLabel("Settings Flee");
            Flee.AddSeparator();
            Flee.Add("F1E", new CheckBox("Spell (E)"));
            Flee.Add("F1W", new CheckBox("Spell (W)"));
            //Misc
            Misc = OriMenu.AddSubMenu("Misc");
            Misc.AddLabel("Settings Misc");
            Misc.Add("M1R", new CheckBox("Use R Prediction"));
            Misc.Add("IG", new CheckBox("Spell Ignite"));
            //Draws
            Draws = OriMenu.AddSubMenu("Draws");
            Draws.Add("D1Q", new CheckBox("Drawings (Q)"));
            Draws.Add("D2E", new CheckBox("Drawings (E)"));
            Draws.Add("DIG", new CheckBox("Drawings (Spell)"));
            //Comandos
        }

        internal static void Update(EventArgs args)
        {
            var target = TargetSelector.GetTarget(700, DamageType.True, Player.Instance.Position);

            float IginiteDamager = 50 + (20 * meuheroi.Level);

            if (target != null)
            {
                float Life10 = target.HPRegenRate * 10;

                if (Menus.Misc["IG"].Cast<CheckBox>().CurrentValue && Spells.Ignite.IsReady() && target.IsValidTarget(Spells.Ignite.Range) &&
              (IginiteDamager > (target.TotalShieldHealth() + Life10)))
                {
                    Spells.Ignite.Cast(target);
                }
            }
        }
    }
}