using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate
{
    class ModeManager
    {
        // Preforms this method after the OrbWalker flag check
        public static void Combo()
        {
            // Let's confirm the Menu CheckBox is active to continue.
                // Use .Get<Value>("uniqueIdentifier").CurrentValue to find the value currently set.
            if (MenuManager.comboMenu.Get<CheckBox>("CheckBox").CurrentValue)
            {
                // Let's confirm the Menu Slider coorelates with the player's Champion's mana percentage.
                if (Player.Instance.ManaPercent >= MenuManager.comboMenu.Get<Slider>("Slider").CurrentValue)
                {
                    // Time to cast the spell Q.
                    // There are various methods to grabbing a target object.
                    // Let's use TargetSelector.GetTarget() this time.
                        // Use the EntityManager for selecting a list of objects.
                    Obj_AI_Base target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies, SpellManager.Q.DamageType);

                    // Preform a check for the target object for reasons why it wouldn't be targeted.
                    // At the same time check if the Spell Q is off-cooldown using IsReady().
                    if (target != null && SpellManager.Q.IsReady())
                    {
                        // Prediction is how likley the spell will hit. We need two things to strike an object.
                        // The predictionResult is the predicted position of the target after Predicition logic is applied.
                        PredictionResult pred = SpellManager.Q.GetPrediction(target);

                        // If that result isn't null, compare the predicted result hitchance to the manual set hitchance.
                        if (pred != null && pred.HitChance >= SpellManager.Q.MinimumHitChance)
                            // Cast() will use the spell upon activation.
                            SpellManager.Q.Cast(pred.CastPosition);
                    }
                }
            }
        }
    }
}