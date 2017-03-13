using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace AbsoluteGaren
{
    class Program
    {
        static AIHeroClient _player;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        
        static void Loading_OnLoadingComplete(EventArgs args)
        {
            // Initialize player object
            _player  = Player.Instance;
            SpellManager._player = _player;
            ModeManager._player = _player;
            
            // Validate champion instance
            if (!_player.VerifyHero(Champion.Garen)) return;

            // Initialize classes
            SpellManager.Initialize();
            MenuManager.Initialize();

            // Activate events
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
        }

        static void Game_OnTick(EventArgs args)
        {
            SpellManager.SpellConfig();

            if (_player.IsDead) return;

            SpellManager.hasPerformedAction = false;

            if (!_player.IsRecalling())
            {
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                    ModeManager.Combo();
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                    ModeManager.LaneClear();
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                    ModeManager.LastHit();
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                    ModeManager.JungleClear();
                
                ModeManager.Destroyer();
                ModeManager.Passives();
            }

            ModeManager.KillSteal();
        }

        static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            SpellManager.LastAutoTime = Game.Time;
        }

        static void Drawing_OnDraw(EventArgs args)
        {
            if (_player.IsDead && Game.Time < 10) return;

            if (MenuManager.Rendering.GetCheckBoxValue("killable"))
            {
                foreach (AIHeroClient target in EntityManager.Heroes.Enemies.Where(a => a.IsValidTarget()
                    && a.Health <= SpellManager.FullDamage(a) + _player.GetActiveItemDamage(a)))
                {
                    Drawing.DrawText(target.Position.WorldToScreen(), Color.Red, "Killable", 15);
                }
            }
        }

        static void Drawing_OnEndScene(EventArgs args)
        {
            if (_player.IsDead) return;

            if (MenuManager.Rendering.GetCheckBoxValue("enemy"))
            {
                List<Obj_AI_Base> units = EntityManager.Heroes.Enemies.ToObj_AI_BaseList();

                foreach (Obj_AI_Base target in units.Where(a => a.IsValidTarget() && a.IsHPBarRendered))
                {
                    float damage = 0;

                    if (MenuManager.Rendering.GetCheckBoxValue("spell_dmg"))
                        damage += SpellManager.FullDamage(target);
                    if (MenuManager.Rendering.GetCheckBoxValue("item_dmg"))
                        damage += _player.GetActiveItemDamage(target);

                    target.RenderHPBar(damage);
                }
            }

            if (MenuManager.Rendering.GetCheckBoxValue("player"))
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health).ThenBy(a => _player.Distance(a))
                    .Where(a => a.IsValidTarget()).FirstOrDefault();

                float heal = 0;

                if (MenuManager.Rendering.GetCheckBoxValue("item_dmg"))
                    heal += _player.GetActiveItemHealing(target);

                _player.RenderHPBar(heal);
            }
        }
    }
}