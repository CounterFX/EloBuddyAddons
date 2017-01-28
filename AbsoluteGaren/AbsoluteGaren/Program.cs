using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Spells;
using SharpDX;

namespace AbsoluteGaren
{
    class Program
    {
        static Champion _champion = Champion.Garen;
        static AIHeroClient _player;

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            // Assign player object
            _player = Player.Instance;
            ModeManager._player = _player;
            
            // Validate champion instance
            if (!_player.VerifyHero(_champion))
                return;

            // Initialize classes
            SpellManager.Initialize();
            MenuManager.Initialize();

            // Activate events
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            ModeManager.LastAutoTime = Game.Time;
        }

        private static void Game_OnTick(EventArgs args)
        {
            MenuManager.MenuConfig();

            if (Player.Instance.IsAlive())
            {
                if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Combo)
                    ModeManager.Combo();
                if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.LaneClear)
                    ModeManager.LaneClear();
                if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.LastHit)
                    ModeManager.LastHit();
                if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.JungleClear)
                    ModeManager.JungleClear();

                ModeManager.Passives();
                ModeManager.Destroyer();
                ModeManager.KillSteal();
            }
        }
    }
}
