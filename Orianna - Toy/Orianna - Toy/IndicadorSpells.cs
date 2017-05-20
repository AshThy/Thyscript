using System;
using EloBuddy;
using EloBuddy.SDK;
using static Orianna___Toy.Menus;
using static Orianna___Toy.Spells;

namespace Orianna___Toy
{
    class IndicadorSpells
    {
        private static object target;
       

        private static AIHeroClient Orianna => Player.Instance;
        public static float VejoSuaHP(Obj_AI_Base e, int d = 250) => Prediction.Health.GetPrediction(e, d);
        public static float Q(Obj_AI_Base e)
        {
            float Vagalinda = 0;

            if (Spells.Q.IsReady())
            {
                var SedezRapidoeFacil = Player.GetSpell(SpellSlot.Q).Level - 1;
                var Good = new float[] { 60, 90, 120, 150, 180 }[SedezRapidoeFacil];
                var PoderDeHabilidade = 0.5f * Orianna.FlatMagicDamageMod;

                Vagalinda = Good + PoderDeHabilidade;
            }

            return Orianna.CalculateDamageOnUnit(e, DamageType.Magical, Vagalinda);
        }
        public static float W(Obj_AI_Base e)
        {
            float Minhamae = 0;

            if (Spells.W.IsReady())
            {
                var SedexRapidoeFacil = Player.GetSpell(SpellSlot.W).Level - 1;
                var GoddMi = new float[] { 75, 115, 160, 205, 250 }[SedexRapidoeFacil];
                var PoderdeHabilidade = 0.7f * Orianna.FlatMagicDamageMod;

                Minhamae = GoddMi + PoderdeHabilidade;
            }

            return Orianna.CalculateDamageOnUnit(e, DamageType.Magical, Minhamae);
        }

        public static float R(Obj_AI_Base e)
        {
            float Démeurabo = 0;

            if (Spells.R.IsReady())
            {
                var Vagabundo = Player.GetSpell(SpellSlot.R).Level - 1;
                var BNãoseiireuneu = new float[] { 150, 225, 300 }[Vagabundo];
                var PoderFinal = 0.7f * Orianna.FlatMagicDamageMod;

                Démeurabo = BNãoseiireuneu + PoderFinal;
            }

            return Orianna.CalculateDamageOnUnit(e, DamageType.Magical, Démeurabo);
        }
    }
}