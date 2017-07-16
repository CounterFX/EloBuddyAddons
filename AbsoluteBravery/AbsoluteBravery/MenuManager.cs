using System;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace AbsoluteBravery
{
    class MenuManager
    {
        public static Menu mainMenu, Rules, Settings;

        public static void Initialize()
        {
            mainMenu = MainMenu.AddMenu("AbsoluteBravery", "mainMenu");
            Rules = mainMenu.AddSubMenu("Rules");
            Settings = mainMenu.AddSubMenu("Settings");

            mainMenu.AddGroupLabel("Created by Counter");
            mainMenu.AddLabel("This addon is designed for the custom game mode, AbsoluteBravery.");
            mainMenu.AddLabel("Found a bug or error? Please contact me by PM on EloBuddy.");

            Rules.AddGroupLabel("Rules");
            Rules.AddLabel("AbsoluteBravery is a game mode designed to challenge players.");
            Rules.AddLabel("Using randomized item sets and leveling systems to achieve victory.");
            Rules.AddGroupLabel("How It Works:");
            Rules.AddLabel("1. Auto buy boots as first time.");
            Rules.AddLabel("Exception: Cassiopeia begins building items.");

            Settings.AddGroupLabel("Settings");
            Settings.AddCheckBox("dirk", "Build Poacher's Dirk first", false);

            Console.WriteLine("MenuManager initialized.");
        }
    }
}
