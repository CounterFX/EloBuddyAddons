using System;
using EloBuddy;
using EloBuddy.SDK;

namespace AbsoluteGaren
{
    class SpellManager
    {
        public static Spell.Active Q, W, E;
        public static Spell.Targeted R;
        static AIHeroClient _player;
        public static bool QActive;
        public static bool EActive;

        public static void Initialize()
        {
            Q = new Spell.Active(SpellSlot.Q)
            {
                DamageType = DamageType.Physical,
            };
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, 300, DamageType.Physical);
            R = new Spell.Targeted(SpellSlot.R, 400, DamageType.Magical);

            _player = Player.Instance;

            QActive = false;
            EActive = false;

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

            damage += Q.IsReady() && !Q.IsOnCooldown ? QDamage(target) : 0;
            damage += R.IsReady() && !R.IsOnCooldown ? RDamage(target) : 0;
            damage += _player.GetAutoAttackDamage(target) * MenuManager.Rendering.GetSliderValue("renderAA");

            return damage;
        }

        public static void SpellConfig()
        {
            if (Q.IsOnCooldown)
                QActive = false;
            
            EActive = E.Name == "GarenECancel" ? true : false;
        }
    }
}
