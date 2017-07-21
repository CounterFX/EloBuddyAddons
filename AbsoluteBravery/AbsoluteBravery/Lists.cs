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
    class Lists
    {
        public static ItemId dirkoption;

        #region MapId ItemLists
        public static List<ItemId> globalItemList = new List<ItemId>()
        {
            ItemId.Abyssal_Scepter, ItemId.Ardent_Censer, ItemId.Athenes_Unholy_Grail,
            ItemId.Banner_of_Command, ItemId.Banshees_Veil, ItemId.Blade_of_the_Ruined_King,
            ItemId.Dead_Mans_Plate, ItemId.Deaths_Dance, ItemId.Duskblade_of_Draktharr,
            ItemId.Edge_of_Night, ItemId.Essence_Reaver, ItemId.Frozen_Heart,
            ItemId.Frozen_Mallet, ItemId.Guinsoos_Rageblade, ItemId.Hextech_GLP_800,
            ItemId.Hextech_Gunblade, ItemId.Hextech_Protobelt_01, ItemId.Iceborn_Gauntlet,
            ItemId.Infinity_Edge, ItemId.Knights_Vow, ItemId.Liandrys_Torment,
            ItemId.Lich_Bane, ItemId.Locket_of_the_Iron_Solari, ItemId.Lord_Dominiks_Regards,
            ItemId.Ludens_Echo, ItemId.Maw_of_Malmortius, ItemId.Mercurial_Scimitar,
            ItemId.Mikaels_Crucible, ItemId.Morellonomicon,
            ItemId.Mortal_Reminder, ItemId.Nashors_Tooth, ItemId.Phantom_Dancer,
            ItemId.Randuins_Omen, ItemId.Rapid_Firecannon, ItemId.Redemption,
            ItemId.Righteous_Glory, ItemId.Rylais_Crystal_Scepter, ItemId.Spirit_Visage,
            ItemId.Statikk_Shiv, ItemId.Steraks_Gage, ItemId.Sunfire_Cape,
            ItemId.The_Black_Cleaver, ItemId.The_Bloodthirster, ItemId.Thornmail,
            ItemId.Trinity_Force, ItemId.Void_Staff, ItemId.Warmogs_Armor,
            ItemId.Wits_End, ItemId.Youmuus_Ghostblade, ItemId.Zekes_Harbinger,
            /* Adapative Helm*/ (ItemId)3194, /* Gargoyle Stoneplate */ (ItemId)3193,
        };

        public static List<ItemId> SRItemList = new List<ItemId>()
        {
            ItemId.Archangels_Staff, ItemId.Eye_of_the_Equinox, ItemId.Eye_of_the_Oasis,
            ItemId.Eye_of_the_Watchers, ItemId.Face_of_the_Mountain, ItemId.Frost_Queens_Claim,
            ItemId.Guardian_Angel, ItemId.Manamune, ItemId.Mejais_Soulstealer,
            ItemId.Ohmwrecker, ItemId.Rabadons_Deathcap, ItemId.Rod_of_Ages,
            ItemId.Ruby_Sightstone, ItemId.Talisman_of_Ascension, ItemId.Zhonyas_Hourglass,
            ItemId.ZzRot_Portal,
        };

        public static List<ItemId> HAItemList = new List<ItemId>()
        {
            ItemId.Archangels_Staff_Quick_Charge, ItemId.Manamune_Quick_Charge, ItemId.Rabadons_Deathcap,
            ItemId.Rod_of_Ages_Quick_Charge, ItemId.Zhonyas_Hourglass,
        };

        public static List<ItemId> TTItemList = new List<ItemId>()
        {
            ItemId.Archangels_Staff, ItemId.Face_of_the_Mountain, ItemId.Frost_Queens_Claim,
            ItemId.Lord_Van_Damms_Pillager, ItemId.Manamune, ItemId.Moonflair_Spellblade,
            ItemId.Rod_of_Ages, ItemId.Talisman_of_Ascension, ItemId.Wooglets_Witchcap,
        };
        #endregion

        #region Statistic ItemLists
        public static List<ItemId> ArmorPenItemList = new List<ItemId>()
        {
            ItemId.Last_Whisper, ItemId.Lord_Dominiks_Regards, ItemId.Mortal_Reminder,
            ItemId.The_Black_Cleaver,
        };

        public static List<ItemId> ActiveItemList = new List<ItemId>()
        {
            ItemId.Banner_of_Command, ItemId.Bilgewater_Cutlass,
            ItemId.Blade_of_the_Ruined_King, ItemId.Edge_of_Night, ItemId.Eye_of_the_Equinox,
            ItemId.Eye_of_the_Oasis, ItemId.Eye_of_the_Watchers, ItemId.Face_of_the_Mountain,
            ItemId.Farsight_Alteration, ItemId.Frost_Queens_Claim, ItemId.Hextech_GLP_800,
            ItemId.Hextech_Gunblade, ItemId.Hextech_Protobelt_01, ItemId.Knights_Vow,
            ItemId.Locket_of_the_Iron_Solari, ItemId.Mercurial_Scimitar, ItemId.Mikaels_Crucible,
            ItemId.Ohmwrecker, ItemId.Oracle_Alteration, ItemId.Quicksilver_Sash,
            ItemId.Randuins_Omen, ItemId.Redemption, ItemId.Righteous_Glory,
            ItemId.Ruby_Sightstone, ItemId.Sightstone, ItemId.Soul_Anchor_Trinket,
            ItemId.Sweeping_Lens_Trinket, ItemId.Talisman_of_Ascension, ItemId.Warding_Totem_Trinket,
            ItemId.Wooglets_Witchcap, ItemId.Youmuus_Ghostblade, ItemId.Zhonyas_Hourglass,
            ItemId.ZzRot_Portal,
        };

        public static List<ItemId> ADItemList = new List<ItemId>()
        {
            ItemId.B_F_Sword, ItemId.Bilgewater_Cutlass, ItemId.Blade_of_the_Ruined_King,
            ItemId.Caulfields_Warhammer, ItemId.Cull, ItemId.Deaths_Dance,
            ItemId.Dorans_Blade, ItemId.Duskblade_of_Draktharr, ItemId.Edge_of_Night,
            ItemId.Elixir_of_Wrath, ItemId.Essence_Reaver, ItemId.Executioners_Calling,
            ItemId.Frozen_Mallet, ItemId.Giant_Slayer, ItemId.Guardian_Angel,
            ItemId.Guardians_Hammer, ItemId.Guinsoos_Rageblade, ItemId.Hexdrinker,
            ItemId.Hextech_Gunblade, ItemId.Infinity_Edge, ItemId.Jaurims_Fist,
            ItemId.Last_Whisper, ItemId.Long_Sword, ItemId.Lord_Dominiks_Regards,
            ItemId.Lord_Van_Damms_Pillager, ItemId.Manamune, ItemId.Manamune_Quick_Charge,
            ItemId.Maw_of_Malmortius, ItemId.Mercurial_Scimitar, ItemId.Mortal_Reminder,
            ItemId.Muramana, ItemId.Phage, ItemId.Pickaxe,
            ItemId.Poachers_Dirk, ItemId.Ravenous_Hydra, ItemId.Serrated_Dirk,
            ItemId.Steraks_Gage, ItemId.The_Black_Cleaver, ItemId.The_Bloodthirster,
            ItemId.Tiamat, ItemId.Titanic_Hydra, ItemId.Trinity_Force,
            ItemId.Vampiric_Scepter,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.Trackers_Knife_Enchantment_Warrior,
            ItemId.Youmuus_Ghostblade,
        };

        public static List<ItemId> APItemList = new List<ItemId>()
        {
            ItemId.Aether_Wisp, ItemId.Amplifying_Tome, ItemId.Archangels_Staff,
            ItemId.Archangels_Staff_Quick_Charge, ItemId.Ardent_Censer, ItemId.Athenes_Unholy_Grail,
            ItemId.Banshees_Veil, ItemId.Blasting_Wand, ItemId.Dorans_Ring,
            ItemId.Elixir_of_Sorcery, ItemId.Eye_of_the_Watchers, ItemId.Fiendish_Codex,
            ItemId.Frost_Queens_Claim, ItemId.Frostfang, ItemId.Guardians_Orb,
            ItemId.Guinsoos_Rageblade, ItemId.Haunting_Guise, ItemId.Hextech_GLP_800,
            ItemId.Hextech_Gunblade, ItemId.Hextech_Protobelt_01, ItemId.Hextech_Revolver,
            ItemId.Liandrys_Torment, ItemId.Lich_Bane, ItemId.Lost_Chapter,
            ItemId.Ludens_Echo, ItemId.Mejais_Soulstealer, ItemId.Moonflair_Spellblade,
            ItemId.Morellonomicon, ItemId.Nashors_Tooth, ItemId.Needlessly_Large_Rod,
            ItemId.Rabadons_Deathcap, ItemId.Rod_of_Ages, ItemId.Rod_of_Ages_Quick_Charge,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Trackers_Knife_Enchantment_Runic_Echoes,
            ItemId.Seekers_Armguard, ItemId.Seraphs_Embrace, ItemId.Sorcerers_Shoes,
            ItemId.Spellthiefs_Edge, ItemId.The_Dark_Seal, ItemId.Void_Staff,
            ItemId.Wooglets_Witchcap, ItemId.Zhonyas_Hourglass,
        };

        public static List<ItemId> ArmorItemList = new List<ItemId>()
        {
            ItemId.Aegis_of_the_Legion, ItemId.Banner_of_Command, ItemId.Chain_Vest,
            ItemId.Cloth_Armor, ItemId.Dead_Mans_Plate, ItemId.Frozen_Heart,
            /* Gargoyle Stoneplate */ (ItemId)3193, ItemId.Glacial_Shroud, ItemId.Guardian_Angel,
            ItemId.Iceborn_Gauntlet, ItemId.Knights_Vow, ItemId.Locket_of_the_Iron_Solari,
            ItemId.Moonflair_Spellblade, ItemId.Ninja_Tabi, ItemId.Ohmwrecker,
            ItemId.Randuins_Omen, ItemId.Raptor_Cloak, ItemId.Righteous_Glory,
            ItemId.Seekers_Armguard, ItemId.Sunfire_Cape, ItemId.Talisman_of_Ascension,
            ItemId.Thornmail, ItemId.Wardens_Mail, ItemId.Wooglets_Witchcap,
            ItemId.Zekes_Harbinger, ItemId.Zhonyas_Hourglass, ItemId.ZzRot_Portal,
        };

        public static List<ItemId> AttackSpeedItemList = new List<ItemId>()
        {
            ItemId.Berserkers_Greaves, ItemId.Blade_of_the_Ruined_King,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Trackers_Knife_Enchantment_Bloodrazor,
            ItemId.Dagger, ItemId.Guinsoos_Rageblade,
            ItemId.Kircheis_Shard, ItemId.Maw_of_Malmortius, ItemId.Nashors_Tooth,
            ItemId.Phantom_Dancer, ItemId.Phantom_Dancer, ItemId.Rapid_Firecannon,
            ItemId.Recurve_Bow, ItemId.Recurve_Bow_Enchantment_Bloodrazor, ItemId.Runaans_Hurricane,
            ItemId.Statikk_Shiv, ItemId.Stinger, ItemId.Trinity_Force,
            ItemId.Wits_End, ItemId.Zeal,
        };

        public static List<ItemId> AuraItemList = new List<ItemId>()
        {
            ItemId.Abyssal_Scepter, ItemId.Frozen_Heart,
        };

        public static List<ItemId> CDItemList_TenPercent = new List<ItemId>()
        {
            ItemId.Abyssal_Scepter, /* Adapative Helm*/ (ItemId)3194, ItemId.Ancient_Coin,
            ItemId.Ardent_Censer, ItemId.Athenes_Unholy_Grail, ItemId.Banner_of_Command,
            ItemId.Banshees_Veil, ItemId.Caulfields_Warhammer, ItemId.Deaths_Dance,
            ItemId.Essence_Reaver, ItemId.Face_of_the_Mountain, ItemId.Fiendish_Codex,
            ItemId.Forbidden_Idol, ItemId.Frost_Queens_Claim, ItemId.Frozen_Heart,
            ItemId.Glacial_Shroud, ItemId.Hextech_Protobelt_01, ItemId.Iceborn_Gauntlet,
            ItemId.Ionian_Boots_of_Lucidity, ItemId.Kindlegem, ItemId.Knights_Vow,
            ItemId.Lord_Van_Damms_Pillager, ItemId.Maw_of_Malmortius, ItemId.Mikaels_Crucible,
            ItemId.Morellonomicon, ItemId.Nashors_Tooth, ItemId.Nomads_Medallion,
            ItemId.Ohmwrecker, ItemId.Redemption, ItemId.Righteous_Glory,
            ItemId.Sheen, ItemId.Spirit_Visage, ItemId.Stinger,
            ItemId.Talisman_of_Ascension, ItemId.The_Black_Cleaver, ItemId.Trinity_Force,
            ItemId.Warmogs_Armor,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.Trackers_Knife_Enchantment_Warrior,
            ItemId.Youmuus_Ghostblade, ItemId.Zekes_Harbinger, ItemId.Zhonyas_Hourglass,
        };

        public static List<ItemId> ConsumableItemList = new List<ItemId>()
        {
            ItemId.Corrupting_Potion, ItemId.Elixir_of_Iron, ItemId.Elixir_of_Sorcery,
            ItemId.Elixir_of_Wrath, ItemId.Health_Potion, ItemId.Hunters_Potion,
            ItemId.Oracles_Extract, ItemId.Poro_Snax, ItemId.Diet_Poro_Snax,
            ItemId.Refillable_Potion, ItemId.Total_Biscuit_of_Rejuvenation,
        };

        public static List<ItemId> CriticalItemList = new List<ItemId>()
        {
            ItemId.Brawlers_Gloves, ItemId.Cloak_of_Agility, ItemId.Essence_Reaver,
            ItemId.Infinity_Edge, ItemId.Phantom_Dancer, ItemId.Rapid_Firecannon,
            ItemId.Runaans_Hurricane, ItemId.Statikk_Shiv, ItemId.Zeal,
        };

        public static List<ItemId> GoldItemList = new List<ItemId>()
        {
            ItemId.Ancient_Coin, ItemId.Cull, ItemId.Eye_of_the_Equinox, ItemId.Eye_of_the_Oasis,
            ItemId.Eye_of_the_Watchers, ItemId.Face_of_the_Mountain, ItemId.Frost_Queens_Claim,
            ItemId.Frostfang, ItemId.Nomads_Medallion, ItemId.Relic_Shield,
            ItemId.Spellthiefs_Edge, ItemId.Talisman_of_Ascension, ItemId.Targons_Brace,
        };

        public static List<ItemId> HealthItemList = new List<ItemId>()
        {
            ItemId.Abyssal_Scepter, /* Adapative Helm*/ (ItemId)3194, ItemId.Bamis_Cinder,
            ItemId.Catalyst_of_Aeons,
            ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk,
            ItemId.Stalkers_Blade_Enchantment_Cinderhulk,
            ItemId.Trackers_Knife_Enchantment_Cinderhulk,
            ItemId.Crystalline_Bracer, ItemId.Dead_Mans_Plate, ItemId.Dorans_Blade,
            ItemId.Dorans_Ring, ItemId.Dorans_Shield, ItemId.Eye_of_the_Equinox,
            ItemId.Eye_of_the_Oasis, ItemId.Eye_of_the_Watchers, ItemId.Face_of_the_Mountain,
            ItemId.Frozen_Mallet, /* Gargoyle Stoneplate */ (ItemId)3193, ItemId.Giants_Belt,
            ItemId.Guardians_Hammer, ItemId.Guardians_Horn, ItemId.Guardians_Orb,
            ItemId.Haunting_Guise, ItemId.Hextech_GLP_800, ItemId.Hextech_Protobelt_01,
            ItemId.Jaurims_Fist, ItemId.Kindlegem, ItemId.Knights_Vow,
            ItemId.Liandrys_Torment, ItemId.Lord_Van_Damms_Pillager, ItemId.Ohmwrecker,
            ItemId.Phage, ItemId.Randuins_Omen, ItemId.Redemption,
            ItemId.Relic_Shield, ItemId.Righteous_Glory, ItemId.Rod_of_Ages,
            ItemId.Rod_of_Ages_Quick_Charge, ItemId.Ruby_Crystal, ItemId.Ruby_Sightstone,
            ItemId.Rylais_Crystal_Scepter, ItemId.Sightstone, ItemId.Spectres_Cowl,
            ItemId.Spirit_Visage, ItemId.Steraks_Gage, ItemId.Sunfire_Cape,
            ItemId.Targons_Brace, ItemId.Titanic_Hydra, ItemId.Trinity_Force,
            ItemId.Warmogs_Armor,
        };

        public static List<ItemId> HPRegenItemList = new List<ItemId>()
        {
            /* Adapative Helm*/ (ItemId)3194, ItemId.Banner_of_Command, ItemId.Crystalline_Bracer,
            ItemId.Dorans_Shield, ItemId.Eye_of_the_Equinox, ItemId.Eye_of_the_Oasis,
            ItemId.Face_of_the_Mountain, ItemId.Guardians_Horn, ItemId.Nomads_Medallion,
            ItemId.Ohmwrecker, ItemId.Raptor_Cloak, ItemId.Ravenous_Hydra,
            ItemId.Redemption, ItemId.Rejuvenation_Bead, ItemId.Righteous_Glory,
            ItemId.Spirit_Visage, ItemId.Talisman_of_Ascension, ItemId.Targons_Brace,
            ItemId.Tiamat, ItemId.Titanic_Hydra, ItemId.Warmogs_Armor,
            ItemId.ZzRot_Portal,
        };

        public static List<ItemId> LethalityItemList = new List<ItemId>()
        {
            ItemId.Duskblade_of_Draktharr, ItemId.Edge_of_Night, ItemId.Serrated_Dirk,
            ItemId.Youmuus_Ghostblade,
        };

        public static List<ItemId> LifeStealItemList = new List<ItemId>()
        {
            ItemId.Bilgewater_Cutlass, ItemId.Blade_of_the_Ruined_King, ItemId.Deaths_Dance,
            ItemId.Dorans_Blade, ItemId.Guardians_Hammer, ItemId.Guinsoos_Rageblade,
            ItemId.Hextech_Gunblade, ItemId.Hunters_Machete, ItemId.Maw_of_Malmortius,
            ItemId.Ravenous_Hydra, ItemId.Skirmishers_Sabre,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
            ItemId.Stalkers_Blade,
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Cinderhulk,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.The_Bloodthirster, ItemId.Trackers_Knife,
            ItemId.Trackers_Knife_Enchantment_Bloodrazor,
            ItemId.Trackers_Knife_Enchantment_Cinderhulk,
            ItemId.Trackers_Knife_Enchantment_Runic_Echoes,
            ItemId.Trackers_Knife_Enchantment_Warrior,
            ItemId.Vampiric_Scepter,
        };

        public static List<ItemId> MagicPenItemList = new List<ItemId>()
        {
            ItemId.Haunting_Guise, ItemId.Liandrys_Torment, ItemId.Sorcerers_Shoes,
            ItemId.Void_Staff, ItemId.Wits_End,
        };

        public static List<ItemId> MagicResistItemList = new List<ItemId>()
        {
            ItemId.Abyssal_Scepter, /* Adapative Helm*/ (ItemId)3194, ItemId.Aegis_of_the_Legion,
            ItemId.Athenes_Unholy_Grail, ItemId.Banner_of_Command, ItemId.Banshees_Veil,
            ItemId.Chalice_of_Harmony, ItemId.Edge_of_Night, /* Gargoyle Stoneplate */ (ItemId)3193,
            ItemId.Hexdrinker, ItemId.Lich_Bane, ItemId.Locket_of_the_Iron_Solari,
            ItemId.Maw_of_Malmortius, ItemId.Mercurial_Scimitar, ItemId.Mercurys_Treads,
            ItemId.Mikaels_Crucible, ItemId.Moonflair_Spellblade, ItemId.Negatron_Cloak,
            ItemId.Null_Magic_Mantle, ItemId.Quicksilver_Sash, ItemId.Spectres_Cowl,
            ItemId.Spirit_Visage, ItemId.Wits_End, ItemId.Zekes_Harbinger,
            ItemId.ZzRot_Portal,
        };

        public static List<ItemId> ManaItemList = new List<ItemId>()
        {
            ItemId.Abyssal_Scepter, ItemId.Archangels_Staff, ItemId.Archangels_Staff_Quick_Charge,
            ItemId.Catalyst_of_Aeons, ItemId.Frozen_Heart, ItemId.Glacial_Shroud,
            ItemId.Hextech_GLP_800, ItemId.Iceborn_Gauntlet, ItemId.Lich_Bane,
            ItemId.Lost_Chapter, ItemId.Manamune, ItemId.Manamune_Quick_Charge,
            ItemId.Mejais_Soulstealer, ItemId.Mikaels_Crucible, ItemId.Muramana,
            ItemId.Righteous_Glory, ItemId.Rod_of_Ages, ItemId.Rod_of_Ages_Quick_Charge,
            ItemId.Sapphire_Crystal, ItemId.Seraphs_Embrace, ItemId.Sheen,
            ItemId.Tear_of_the_Goddess, ItemId.Tear_of_the_Goddess_Quick_Charge, ItemId.The_Dark_Seal,
            ItemId.Trinity_Force, ItemId.Zekes_Harbinger,
        };

        public static List<ItemId> ManaRegenItemList = new List<ItemId>()
        {
            ItemId.Ancient_Coin, ItemId.Archangels_Staff, ItemId.Archangels_Staff_Quick_Charge,
            ItemId.Ardent_Censer, ItemId.Athenes_Unholy_Grail, ItemId.Chalice_of_Harmony,
            ItemId.Dorans_Ring, ItemId.Elixir_of_Sorcery, ItemId.Essence_Reaver,
            ItemId.Eye_of_the_Oasis, ItemId.Eye_of_the_Watchers, ItemId.Faerie_Charm,
            ItemId.Forbidden_Idol, ItemId.Frost_Queens_Claim, ItemId.Frost_Queens_Claim,
            ItemId.Frostfang, ItemId.Guardians_Orb, ItemId.Hunters_Talisman,
            ItemId.Manamune, ItemId.Manamune_Quick_Charge, ItemId.Mikaels_Crucible,
            ItemId.Morellonomicon, ItemId.Muramana, ItemId.Nomads_Medallion,
            ItemId.Redemption, ItemId.Seraphs_Embrace, ItemId.Skirmishers_Sabre,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
            ItemId.Spellthiefs_Edge, ItemId.Stalkers_Blade,
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Cinderhulk,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.Talisman_of_Ascension, ItemId.Tear_of_the_Goddess, ItemId.Tear_of_the_Goddess_Quick_Charge,
            ItemId.Trackers_Knife,
            ItemId.Trackers_Knife_Enchantment_Bloodrazor,
            ItemId.Trackers_Knife_Enchantment_Cinderhulk,
            ItemId.Trackers_Knife_Enchantment_Runic_Echoes,
            ItemId.Trackers_Knife_Enchantment_Warrior,
        };

        public static List<ItemId> MovementItemList = new List<ItemId>()
        {
            ItemId.Aether_Wisp, ItemId.Ardent_Censer, ItemId.Banner_of_Command,
            ItemId.Berserkers_Greaves, ItemId.Boots_of_Mobility, ItemId.Boots_of_Speed,
            ItemId.Boots_of_Swiftness, ItemId.Dead_Mans_Plate, ItemId.Duskblade_of_Draktharr,
            ItemId.Edge_of_Night, ItemId.Ionian_Boots_of_Lucidity, ItemId.Knights_Vow,
            ItemId.Lich_Bane, ItemId.Ludens_Echo, ItemId.Mejais_Soulstealer,
            ItemId.Mercurial_Scimitar, ItemId.Mercurys_Treads, ItemId.Ninja_Tabi,
            ItemId.Phantom_Dancer, ItemId.Poachers_Dirk, ItemId.Rapid_Firecannon,
            ItemId.Runaans_Hurricane,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Trackers_Knife_Enchantment_Runic_Echoes,
            ItemId.Sorcerers_Shoes, ItemId.Statikk_Shiv, ItemId.Trinity_Force,
            ItemId.Youmuus_Ghostblade, ItemId.Zeal,
        };

        public static List<ItemId> OnHitItemList = new List<ItemId>()
        {
            ItemId.Blade_of_the_Ruined_King,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Trackers_Knife_Enchantment_Bloodrazor,
            ItemId.Elixir_of_Sorcery, ItemId.Frozen_Mallet, ItemId.Guinsoos_Rageblade,
            ItemId.Hunters_Machete, ItemId.Iceborn_Gauntlet, ItemId.Kircheis_Shard,
            ItemId.Lich_Bane, ItemId.Manamune, ItemId.Manamune_Quick_Charge,
            ItemId.Muramana, ItemId.Nashors_Tooth, ItemId.Phage,
            ItemId.Rapid_Firecannon, ItemId.Ravenous_Hydra, ItemId.Runaans_Hurricane,
            ItemId.Sheen, ItemId.Skirmishers_Sabre,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
            ItemId.Stalkers_Blade,
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Cinderhulk,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.Statikk_Shiv, ItemId.The_Black_Cleaver, ItemId.Thornmail,
            ItemId.Tiamat, ItemId.Trackers_Knife,
            ItemId.Trackers_Knife_Enchantment_Bloodrazor,
            ItemId.Trackers_Knife_Enchantment_Cinderhulk,
            ItemId.Trackers_Knife_Enchantment_Runic_Echoes,
            ItemId.Trackers_Knife_Enchantment_Warrior,
            ItemId.Trinity_Force, ItemId.Wits_End,
        };

        public static List<ItemId> SlowItemList = new List<ItemId>()
        {
            ItemId.Bilgewater_Cutlass, ItemId.Dead_Mans_Plate, ItemId.Frozen_Mallet,
            ItemId.Hextech_Gunblade, ItemId.Iceborn_Gauntlet, ItemId.Randuins_Omen,
            ItemId.Rylais_Crystal_Scepter, ItemId.Wardens_Mail,
        };

        public static List<ItemId> SpellVampItemList = new List<ItemId>()
        {
            ItemId.Hextech_Gunblade, ItemId.Hextech_Revolver, ItemId.Maw_of_Malmortius,
        };

        public static List<ItemId> TenacityItemList = new List<ItemId>()
        {
            ItemId.Elixir_of_Iron, ItemId.Mercurys_Treads, ItemId.Moonflair_Spellblade,
        };

        public static List<ItemId> TrinketItemList = new List<ItemId>()
        {
            ItemId.Warding_Totem_Trinket, ItemId.Sweeping_Lens_Trinket,
        };

        public static List<ItemId> StarterItemList = new List<ItemId>()
        {
            ItemId.Amplifying_Tome, ItemId.Ancient_Coin, ItemId.Boots_of_Speed,
            ItemId.Brawlers_Gloves, ItemId.Cloth_Armor, ItemId.Cull,
            ItemId.Dorans_Blade, ItemId.Dorans_Ring, ItemId.Dorans_Shield,
            ItemId.Faerie_Charm, ItemId.Guardians_Hammer, ItemId.Guardians_Horn,
            ItemId.Guardians_Orb, ItemId.Hunters_Machete, ItemId.Hunters_Talisman,
            ItemId.Long_Sword, ItemId.Prototype_Hex_Core, ItemId.Rejuvenation_Bead,
            ItemId.Relic_Shield, ItemId.Ruby_Crystal, ItemId.Sapphire_Crystal,
            ItemId.Spellthiefs_Edge, ItemId.The_Black_Spear, ItemId.The_Dark_Seal,
        };

        public static List<ItemId> UpgradedTrinketItemList = new List<ItemId>()
        {
            ItemId.Farsight_Alteration, ItemId.Oracle_Alteration,
        };

        #endregion

        #region Various ItemLists
        public static List<ItemId> UpgradedBootsItemList = new List<ItemId>()
        {
            ItemId.Berserkers_Greaves,
            ItemId.Boots_of_Mobility,
            ItemId.Boots_of_Swiftness,
            ItemId.Ionian_Boots_of_Lucidity,
            ItemId.Mercurys_Treads,
            ItemId.Ninja_Tabi,
            ItemId.Sorcerers_Shoes,
        };

        public static List<ItemId> SRJungleItemList = new List<ItemId>()
        {
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Cinderhulk,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
            ItemId.Trackers_Knife_Enchantment_Bloodrazor,
            ItemId.Trackers_Knife_Enchantment_Cinderhulk,
            ItemId.Trackers_Knife_Enchantment_Runic_Echoes,
            ItemId.Trackers_Knife_Enchantment_Warrior,
        };

        public static List<ItemId> TTJungleItemList = new List<ItemId>()
        {
            ItemId.Stalkers_Blade_Enchantment_Bloodrazor,
            ItemId.Stalkers_Blade_Enchantment_Cinderhulk,
            ItemId.Stalkers_Blade_Enchantment_Runic_Echoes,
            ItemId.Stalkers_Blade_Enchantment_Warrior,
            ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor,
            ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk,
            ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes,
            ItemId.Skirmishers_Sabre_Enchantment_Warrior,
        };

        public static List<ItemId> SR_BasicStarterItemList = new List<ItemId>()
        {
            ItemId.Dorans_Blade, ItemId.Dorans_Ring, ItemId.Dorans_Shield,
            ItemId.Cull, ItemId.The_Dark_Seal,
        };

        public static List<ItemId> HA_BasicStarterItemList = new List<ItemId>()
        {
            ItemId.Guardians_Hammer, ItemId.Guardians_Horn, ItemId.Guardians_Orb,
        };

        public static List<ItemId> TT_BasicStarterItemList = new List<ItemId>()
        {
            ItemId.Dorans_Blade, ItemId.Dorans_Ring, ItemId.Dorans_Shield,
            ItemId.Cull,
        };

        public static List<ItemId> BasicSupportItemList = new List<ItemId>()
        {
            ItemId.Ancient_Coin, ItemId.Relic_Shield, ItemId.Spellthiefs_Edge,
        };

        public static List<ItemId> SupportItemList = new List<ItemId>()
        {
            ItemId.Eye_of_the_Equinox, ItemId.Eye_of_the_Oasis, ItemId.Eye_of_the_Watchers,
            ItemId.Talisman_of_Ascension, ItemId.Frost_Queens_Claim, ItemId.Face_of_the_Mountain,
        };

        public static List<ItemId> AStackList = new List<ItemId>()
        {
            ItemId.Archangels_Staff, ItemId.Archangels_Staff_Quick_Charge, ItemId.Seraphs_Embrace,
        };

        public static List<ItemId> MStackList = new List<ItemId>()
        {
            ItemId.Manamune, ItemId.Manamune_Quick_Charge, ItemId.Muramana,
        };
        #endregion

        #region ItemBuilding objects
        public static List<ItemBuilding> ItemsBuiltList = new List<ItemBuilding>()
        {
            new ItemBuilding(ItemId.Farsight_Alteration, ItemId.Warding_Totem_Trinket),
            new ItemBuilding(ItemId.Oracle_Alteration, ItemId.Sweeping_Lens_Trinket),

            new ItemBuilding(ItemId.Berserkers_Greaves, ItemId.Boots_of_Speed, ItemId.Dagger),
            new ItemBuilding(ItemId.Boots_of_Mobility, ItemId.Boots_of_Speed),
            new ItemBuilding(ItemId.Boots_of_Swiftness, ItemId.Boots_of_Speed),
            new ItemBuilding(ItemId.Ionian_Boots_of_Lucidity, ItemId.Boots_of_Speed),
            new ItemBuilding(ItemId.Mercurys_Treads, ItemId.Boots_of_Speed, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Ninja_Tabi, ItemId.Boots_of_Speed, ItemId.Cloth_Armor),
            new ItemBuilding(ItemId.Sorcerers_Shoes, ItemId.Boots_of_Speed),

            new ItemBuilding(ItemId.Aegis_of_the_Legion, ItemId.Cloth_Armor, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Aether_Wisp, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Bamis_Cinder, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Bilgewater_Cutlass, ItemId.Vampiric_Scepter, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Catalyst_of_Aeons, ItemId.Ruby_Crystal, ItemId.Sapphire_Crystal),
            new ItemBuilding(ItemId.Caulfields_Warhammer, ItemId.Long_Sword, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Chain_Vest, ItemId.Cloth_Armor),
            new ItemBuilding(ItemId.Chalice_of_Harmony, ItemId.Null_Magic_Mantle, ItemId.Faerie_Charm, ItemId.Faerie_Charm),
            new ItemBuilding(ItemId.Crystalline_Bracer, ItemId.Ruby_Crystal, ItemId.Rejuvenation_Bead),
            new ItemBuilding(ItemId.Executioners_Calling, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Fiendish_Codex, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Forbidden_Idol, ItemId.Faerie_Charm, ItemId.Faerie_Charm),
            new ItemBuilding(ItemId.Frostfang, ItemId.Spellthiefs_Edge, ItemId.Faerie_Charm),
            new ItemBuilding(ItemId.Giants_Belt, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Giant_Slayer, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Glacial_Shroud, ItemId.Cloth_Armor, ItemId.Sapphire_Crystal),
            new ItemBuilding(ItemId.Haunting_Guise, ItemId.Ruby_Crystal, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Hexdrinker, ItemId.Long_Sword, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Hextech_Revolver, ItemId.Amplifying_Tome, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Jaurims_Fist, ItemId.Ruby_Crystal, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Kindlegem, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Kircheis_Shard, ItemId.Dagger),
            new ItemBuilding(ItemId.Last_Whisper, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Lost_Chapter, ItemId.Amplifying_Tome, ItemId.Sapphire_Crystal),
            new ItemBuilding(ItemId.Negatron_Cloak, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Nomads_Medallion, ItemId.Ancient_Coin, ItemId.Rejuvenation_Bead),
            new ItemBuilding(ItemId.Phage, ItemId.Ruby_Crystal, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Poachers_Dirk, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Quicksilver_Sash, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Raptor_Cloak, ItemId.Rejuvenation_Bead, ItemId.Cloth_Armor),
            new ItemBuilding(ItemId.Recurve_Bow, ItemId.Dagger, ItemId.Dagger),
            new ItemBuilding(ItemId.Seekers_Armguard, ItemId.Cloth_Armor, ItemId.Amplifying_Tome, ItemId.Cloth_Armor),
            new ItemBuilding(ItemId.Serrated_Dirk, ItemId.Long_Sword, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Sheen, ItemId.Sapphire_Crystal),
            new ItemBuilding(ItemId.Sightstone, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Spectres_Cowl, ItemId.Null_Magic_Mantle, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Stinger, ItemId.Dagger, ItemId.Dagger),
            new ItemBuilding(ItemId.Targons_Brace, ItemId.Relic_Shield, ItemId.Rejuvenation_Bead),
            new ItemBuilding(ItemId.Tear_of_the_Goddess, ItemId.Sapphire_Crystal, ItemId.Faerie_Charm),
            new ItemBuilding(ItemId.Tiamat, ItemId.Long_Sword, ItemId.Long_Sword, ItemId.Rejuvenation_Bead),
            new ItemBuilding(ItemId.Vampiric_Scepter, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Wardens_Mail, ItemId.Cloth_Armor, ItemId.Cloth_Armor),
            new ItemBuilding(ItemId.Zeal, ItemId.Brawlers_Gloves, ItemId.Dagger),

            new ItemBuilding(ItemId.Abyssal_Scepter, ItemId.Catalyst_of_Aeons, ItemId.Negatron_Cloak),
            new ItemBuilding(/* Adapative Helm*/ (ItemId)3194, ItemId.Spectres_Cowl, ItemId.Null_Magic_Mantle, ItemId.Rejuvenation_Bead),
            new ItemBuilding(ItemId.Archangels_Staff, ItemId.Tear_of_the_Goddess, ItemId.Needlessly_Large_Rod),
            new ItemBuilding(ItemId.Archangels_Staff_Quick_Charge, ItemId.Tear_of_the_Goddess_Quick_Charge, ItemId.Needlessly_Large_Rod),
            new ItemBuilding(ItemId.Ardent_Censer, ItemId.Forbidden_Idol, ItemId.Aether_Wisp),
            new ItemBuilding(ItemId.Athenes_Unholy_Grail, ItemId.Chalice_of_Harmony, ItemId.Fiendish_Codex),
            new ItemBuilding(ItemId.Banner_of_Command, ItemId.Aegis_of_the_Legion, ItemId.Raptor_Cloak),
            new ItemBuilding(ItemId.Banshees_Veil, ItemId.Fiendish_Codex, ItemId.Blasting_Wand, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Blade_of_the_Ruined_King, ItemId.Bilgewater_Cutlass, ItemId.Recurve_Bow),
            new ItemBuilding(ItemId.Dead_Mans_Plate, ItemId.Chain_Vest, ItemId.Giants_Belt),
            new ItemBuilding(ItemId.Deaths_Dance, ItemId.Caulfields_Warhammer, ItemId.Pickaxe, ItemId.Vampiric_Scepter),
            new ItemBuilding(ItemId.Duskblade_of_Draktharr, dirkoption, ItemId.Caulfields_Warhammer),
            new ItemBuilding(ItemId.Edge_of_Night, dirkoption, ItemId.Pickaxe, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Essence_Reaver, ItemId.B_F_Sword, ItemId.Caulfields_Warhammer, ItemId.Cloak_of_Agility),
            new ItemBuilding(ItemId.Eye_of_the_Equinox, ItemId.Targons_Brace, ItemId.Sightstone),
            new ItemBuilding(ItemId.Eye_of_the_Oasis, ItemId.Nomads_Medallion, ItemId.Sightstone),
            new ItemBuilding(ItemId.Eye_of_the_Watchers, ItemId.Frostfang, ItemId.Sightstone),
            new ItemBuilding(ItemId.Face_of_the_Mountain, ItemId.Targons_Brace, ItemId.Kindlegem),
            new ItemBuilding(ItemId.Frost_Queens_Claim, ItemId.Frostfang, ItemId.Fiendish_Codex),
            new ItemBuilding(ItemId.Frozen_Heart, ItemId.Glacial_Shroud, ItemId.Wardens_Mail),
            new ItemBuilding(ItemId.Frozen_Mallet, ItemId.Jaurims_Fist, ItemId.Giants_Belt),
            new ItemBuilding(/* Gargoyle Stoneplate */ (ItemId)3193, ItemId.Chain_Vest, ItemId.Negatron_Cloak),
            new ItemBuilding(ItemId.Guardian_Angel, ItemId.B_F_Sword, ItemId.Cloth_Armor),
            new ItemBuilding(ItemId.Guinsoos_Rageblade, ItemId.Blasting_Wand, ItemId.Pickaxe, ItemId.Recurve_Bow),
            new ItemBuilding(ItemId.Hextech_GLP_800, ItemId.Hextech_Revolver, ItemId.Catalyst_of_Aeons),
            new ItemBuilding(ItemId.Hextech_Gunblade, ItemId.Hextech_Revolver, ItemId.Bilgewater_Cutlass),
            new ItemBuilding(ItemId.Hextech_Protobelt_01, ItemId.Hextech_Revolver, ItemId.Kindlegem),
            new ItemBuilding(ItemId.Iceborn_Gauntlet, ItemId.Sheen, ItemId.Glacial_Shroud),
            new ItemBuilding(ItemId.Infinity_Edge, ItemId.B_F_Sword, ItemId.Pickaxe, ItemId.Cloak_of_Agility),
            new ItemBuilding(ItemId.Knights_Vow, ItemId.Kindlegem, ItemId.Chain_Vest),
            new ItemBuilding(ItemId.Liandrys_Torment, ItemId.Haunting_Guise, ItemId.Blasting_Wand),
            new ItemBuilding(ItemId.Lich_Bane, ItemId.Sheen, ItemId.Aether_Wisp, ItemId.Blasting_Wand),
            new ItemBuilding(ItemId.Locket_of_the_Iron_Solari, ItemId.Aegis_of_the_Legion, ItemId.Null_Magic_Mantle),
            new ItemBuilding(ItemId.Lord_Dominiks_Regards, ItemId.Last_Whisper, ItemId.Giant_Slayer),
            new ItemBuilding(ItemId.Ludens_Echo, ItemId.Aether_Wisp, ItemId.Needlessly_Large_Rod),
            new ItemBuilding(ItemId.Manamune, ItemId.Tear_of_the_Goddess, ItemId.Pickaxe),
            new ItemBuilding(ItemId.Manamune_Quick_Charge, ItemId.Tear_of_the_Goddess_Quick_Charge, ItemId.Pickaxe),
            new ItemBuilding(ItemId.Maw_of_Malmortius, ItemId.Hexdrinker, ItemId.Caulfields_Warhammer),
            new ItemBuilding(ItemId.Mejais_Soulstealer, ItemId.The_Dark_Seal),
            new ItemBuilding(ItemId.Mercurial_Scimitar, ItemId.Quicksilver_Sash, ItemId.Pickaxe, ItemId.Vampiric_Scepter),
            new ItemBuilding(ItemId.Mikaels_Crucible, ItemId.Chalice_of_Harmony, ItemId.Forbidden_Idol),
            new ItemBuilding(ItemId.Moonflair_Spellblade, ItemId.Seekers_Armguard, ItemId.Negatron_Cloak),
            new ItemBuilding(ItemId.Morellonomicon, ItemId.Lost_Chapter, ItemId.Fiendish_Codex, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Mortal_Reminder, ItemId.Last_Whisper, ItemId.Executioners_Calling),
            new ItemBuilding(ItemId.Nashors_Tooth, ItemId.Stinger, ItemId.Fiendish_Codex),
            new ItemBuilding(ItemId.Ohmwrecker, ItemId.Raptor_Cloak, ItemId.Kindlegem),
            new ItemBuilding(ItemId.Phantom_Dancer, ItemId.Zeal, ItemId.Dagger, ItemId.Dagger),
            new ItemBuilding(ItemId.Rabadons_Deathcap, ItemId.Needlessly_Large_Rod, ItemId.Blasting_Wand, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Randuins_Omen, ItemId.Wardens_Mail, ItemId.Giants_Belt),
            new ItemBuilding(ItemId.Rapid_Firecannon, ItemId.Kircheis_Shard, ItemId.Zeal),
            new ItemBuilding(ItemId.Ravenous_Hydra, ItemId.Tiamat, ItemId.Vampiric_Scepter, ItemId.Pickaxe),
            new ItemBuilding(ItemId.Redemption, ItemId.Forbidden_Idol, ItemId.Crystalline_Bracer),
            new ItemBuilding(ItemId.Righteous_Glory, ItemId.Glacial_Shroud, ItemId.Crystalline_Bracer),
            new ItemBuilding(ItemId.Rod_of_Ages, ItemId.Catalyst_of_Aeons, ItemId.Blasting_Wand),
            new ItemBuilding(ItemId.Rod_of_Ages_Quick_Charge, ItemId.Catalyst_of_Aeons, ItemId.Blasting_Wand),
            new ItemBuilding(ItemId.Ruby_Sightstone, ItemId.Sightstone, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Runaans_Hurricane, ItemId.Zeal, ItemId.Dagger, ItemId.Dagger),
            new ItemBuilding(ItemId.Rylais_Crystal_Scepter, ItemId.Blasting_Wand, ItemId.Amplifying_Tome, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Spirit_Visage, ItemId.Spectres_Cowl, ItemId.Kindlegem),
            new ItemBuilding(ItemId.Statikk_Shiv, ItemId.Kircheis_Shard, ItemId.Zeal),
            new ItemBuilding(ItemId.Steraks_Gage, ItemId.Jaurims_Fist, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Sunfire_Cape, ItemId.Bamis_Cinder, ItemId.Chain_Vest, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Talisman_of_Ascension, ItemId.Nomads_Medallion, ItemId.Raptor_Cloak),
            new ItemBuilding(ItemId.The_Black_Cleaver, ItemId.Phage, ItemId.Kindlegem),
            new ItemBuilding(ItemId.The_Bloodthirster, ItemId.B_F_Sword, ItemId.Vampiric_Scepter, ItemId.Long_Sword),
            new ItemBuilding(ItemId.Thornmail, ItemId.Bramble_Vest, ItemId.Wardens_Mail, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Titanic_Hydra, ItemId.Tiamat, ItemId.Jaurims_Fist, ItemId.Ruby_Crystal),
            new ItemBuilding(ItemId.Trinity_Force, ItemId.Sheen, ItemId.Phage, ItemId.Dagger),
            new ItemBuilding(ItemId.Void_Staff, ItemId.Blasting_Wand, ItemId.Amplifying_Tome),
            new ItemBuilding(ItemId.Warmogs_Armor, ItemId.Giants_Belt, ItemId.Kindlegem, ItemId.Crystalline_Bracer),
            new ItemBuilding(ItemId.Wits_End, ItemId.Recurve_Bow, ItemId.Negatron_Cloak, ItemId.Dagger),
            new ItemBuilding(ItemId.Wooglets_Witchcap, ItemId.Seekers_Armguard, ItemId.Needlessly_Large_Rod),
            new ItemBuilding(ItemId.Youmuus_Ghostblade, dirkoption, ItemId.Caulfields_Warhammer),
            new ItemBuilding(ItemId.Zekes_Harbinger, ItemId.Glacial_Shroud, ItemId.Aegis_of_the_Legion),
            new ItemBuilding(ItemId.Zhonyas_Hourglass, ItemId.Seekers_Armguard, ItemId.Fiendish_Codex),
            new ItemBuilding(ItemId.ZzRot_Portal, ItemId.Raptor_Cloak, ItemId.Negatron_Cloak),

            new ItemBuilding(ItemId.Skirmishers_Sabre, ItemId.Hunters_Machete, ItemId.Hunters_Talisman),
            new ItemBuilding(ItemId.Stalkers_Blade, ItemId.Hunters_Machete, ItemId.Hunters_Talisman),
            new ItemBuilding(ItemId.Trackers_Knife, ItemId.Hunters_Machete, ItemId.Hunters_Talisman),
            new ItemBuilding(ItemId.Skirmishers_Sabre_Enchantment_Bloodrazor, ItemId.Skirmishers_Sabre, ItemId.Recurve_Bow),
            new ItemBuilding(ItemId.Skirmishers_Sabre_Enchantment_Cinderhulk, ItemId.Skirmishers_Sabre, ItemId.Bamis_Cinder),
            new ItemBuilding(ItemId.Skirmishers_Sabre_Enchantment_Runic_Echoes, ItemId.Skirmishers_Sabre, ItemId.Aether_Wisp),
            new ItemBuilding(ItemId.Skirmishers_Sabre_Enchantment_Warrior, ItemId.Skirmishers_Sabre, ItemId.Caulfields_Warhammer),
            new ItemBuilding(ItemId.Stalkers_Blade_Enchantment_Bloodrazor, ItemId.Stalkers_Blade, ItemId.Recurve_Bow),
            new ItemBuilding(ItemId.Stalkers_Blade_Enchantment_Cinderhulk, ItemId.Stalkers_Blade, ItemId.Bamis_Cinder),
            new ItemBuilding(ItemId.Stalkers_Blade_Enchantment_Runic_Echoes, ItemId.Stalkers_Blade, ItemId.Aether_Wisp),
            new ItemBuilding(ItemId.Stalkers_Blade_Enchantment_Warrior, ItemId.Stalkers_Blade, ItemId.Caulfields_Warhammer),
            new ItemBuilding(ItemId.Trackers_Knife_Enchantment_Bloodrazor, ItemId.Trackers_Knife, ItemId.Recurve_Bow),
            new ItemBuilding(ItemId.Trackers_Knife_Enchantment_Cinderhulk, ItemId.Trackers_Knife, ItemId.Bamis_Cinder),
            new ItemBuilding(ItemId.Trackers_Knife_Enchantment_Runic_Echoes, ItemId.Trackers_Knife, ItemId.Aether_Wisp),
            new ItemBuilding(ItemId.Trackers_Knife_Enchantment_Warrior, ItemId.Trackers_Knife, ItemId.Caulfields_Warhammer),
        };
        #endregion
    }
}
