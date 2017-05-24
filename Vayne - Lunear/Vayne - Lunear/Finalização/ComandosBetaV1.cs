using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Vayne___Lunear.Finalização
{
   static class ComandosBetaV1
    {
        public static AIHeroClient jogadorJoob
        {
            get { return ObjectManager.Player; }
        }

        public static long UtimiHitemverificação;
        public static int ChecagemDaSpell;
        //Utilização do E Spell da Partida Passa Funcoina COM SUcesso mas não o seu cotem nenhum tipo renilização para aquele cara pensar nisso.
        public static Spell.Skillshot EextençãodaSpell;

        public static bool ExtençãodeObjeto(this AIHeroClient OlhaSó, Vector2 VejaBem = new Vector2())
        {
            if (OlhaSó.HasBuffOfType(BuffType.SpellImmunity) || OlhaSó.HasBuffOfType(BuffType.SpellShield) ||
                UtimiHitemverificação + 50 > Environment.TickCount || jogadorJoob.IsDashing()) return false;
            var PrevisãodoMeuRabo = EextençãodaSpell.GetPrediction(OlhaSó);
            var previsão = VejaBem.IsValid()
                ? new List<Vector3>() { VejaBem.To3D() }
                : new List<Vector3>
                {
                    OlhaSó.ServerPosition,
                    OlhaSó.Position,
                    PrevisãodoMeuRabo.CastPosition,
                    PrevisãodoMeuRabo.UnitPosition
                };

            var Cordenação = 0;
            VayneTy.PosiçãoDoInimigo = new List<Vector2>();
            foreach (var position in previsão)
            {
                for (var terounãotero = 0;
                    terounãotero < VayneTy.vKil["GoodPush"].Cast<Slider>().CurrentValue;
                    terounãotero += (int)OlhaSó.BoundingRadius)
                {
                    var cPos = jogadorJoob.Position.Extend(position, jogadorJoob.Distance(position) + terounãotero).To3D();
                    VayneTy.PosiçãoDoInimigo.Add(cPos.To2D());
                    if (NavMesh.GetCollisionFlags(cPos).HasFlag(CollisionFlags.Wall) ||
                        NavMesh.GetCollisionFlags(cPos).HasFlag(CollisionFlags.Building))
                    {
                        Cordenação++;
                        break;
                    }
                }
            }
            if ((Cordenação / previsão.Count) >= VayneTy.vKil["Precentir"].Cast<Slider>().CurrentValue / 100f)
            {
                return true;
            }

            return false;
        }

        public static Vector2 PrimeiraClasse(Vector2 GoodRetriver, Vector2 VocêLeuIsso)
        {
            int declaraçãodadistancia = 0;
            for (int i = 0; i < VayneTy.vKil["GoodPush"].Cast<Slider>().CurrentValue; i += 20)
            {
                var ceuémeurabo = GoodRetriver.Extend(VocêLeuIsso, VocêLeuIsso.Distance(GoodRetriver) + i);
                if (NavMesh.GetCollisionFlags(ceuémeurabo).HasFlag(CollisionFlags.Wall) ||
                    NavMesh.GetCollisionFlags(ceuémeurabo).HasFlag(CollisionFlags.Building))
                {
                    declaraçãodadistancia = i - 20;
                }
            }
            return GoodRetriver.Extend(VocêLeuIsso, declaraçãodadistancia + VocêLeuIsso.Distance(GoodRetriver));
        }
    }
}
    