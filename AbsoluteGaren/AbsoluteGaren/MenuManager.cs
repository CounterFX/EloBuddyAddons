using System;
using EloBuddy.SDK.Menu;

namespace AbsoluteGaren
{
    class MenuManager
    {
        public static Menu mainMenu, Combo, LaneClear, LastHit, JungleClear, KillSteal, Rendering, Settings;
        public static int percentHealth;

        public static void Initialize()
        {
            mainMenu = MainMenu.AddMenu("AbsoluteGaren", "mainMenu");
            Combo = mainMenu.AddSubMenu("Combo", "ComboMenu");
            LaneClear = mainMenu.AddSubMenu("LaneClear", "LaneClearMenu");
            LastHit = mainMenu.AddSubMenu("LastHit", "LastHitMenu");
            JungleClear = mainMenu.AddSubMenu("JungleClear", "JungleClearMenu");
            KillSteal = mainMenu.AddSubMenu("KillSteal", "KillStealMenu");
            Rendering = mainMenu.AddSubMenu("Rendering", "RenderingMenu");
            Settings = mainMenu.AddSubMenu("Settings", "SettingsMenu");

            mainMenu.AddGroupLabel("Created by Counter");
            mainMenu.AddLabel("This addon is designed for the Champion, Garen.");
            mainMenu.AddLabel("Found a bug or error? Please contact me by PM on EloBuddy.");
            
            Combo.AddGroupLabel("Combo Features");
            Combo.AddCheckBox("comboQ", "Use Q");
            Combo.AddCheckBox("comboE", "Use E");
            
            LaneClear.AddGroupLabel("LaneClear Features");
            LaneClear.AddCheckBox("laneQ", "Use Q", false);
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
            
            Rendering.AddGroupLabel("Rendering Features");
            //Rendering.AddCheckBox("renderP", "Render Player HP Bar");
            //Rendering.AddCheckBox("renderA", "Render Ally HP Bar");
            Rendering.AddCheckBox("renderE", "Render Enemy HP Bar");
            Rendering.AddCheckBox("killable", "Display 'Killable' text");
            Rendering.AddLabel("Rendering Configurations");
            Rendering.AddCheckBox("renderS_dmg", "Render Spell damage");
            Rendering.AddCheckBox("renderI_dmg", "Render Item damage");
            Rendering.AddSlider("renderAA", "Render Basic Attack damage", 2, 0, 5);
            //Rendering.AddCheckBox("renderS_heal", "Render Spell healing");
            //Rendering.AddCheckBox("renderI_heal", "Render Item healing");

            Settings.AddGroupLabel("Settings Features");
            Settings.AddCheckBox("cleanseQ", "Cleanse Slows with Q", false);
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
