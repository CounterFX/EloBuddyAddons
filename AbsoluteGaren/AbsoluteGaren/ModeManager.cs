using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace AbsoluteGaren
{
    class ModeManager
    {
        public static float LastAutoTime = 0;
        public static AIHeroClient _player;

        public static void Combo()
        {
            if (MenuManager.Combo.GetCheckBoxValue("Q") && SpellManager.Q.IsReady()
                && !SpellManager.IsSpinning)
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, _player.GetAutoAttackRange())
                        && a.HealthPercent >= MenuManager.percentHealth
                        && LastAutoTime.IsWithinTime(0.5f)
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.Combo.GetCheckBoxValue("E") && SpellManager.E.IsReady()
                && _player.CountEnemyChampionsInRange(SpellManager.E.Range) > 0
                && !SpellManager.IsSpinning)
            {
                SpellManager.E.Cast();
            }
        }

        public static void LaneClear()
        {
            if (MenuManager.LaneClear.GetCheckBoxValue("Q") && SpellManager.Q.IsReady()
                && !SpellManager.IsSpinning)
            {
                List<Obj_AI_Base> targets = new List<Obj_AI_Base>();

                targets.AddRange(EntityManager.MinionsAndMonsters.EnemyMinions.ToObj_AI_BaseList());
                targets.AddRange(EntityManager.MinionsAndMonsters.OtherEnemyMinions.ToObj_AI_BaseList());

                Obj_AI_Base target = targets
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, _player.GetAutoAttackRange())
                        && ((a.HealthPercent >= MenuManager.percentHealth && LastAutoTime.IsWithinTime(0.5f))
                        || a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a))
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.LaneClear.GetCheckBoxValue("E") && SpellManager.E.IsReady()
                && _player.CountEnemyMinionsInRange(SpellManager.E.Range) > 1
                && !SpellManager.IsSpinning)
            {
                SpellManager.E.Cast();
            }
        }

        public static void LastHit()
        {
            if (MenuManager.LastHit.GetCheckBoxValue("Q") && SpellManager.Q.IsReady()
                && !SpellManager.IsSpinning)
            {
                List<Obj_AI_Base> targets = new List<Obj_AI_Base>();

                targets.AddRange(EntityManager.MinionsAndMonsters.EnemyMinions.ToObj_AI_BaseList());
                targets.AddRange(EntityManager.MinionsAndMonsters.Monsters.ToObj_AI_BaseList());
                targets.AddRange(EntityManager.MinionsAndMonsters.OtherEnemyMinions.ToObj_AI_BaseList());

                Obj_AI_Base target = targets
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, _player.GetAutoAttackRange())
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
            if (MenuManager.JungleClear.GetCheckBoxValue("Q") && SpellManager.Q.IsReady()
                && !SpellManager.IsSpinning)
            {
                Obj_AI_Base target = EntityManager.MinionsAndMonsters.Monsters
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, _player.GetAutoAttackRange())
                        && a.IsLargeMonster()
                        && ((a.HealthPercent >= MenuManager.percentHealth)
                        || a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a))
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.JungleClear.GetCheckBoxValue("E") && SpellManager.E.IsReady()
                && _player.CountMonstersInRange(SpellManager.E.Range) > 1
                && !SpellManager.IsSpinning)
            {
                SpellManager.E.Cast();
            }
        }

        public static void KillSteal()
        {
            if (MenuManager.KillSteal.GetCheckBoxValue("AA")
                && !SpellManager.HasQActive && !SpellManager.IsSpinning)
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.CanKillWithBasicAttack(a)
                    ).FirstOrDefault();

                if (target != null)
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
            }
            else if (MenuManager.KillSteal.GetCheckBoxValue("Q") && SpellManager.Q.IsReady()
                && !SpellManager.IsSpinning)
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, _player.GetAutoAttackRange())
                        && a.Health <= _player.GetAutoAttackDamage(a) + SpellManager.QDamage(a)
                    ).FirstOrDefault();

                if (target != null)
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }

            if (MenuManager.KillSteal.GetCheckBoxValue("R") && SpellManager.R.IsReady()
                && _player.CountEnemyChampionsInRange(SpellManager.R.Range) > 0)
            {
                Obj_AI_Base target = EntityManager.Heroes.Enemies
                    .OrderBy(a => a.HasBuff("garenpassiveenemytarget"))
                    .ThenBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, SpellManager.R.Range)
                        && a.Health <= SpellManager.RDamage(a)
                    ).FirstOrDefault();

                if (target != null)
                    SpellManager.R.Cast(target);
            }
        }

        public static void Destroyer()
        {
            if (MenuManager.Settings.GetCheckBoxValue("destroy") && !SpellManager.IsSpinning)
            {
                List<GameObjectType> list = new List<GameObjectType> { GameObjectType.obj_AI_Turret,
                GameObjectType.obj_Barracks, GameObjectType.obj_HQ};

                Obj_AI_Base turret = ObjectManager.Get<Obj_AI_Base>()
                .Where(a => list.Contains(a.Type)
                    && a.IsValid && a.IsHPBarRendered
                    && !a.IsInvulnerable
                    && a.IsEnemy
                    && _player.IsInRange(a, _player.GetAutoAttackRange())
                ).FirstOrDefault();

                if (turret != null && !SpellManager.HasQActive
                    && ((turret.HealthPercent >= MenuManager.percentHealth && LastAutoTime.IsWithinTime(0.5f))
                        || turret.Health <= _player.GetAutoAttackDamage(turret)))
                    Player.IssueOrder(GameObjectOrder.AttackUnit, turret);
                else if (turret != null && SpellManager.Q.IsReady()
                    && ((turret.HealthPercent >= MenuManager.percentHealth && LastAutoTime.IsWithinTime(0.5f))
                        || turret.Health <= _player.GetAutoAttackDamage(turret) + SpellManager.QDamage(turret)))
                {
                    SpellManager.Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, turret);
                }
            }
        }

        public static void Passives()
        {
            if (MenuManager.Settings.GetCheckBoxValue("cleanse") && SpellManager.Q.IsReady())
            {
                if (_player.HasBuffOfType(BuffType.Slow))
                    SpellManager.Q.Cast();
            }
        }
    }
}
