using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Welt
    {

        //Listen die mit Dingen gefüllt werden//

        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();


        //Fixe Wert zuweisung von Items, Monstern, Orten, Quests, 
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;
        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        static Welt()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }
        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rostiges Schwert", "Rostige Schwerter", 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rattenschwanz ", "Rattenschänze"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Pelz", "Pelze"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Schlangenzahn", "Schlangenzähne"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Schlangenhaut", "Schlangenhäute"));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Knüppel", "Knüppel", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Heiltrank", "Heiltränke", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spinnenzahn", "Spinnenzähne"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spinnenseide", "Spinnenseiden"));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Abenteurer Pass", "Abenteurer Pässe"));
        }
        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Ratte", 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));
            Monster snake = new Monster(MONSTER_ID_SNAKE, "Schlange", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));
            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Große Spinne", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));
            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }
        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Töte die Ratten im Alchemisten Garten",
                    "Töte die Ratten im Alchemisten Garten und bringe mir 3 Rattenschwänze als Beweis zurück. Du wirst einen Heiltrank und 10 Goldstücke als Belohnung erhalten.", 20, 10);
            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletItem(ItemByID(ITEM_ID_RAT_TAIL), 3));
            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);
            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Helfe den Farmer",
                    "Töte die Schlangen am Weizenfeld und bringe mir 3 Schlangenzähne als Beweis zurück. Als Belohnung erhälst du einen Abenteurer Pass und 20 Goldstücke", 20, 20);
            clearFarmersField.QuestCompletionItems.Add(new QuestCompletItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));
            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);
            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }
        private static void PopulateLocations()
        {
            // Orte die gebaut werden
            Location home = new Location(LOCATION_ID_HOME, "Home", "Dein Haus. Du solltest wieder einmal aufräumen.");
            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Stadtplatz", "Du siehst einen Brunnen.");
            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemisten Haus", "Da sind viele merkwürdige Pflanzen in den Regalen.");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);
            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemisten Garten", "Viele Pflanzen wachsen hier.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);
            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Bauernhaus", "Da ist ein kleines Bauernhaus davor steht ein Bauer.");
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);
            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Weizenfeld", "Du siehst Weizen an diesen Feld heranwachsen.");
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);
            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Wache", "Da steht eine bedrohlich ausehende Wache.", ItemByID(ITEM_ID_ADVENTURER_PASS));
            Location bridge = new Location(LOCATION_ID_BRIDGE, "Brücke", "Eine Steinbrücke die übern den ganzen Fluss ragt.");
            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Wald", "Du siehst wie gigantische Spinnennetze den Wald zudecken.");
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

            // Verlnüpft die Orte miteinander
            home.LocationToNorth = townSquare;
            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;
            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;
            farmersField.LocationToEast = farmhouse;
            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;
            alchemistsGarden.LocationToSouth = alchemistHut;
            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;
            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;
            spiderField.LocationToWest = bridge;

            // Orte werden den statischen Listen hinzugefügt
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }
        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }
        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }
        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}

    

