using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Spieler: Lebende
    {
        
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<SpielerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }

        public Spieler(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
            Inventory = new List<InventoryItem>();
            Quests = new List<SpielerQuest>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // Für diesen Ort wird kein Item benötigt deshalb true
                return true;
            }

            // Schau nach ob Spieler benötigtes Item hat
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    // Gefunden deshalb True
                    return true;
                }
            }

            // Nicht gefunden deshalb false
            return false;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (SpielerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (SpielerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // Schaut nach ob Spieler benötigte Items hat
            foreach (QuestCompletItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Schaut nach ob Spieler die richtige anzahl hat
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // Spieler hat die Items
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // Spieler hat zuwenig Items
                        {
                            return false;
                        }
                    }
                }

                // Der Spieler hat überhaupt keine richtige Items 
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // Wenn schleife bis hier geht dann hat Spieler alle benötigten Items
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        // Zieht die Items vom Inventar ab 
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    // Wenn Item im Inventar zähl 1 hinauf
                    ii.Quantity++;

                    return; // Item ist +1 also fertig
                }
            }

            // Keines Vorhanden deswegen von 0 auf 1
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Suche den Quest im Questlog
            foreach (SpielerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Makier als fertig
                    pq.IsCompleted = true;

                    return; // Gefunden und Markiert 
                }
            }
        }
    }
}
