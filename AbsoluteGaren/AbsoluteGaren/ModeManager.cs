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
    class ModeManager
    {
        public static float LastAutoTime = 0;
        public static AIHeroClient _player;

        public static void Combo()
        {
            if (MenuManager.Combo.GetCheckBoxValue("comboQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget(_player.GetAutoAttackRange())
                    && _player.IsInRange(a, _player.GetAutoAttackRange())
                    && a.Health >= MenuManager.percentHealth
                    && Game.Time - LastAutoTime < 0.1f
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.Combo.GetCheckBoxValue("comboE") && SpellManager.E.IsReady()
                && SpellManager.E.Name != "GarenECancel"
                && _player.CountEnemyChampionsInRange(SpellManager.E.Range) > 0)
                SpellManager.E.Cast();
        }

        public static void LaneClear()
        {
            if (MenuManager.LaneClear.GetCheckBoxValue("laneQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.MinionsAndMonsters.EnemyMinions
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                    && _player.IsInAutoAttackRange(a)
                    && ((a.HealthPercent >= MenuManager.percentHealth
                    && Game.Time - LastAutoTime < 0.1f)
                    || a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a))
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.LaneClear.GetCheckBoxValue("laneE") && SpellManager.E.IsReady()
                && SpellManager.E.Name != "GarenECancel"
                && _player.CountEnemyMinionsInRange(SpellManager.E.Range) > 1)
                SpellManager.E.Cast();
        }

        public static void LastHit()
        {
            if (MenuManager.LastHit.GetCheckBoxValue("lasthitQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.MinionsAndMonsters.EnemyMinions
                    .OrderByDescending(a => a.FlatGoldRewardMod)
                    .ThenBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                    && _player.IsInAutoAttackRange(a)
                    && a.Health > _player.GetAutoAttackDamage(a)
                    && a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a)
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }
        }

        public static void JungleClear()
        {
            if (MenuManager.JungleClear.GetCheckBoxValue("jungleQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.MinionsAndMonsters.Monsters
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                    && a.IsLargeMonster()
                    && _player.IsInAutoAttackRange(a)
                    && ((a.HealthPercent >= MenuManager.percentHealth
                    && Game.Time - LastAutoTime < 0.1f)
                    || a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a))
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.JungleClear.GetCheckBoxValue("jungleE") && SpellManager.E.IsReady()
                && SpellManager.E.Name != "GarenECancel"
                && _player.CountJungleCreaturesInRange(SpellManager.E.Range) > 1)
                SpellManager.E.Cast();
        }

        public static void KillSteal()
        {
            if (MenuManager.KillSteal.GetCheckBoxValue("ksAA"))
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget(_player.GetAutoAttackRange())
                    && _player.IsInRange(a, _player.GetAutoAttackRange())
                    && a.Health <= _player.GetAutoAttackDamage(a)
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }
            else if (MenuManager.KillSteal.GetCheckBoxValue("ksQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget(_player.GetAutoAttackRange())
                    && _player.IsInRange(a, _player.GetAutoAttackRange())
                    && a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a)
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.KillSteal.GetCheckBoxValue("ksR") && SpellManager.R.IsReady())
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget(SpellManager.R.Range)
                    && _player.IsInRange(a, SpellManager.R.Range)
                    && a.Health <= SpellManager.RDamage(a)
                    ).FirstOrDefault();

                if (target != null)
                    SpellManager.R.Cast(target);
            }
        }

        public static void Destroyer()
        {
            if (MenuManager.Settings.GetCheckBoxValue("destroy") && SpellManager.Q.IsReady())
            {
                List<GameObjectType> list = new List<GameObjectType> { GameObjectType.obj_AI_Turret,
                GameObjectType.obj_Barracks, GameObjectType.obj_HQ};

                Obj_AI_Base turret = ObjectManager.Get<Obj_AI_Base>()
                    .Where(a => a.IsValidTarget()
                    && a.IsEnemy
                    && list.Contains(a.Type)
                    && _player.CountEnemyChampionsInRange(a.GetAutoAttackRange()) == 0
                    && _player.IsInAutoAttackRange(a)
                    && ((a.HealthPercent >= MenuManager.percentHealth
                    && Game.Time - LastAutoTime < 0.1f)
                    || a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a))
                    ).FirstOrDefault();

                if (turret != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, turret);
                }
            }
        }

        public static void Passives()
        {
            if (MenuManager.Settings.GetCheckBoxValue("cleanseQ") && SpellManager.Q.IsReady())
            {
                if (_player.HasBuffOfType(BuffType.Slow))
                    SpellManager.Q.Cast();
            }
        }
    }
}
