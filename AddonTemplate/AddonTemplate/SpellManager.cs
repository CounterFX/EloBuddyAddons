using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace AddonTemplate
{
    class SpellManager
    {
        // We need a global variable for each of the player's Champion spells.
            // There are four types of spells: Active, Chargeable, Skillshot, Targeted
        public static Spell.Skillshot Q;

        // The method we called inside Loading.OnLoadingComplete event to initalize spell information.
        public static void Initialize()
        {
            // Each spell object needs an instance created.
            // This information can be found multiple ways. I would suggest a wiki or by database.
            Q = new Spell.Skillshot(SpellSlot.Q, 100, SkillShotType.Linear)
            {
                // For Skillshots, each spell has a shape like Linear, Circular, or Cone. It is assigned in the paramater above.

                // Allowed Collision Count is the # of units the spell will hit before it hits its target.
                    // 0 for hitting just a target, 1 for hitting a single intercept and a target,
                    // int.MaxValue for multiple targets
                AllowedCollisionCount = 0,

                // CastDelay is the time it takes to attack before preforming the spell.
                CastDelay = 250,

                // DamageType is how the damage is calculated depending on Armor, Magic Resistance, and shielding.
                DamageType = DamageType.Magical,

                // MinimumHitChance is used for Prediction to calculate how likely the spell will hit.
                    // We will use High which is 4 as an example.
                MinimumHitChance = HitChance.High,

                // Range is how far in distance at which the spell can be casted.
                Range = 1000,

                // Speed is the how quickly the skillshot can move.
                Speed = 1700,

                // Width is the horizontal length of the skillshot.
                Width = 100,
            };
        }
    }
}