using System;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using System;
using System.Linq;

namespace Orianna___Toy
{
    internal class BolaEsquerda
    {
        public static Vector3 Bola;
        public static bool FlordoDia;
        private static Obj_GeneralParticleEmitter obj;
        private static AIHeroClient Orianna => Player.Instance;
        



        internal static void Iniciar()
        {
            Game.OnUpdate += Jogo_EmUpdate;
            GameObject.OnCreate += Criação;
        }
        public static class BoladoW
        {
            public static int CountEnemyMinionsNear => Bola != null ? Bola.CountEnemyMinionsInRangeWithPrediction(250, 250) : 0;
            public static int CountEnemyHeroesNear => Bola != null ? Bola.CountEnemyHeroesInRangeWithPrediction(250, 250) : 0;
            public const int DeleydaMinhaRola = 250;
            public const int Vadia = 250;

            public static bool IsInBall(Obj_AI_Base e) => e.IsInRange(Bola, Vadia);
        }

        public static class BoladoR
        {
            public static int CountEnemyMinionsNear => Bola != null ? Bola.CountEnemyMinionsInRangeWithPrediction(410, 750) : 0;
            public static int CountEnemyHeroesNear => Bola != null ? Bola.CountEnemyHeroesInRangeWithPrediction(410, 750) : 0;
            public const int DeleydaMinhaRola = 750;
            public const int Vadia = 410;

            public static bool IsInBall(Obj_AI_Base e) => e.IsInRange(Bola, Vadia);
        }

        private static void Criação(GameObject sender, EventArgs args)
        {
            var particle = obj as Obj_GeneralParticleEmitter;
            if (particle != null && particle.Name == "Orianna_Base_Q_yomu_ring_green.troy")
            {
                Bola = particle.Position;
                FlordoDia = true;
            }
        }

        private static void Jogo_EmUpdate(EventArgs args)
        {
            var AliadoProtegido = EntityManager.Heroes.Allies.Where(x => x.HasBuff("OrianaFlash")).FirstOrDefault();
            if (AliadoProtegido != null)
            {
                Bola = AliadoProtegido.Position;
                FlordoDia = false;
            }
        }
    }
}
