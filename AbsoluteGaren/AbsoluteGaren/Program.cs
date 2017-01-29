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
            // Initialize player object
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
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
        }

        private static void Game_OnTick(EventArgs args)
        {
            MenuManager.MenuConfig();

            if (Player.Instance.IsAlive())
            {
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                    ModeManager.Combo();
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                    ModeManager.LaneClear();
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                    ModeManager.LastHit();
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                    ModeManager.JungleClear();

                ModeManager.Passives();
                ModeManager.Destroyer();
                ModeManager.KillSteal();
            }
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            ModeManager.LastAutoTime = Game.Time;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (_player.IsAlive())
            {
                if (MenuManager.Drawing.GetCheckBoxValue("killable"))
                {
                    foreach (AIHeroClient target in EntityManager.Heroes.Enemies
                        .Where(a => a.IsValidTarget() && a.Health <= SpellManager.FullDamage(a) + _player.GetActiveItemDamage(a)))
                        Drawing.DrawText(target.Position.WorldToScreen(), Color.Red, "Killable", 15);
                }
            }
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            if (_player.IsAlive()
                && MenuManager.Drawing.GetCheckBoxValue("render"))
            {
                foreach (AIHeroClient target in EntityManager.Heroes.Enemies.Where(a => a.IsValidTarget()))
                {
                    float damage = 0;
                    int targetHPBarWidth = 96;

                    if (MenuManager.Drawing.GetCheckBoxValue("renderS"))
                        damage += SpellManager.FullDamage(target);

                    if (MenuManager.Drawing.GetCheckBoxValue("renderI"))
                        damage += _player.GetActiveItemDamage(target);

                    float targetDamageAmount = Math.Max((100 * (target.Health - damage)) / target.MaxHealth, 0);

                    Vector2 targetHPBarOffset = new Vector2(2, 9.5f);
                    Vector2 targetHPCurrentOffset = target.HPBarPosition + targetHPBarOffset
                        + new Vector2(100 * target.HealthPercent / targetHPBarWidth, 0);
                    Vector2 targetHPEndOffset = target.HPBarPosition + targetHPBarOffset
                        + new Vector2(targetDamageAmount, 0);

                    Drawing.DrawLine(targetHPCurrentOffset, targetHPEndOffset, 9, Color.Yellow);
                }
            }
        }
    }
}
