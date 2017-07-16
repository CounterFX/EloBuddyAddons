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
        public static List<SpellSlot> spellList;
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
            itemList = GenerateItemList();
            spellList = GenerateSpellList();
            Time = Game.Time;

            // Activate events
            Game.OnTick += Game_OnTick;
            Player_OnLevelUp(null, null);
            Player.OnLevelUp += Player_OnLevelUp;
        }

        private static void Game_OnTick(EventArgs args)
        {
            // Prevent purchasing too quickly
            if (Game.Time - Time >= 1f)
            {
                Time = Game.Time;

                // if shopping is available by fountain or death
                if (Shop.CanShop)
                {
                    // Check each item in list
                    foreach (ItemId item in itemList)
                    {
                        // Check to see if all previous items in the list were purchased
                        if (itemList.IndexOf(item) - 1 >= 0
                            && itemList[itemList.IndexOf(item) - 1] != ItemId.Farsight_Alteration
                            && itemList[itemList.IndexOf(item) - 1] != ItemId.Oracle_Alteration
                            && _player.InventoryItems.All(a => a.Id != itemList[itemList.IndexOf(item) - 1]))
                            break;
                        
                        // Check to make sure player doesn't own said item
                        if (_player.InventoryItems.All(a => a.Id != item))
                        {
                            // If player cannot buy item, check for components of that item
                            if (!Shop.BuyItem(item)
                                || ((item == ItemId.Farsight_Alteration || item == ItemId.Oracle_Alteration)
                                && _player.Level < 9))
                            {
                                // If player cannot buy components of said item, check for its components
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
        }

        private static void Player_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            spellList.All(a => Player.LevelSpell(a));
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
                list.Add(GenerateBoots());

            if (_player.GetSpellSlotFromName("summonersmite") != SpellSlot.Unknown)
                list.Add(GenerateJungleItem());
            
            while (list.Count < itemcount)
            {
                ItemId item = GenerateRandomItem();
                if (!list.Contains(item) && ItemChecks(list, item))
                    list.Add(item);
            }
            
            return list;
        }

        private static ItemId GenerateBoots()
        {
            List<ItemId> list = new List<ItemId>();

            if (list.Count == 0)
                list.AddRange(Lists.BootsItemList);

            return list.RandomItemIdFromList();
        }

        private static ItemId GenerateJungleItem()
        {
            List<ItemId> list = new List<ItemId>();

            if (Game.MapId == GameMapId.SummonersRift)
                list.AddRange(Lists.SRJungleItemList);
            else if (Game.MapId == GameMapId.TwistedTreeline)
                list.AddRange(Lists.TTJungleItemList);

            return list.RandomItemIdFromList();
        }

        private static ItemId GenerateRandomItem()
        {
            List<ItemId> list = new List<ItemId>();
            list.AddRange(Lists.globalItemList); 

            if (Game.MapId == GameMapId.SummonersRift)
                list.AddRange(Lists.SRItemList);
            else if (Game.MapId == GameMapId.HowlingAbyss)
                list.AddRange(Lists.HAItemList);
            else if (Game.MapId == GameMapId.TwistedTreeline)
                list.AddRange(Lists.TTItemList);

            if (_player.IsMelee
                && (_player.Hero == Champion.Jayce || _player.Hero == Champion.Nidalee || _player.Hero == Champion.Gnar))
            {
                list.Add(ItemId.Ravenous_Hydra);
                list.Add(ItemId.Titanic_Hydra);
            }
            if (_player.IsRanged
                && (_player.Hero == Champion.Jayce || _player.Hero == Champion.Nidalee || _player.Hero == Champion.Gnar))
                list.Add(ItemId.Runaans_Hurricane);

            return list.RandomItemIdFromList();
        }

        private static bool ItemChecks(List<ItemId> list, ItemId item)
        {
            if (item == ItemId.Ravenous_Hydra && list.Contains(ItemId.Titanic_Hydra))
                return false;

            if (item == ItemId.Titanic_Hydra && list.Contains(ItemId.Ravenous_Hydra))
                return false;

            if (Lists.SupportItemList.Contains(item) && list.Any(a => Lists.SupportItemList.Any(b => b == a)))
                return false;

            return true;
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
    }
}
