using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Spells;
using SharpDX;

namespace AbsoluteGaren
{
    class SpellManager
    {
        public static AIHeroClient _player;
        public static Spell.Active Q, W, E;
        public static Spell.Targeted R;
        public static bool HasQActive;
        public static bool IsSpinning;
        public static bool hasPerformedAction;
        public static float LastAutoTime;

        public static void Initialize()
        {
            Q = new Spell.Active(SpellSlot.Q)
            {
                DamageType = DamageType.Physical,
            };
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, 300, DamageType.Physical);
            R = new Spell.Targeted(SpellSlot.R, 400, DamageType.Magical);

            HasQActive = _player.HasBuff("GarenQ");
            IsSpinning = _player.HasBuff("GarenE");
            hasPerformedAction = false;
            LastAutoTime = 0;

            Console.WriteLine("SpellManager initialized.");
        }

        public static float QDamage(Obj_AI_Base target)
        {
            float damage = _player.GetAutoAttackDamage(target) + 5 + (25 * Q.Level) + _player.PercentAttackDamage(40);
            return _player.CalculateDamageOnUnit(target, Q.DamageType, damage, false, true);
        }

        public static float RDamage(Obj_AI_Base target)
        {
            if (target.HasBuff("garenpassiveenemytarget"))
                return _player.CalculateDamageOnUnit(target, DamageType.True, R.GetSpellDamage(target));

            return _player.CalculateDamageOnUnit(target, R.DamageType, R.GetSpellDamage(target));
        }

        public static float FullDamage(Obj_AI_Base target)
        {
            float damage = 0;

            damage += Q.IsReady() ? QDamage(target) : 0;
            damage += R.IsReady() ? RDamage(target) : 0;
            damage += Orbwalker.CanAutoAttack ? _player.GetAutoAttackDamage(target)
                * MenuManager.Rendering.GetSliderValue("aa_dmg") : 0;

            return damage;
        }

        public static void SpellConfig()
        {
            HasQActive = _player.HasBuff("GarenQ");
            IsSpinning = _player.HasBuff("GarenE");

            Orbwalker.DisableAttacking = _player.HasBuff("GarenE");
        }

        public static void CastBasicAttack(Menu menu, List<Obj_AI_Base> list, bool IsKillSteal = false)
        {
            if (menu.GetCheckBoxValue("AA") && !hasPerformedAction)
            {
                Obj_AI_Base target = list
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInAutoAttackRange(a)
                        && (!IsKillSteal || _player.CanKillWithBasicAttack(a))
                    ).FirstOrDefault();

                if (target != null)
                    hasPerformedAction = Player.IssueOrder(GameObjectOrder.AttackUnit, target);
            }
        }

        public static void CastQ(Menu menu, List<Obj_AI_Base> list, bool IsKillSteal = false)
        {
            if (menu.GetCheckBoxValue("Q") && Q.IsReady() && !IsSpinning)
            {
                Obj_AI_Base target = list
                    .OrderBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, _player.GetAutoAttackRange())
                        && (!IsKillSteal ||
                        ((a.HealthPercent >= MenuManager.percentHealth && LastAutoTime.IsWithinTime(0.5f))
                        || (a.Health > _player.GetAutoAttackDamage(a) && a.Health <= _player.GetAutoAttackDamage(a) + QDamage(a))))
                    ).FirstOrDefault();

                if (target != null)
                {
                    Q.Cast();
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }
        }

        public static void CastE(Menu menu, List<Obj_AI_Base> list, float HitNumber = 0)
        {
            if (menu.GetCheckBoxValue("E") && E.IsReady() && !IsSpinning)
            {
                float amount = list
                        .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, E.Range)
                    ).Count();

                if (amount > HitNumber)
                    E.Cast();
            }
        }

        public static void CastR(Menu menu, List<Obj_AI_Base> list, bool IsKillSteal = false)
        {
            if (menu.GetCheckBoxValue("R") && R.IsReady()
                && _player.CountEnemyChampionsInRange(R.Range) > 0)
            {
                Obj_AI_Base target = list
                    .OrderBy(a => a.HasBuff("garenpassiveenemytarget"))
                    .ThenBy(a => a.Health)
                    .Where(a => a.IsValidTarget()
                        && _player.IsInRange(a, R.Range)
                        && (!IsKillSteal || a.Health <= RDamage(a))
                    ).FirstOrDefault();

                if (target != null)
                    R.Cast(target);
            }
        }
    }
}
