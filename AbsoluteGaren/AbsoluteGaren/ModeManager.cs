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
        static AIHeroClient _player => Player.Instance;

        public static void Combo()
        {
            if (MenuManager.Menu.GetCheckBoxValue("comboQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget(_player.GetAutoAttackRange())
                    && _player.IsInRange(a, _player.GetAutoAttackRange())
                    && a.Health >= MenuManager.percentHealth
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.Menu.GetCheckBoxValue("comboE") && SpellManager.E.IsReady()
                && SpellManager.E.Name != "GarenECancel"
                && _player.CountEnemyMinionsInRange(SpellManager.E.Range) > 0)
                SpellManager.E.Cast();
        }

        public static void LaneClear()
        {
            if (MenuManager.Menu.GetCheckBoxValue("laneQ") && SpellManager.Q.IsReady())
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

            if (MenuManager.Menu.GetCheckBoxValue("laneE") && SpellManager.E.IsReady()
                && SpellManager.E.Name != "GarenECancel"
                && _player.CountEnemyMinionsInRange(SpellManager.E.Range) > 1)
                SpellManager.E.Cast();
        }

        public static void LastHit()
        {
            if (MenuManager.Menu.GetCheckBoxValue("lasthitQ") && SpellManager.Q.IsReady())
            {
                Obj_AI_Base target = EntityManager.MinionsAndMonsters.EnemyMinions
                    .OrderByDescending(a => a.FlatGoldRewardMod)
                    .ThenBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                    && _player.IsInAutoAttackRange(a)
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
            if (MenuManager.Menu.GetCheckBoxValue("jungleQ") && SpellManager.Q.IsReady())
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

            if (MenuManager.Menu.GetCheckBoxValue("jungleE") && SpellManager.E.IsReady()
                && SpellManager.E.Name != "GarenECancel"
                && _player.CountJungleCreaturesInRange(SpellManager.E.Range) > 1)
                SpellManager.E.Cast();
        }

        public static void KillSteal()
        {
            if (MenuManager.Menu.GetCheckBoxValue("ksAA"))
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
            else if (MenuManager.Menu.GetCheckBoxValue("ksQ") && SpellManager.Q.IsReady())
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

            if (MenuManager.Menu.GetCheckBoxValue("ksR") && SpellManager.R.IsReady())
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
            if (MenuManager.Menu.GetCheckBoxValue("destroy") && SpellManager.Q.IsReady())
            {
                List<GameObjectType> list = new List<GameObjectType> { GameObjectType.obj_AI_Turret,
                GameObjectType.obj_Barracks, GameObjectType.obj_HQ};

                Obj_AI_Base turret = ObjectManager.Get<Obj_AI_Base>()
                    .Where(a => a.IsValidTarget()
                    && a.IsEnemy
                    && list.Contains(a.Type)
                    && _player.CountEnemyChampionsInRange(a.GetAutoAttackRange()) == 0
                    && _player.IsInAutoAttackRange(a)
                    && (a.HealthPercent >= MenuManager.percentHealth
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
            if (MenuManager.Menu.GetCheckBoxValue("cleanseQ") && SpellManager.Q.IsReady())
            {
                if (_player.HasBuffOfType(BuffType.Slow))
                    SpellManager.Q.Cast();
            }
        }
    }
}
