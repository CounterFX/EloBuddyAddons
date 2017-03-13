using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;

namespace AbsoluteGaren
{
    class ModeManager
    {
        public static AIHeroClient _player;

        public static void Combo()
        {
            Menu menu = MenuManager.Combo;
            List<Obj_AI_Base> targets = EntityManager.Heroes.Enemies.ToObj_AI_BaseList();

            SpellManager.CastQ(menu, targets);
            SpellManager.CastE(menu, targets);
        }

        public static void LaneClear()
        {
            Menu menu = MenuManager.LaneClear;
            List<Obj_AI_Base> targets = EntityManager.MinionsAndMonsters.EnemyMinions
                .Concat(EntityManager.MinionsAndMonsters.OtherEnemyMinions
                    .Where(a => a.IsTargetable && a.Name != "God" &&  a.Name != "VoidSpawn")
                ).ToObj_AI_BaseList();

            SpellManager.CastQ(menu, targets);
            SpellManager.CastE(menu, targets, 1);
        }

        public static void LastHit()
        {
            Menu menu = MenuManager.LastHit;
            List<Obj_AI_Base> targets = EntityManager.MinionsAndMonsters.EnemyMinions
                .Concat(EntityManager.MinionsAndMonsters.OtherEnemyMinions
                    .Where(a => a.IsTargetable && a.Name != "God" &&  a.Name != "VoidSpawn")
                ).Concat(EntityManager.MinionsAndMonsters.Monsters).ToObj_AI_BaseList();

            SpellManager.CastQ(menu, targets, true);
        }

        public static void JungleClear()
        {
            Menu menu = MenuManager.JungleClear;
            List<Obj_AI_Base> targets = EntityManager.MinionsAndMonsters.Monsters
                .ToObj_AI_BaseList();
            List<Obj_AI_Base> largetargets = targets
                .Where(a => a.IsLargeMonster()).ToList();

            SpellManager.CastQ(menu, largetargets);
            SpellManager.CastE(menu, targets, 1);
        }

        public static void KillSteal()
        {
            Menu menu = MenuManager.KillSteal;
            List<Obj_AI_Base> targets = EntityManager.Heroes.Enemies.ToObj_AI_BaseList();

            SpellManager.CastBasicAttack(menu, targets, true);
            SpellManager.CastQ(menu, targets, true);
            SpellManager.CastR(menu, targets, true);
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
                    && ((turret.HealthPercent >= MenuManager.percentHealth && SpellManager.LastAutoTime.IsWithinTime(0.5f))
                        || turret.Health <= _player.GetAutoAttackDamage(turret)))
                    Player.IssueOrder(GameObjectOrder.AttackUnit, turret);
                else if (turret != null && SpellManager.Q.IsReady()
                    && ((turret.HealthPercent >= MenuManager.percentHealth && SpellManager.LastAutoTime.IsWithinTime(0.5f))
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
