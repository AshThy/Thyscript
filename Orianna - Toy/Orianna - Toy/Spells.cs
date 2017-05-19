using System;
using EloBuddy.SDK;
using EloBuddy;
using EloBuddy.SDK.Enumerations;

namespace Orianna___Toy
{
    internal class Spells
    {
        public static Spell.Skillshot Q;
        public static Spell.Active W, R;
        public static Spell.Targeted E;
        public static Spell.Targeted Ignite;

        internal static void Iniciar()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 825, SkillShotType.Circular, 1, 1200, 175)
            {
                AllowedCollisionCount = -1,
            };
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 1100);
            R = new Spell.Active(SpellSlot.R);

            var shollt = Player.Instance.GetSpellSlotFromName("summonerdot");
            if (shollt != SpellSlot.Unknown)
                Ignite = new Spell.Targeted(shollt, 600);
        }
    }
}