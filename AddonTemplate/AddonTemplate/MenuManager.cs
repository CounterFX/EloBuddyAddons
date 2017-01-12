using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate
{
    class MenuManager
    {
        // These are our Menu objects to begin constructing with.
        public static Menu mainMenu, comboMenu;
        
        // The method we called inside Loading.OnLoadingComplete event to initalize Menu information.
        public static void Initialize()
        {
            // Let's create a Menu with a SubMenu, a GroupLabel, a Label, s Seperator, a Checkbox, and a Slider.
            // Firstly we must assign the mainMenu object with a new Menu.
                // To add a Menu, use the extension - AddMenu("Display Name", "UniqueIdentifierString").
            mainMenu = MainMenu.AddMenu("Main Menu", "M");

            // A SubMenu is a menu option below the Main class that holds specific information.
                // Let's create a Combo feature SubMenu!
            comboMenu = mainMenu.AddSubMenu("Combo", "C");

            // A Group Label is a header Label for our Menu.
            comboMenu.AddGroupLabel("Combo Features");

            // A Label is a line of line that displays information.
            comboMenu.AddLabel("(These features are only used in Combo Mode!)");

            // A Separator is a blank line to space apart Menu features.
            comboMenu.AddSeparator();

            // A Checkbox is a on / off toggle box that is often used for features.
            comboMenu.Add("CheckBox", new CheckBox("Use Q"));

            // A Slider is a scrolling bar that is used to selct multiple options.
                // Sliders have an origin amount (like pre-set amount), a minimum amount, and a maximum amount.
            comboMenu.Add("Slider", new Slider("Limit Q by Mana Percentage", 75, 0, 100));
        }
    }
}