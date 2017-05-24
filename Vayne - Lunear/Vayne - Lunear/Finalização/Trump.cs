using System;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using static Vayne___Lunear.VayneTy;
using Color = System.Drawing.Color;


namespace Vayne___Lunear.Finalização
{
    internal class Trump
    {
        //Teste
        internal static void OnDraw(EventArgs args)
        {
            if (VayneTy.vDraw["UnicoDraw"].Cast<CheckBox>().CurrentValue)
            {
                new Circle { Color = Color.LightCyan, Radius = E.Range, BorderWidth = 2f }.Draw(VayneTy.JogadorJoob.Position);
            }
        }
    }
}
    
