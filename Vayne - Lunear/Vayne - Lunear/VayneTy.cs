using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Color = System.Drawing.Color;

namespace Vayne___Lunear
{
    internal class VayneTy
    {
        public static Spell.Ranged Q;
        public static Spell.Targeted E;
        public static Spell.Skillshot EDeclaraçãoParaoInimigo;
        public static Spell.Active W;
        public static Spell.Active R;

        public static bool ForçãoDoPoderosoTorrente(Vector2 pos)
        {
            return EntityManager.Turrets.Enemies.Where(a => a.Health > 0 && !a.IsDead).Any(a => a.Distance(pos) < 1100);
        }
        public static bool UltActive()
        {
            return Player.HasBuff("VaitomanoBuff") && !ForçãoDoPoderosoTorrente((Vector2)JogadorJoob.Position);
        }

        public static Menu MainVayne, vCombo, vHarass, vLane, vJungle, vDraw, vKil, vIter;

        public static AIHeroClient JogadorJoob
        {
            get { return ObjectManager.Player; }
        }
        public static List<Vector2> PosiçãoDoInimigo = new List<Vector2>();


        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        public static void OnLoadingComplete(EventArgs args)
        {
            if (EloBuddy.Player.Instance.Hero != Champion.Vayne)
            {
                return;
            }
            Chat.Print("Version 1v Beta", Color.LightBlue);
            
            //spells
            Q = new Spell.Skillshot(SpellSlot.Q, int.MaxValue, SkillShotType.Linear);
            E = new Spell.Targeted(SpellSlot.E, 750);
            EDeclaraçãoParaoInimigo = new Spell.Skillshot(SpellSlot.E, 590, SkillShotType.Linear, 150, 1150);
            W = new Spell.Active(SpellSlot.W);
            R = new Spell.Active(SpellSlot.R);

            //Menu
            MainVayne = MainMenu.AddMenu("Vayne", "Vayne");
            vCombo = MainVayne.AddSubMenu("[Combo]");
            vCombo.AddGroupLabel("Q Settings");
            vCombo.Add("Qcombo", new ComboBox("Q Logic", 0, "Side", "Cursor", "Burst"));
            vCombo.Add("QeR", new CheckBox("Auto [Q+R]", false));
            vCombo.Add("UsarE", new CheckBox("Use E Combo"));
            vCombo.AddLabel("W Settings:");
            vCombo.Add("FocusW", new CheckBox("[Focus target]"));
            vCombo.AddLabel("R Settings");
            vCombo.Add("RCombo", new CheckBox("Use R"));
            vCombo.Add("RC", new Slider("R enemies= {0} ", 2, 1, 5));
            vCombo.Add("ResetAA", new CheckBox("No AA If active Ulty "));
            vCombo.Add("Joberr", new Slider("AA enemy", 2, 1, 5));
            //Harass
            vHarass = MainVayne.AddSubMenu("[Harass]");
            vHarass.Add("UseE", new CheckBox("Use Spell E", false));
            vHarass.Add("MiniManar", new Slider("E Mana = {0}", 70, 0, 100));
            //Lane
            vLane = MainVayne.AddSubMenu("[Lane]");
            vLane.Add("QLane", new CheckBox("Use Q"));
            vLane.Add("QMana", new Slider("Q Mana = {0}", 75));
            //Jungle
            vJungle = MainVayne.AddSubMenu("[Jungle]");
            vJungle.Add("Qjungle", new CheckBox("Use Q Jungle"));
            vJungle.Add("QMana", new Slider("Q Mana = {0}", 75));
            //Draw
            vDraw = MainVayne.AddSubMenu("[Draw]");
            vDraw.Add("UnicoDraw", new CheckBox("Draw E"));
            //KilSteal
            vKil = MainVayne.AddSubMenu("[KillSteal]");
            vKil.AddLabel("E Settings:");
            vKil.Add("EKillSteal", new CheckBox("[Use E KS]"));
            vKil.Add("Ecombo", new ComboBox("E Logic", 1, "EloBuddy", "Joker"));
            vKil.Add("GoodPush", new Slider("Distance = {0}", 410, 350, 420));
            vKil.Add("Precentir", new Slider("HitChange = {0}", 70));
            //Iter
            vIter = MainVayne.AddSubMenu("[Interrupter]");
            vIter.Add("interrupter", new CheckBox(" Use E Interrupter"));
            vIter.Add("AutoQ", new CheckBox("Q Gapcloser", false));
            vIter.Add("interronperespell", new ComboBox("Interrupter HitChance", 0, "High", "Medium", "Low"));

            //Some daqui seu cachorro
            Drawing.OnDraw += Finalização.Trump.OnDraw;           
            Game.OnUpdate += Definições_dos_Modos.Modos.Atualização;
            Orbwalker.OnPostAttack += Definições_dos_Modos.Modos.DespoisDoAtauqe;          
            Gapcloser.OnGapcloser += Definições_dos_Modos.ModV2.AntiGapCloser;
            Interrupter.OnInterruptableSpell += Definições_dos_Modos.ModV2.PorjetoBase;
            Interrupter.OnInterruptableSpell += Definições_dos_Modos.ModV2.HomemInvible;
            Interrupter.OnInterruptableSpell += Definições_dos_Modos.ModV2.JookerLoL;
            Obj_AI_Base.OnProcessSpellCast += Definições_dos_Modos.ModV2.CasteloDoReiArthur;
            EloBuddy.Player.OnIssueOrder += Definições_dos_Modos.ModV2.BorResetaOSeusAtacks;

        }
    }
}
