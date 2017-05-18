using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK;

namespace Ziggs___Beta
{
    internal class Spells
    {
        
        private static Spell.Skillshot Q,W,E,R;
       
        internal static void Iniciar()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 850, SkillShotType.Circular, 30, 1700, 130);
            W = new Spell.Skillshot(SpellSlot.W, 1000, SkillShotType.Circular, 25, 1750, 275);
            E = new Spell.Skillshot(SpellSlot.E, 900, SkillShotType.Circular, 50, 1750, 100);
            R = new Spell.Skillshot(SpellSlot.R, 5300, SkillShotType.Circular, 2000, 1500, 500);

            DamagerIndicador.Iniciar();
            
        }
    }
}