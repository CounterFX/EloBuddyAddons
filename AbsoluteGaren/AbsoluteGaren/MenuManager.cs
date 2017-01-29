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
        public static Menu mainMenu, Combo, LaneClear, LastHit, JungleClear, KillSteal, Drawing, Settings;
        public static int percentHealth;

        public static void Initialize()
        {
            mainMenu = MainMenu.AddMenu("AbsoluteGaren", "mainMenu");
            Combo = mainMenu.AddSubMenu("Combo", "ComboMenu");
            LaneClear = mainMenu.AddSubMenu("LaneClear", "LaneClearMenu");
            LastHit = mainMenu.AddSubMenu("LastHit", "LastHitMenu");
            JungleClear = mainMenu.AddSubMenu("JungleClear", "JungleClearMenu");
            KillSteal = mainMenu.AddSubMenu("KillSteal", "KillStealMenu");
            Drawing = mainMenu.AddSubMenu("Drawing", "DrawingMenu");
            Settings = mainMenu.AddSubMenu("Settings", "SettingsMenu");

            mainMenu.AddGroupLabel("Created by Counter");
            mainMenu.AddLabel("This addon is designed for the Champion, Garen.");
            mainMenu.AddLabel("Found a bug or error? Please contact me by PM on EloBuddy.");
            
            Combo.AddGroupLabel("Combo Features");
            Combo.AddCheckBox("comboQ", "Use Q");
            Combo.AddCheckBox("comboE", "Use E");
            
            LaneClear.AddGroupLabel("LaneClear Features");
            LaneClear.AddCheckBox("laneQ", "Use Q");
            LaneClear.AddCheckBox("laneE", "Use E");
            
            LastHit.AddGroupLabel("LastHit Features");
            LastHit.AddCheckBox("lasthitQ", "Use Q");
            
            JungleClear.AddGroupLabel("JungleClear Features");
            JungleClear.AddCheckBox("jungleQ", "Use Q");
            JungleClear.AddCheckBox("jungleE", "Use E");
            
            KillSteal.AddGroupLabel("KillSteal Features");
            KillSteal.AddCheckBox("ksAA", "KS with Auto Attack");
            KillSteal.AddCheckBox("ksQ", "KS with Q");
            KillSteal.AddCheckBox("ksR", "KS with R");
            
            Drawing.AddGroupLabel("Drawing Features");
            Drawing.AddCheckBox("render", "Render Health Bar");
            Drawing.AddCheckBox("killable", "Display 'Killable' text");
            Drawing.AddLabel("Rendering Configurations");
            Drawing.AddCheckBox("renderS", "Render Spell damage");
            Drawing.AddCheckBox("renderI", "Render Item damage");
            Drawing.AddSlider("renderAA", "Render Auto Attack damage", 2, 0, 5);

            Settings.AddGroupLabel("Settings Features");
            Settings.AddCheckBox("cleanseQ", "Cleanse Slows with Q");
            Settings.AddCheckBox("destroy", "Destroy structures with Q");
            Settings.AddSlider("percentQ", "Save Q for ks when unit Health percent >= ", 35, 0, 100);

            percentHealth = Settings.GetSliderValue("percentQ");

            Console.WriteLine("MenuManager initialized.");
        }

        public static void MenuConfig()
        {
            if (percentHealth != Settings.GetSliderValue("percentQ"))
                percentHealth = Settings.GetSliderValue("percentQ");
        }
    }
}
