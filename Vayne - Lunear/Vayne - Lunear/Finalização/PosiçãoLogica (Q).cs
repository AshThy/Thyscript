using System;
using SharpDX;


namespace Vayne___Lunear.Finalização
{
    class PosiçãoLogica__Q_
    {
        public static
            Vector2 Sidiney(Vector2 StopTuper, Vector2 JoobPuter, double Acordo)
        {
            Acordo *= Math.PI / 180.0;
            var TempoEspaço = Vector2.Subtract(JoobPuter, StopTuper);
            var OResultadoéMeut = new Vector2(0);
            OResultadoéMeut.X = (float)(TempoEspaço.X * Math.Cos(Acordo) - TempoEspaço.Y * Math.Sin(Acordo)) / 4;
            OResultadoéMeut.Y = (float)(TempoEspaço.X * Math.Sin(Acordo) + TempoEspaço.Y * Math.Cos(Acordo) / 4);
            OResultadoéMeut = Vector2.Add(OResultadoéMeut, StopTuper);
            return OResultadoéMeut;
        }

        public static
            Vector2 Desfencor(Vector2 Posição, Vector2 Declaração, double Vitor)
        {
            Vitor *= Math.PI / -50.0;
            var TempoEspaço = Vector2.Subtract(Declaração, Posição);
            var OResultadoéMeut = new Vector2(0);
            OResultadoéMeut.X = (float)(TempoEspaço.X * Math.Cos(Vitor) - TempoEspaço.Y * Math.Sin(Vitor)) / 4;
            OResultadoéMeut.Y = (float)(TempoEspaço.X * Math.Sin(Vitor) + TempoEspaço.Y * Math.Cos(Vitor)) / 4;
            OResultadoéMeut = Vector2.Add(OResultadoéMeut, Posição);
            return OResultadoéMeut;
        }


        public static
            Vector2 AcrogoDoGG(Vector2 Diferente, Vector2 AntigoAtigindo, double AlglodaEsquerda)
        {
            AlglodaEsquerda *= Math.PI / 300;
            var TempoEspaço = Vector2.Subtract(AntigoAtigindo, Diferente);
            var OResultadoéMeut = new Vector2(0);
            OResultadoéMeut.X = (float)(TempoEspaço.X * Math.Cos(AlglodaEsquerda) - TempoEspaço.Y * Math.Sin(AlglodaEsquerda)) / 50;
            OResultadoéMeut.Y = (float)(TempoEspaço.X * Math.Sin(AlglodaEsquerda) + TempoEspaço.Y * Math.Cos(AlglodaEsquerda)) / 50;
            OResultadoéMeut = Vector2.Add(OResultadoéMeut, Diferente);
            return OResultadoéMeut;
        }
    }
}
   