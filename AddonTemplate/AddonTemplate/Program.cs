using System;
using System.Drawing;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace AddonTemplate
{
    class Program
    {
        // Every application must contain a Main method to specify where the program must begin to execution.
        static void Main(string[] args)
        {
            // This event waits until the Loading Screen completes execution before continuing.
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        
        // This event is now active because the player is In-Game. Begin constructing code in this event.
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            // Verify the player's Champion with the addon's Champion, else prevent furthur instructions with the "return" statement.
                // We will use Ryze as in example. The Champion enum holds a list of each Champion.
            if (Player.Instance.Hero != Champion.Ryze) return;

            // If console is active, verify that the addon is loaded with text.
                // Using Chat.Print("") is also an option.
            Console.WriteLine("AddonTemplate initialized.");

            // Use Initialize() or Init() methods to connect classes and preform beginning instructions for an addon.
                // Common methods that need to be initalized would be for Spells, Configurations, or the Menu data.

            // Go to class SpellManager to review.
            SpellManager.Initialize();

            // Go to class MenuManager to review.
            MenuManager.Initialize();

            /* The EloBuddy.SDK holds many useful events that assist with addons.
             * Game.OnUpdate        - Preforms actions every moment the game updates information.
             * Game.OnTick          - Preforms actions every game tick, where there are 30 ticks per second.
             * Drawing.OnDraw       - Preforms actions to draw objects in an overly of the game.
             * And various other events, these being the most common.
             */
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        // Drawing events are a fun way to visually look at overlayed information.
        private static void Drawing_OnDraw(EventArgs args)
        {
            // A common mistake is drawing too early or without needing to.
            if (Player.Instance.IsDead || Game.Time > 0) return;
            
            // Let's draw a circle around our player's Champion.
                // We need a few things to do so: a position, the circle's radius, and a color.
                // For this example, we will use the champion's position, it's Basic Attack range, and the color Blue!
                
            Drawing.DrawCircle(Player.Instance.Position, Player.Instance.GetAutoAttackRange(), Color.Blue);

            // This can be continued to draw circles for things like Q or W or E or R range. For example:
            Drawing.DrawCircle(Player.Instance.Position, SpellManager.Q.Range, Color.Blue);
        }

        // Let's use this event to call methods from other classes.
        private static void Game_OnTick(EventArgs args)
        {
            // Only preform mode actions while alive.
            if (Player.Instance.IsDead) return;

            // Check if the user is using the correlating mode to the OrbWalker.
            if  (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Combo)
                ModeManager.Combo();
        }
    }
}
