using System;
using EloBuddy.SDK.Menu;
using EloBuddy;
using EloBuddy.SDK;

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
            Combo.AddCheckBox("Q", "Use Q");
            Combo.AddCheckBox("E", "Use E");
            
            LaneClear.AddGroupLabel("LaneClear Features");
            LaneClear.AddCheckBox("Q", "Use Q", false);
            LaneClear.AddCheckBox("E", "Use E");
            
            LastHit.AddGroupLabel("LastHit Features");
            LastHit.AddCheckBox("Q", "Use Q");
            
            JungleClear.AddGroupLabel("JungleClear Features");
            JungleClear.AddCheckBox("Q", "Use Q");
            JungleClear.AddCheckBox("E", "Use E");
            
            KillSteal.AddGroupLabel("KillSteal Features");
            KillSteal.AddCheckBox("AA", "KS with Basic Attack");
            KillSteal.AddCheckBox("Q", "KS with Q");
            KillSteal.AddCheckBox("R", "KS with R");
            
            Rendering.AddGroupLabel("Rendering Features");
            Rendering.AddCheckBox("player", "Render Player HP Bar");
            Rendering.AddCheckBox("enemy", "Render Enemy HP Bar");
            Rendering.AddCheckBox("killable", "Display 'Killable' text");
            Rendering.AddLabel("Rendering Configurations");
            Rendering.AddCheckBox("spell_dmg", "Render Spell damage");
            Rendering.AddCheckBox("item_dmg", "Render Item damage");
            Rendering.AddSlider("aa_dmg", "Render Basic Attack damage", 2, 0, 5);
            Rendering.AddCheckBox("item_heal", "Render Item healing");

            Settings.AddGroupLabel("Settings Features");
            Settings.AddCheckBox("cleanse", "Cleanse Slows with Q", false);
            Settings.AddCheckBox("destroy", "Destroy structures with Q");
            Settings.AddSlider("percentQ", "Save Q for ks when unit Health percent >= ", 35, 0, 100);

            Settings.GetSliderObject("percentQ").OnValueChange += PercentageQ_OnValueChange;

            Console.WriteLine("MenuManager initialized.");
        }

        static void PercentageQ_OnValueChange(EloBuddy.SDK.Menu.Values.ValueBase<int> sender,
            EloBuddy.SDK.Menu.Values.ValueBase<int>.ValueChangeArgs args)
        {
            percentHealth = args.NewValue;
        }
    }
}
