using System;
using EloBuddy.SDK.Events;
using EloBuddy;

namespace Orianna___Toy
{
    class Program
    {

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoad;
        }

        private static void OnLoad(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Orianna")
            {
                return;
            }


            Menus.Iniciar();
            Spells.Iniciar();
            BolaEsquerda.Iniciar();
            
                
            Game.OnTick += Menus.Game_OnTick;
            Drawing.OnDraw += Menus.Draw;
            Obj_AI_Base.OnBasicAttack += Menus.BasicAttack;
            Spellbook.OnCastSpell += Menus.Spellbook_OnCastSpell;
            
            }

        }
    }

