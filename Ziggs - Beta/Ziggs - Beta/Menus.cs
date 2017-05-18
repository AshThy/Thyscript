using System;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Ziggs___Beta
{
    internal class Menus
    {
        private static Menu OriginalMenu, ComboTabela, LaneTabela, JungleTabela, HarassTabela, LastLabela, KillSteal, FleeTabela, DrawTabela;

        internal static void Iniciar()
        {

            OriginalMenu = MainMenu.AddMenu("Ziggs", "Ziggs");
            OriginalMenu.AddGroupLabel("Ziggs em modo Beta");
            OriginalMenu.AddLabel("Ziggs versão 7.1.0.2");
            // Fazer o Menu Do Combo
            ComboTabela = OriginalMenu.AddSubMenu("zCombo");
            ComboTabela.Add("usarQ", new CheckBox("Usar Q"));
            ComboTabela.Add("usarW", new CheckBox("Usar W"));
            ComboTabela.Add("usarE", new CheckBox("Usar E", false));
            ComboTabela.Add("usarR", new CheckBox("Usar R"));
            ComboTabela.AddLabel("Configurações para Spell R");
            ComboTabela.Add("MinimoEnemy", new Slider("Use R min Enemys", 1,0,5));
            ComboTabela.Add("ModoSuicida", new CheckBox("Mode Suicidal", false));
            ComboTabela.AddLabel("Config AA");
            ComboTabela.Add("UsarAA", new CheckBox("User Mode AA"));
            // Fazer o Menu Harass
            HarassTabela = OriginalMenu.AddSubMenu("zHarass");
            // Lane Clear
            LaneTabela = OriginalMenu.AddSubMenu("zLane");
            // Jungle Clear
            JungleTabela = OriginalMenu.AddSubMenu("zJungle");
            // KilSteal
            KillSteal = OriginalMenu.AddSubMenu("zKillSteal");
            // Last
            LastLabela = OriginalMenu.AddSubMenu("zLast");
            // Draws
            DrawTabela = OriginalMenu.AddSubMenu("zDraw");
            DrawTabela.AddLabel("Draws Spells");
            DrawTabela.Add("DQ", new CheckBox("Draw Q Spell"));
            DrawTabela.Add("DW", new CheckBox("Draw W Spell"));
            DrawTabela.Add("DE", new CheckBox("Draw E Spell"));
            DrawTabela.Add("DR", new CheckBox("Draw R Spell"));
            //COmando
            Drawing.OnDraw += zDrawing_OnDraw;

        }

        private static void zDrawing_OnDraw(EventArgs args)
        {
            if (DrawTabela["DQ"].Cast<CheckBox>().CurrentValue && Spells.E.IsLearned)
            {
                Circle.Draw(Color.MediumVioletRed, E.Range, Player.Instance.Position);
            }

        }
    }
}