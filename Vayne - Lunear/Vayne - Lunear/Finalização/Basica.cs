using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;


namespace Vayne___Lunear.Finalização
{
    public static partial class Basica
    {

        public static AIHeroClient JogadorJoob
        {
            get { return ObjectManager.Player; }
        }
        public static bool DepoisDoAtaqueesquerdo;
        public static bool AntesDoAtqueDireito;
        //Safado
        public static bool Forçadoparamatarocaulcação(Vector2 ArrozFeijãoSaladaeMacarrão)
        {
            return EntityManager.Turrets.Enemies.Where(a => a.Health > 0 && !a.IsDead).Any(a => a.Distance(ArrozFeijãoSaladaeMacarrão) < 950);
        }

        public static bool UverBasicodacalculaçãoexterna(this Vector3 PossiçãoDoInimigo)
        {
            return ObjectManager.Get<Obj_AI_Turret>().Any(t => t.IsAlly && !t.IsDead);
        }

        public static IEnumerable<AIHeroClient> MeleeEnemiesTowardsMe
        {
            get
            {
                return

                    EntityManager.Heroes.Enemies.FindAll(
                        m => m.IsMelee && m.Distance(Basica.JogadorJoob) <= JogadorJoob.GetAutoAttackRange(m)
                             &&
                             (m.ServerPosition.To2D() + (m.BoundingRadius + 25f) * m.Direction.To2D().Perpendicular())
                                 .Distance(Basica.JogadorJoob.ServerPosition.To2D()) <=
                             m.ServerPosition.Distance(Basica.JogadorJoob.ServerPosition)
                             && m.IsValidTarget(1200, false));
            }
        }

        public static IEnumerable<AIHeroClient> EnemiesClose => EntityManager.Heroes.Enemies.Where(
                        m =>
                            m.Distance(ObjectManager.Player, true) <= Math.Pow(1000, 2) && m.IsValidTarget(1500, false) &&
                            m.CountEnemiesInRange(m.IsMelee ? m.AttackRange * 1.5f : m.AttackRange + 20 * 1.5f) > 0);

        public static List<AIHeroClient> GetLhEnemiesNear(this Vector3 PosiçãodoIi, float RangerDOqUE, float NãouitlizaRio)
        {
            return
                EntityManager.Heroes.Enemies.Where(
                    hero => hero.IsValidTarget(RangerDOqUE, true, PosiçãodoIi) && hero.HealthPercent <= NãouitlizaRio).ToList();
        }
    }
}

   