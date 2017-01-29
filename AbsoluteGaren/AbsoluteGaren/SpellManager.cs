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
    class SpellManager
    {
        public static Spell.Active Q, W, E;
        public static Spell.Targeted R;
        static AIHeroClient _player;

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
            damage += _player.GetAutoAttackDamage(target) * MenuManager.Drawing.GetSliderValue("renderAA");

            return damage;
        }
    }
}
