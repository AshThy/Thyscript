using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Vayne___Lunear.VayneTy;
using static Vayne___Lunear.Finalização.ComandosBetaV1;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;

namespace Vayne___Lunear.Definições_dos_Modos
{
    internal class ModV2
    {
        internal static void AntiGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            var UsarNossoQparaAnti = vIter["AutoQ"].Cast<CheckBox>().CurrentValue;

            if (UsarNossoQparaAnti && sender.IsEnemy &&
                e.End.Distance(jogadorJoob) <= 350)
            {
                EloBuddy.Player.CastSpell(SpellSlot.Q,
                    e.End.Extend(EloBuddy.Player.Instance.Position, e.End.Distance(EloBuddy.Player.Instance) - 325)
                        .To3D());
            }
        }

        internal static void PorjetoBase(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (vIter["interrupter"].Cast<CheckBox>().CurrentValue)
            {
                if (vIter["interronperespell"].Cast<ComboBox>().CurrentValue == 0)
                {
                    if (e.DangerLevel == DangerLevel.High && E.IsReady() && sender.IsValidTarget(E.Range))
                    {
                        E.Cast(sender);

                    }
                }
            }
        }

        internal static void HomemInvible(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (vIter["interrupter"].Cast<CheckBox>().CurrentValue)
            {
                if (vIter["interronperespell"].Cast<ComboBox>().CurrentValue == 1)
                {
                    if (e.DangerLevel == DangerLevel.Medium && E.IsReady() && sender.IsValidTarget(E.Range))
                    {
                        E.Cast(sender);

                    }
                }
            }
        }

        internal static void JookerLoL(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (vIter["interrupter"].Cast<CheckBox>().CurrentValue)
            {
                if (vIter["interronperespell"].Cast<ComboBox>().CurrentValue == 2)
                {
                    if (e.DangerLevel == DangerLevel.Low && E.IsReady() && sender.IsValidTarget(E.Range))
                    {
                        E.Cast(sender);

                    }
                }
            }
        }

        internal static void CasteloDoReiArthur(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe)
            {
                if (args.Slot == SpellSlot.R)
                    if (vCombo["QeR"].Cast<CheckBox>().CurrentValue && Q.IsReady())
                    {
                        EloBuddy.Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                    }
            }
        }

        internal static void BorResetaOSeusAtacks(Obj_AI_Base sender, PlayerIssueOrderEventArgs Vocequebromeuovo)
        {
            if (sender.IsMe && vCombo["ResetAA"].Cast<CheckBox>().CurrentValue
                && (Vocequebromeuovo.Order == GameObjectOrder.AttackUnit || Vocequebromeuovo.Order == GameObjectOrder.AttackTo)
                &&
                (jogadorJoob.CountEnemiesInRange(1000f) >=
                 vCombo["Joberr"].Cast<Slider>().CurrentValue)
                && UltActive() || Player.HasBuffOfType(BuffType.Invisibility)
                && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Vocequebromeuovo.Process = false;
            }
        }
    }
}