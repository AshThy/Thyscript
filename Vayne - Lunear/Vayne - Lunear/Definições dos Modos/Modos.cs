using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Vayne___Lunear.VayneTy;
using static Vayne___Lunear.Finalização.ComandosBetaV1;
using SharpDX;

namespace Vayne___Lunear.Definições_dos_Modos
{

    internal class Modos
    {

        internal static void Atualização(EventArgs args)
        {
            Orbwalker.ForcedTarget = null;

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {

                ComboDaUtilizaçãodoR();
                BustarOInimgo();
                Codernação();
                FocaçãoTargetW();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {

            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                LaneClear();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                JungleClear();
            }

            KillSteal();
        }

        private static void KillSteal()
        {
            foreach (
                var Inimigos in
                    EntityManager.Heroes.Enemies.Where(
                        e => e.Distance(jogadorJoob) <= E.Range && e.IsValidTarget(1000) && !e.IsInvulnerable))
            {
                if (vKil["EKillSteal"].Cast<CheckBox>().CurrentValue && E.IsReady() &&
                    jogadorJoob.GetSpellDamage(Inimigos, SpellSlot.E) >= Inimigos.Health)
                {
                    E.Cast(Inimigos);
                }
            }
        }



        private static void JungleClear()
        {
            var QSpellNaNossaJungle = vJungle["QJungle"].Cast<CheckBox>().CurrentValue;
            var SentirAmana = vJungle["QMana"].Cast<Slider>().CurrentValue;
            foreach (
                var mob in
                    EntityManager.MinionsAndMonsters.Monsters.Where(
                        x => x.IsValid && !x.IsDead && x.Position.Distance(jogadorJoob) < jogadorJoob.GetAutoAttackRange(x)))
            {
                if (QSpellNaNossaJungle && Q.IsReady() && mob != null && mob.IsValidTarget(Q.Range) &&
                    jogadorJoob.ManaPercent >= SentirAmana)
                {
                    EloBuddy.Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                }
            }
        }
    


        private static void LaneClear()
        {
            var UsarSpellQ = vLane["QLane"].Cast<CheckBox>().CurrentValue;
            var QManaDoCmapião = vLane["QMana"].Cast<Slider>().CurrentValue;

            if (Q.IsReady() && UsarSpellQ && jogadorJoob.ManaPercent >= QManaDoCmapião)
            {
                var MinionsENossoaQuueridosMonters = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                   jogadorJoob.Position, jogadorJoob.GetAutoAttackRange());
                foreach (var minions in
                    MinionsENossoaQuueridosMonters.Where(
                        minions => minions.Health < Finalização.Calculação.QCalculação(minions)))
                {
                    if (minions != null)
                    {
                        Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                    }
                }
            }
        }

        private static void FocaçãoTargetW()
        {
            var FocaçãoNoW = vCombo["FocusW"].Cast<CheckBox>().CurrentValue;
            var TragetoriaDoW = EntityManager.Heroes.Enemies.FirstOrDefault(
                    h =>
                        h.ServerPosition.Distance(jogadorJoob.ServerPosition) < 600 &&
                        h.GetBuffCount("BugDelay") == 1);
            if (FocaçãoNoW && TragetoriaDoW.IsValidTarget())
            {
                Orbwalker.ForcedTarget = TragetoriaDoW;
            }
        }

        private static void Codernação()
        {
            var DistiaçãodoInimigo = vKil["GoodPush"].Cast<Slider>().CurrentValue;

            if (vCombo["UsarE"].Cast<ComboBox>().CurrentValue == 0 && E.IsReady())
                foreach (
                    var InimigoSafado in
                        from enemy in ObjectManager.Get<AIHeroClient>().Where(enemy => enemy.IsValidTarget(550f))
                        let prediction = EDeclaraçãoParaoInimigo.GetPrediction(enemy)
                        where NavMesh.GetCollisionFlags(
                            prediction.UnitPosition.To2D().Extend(ObjectManager.Player.ServerPosition.To2D(), -DistiaçãodoInimigo).To3D()).HasFlag(CollisionFlags.Wall) || NavMesh.GetCollisionFlags(
                                prediction.UnitPosition.To2D().Extend(ObjectManager.Player.ServerPosition.To2D(), -(DistiaçãodoInimigo / 2)).To3D())
                         .HasFlag(CollisionFlags.Wall)
                        select enemy)
                {
                    E.Cast(InimigoSafado);
                }
        }

        internal static void DespoisDoAtauqe(AttackableUnit target, EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && target.IsValid)
                if (Q.IsReady() && vCombo["Qcombo"].Cast<ComboBox>().CurrentValue == 0 &&
                    !ForçãoDoPoderosoTorrente((Vector2)jogadorJoob.Position))
                {
                    EloBuddy.Player.CastSpell(SpellSlot.Q,
                        Finalização.PosiçãoLogica__Q_.Sidiney(jogadorJoob.Position.To2D(), target.Position.To2D(), 65).To3D());
                    Orbwalker.ResetAutoAttack();
                }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && target.IsValid)
                if (Q.IsReady() && vCombo["Qcombo"].Cast<ComboBox>().CurrentValue == 1 &&
                    !ForçãoDoPoderosoTorrente((Vector2)jogadorJoob.Position))
                {
                    EloBuddy.Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                    Orbwalker.ResetAutoAttack();
                }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && target.IsValid)
                if (Q.IsReady() && vCombo["Qcombo"].Cast<ComboBox>().CurrentValue == 2 &&
                    !ForçãoDoPoderosoTorrente((Vector2)jogadorJoob.Position))
                    if (jogadorJoob.Position.Extend(Game.CursorPos, 700).CountEnemiesInRange(700) <= 1)
                    {
                        EloBuddy.Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                        Orbwalker.ResetAutoAttack();
                    }
        }
    

        private static void BustarOInimgo()
        {
            var TraçãodoCorretor = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            if (!TraçãodoCorretor.IsValidTarget())
            {
                return;
            }
            if (Q.IsReady() && vCombo["Qcombo"].Cast<ComboBox>().CurrentValue == 3 && TraçãodoCorretor.IsValidTarget(600) &&
                TraçãodoCorretor.GetBuffCount("BugDelay") == 2 && !ForçãoDoPoderosoTorrente((Vector2)jogadorJoob.Position))
            {
                EloBuddy.Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                Orbwalker.ResetAutoAttack();
            }
        }
  

        private static void ComboDaUtilizaçãodoR()
        {
            var RDosInimigos = vCombo["RC"].Cast<Slider>().CurrentValue;
            var UtilizarRCombo = vCombo["RCombo"].Cast<CheckBox>().CurrentValue;
            var TraçãodoRCombo = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if (UtilizarRCombo && jogadorJoob.CountEnemiesInRange(jogadorJoob.AttackRange + 350) >= RDosInimigos && R.IsReady()
                && TraçãodoRCombo != null)
            {
                R.Cast();
            }
        }
    }
}
