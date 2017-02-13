using Color = System.Drawing.Color;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace AbsoluteGaren
{
    static class Extensions
    {
        #region Count
        /// <summary>
        /// Returns the amount of specified units in a desired range.
        /// </summary>
        public static float CountUnitsInRange(this Obj_AI_Base sender, List<Obj_AI_Base> units, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return units.Count(a => a.IsValidTarget() && sender.IsInRange(a, range));
        }

        /// <summary>
        /// Returns the amount of specified units in a desired range with Prediction.
        /// </summary>
        public static float CountUnitsInRangeWithPrediction(this Obj_AI_Base sender, List<Obj_AI_Base> units, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return units.Count(a => a.IsValidTarget() 
                    && sender.IsInRange(a.PredictedPositionInTime(delay), range));
        }

        /// <summary>
        /// Returns the amount of champions in a desired range.
        /// </summary>
        public static float CountChampionsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Heroes.AllHeroes.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of champions in a desired range with Prediction.
        /// </summary>
        public static float CountChampionsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Heroes.AllHeroes.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of minions in a desired range.
        /// </summary>
        public static float CountMinionsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Minions.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of minions in a desired range with Prediction.
        /// </summary>
        public static float CountMinionsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Minions.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of neutral targets in a desired range.
        /// </summary>
        public static float CountNeutralsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.EnemyMinions
                .Concat(EntityManager.MinionsAndMonsters.OtherEnemyMinions)
                .Concat(EntityManager.MinionsAndMonsters.Monsters).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of neutral targets in a desired range with Prediction.
        /// </summary>
        public static float CountNeutralsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.EnemyMinions
                .Concat(EntityManager.MinionsAndMonsters.OtherEnemyMinions)
                .Concat(EntityManager.MinionsAndMonsters.Monsters).ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of jungle creatures in a desired range.
        /// </summary>
        public static float CountMonstersInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Monsters.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of jungle creatures in a desired range with Prediction.
        /// </summary>
        public static float CountMonstersInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Monsters.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of large jungle creatures in a desired range.
        /// </summary>
        public static float CountLargeMonsterInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsLargeMonster()).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of large jungle creatures in a desired range with Prediction.
        /// </summary>
        public static float CountLargeMonsterInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsLargeMonster()).ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of epic jungle creatures in a desired range.
        /// </summary>
        public static float CountEpicMonsterInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsEpicMonster()).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of epic jungle creatures in a desired range with Prediction.
        /// </summary>
        public static float CountEpicMonsterInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsEpicMonster()).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of turret structures in a desired range.
        /// </summary>
        public static float CountTurretsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Turrets.AllTurrets.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of turret structures in a desired range with Prediction.
        /// </summary>
        public static float CountTurretsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Turrets.AllTurrets.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of friendly turret structures in a desired range.
        /// </summary>
        public static float CountAllyTurretsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Turrets.Allies.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of friendly turret structures in a desired range with Prediction.
        /// </summary>
        public static float CountAllyTurretsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Turrets.Allies.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of enemy turret structures in a desired range.
        /// </summary>
        public static float CountEnemyTurretsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Turrets.Enemies.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of enemy turret structures in a desired range with Prediction.
        /// </summary>
        public static float CountEnemyTurretsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Turrets.Enemies.ToObj_AI_BaseList(), range, delay);
        }

        #endregion

        #region Calculations
        /// <summary>
        /// Calculates if target can be killed with a basic attack.
        /// </summary>
        public static bool CanKillWithBasicAttack(this Obj_AI_Base sender, Obj_AI_Base target)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            if (target.IsNull())
                throw new ArgumentNullException("target");
            
            return sender.IsInRange(target, sender.GetAutoAttackRange()) && target.Health <= sender.GetAutoAttackDamage(target);
        }

        /// <summary>
        /// Returns the amount of active item calculated damage.
        /// </summary>
        public static float GetActiveItemDamage(this AIHeroClient sender, Obj_AI_Base target)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            if (target.IsNull())
                throw new ArgumentNullException("target");

            float damage = 0;
            List<ItemId> itemList = new List<ItemId>
            {
                ItemId.Bilgewater_Cutlass,
                ItemId.Blade_of_the_Ruined_King,
                ItemId.Hextech_Gunblade,
                ItemId.Hextech_Protobelt_01,
                ItemId.Hextech_GLP_800,
                ItemId.Redemption,
                ItemId.Ravenous_Hydra,
                ItemId.Titanic_Hydra,
                ItemId.Tiamat
            };

            // Items with same unique active abilities
            bool hasTiamat = sender.InventoryItems.Any(a => a.Id == ItemId.Tiamat) ? true : false;
            bool hasRavenousHydra = sender.InventoryItems.Any(a => a.Id == ItemId.Ravenous_Hydra) ? true : false;
            bool hasTitanicHydra = sender.InventoryItems.Any(a => a.Id == ItemId.Titanic_Hydra) ? true : false;

            foreach (ItemId id in itemList)
            {
                InventorySlot item = sender.InventoryItems.FirstOrDefault(a => a.Id == id);

                if (item != null && item.CanUseItem() && target.IsValidTarget())
                    damage += sender.GetItemDamage(target, id);
            }

            return damage;
        }

        /// <summary>
        /// Returns the amount of active item calculated healing.
        /// </summary>
        public static float GetActiveItemHealing(this AIHeroClient sender, Obj_AI_Base target = null)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            float healing = 0;
            List<ItemId> itemList = new List<ItemId>
            {
                ItemId.Blade_of_the_Ruined_King,
                ItemId.Corrupting_Potion,
                ItemId.Health_Potion,
                ItemId.Redemption,
                ItemId.Refillable_Potion,
                ItemId.Total_Biscuit_of_Rejuvenation
            };

            foreach (ItemId id in itemList)
            {
                InventorySlot item = sender.InventoryItems.FirstOrDefault(a => a.Id == id);
                
                if (item != null && item.CanUseItem())
                {
                    if (item.Id.Equals(ItemId.Blade_of_the_Ruined_King)
                        && target != null && target.IsValidTarget())
                        healing += sender.GetItemDamage(target, id);
                    if (item.Id.Equals(ItemId.Corrupting_Potion))
                        healing += 125 * item.Stacks;
                    if (item.Id.Equals(ItemId.Health_Potion))
                        healing += 150;
                    if (item.Id.Equals(ItemId.Redemption))
                            healing += 40 + (25 * sender.Level);
                    if (item.Id.Equals(ItemId.Refillable_Potion))
                        healing += 125 * item.Stacks;
                    if (item.Id.Equals(ItemId.Total_Biscuit_of_Rejuvenation))
                        healing += 165;
                }  
            }

            if (sender.HasItem(ItemId.Spirit_Visage))
                healing *= 1.25f;

            return healing;
        }

        /// <summary>
        /// Returns the predicted position a unit is traveling to in time.
        /// </summary>
        public static Vector3 PredictedPositionInTime(this Obj_AI_Base sender, int time)
        {
            Vector3 pos = Prediction.Position.PredictUnitPosition(sender, time).To3D(0);

            return new Vector3(pos.X, pos.Y, NavMesh.GetHeightForPosition(pos.X, pos.Y));
        }
        #endregion

        #region Menu
        /// <summary>
        /// Generates a Checkbox to a specified Menu object.
        /// </summary>
        public static void AddCheckBox(this Menu sender, string uniqueIdentifier, string displayName, bool defaultValue = true)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new CheckBox(displayName, defaultValue));
        }

        /// <summary>
        /// Returns a CheckBox object with a unique identifier.
        /// </summary>
        public static CheckBox GetCheckBoxObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<CheckBox>(uniqueIdentifier) != null)
                return sender.Get<CheckBox>(uniqueIdentifier);
            else
                Console.WriteLine("CheckBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Returns the current value of a CheckBox object with a unique identifier.
        /// </summary>
        public static bool GetCheckBoxValue(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetCheckBoxObject(uniqueIdentifier) != null)
                return sender.GetCheckBoxObject(uniqueIdentifier).CurrentValue;
            else
                Console.WriteLine("CheckBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return false;
        }

        /// <summary>
        /// Generates a Slider to a specified Menu object.
        /// </summary>
        public static void AddSlider(this Menu sender, string uniqueIdentifier, string displayName,
            int defaultValue = 0, int minValue = 0, int maxValue = 100)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new Slider(displayName, defaultValue, minValue, maxValue));
        }

        /// <summary>
        /// Returns a Slider object with a unique identifier.
        /// </summary>
        public static Slider GetSliderObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<Slider>(uniqueIdentifier) != null)
                return sender.Get<Slider>(uniqueIdentifier);
            else
                Console.WriteLine("Slider with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Returns the current value of a Slider object with a unique identifier.
        /// </summary>
        public static int GetSliderValue(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetSliderObject(uniqueIdentifier) != null)
                return sender.GetSliderObject(uniqueIdentifier).CurrentValue;
            else
                Console.WriteLine("Slider with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return -1;
        }

        /// <summary>
        /// Generates a ComboBox to a specified Menu object.
        /// </summary>
        public static void AddComboBox(this Menu sender, string uniqueIdentifier, string displayName,
            List<string> textValues, int defaultIndex)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new ComboBox(displayName, textValues, defaultIndex));
        }

        /// <summary>
        /// Returns a ComboBox object with a unique identifier.
        /// </summary>
        public static ComboBox GetComboBoxObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<ComboBox>(uniqueIdentifier) != null)
                return sender.Get<ComboBox>(uniqueIdentifier);
            else
                Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Returns the selected index of a ComboBox object with a unique identifier.
        /// </summary>
        public static int GetComboBoxSelectedIndex(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetComboBoxObject(uniqueIdentifier) != null)
                return sender.GetComboBoxObject(uniqueIdentifier).SelectedIndex;
            else
                Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return -1;
        }

        /// <summary>
        /// Returns the selected text of a ComboBox object with a unique identifier.
        /// </summary>
        public static string GetComboBoxSelectedText(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetComboBoxObject(uniqueIdentifier) != null)
                return sender.GetComboBoxObject(uniqueIdentifier).SelectedText;
            else
                Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }
        #endregion

        #region Rendering
        /// <summary>
        /// Used to graphically render over a unit's Health Bar.
        /// </summary>
        public static void RenderHPBar(this Obj_AI_Base sender, float amount)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            float unitHPBarWidth = 96;
            float unitHPBarAmount = 0;
            Vector2 unitHPBarOffset = Vector2.Zero;
            Vector2 unitHPCurrentOffset = Vector2.Zero;
            Vector2 unitHPEndOffset = Vector2.Zero;
            Color color = Color.White;

            if (sender.IsEnemy)
            {
                unitHPBarAmount = Math.Max((100 * ((sender.Health - amount) / sender.MaxHealth)), 0);
                unitHPBarOffset = new Vector2(sender.HPBarXOffset, sender.HPBarYOffset + 9.2f);
                unitHPCurrentOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(100 * sender.HealthPercent / unitHPBarWidth, 0);
                unitHPEndOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(unitHPBarAmount, 0);
                color = Color.DarkRed;
            }
            else
            {
                unitHPBarAmount = Math.Max(100 * (sender.Health + amount) / sender.MaxHealth, 0);
                unitHPBarOffset = new Vector2(sender.HPBarXOffset, sender.HPBarYOffset);
                unitHPCurrentOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(100 * sender.HealthPercent / unitHPBarWidth, 0);
                unitHPEndOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(100 * unitHPBarAmount / unitHPBarWidth, 0);
                color = Color.YellowGreen;
            }

            Drawing.DrawLine(unitHPCurrentOffset, unitHPEndOffset, 9, color);
        }
        #endregion

        #region Spells
        /// <summary>
        /// Returns the amount of ability power for a specified unit.
        /// </summary>
        public static float AbilityPower(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.FlatMagicDamageMod;
        }

        /// <summary>
        /// Returns the amount of attack damage for a specified unit.
        /// </summary>
        public static float AttackDamage(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.FlatPhysicalDamageMod;
        }
        
        /// <summary>
        /// Returns the amount of missing health for a specified unit.
        /// </summary>
        public static float MissingHealth(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (sender.MaxHealth - sender.Health);
        }
        
        /// <summary>
        /// Returns the percentage of ability power for a specified unit.
        /// </summary>
        public static float PercentAbilityPower(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * sender.FlatMagicDamageMod;
        }
        
        /// <summary>
        /// Returns the percentage of bonus ability power for a specified unit.
        /// </summary>
        public static float PercentBonusAbilityPower(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * (sender.TotalMagicalDamage - sender.BaseAbilityDamage);
        }

        /// <summary>
        /// Returns the percentage of attack damage for a specified unit.
        /// </summary>
        public static float PercentAttackDamage(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * sender.FlatPhysicalDamageMod;
        }
        
        /// <summary>
        /// Returns the percentage of bonus attack damage for a specified unit.
        /// </summary>
        public static float PercentBonusAttackDamage(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * (sender.TotalAttackDamage - sender.BaseAttackDamage);
        }
        
        /// <summary>
        /// Returns the percentage of maximum health for a specified unit.
        /// </summary>
        public static float PercentMaximumHealth(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent * 100) * sender.MaxHealth;
        }
        
        /// <summary>
        /// Returns the percentage of missing health for a specified unit.
        /// </summary>
        public static float PercentMissingHealth(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.MissingHealth() / sender.MaxHealth;
        }

        /// <summary>
        /// Returns the sight range to fog of war for a specified hero unit.
        /// </summary>
        public static float ViewRange(this AIHeroClient sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return 1200;
        }
        #endregion

        #region Verifications
        /// <summary>
        /// Verify an AIHeroClient object's Champion attribute.
        /// </summary>
        public static bool VerifyHero(this AIHeroClient sender, Champion check)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            if (sender.Hero != check)
            {
                Console.WriteLine(sender.Hero + "isn't compatible with this Addon.");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Returns true if object identifies as a large monster.
        /// </summary>
        public static bool IsLargeMonster(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            
            List<string> list = new List<string> { "SRU_Red", "SRU_Blue",
            "SRU_Murkwolf", "SRU_Razorbeak", "SRU_Krug", "SRU_KrugMini", "SRU_Gromp", "Sru_Crab",
            "SRU_Dragon_Air", "SRU_Dragon_Fire", "SRU_Dragon_Water", "SRU_Dragon_Earth",
            "SRU_Dragon_Elder", "SRU_RiftHerald", "SRU_Baron",
            "TT_NWraith", "TT_NGolem", "TT_NWolf", "TT_Spiderboss" };

            return list.Contains(sender.BaseSkinName);
        }

        /// <summary>
        /// Returns true if object isn't set to an instance.
        /// </summary>
        public static bool IsNull(this Obj_AI_Base sender)
        {
            return sender == null;
        }

        /// <summary>
        /// Returns true if object identifies as an objective monster.
        /// </summary>
        public static bool IsEpicMonster(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            
            List<string> list = new List<string> { "SRU_Dragon_Elder",
                "SRU_Dragon_Air", "SRU_Dragon_Fire", "SRU_Dragon_Water", "SRU_Dragon_Earth",
                "SRU_Dragon_Elder", "SRU_RiftHerald", "SRU_Baron", "TT_Spiderboss" };

            return list.Contains(sender.BaseSkinName);
        }

        public static bool IsWithinTime(this float startTime, float duration)
        {
            return (Game.Time - startTime) < duration;
        }
        #endregion
    }
}
