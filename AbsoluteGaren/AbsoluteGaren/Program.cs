using System;
using System.Linq;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;


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
            SpellManager.SpellConfig();

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
                if (MenuManager.Rendering.GetCheckBoxValue("killable"))
                {
                    foreach (AIHeroClient target in EntityManager.Heroes.Enemies
                        .Where(a => a.IsValidTarget() 
                        && a.Health <= SpellManager.FullDamage(a) + _player.GetActiveItemDamage(a)))
                        Drawing.DrawText(target.Position.WorldToScreen(), Color.Red, "Killable", 15);
                }
            }
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            if (_player.IsAlive())
            {
                /*if (MenuManager.Rendering.GetCheckBoxValue("renderP"))
                {
                    float damage = 0;

                    if (_player.IsHPBarRendered)
                    {
                        if (MenuManager.Rendering.GetCheckBoxValue("renderI_heal"))
                            damage += _player.GetActiveItemHealing();

                        _player.RenderHPBar(damage);
                    }
                }

                if (MenuManager.Rendering.GetCheckBoxValue("renderA"))
                {
                    float damage = 0;
                    List<Obj_AI_Base> units = EntityManager.Heroes.Allies.ToObj_AI_BaseList();

                    foreach (AIHeroClient unit in units.Where(a => a.IsValidTarget() && a.IsHPBarRendered))
                    {
                        if (MenuManager.Rendering.GetCheckBoxValue("renderI_heal"))
                            damage += _player.GetActiveItemHealing();

                        unit.RenderHPBar(damage);
                    }
                }*/

                if (MenuManager.Rendering.GetCheckBoxValue("renderE"))
                {
                    float damage = 0;
                    List<Obj_AI_Base> units = EntityManager.Heroes.Enemies.ToObj_AI_BaseList();

                    foreach (AIHeroClient unit in units.Where(a => a.IsValidTarget() && a.IsHPBarRendered))
                    {
                        if (MenuManager.Rendering.GetCheckBoxValue("renderS_dmg"))
                            damage += SpellManager.FullDamage(unit);

                        if (MenuManager.Rendering.GetCheckBoxValue("renderI_dmg"))
                            damage += _player.GetActiveItemDamage(unit);

                        unit.RenderHPBar(damage);
                    }
                }
            }
        }
    }
}
