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
    class MenuManager
    {
        public static Dictionary<string, ValueBase> Menu;
        static List<Menu> MenuList;
        static Menu mainMenu, comboMenu, laneClearMenu, lastHitMenu, jungleClearMenu, ksMenu;
        public static int percentHealth;
        static AIHeroClient _player => Player.Instance;

        public static void Initialize()
        {
            Menu = new Dictionary<string, ValueBase>();
            MenuList = new List<Menu>();

            mainMenu = MainMenu.AddMenu("AbsoluteGaren", "mainMenu");
            mainMenu.AddGroupLabel("Created by Counter");
            mainMenu.AddLabel("This addon is designed for the Champion, Garen.");
            mainMenu.AddLabel("Found a bug or error? Please contact me by PM on EloBuddy.");
            mainMenu.AddSeparator();
            mainMenu.AddLabel("Spell Configurations");
            mainMenu.AddCheckBox("autoW", "Auto W");
            mainMenu.AddCheckBox("cleanseQ", "Cleanse Slows with Q");
            mainMenu.AddCheckBox("destroy", "Destory structures with Q");
            mainMenu.AddSlider("percentQ", "Save Q for ks when unit Health percent >= ", 35, 0, 100);
            MenuList.Add(mainMenu);

            comboMenu = mainMenu.AddSubMenu("Combo", "comboMenu");
            comboMenu.AddLabel("Combo Configurations");
            comboMenu.AddCheckBox("comboQ", "Use Q");
            comboMenu.AddCheckBox("comboE", "Use E");
            MenuList.Add(comboMenu);

            laneClearMenu = mainMenu.AddSubMenu("Lane Clear", "laneClearMenu");
            laneClearMenu.AddLabel("Lane Clear Configurations");
            laneClearMenu.AddCheckBox("laneQ", "Use Q");
            laneClearMenu.AddCheckBox("laneE", "Use E");
            MenuList.Add(laneClearMenu);

            lastHitMenu = mainMenu.AddSubMenu("Last Hit", "lastHitMenu");
            lastHitMenu.AddLabel("Last Hit Configurations");
            lastHitMenu.AddCheckBox("lasthitQ", "Use Q");
            MenuList.Add(lastHitMenu);

            jungleClearMenu = mainMenu.AddSubMenu("Jungle Clear", "jungleClearMenu");
            jungleClearMenu.AddLabel("Jungle Clear Configurations");
            jungleClearMenu.AddCheckBox("jungleQ", "Use Q");
            jungleClearMenu.AddCheckBox("jungleE", "Use E");
            MenuList.Add(jungleClearMenu);

            ksMenu = mainMenu.AddSubMenu("KillSteal", "ksMenu");
            ksMenu.AddLabel("KillSteal Configurations");
            ksMenu.AddCheckBox("ksAA", "KS with Auto Attack");
            ksMenu.AddCheckBox("ksQ", "KS with Q");
            ksMenu.AddCheckBox("ksR", "KS with R");
            MenuList.Add(ksMenu);

            foreach (Menu menu in MenuList)
            {
                if (menu != null)
                    foreach (KeyValuePair<string, ValueBase> pair in menu.LinkedValues)
                        Menu.Add(pair.Key, pair.Value);
                else
                    Console.WriteLine(menu.DisplayName + " not set to a instance.");
            }

            percentHealth = Menu.GetSliderValue("percentQ");

            Console.WriteLine("MenuManager initialized.");
        }

        public static void MenuConfig()
        {
            if (percentHealth != Menu.GetSliderValue("percentQ"))
                percentHealth = Menu.GetSliderValue("percentQ");
        }
    }
}
