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

        internal static void Iniciar()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 825, SkillShotType.Circular, 1, 1200, 175)
            {
                AllowedCollisionCount = -1,
            };
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 1100);
            R = new Spell.Active(SpellSlot.R);
        }
    }
}