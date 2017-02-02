using System;
using EloBuddy;
using EloBuddy.SDK;

namespace AbsoluteGaren
{
    class SpellManager
    {
        public static AIHeroClient _player;
        public static Spell.Active Q, W, E;
        public static Spell.Targeted R;
        public static bool HasQActive;
        public static bool IsSpinning;

        public static void Initialize()
        {
            Q = new Spell.Active(SpellSlot.Q)
            {
                DamageType = DamageType.Physical,
            };
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, 300, DamageType.Physical);
            R = new Spell.Targeted(SpellSlot.R, 400, DamageType.Magical);

            HasQActive = false;
            IsSpinning = false;

            Console.WriteLine("SpellManager initialized.");
        }

        public static float QDamage(Obj_AI_Base target)
        {
            return _player.CalculateDamageOnUnit(target, Q.DamageType, Q.GetSpellDamage(target), true, true);
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
                * MenuManager.Rendering.GetSliderValue("renderAA") : 0;

            return damage;
        }

        public static void SpellConfig()
        {
            HasQActive = _player.HasBuff("GarenQ");
            IsSpinning = _player.HasBuff("GarenE");

            Orbwalker.DisableAttacking = _player.HasBuff("GarenE");
        }
    }
}
