using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Spells;
using EloBuddy.SDK.ThirdParty;
using EloBuddy.SDK.ThirdParty.Glide;
using EloBuddy.SDK.Utils;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace AbsoluteGaren
{
    static class Extensions
    {        
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
            sender.Add(uniqueIdentifier, new CheckBox(displayName, defaultValue));
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
            sender.Add(uniqueIdentifier, new Slider(displayName, defaultValue, minValue, maxValue));
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
            sender.Add(uniqueIdentifier, new ComboBox(displayName, textValues, defaultIndex));
        }

        /// <summary>
        /// Retrieves the value of a Checkbox from a Dictionary with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static bool GetCheckBoxValue(this Dictionary<string, ValueBase> sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                ValueBase checkbox = sender.Where(a => a.Key == uniqueIdentifier.ToLower()).FirstOrDefault().Value;

                if (checkbox != null)
                {
                    return checkbox.Cast<CheckBox>().CurrentValue;
                }
                else
                {
                    Console.WriteLine("CheckBox value with identifier - " + uniqueIdentifier + " - unknown.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Checkbox sender not initialized.");
                return false;
            }
        }

        /// <summary>
        /// Retrieves the value of a Slider from a Dictionary with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static int GetSliderValue(this Dictionary<string, ValueBase> sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                ValueBase slider = sender.Where(a => a.Key == uniqueIdentifier.ToLower()).FirstOrDefault().Value;

                if (slider != null)
                {
                    return slider.Cast<Slider>().CurrentValue;
                }
                else
                {
                    Console.WriteLine("Slider value with identifier - " + uniqueIdentifier + " - unknown.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Slider sender not initialized.");
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the value of a ComboBox from a Dictionary with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static int GetComboBoxValue(this Dictionary<string, ValueBase> sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                ValueBase combobox = sender.Where(a => a.Key == uniqueIdentifier.ToLower()).FirstOrDefault().Value;

                if (combobox != null)
                {
                    return combobox.Cast<ComboBox>().CurrentValue;
                }
                else
                {
                    Console.WriteLine("ComboBox value with identifier - " + uniqueIdentifier + " - unknown.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("ComboBox sender not initialized.");
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the string of a ComboBox from a Dictionary with a unique identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public static string GetComboBoxString(this Dictionary<string, ValueBase> sender, string uniqueIdentifier)
        {
            if (sender != null)
            {
                ValueBase combobox = sender.Where(a => a.Key == uniqueIdentifier.ToLower()).FirstOrDefault().Value;

                if (combobox != null)
                {
                    return combobox.Cast<ComboBox>().CurrentValue.ToString();
                }
                else
                {
                    Console.WriteLine("ComboBox string with identifier - " + uniqueIdentifier + " - unknown.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("ComboBox sender not initialized.");
                return null;
            }
        }
        #endregion

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
