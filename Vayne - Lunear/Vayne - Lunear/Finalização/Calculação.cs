using EloBuddy;
using EloBuddy.SDK;


namespace Vayne___Lunear.Finalização
{
    class Calculação
    {
        public static double QCalculação(Obj_AI_Base target)
        {
            return VayneTy.JogadorJoob.CalculateDamageOnUnit(target, DamageType.Physical,
                (float)
                    new[] { 0.3, 0.35, 0.4, 0.45, 0.5 }[
                        //Achados e Perdidos Na Rota Superios Das SpellShot.Q proteção Maxima
                        //Pode até Calclular muito baixo pro isso tenho que troca extenção do ELobbudy entre os outros Script.
                        VayneTy.JogadorJoob.Spellbook.GetSpell(SpellSlot.Q).Level - 1] *
                        //AutoAtack Doi Desligado Durante atualização do League of Legens
                VayneTy.JogadorJoob.TotalAttackDamage);
        }

        public static double ECalculação(Obj_AI_Base target)
        {
            return VayneTy.JogadorJoob.CalculateDamageOnUnit(target, DamageType.Physical,
                new[] { 45, 80, 115, 150, 185 }[
                    //Quedas Que ocorrem no servidor Beeta Garena (Infelizmente)
                    VayneTy.JogadorJoob.Spellbook.GetSpell(SpellSlot.E).Level - 1] *
                VayneTy.JogadorJoob.TotalAttackDamage);
        }

        public static float WFocusCalculação(Obj_AI_Base target)
        {
            var dmg = VayneTy.W.Level * 10 + 10 + (0.03 + VayneTy.W.Level * 0.01) * target.MaxHealth;
            return (float)dmg;
        }
    }
}
  