using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace AbsoluteBravery
{
    class Program
    {
        public static AIHeroClient _player;
        public static GameMapId mapID;
        public static List<ItemId> itemList;
        public static List<ItemId> potentialItems;
        public static List<SpellSlot> spellList;
        public static string title;
        public static float Time = 0;

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            _player = Player.Instance;
            mapID = Game.MapId;

            // Initialize classes
            MenuManager.Initialize();

            // Initialize methods
            title = GenerateTitle();
            potentialItems = GeneratePotentialList();
            itemList = GenerateItemList();
            spellList = GenerateSpellList();
            Time = Game.Time;

            // Configure dirk options
            if (MenuManager.Settings.GetCheckBoxValue("dirk"))
                Lists.dirkoption = ItemId.Poachers_Dirk;
            else if (!MenuManager.Settings.GetCheckBoxValue("dirk"))
                Lists.dirkoption = ItemId.Serrated_Dirk;

            foreach (ItemId item in itemList)
                Console.WriteLine(item);

            // Activate events
            Game.OnTick += Game_OnTick;
            Player_OnLevelUp(null, null);
            Player.OnLevelUp += Player_OnLevelUp;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Game.Time - Time >= 1f)
            {
                Time = Game.Time;

                BuyItem();
            }
        }

        #region ItemList
        private static List<ItemId> GeneratePotentialList()
        {
            List<ItemId> list = new List<ItemId>();

            list.AddRange(Lists.globalItemList);

            if (Game.MapId == GameMapId.SummonersRift)
                list.AddRange(Lists.SRItemList);
            else if (Game.MapId == GameMapId.HowlingAbyss)
                list.AddRange(Lists.HAItemList);
            else if (Game.MapId == GameMapId.TwistedTreeline)
                list.AddRange(Lists.TTItemList);

            if (_player.IsMelee)
            {
                list.Add(ItemId.Ravenous_Hydra);
                list.Add(ItemId.Titanic_Hydra);
            }

            if (_player.IsRanged)
                list.Add(ItemId.Runaans_Hurricane);

            return list;
        }

        private static List<ItemId> GenerateItemList()
        {
            int itemcount = 6;
            List<ItemId> list = new List<ItemId>();
            
            if (Game.MapId == GameMapId.SummonersRift)
            {
                list.Add(Lists.UpgradedTrinketItemList.RandomItemIdFromList());
                itemcount++;
            }

            if (_player.Hero == Champion.Viktor)
                list.Add(ItemId.Perfect_Hex_Core);

            if (_player.Hero != Champion.Cassiopeia)
                list.Add(AddBoots());

            if (_player.GetSpellSlotFromName("summonersmite") != SpellSlot.Unknown)
                list.Add(AddJungleItem());
            
            while (list.Count < itemcount)
                AddItemToList(list);

            return OrganizeList(list);
        }

        private static bool ItemChecks(List<ItemId> list, ItemId item)
        {
            if (item == ItemId.Ravenous_Hydra && list.Contains(ItemId.Titanic_Hydra))
                return false;

            if (item == ItemId.Titanic_Hydra && list.Contains(ItemId.Ravenous_Hydra))
                return false;

            if (Lists.SupportItemList.Contains(item) && list.Any(a => Lists.SupportItemList.Any(b => b == a)))
                return false;

            if (Lists.AStackList.Contains(item) && list.Any(a => Lists.AStackList.Any(b => b == a))
                && _player.InventoryItems.All(a => !Lists.AStackList.Contains(a.Id)))
                return false;

            if (Lists.MStackList.Contains(item) && list.Any(a => Lists.MStackList.Any(b => b == a))
                && _player.InventoryItems.All(a => !Lists.MStackList.Contains(a.Id)))
                return false;

            return true;
        }

        private static List<ItemId> OrganizeList(List<ItemId> list)
        {
            List<ItemId> newlist = new List<ItemId>();
            List<ItemId> stacklist = new List<ItemId>() {
                ItemId.Archangels_Staff,
                ItemId.Archangels_Staff_Quick_Charge,
                ItemId.Manamune,
                ItemId.Manamune_Quick_Charge,
                ItemId.Rod_of_Ages,
                ItemId.Rod_of_Ages_Quick_Charge
            };

            foreach (ItemId item in list)
            {
                if (Lists.UpgradedTrinketItemList.Contains(item))
                    newlist.Add(item);
            }

            foreach (ItemId item in list)
            {
                if (Lists.SRJungleItemList.Contains(item))
                    newlist.Add(item);
            }

            foreach (ItemId item in list)
            {
                if (Lists.UpgradedBootsItemList.Contains(item))
                    newlist.Add(item);
            }

            foreach (ItemId item in list)
            {
                if (item == ItemId.Perfect_Hex_Core)
                    newlist.Add(item);
            }

            foreach (ItemId item in list)
            {
                if (Lists.SupportItemList.Contains(item))
                    newlist.Add(item);
            }

            foreach (ItemId item in list)
            {
                if (stacklist.Contains(item))
                    newlist.Add(item);
            }

            newlist.AddRange(list.Where(a => !newlist.Contains(a)));

            return newlist;
        }
        #endregion

        #region Items
        private static void AddItemToList(List<ItemId> list)
        {
            ItemId item = ItemId.Unknown;
            switch (title)
            {
                case "ADC":
                    item = AddRandomItem();
                    break;
                case "AP":
                    item = AddRandomItem();
                    break;
                case "Tank":
                    item = AddRandomItem();
                    break;
                case "Support":
                    item = AddRandomItem();
                    break;
                case "Random":
                    item = AddRandomItem();
                    break;
            }
            
            if (item != ItemId.Unknown)
                if (!list.Contains(item) && ItemChecks(list, item))
                    list.Add(item);
        }

        private static ItemId AddBoots()
        {
            List<ItemId> list = new List<ItemId>();

            if (list.Count == 0)
                list.AddRange(Lists.UpgradedBootsItemList);

            return list.RandomItemIdFromList();
        }

        private static ItemId AddJungleItem()
        {
            List<ItemId> list = new List<ItemId>();

            if (Game.MapId == GameMapId.SummonersRift)
                list.AddRange(Lists.SRJungleItemList);
            else if (Game.MapId == GameMapId.TwistedTreeline)
                list.AddRange(Lists.TTJungleItemList);

            return list.RandomItemIdFromList();
        }

        private static ItemId AddRandomItem()
        {
            List<ItemId> list = new List<ItemId>();

            list.AddRange(potentialItems);

            return list.RandomItemIdFromList();
        }

        private static ItemId AddADItem()
        {
            List<ItemId> list = new List<ItemId>();

            return list.RandomItemIdFromList();
        }
        #endregion

        #region Spells
        private static List<SpellSlot> GenerateSpellList()
        {
            int spellcount = 1;
            List<SpellSlot> list = new List<SpellSlot>();
            List<SpellSlot> spells = new List<SpellSlot>() { SpellSlot.Q, SpellSlot.W, SpellSlot.E };

            list.Add(SpellSlot.R);

            while (spellcount < 4)
            {
                SpellSlot slot = spells.RandomSpellSlotFromList();
                if (!list.Contains(slot))
                {
                    list.Add(slot);
                    spellcount++;
                }
            }

            return list;
        }

        private static void Player_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (_player.Level == 2 && _player.Spellbook.Spells.Any(a => a.Slot != SpellSlot.R && !a.IsLearned))
                Player.LevelSpell(_player.Spellbook.Spells.FirstOrDefault(a => a.Slot != SpellSlot.R && !a.IsLearned).Slot);
            else
                spellList.All(a => Player.LevelSpell(a));
        }
        #endregion

        #region Shopping
        private static void BuyItem()
        {
            if (Shop.CanShop)
            {
                foreach (ItemId item in itemList)
                {
                    if (itemList.IndexOf(item) - 1 >= 0
                        && itemList[itemList.IndexOf(item) - 1] != ItemId.Farsight_Alteration
                        && itemList[itemList.IndexOf(item) - 1] != ItemId.Oracle_Alteration
                        && _player.InventoryItems.All(a => a.Id != itemList[itemList.IndexOf(item) - 1]))
                        break;
                        
                    if (_player.InventoryItems.All(a => a.Id != item))
                    {
                        if (!Shop.BuyItem(item)
                            || ((item == ItemId.Farsight_Alteration || item == ItemId.Oracle_Alteration)
                            && _player.Level < 9))
                        {
                            if (!BuyComponents(item))
                            {
                                ItemBuilding ibuild = Lists.ItemsBuiltList.FirstOrDefault(a => a.result == item);
                                    
                                if (ibuild != null)
                                    foreach (ItemId id in ibuild.components)
                                        BuyComponents(id);
                            }
                        }
                    }
                }
            }
        }

        private static bool BuyComponents(ItemId item)
        {
            ItemBuilding ibuild = Lists.ItemsBuiltList.FirstOrDefault(a => a.result == item);

            if (ibuild != null)
            {
                bool hasAllItems = ibuild.components.All(a =>
                    ibuild.components.Count(b => b == a) == _player.InventoryItems.Count(c => c.Id == a));

                if (!hasAllItems)
                {
                    foreach (ItemId component in ibuild.components
                        .Where(a => ibuild.components.Count(b => b == a)
                        != _player.InventoryItems.Count(c => c.Id == a)))
                    {
                        if (ibuild.components.IndexOf(component) - 1 >= 0
                            && _player.InventoryItems.All(a => a.Id != ibuild.components[ibuild.components.IndexOf(component) - 1]))
                            break;

                        if (!Shop.BuyItem(component))
                            return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region Title
        private static string GenerateTitle()
        {
            List<string> list = new List<string>()
            {
                "ADC",
                "AP",
                "Tank",
                "Support",
                "Random"
            };

            return list.RandomStringFromList();
        }
        #endregion
    }
}
