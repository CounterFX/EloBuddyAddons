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
        /// Returns the amount of Jungle Creatures in a desired range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static float CountJungleCreaturesInRange(this Obj_AI_Base sender, float range)
        {
            return EntityManager.MinionsAndMonsters.Monsters.Count(a => a.IsValidTarget() && a.IsInRange(sender, range));
        }
        #endregion

        #region Calculations
        /// <summary>
        /// Returns the amount of active item calculated damage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static float GetActiveItemDamage(this AIHeroClient sender, Obj_AI_Base target)
        {
            float damage = 0;
            List<ItemId> itemList = new List<ItemId>
            {
                ItemId.Bilgewater_Cutlass,
                ItemId.Blade_of_the_Ruined_King,
                ItemId.Hextech_Gunblade,
                ItemId.Hextech_Protobelt_01,
                ItemId.Redemption,
                ItemId.Ravenous_Hydra,
                ItemId.Titanic_Hydra,
                ItemId.Tiamat
            };

            foreach (ItemId id in itemList)
            {
                InventorySlot item = sender.InventoryItems.FirstOrDefault(a => a.Id == id);

                if (item != null && item.CanUseItem())
                    damage += DamageLibrary.GetItemDamage(sender, target, id);
            }

            return damage;
        }

        public static float GetActiveItemHealing(this AIHeroClient sender)
        {
            float healing = 0;
            List<ItemId> itemList = new List<ItemId>
            {
                ItemId.Blade_of_the_Ruined_King,
                ItemId.Corrupting_Potion,
                ItemId.Health_Potion,
                ItemId.Redemption,
                ItemId.Refillable_Potion
            };

            foreach (ItemId id in itemList)
            {
                InventorySlot item = sender.InventoryItems.FirstOrDefault(a => a.Id == id);
                
                if (item != null && item.CanUseItem())
                {
                    if (item.Id.Equals(ItemId.Blade_of_the_Ruined_King))
                    {
                        Obj_AI_Base target = EntityManager.Heroes.Enemies
                            .OrderByDescending(a => a.Health)
                            .Where(a => a.IsValidTarget(550)).FirstOrDefault();

                        if (target != null)
                            healing += sender.GetItemDamage(target, id);
                    }
                    if (item.Id.Equals(ItemId.Corrupting_Potion))
                        healing += 125 * item.Stacks;
                    if (item.Id.Equals(ItemId.Health_Potion))
                        healing += 150;
                    if (item.Id.Equals(ItemId.Redemption))
                            healing += 40 + (25 * sender.Level);
                    if (item.Id.Equals(ItemId.Refillable_Potion))
                        healing += 125 * item.Stacks;
                }  
            }

            if (sender.HasItem(ItemId.Spirit_Visage))
                healing *= 1.25f;

            return healing;
        }
        #endregion

        #region Menu
        /// <summary>
        /// Generates a Checkbox to a specified Menu object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="displayName"></param>
        /// <param name="defaultValue"></param>
        public static void AddCheckBox(this Menu sender, string uniqueIdentifier, string displayName, bool defaultValue = true)
        {
            if (sender != null)
                sender.Add(uniqueIdentifier, new CheckBox(displayName, defaultValue));
            else
                Console.WriteLine("Menu isn't initialized to an instance.");
        }

        /// <summary>
        /// Returns a CheckBox object with a unique identifier.
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static CheckBox GetCheckBoxObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.Get<CheckBox>(uniqueIdentifier) != null)
                   return sender.Get<CheckBox>(uniqueIdentifier);
                else
                    Console.WriteLine("CheckBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return null;
        }

        /// <summary>
        /// Returns the current value of a CheckBox object with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static bool GetCheckBoxValue(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.GetCheckBoxObject(uniqueIdentifier) != null)
                    return sender.GetCheckBoxObject(uniqueIdentifier).CurrentValue;
                else
                    Console.WriteLine("CheckBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return false;
        }

        /// <summary>
        /// Generates a Slider to a specified Menu object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="displayName"></param>
        /// <param name="defaultValue"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public static void AddSlider(this Menu sender, string uniqueIdentifier, string displayName,
            int defaultValue = 0, int minValue = 0, int maxValue = 100)
        {
            if (sender != null)
                sender.Add(uniqueIdentifier, new Slider(displayName, defaultValue, minValue, maxValue));
            else
                Console.WriteLine("Menu isn't initialized to an instance.");
        }

        /// <summary>
        /// Returns a Slider object with a unique identifier.
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static Slider GetSliderObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.Get<Slider>(uniqueIdentifier) != null)
                   return sender.Get<Slider>(uniqueIdentifier);
                else
                    Console.WriteLine("Slider with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return null;
        }

        /// <summary>
        /// Returns the current value of a Slider object with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static int GetSliderValue(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.GetSliderObject(uniqueIdentifier) != null)
                    return sender.GetSliderObject(uniqueIdentifier).CurrentValue;
                else
                    Console.WriteLine("Slider with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return -1;
        }

        /// <summary>
        /// Generates a ComboBox to a specified Menu object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="displayName"></param>
        /// <param name="textValues"></param>
        /// <param name="defaultIndex"></param>
        public static void AddComboBox(this Menu sender, string uniqueIdentifier, string displayName,
            List<string> textValues, int defaultIndex)
        {
            if (sender != null)
                sender.Add(uniqueIdentifier, new ComboBox(displayName, textValues, defaultIndex));
            else
                Console.WriteLine("Menu isn't initialized to an instance.");
        }

        /// <summary>
        /// Returns a ComboBox object with a unique identifier.
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static ComboBox GetComboBoxObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.Get<ComboBox>(uniqueIdentifier) != null)
                   return sender.Get<ComboBox>(uniqueIdentifier);
                else
                    Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return null;
        }

        /// <summary>
        /// Returns the selected index of a ComboBox object with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static int GetComboBoxSelectedIndex(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.GetComboBoxObject(uniqueIdentifier) != null)
                    return sender.GetComboBoxObject(uniqueIdentifier).SelectedIndex;
                else
                    Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return -1;
        }

        /// <summary>
        /// Returns the selected text of a ComboBox object with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static string GetComboBoxSelectedText(this Menu sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                if (sender.GetComboBoxObject(uniqueIdentifier) != null)
                    return sender.GetComboBoxObject(uniqueIdentifier).SelectedText;
                else
                    Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");
            }
            else
                Console.WriteLine("Menu isn't initialized to an instance.");

            return null;
        }
        #endregion

        #region Rendering
        public static void RenderHPBar(this Obj_AI_Base unit, float amount)
        {
            float unitHPBarWidth = 96;
            float unitAmount = 0;
            Vector2 unitHPBarOffset = Vector2.Zero;
            Vector2 unitHPCurrentOffset = Vector2.Zero;
            Vector2 unitHPEndOffset = Vector2.Zero;

            if (unit.IsEnemy)
            {
                unitAmount = Math.Max((100 * ((unit.Health - amount) / unit.MaxHealth)), 0);
                unitHPBarOffset = new Vector2(2, 9f);
                unitHPCurrentOffset = unit.HPBarPosition + unitHPBarOffset + new Vector2(100 * unit.HealthPercent / unitHPBarWidth, 0);
                unitHPEndOffset = unit.HPBarPosition + unitHPBarOffset + new Vector2(unitAmount, 0);

                Drawing.DrawLine(unitHPCurrentOffset, unitHPEndOffset, 9, Color.DarkRed);
            }
            else
            {
                unitAmount = Math.Min(100 * (unit.Health + amount) / unit.MaxHealth, 100);
                unitHPBarOffset = new Vector2(26, 7f);
                unitHPCurrentOffset = unit.HPBarPosition + unitHPBarOffset + new Vector2(100 * unit.HealthPercent / unitHPBarWidth, 0);
                unitHPEndOffset = unit.HPBarPosition + unitHPBarOffset + new Vector2(100 * unitAmount / unitHPBarWidth, 0);

                Drawing.DrawLine(unitHPCurrentOffset, unitHPEndOffset, 9, Color.YellowGreen);
            }
        }
        #endregion

        #region Verifications
        /// <summary>
        /// Verify an AIHeroClient object's Champion attribute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public static bool VerifyHero(this AIHeroClient sender, Champion check)
        {
            if (sender != null)
            {
                if (sender.Hero != check)
                {
                    Console.WriteLine(sender.Hero + "isn't compatible with this Addon.");
                    return false;
                }
                else
                    return true;
            }
            else
            {
                Console.WriteLine("This object isn't initialized to an instance.");
                return false;
            }
        }

        /// <summary>
        /// Returns true if Object identifies as a large monster.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool IsLargeMonster(this Obj_AI_Base sender)
        {
            if (sender != null)
            {
                List<string> list = new List<string> { "SRU_Red", "SRU_Blue",
                "SRU_Murkwolf", "SRU_Razorbeak", "SRU_Krug", "SRU_KrugMini", "SRU_Gromp", "Sru_Crab",
                "SRU_Dragon_Air", "SRU_Dragon_Fire", "SRU_Dragon_Water", "SRU_Dragon_Earth",
                "SRU_Dragon_Elder", "SRU_RiftHerald", "SRU_Baron",
                "TT_NWraith", "TT_NGolem", "TT_NWolf", "TT_Spiderboss" };

                return list.Contains(sender.BaseSkinName);
            }
            else
            {
                Console.WriteLine("This object isn't initialized to an instance.");
                return false;
            }
        }
        #endregion
    }
}
