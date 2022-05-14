using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace Wifi_Adventure
{
    public partial class Form1 : Form
    {
        private Spieler _spieler;
        private Monster _currentMonster;
        public Form1()
        {
            InitializeComponent();

            _spieler = new Spieler(10, 10, 20, 0, 1);
            MoveTo(Welt.LocationByID(Welt.LOCATION_ID_HOME));
            _spieler.Inventory.Add(new InventoryItem(Welt.ItemByID(Welt.ITEM_ID_RUSTY_SWORD), 1));

            _spieler.CurrentHitPoints = 10;
            _spieler.MaximumHitPoints = 10;
            _spieler.Gold = 20;
            _spieler.ExperiencePoints = 0;
            _spieler.Level = 1;

            lblHitPoints.Text = _spieler.CurrentHitPoints.ToString();
            lblGold.Text = _spieler.Gold.ToString();
            lblExperience.Text = _spieler.ExperiencePoints.ToString();
            lblLevel.Text = _spieler.Level.ToString();

        }

        private void btnNord_Click(object sender, EventArgs e)
        {
            MoveTo(_spieler.CurrentLocation.LocationToNorth);
        }

        private void btnOst_Click(object sender, EventArgs e)
        {
            MoveTo(_spieler.CurrentLocation.LocationToEast);
        }

        private void btnSüd_Click(object sender, EventArgs e)
        {
            MoveTo(_spieler.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_spieler.CurrentLocation.LocationToWest);
        }

        private void MoveTo(Location newLocation)
        {

            //Abfrage ob der Ort ein Item benötigt
            if (!_spieler.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "Du brauchst ein " + newLocation.ItemRequiredToEnter.Name + " um diesen Ort freizuschalten." + Environment.NewLine;
                return;
            }

            _spieler.CurrentLocation = newLocation;

            btnNord.Visible = (newLocation.LocationToNorth != null);
            btnOst.Visible = (newLocation.LocationToEast != null);
            btnSüd.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            // Zeigt Ort und Beschreibung in dem sich der Spieler gerade befindet
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            // Heilt den Spieler 
            _spieler.CurrentHitPoints = _spieler.MaximumHitPoints;

            // Zeigt aktuelle Hitpoints des Spielers
            lblHitPoints.Text = _spieler.CurrentHitPoints.ToString();

            // Fragt nach Quest in dem Ort in dem sich spieler befindet
            if (newLocation.QuestAvailableHere != null)
            {
                // Fragt nach ob der Spieler die Quest schon besitzt bzw. fertig hat
                bool playerAlreadyHasQuest = _spieler.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _spieler.CompletedThisQuest(newLocation.QuestAvailableHere);


                // Hat Spieler schon die Quest
                if (playerAlreadyHasQuest)
                {
                    // Wenn Spieler die Quest noch nicht fertig hat
                    if (!playerAlreadyCompletedQuest)
                    {
                        // Fragt nach ob Spieler alle Items für die Quest hat
                        bool playerHasAllItemsToCompleteQuest = _spieler.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // Wenn der Spieler alle Items hat die er braucht
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Erscheint die Nachricht 
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "Du hast die'" + newLocation.QuestAvailableHere.Name + "' Quest erledigt." + Environment.NewLine;

                            //Entfernt Item aus dem Inventar
                            _spieler.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            // Quest belohnungen
                            rtbMessages.Text += "Du erhälst: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " Erfahrungspunkte" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " Gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            _spieler.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _spieler.Gold += newLocation.QuestAvailableHere.RewardGold;

                            // Gibt Questbelohnungs Item dem Spieler ins Inventar
                            _spieler.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            // Markier den Quest als erledigt
                            _spieler.MarkQuestCompleted(newLocation.QuestAvailableHere);

                        }
                    }
                }
                else
                {
                    // Der Spieler hat die Quest nocht nicht angenommen

                    // Zeige nachricht

                    rtbMessages.Text += "Du hast die " + newLocation.QuestAvailableHere.Name + "Quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "Um die Quest abzuschließen komme mit:" + Environment.NewLine;
                    foreach (QuestCompletItem questCompletItem in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (questCompletItem.Quantity == 1)
                        {
                            rtbMessages.Text += questCompletItem.Quantity.ToString() + " " + questCompletItem.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += questCompletItem.Quantity.ToString() + " " + questCompletItem.Details.NamePlural + Environment.NewLine;
                        }

                    }
                    rtbMessages.Text += Environment.NewLine;

                    //Quest wird zu Questlog hinzugefügt
                    _spieler.Quests.Add(new SpielerQuest(newLocation.QuestAvailableHere));

                }
            }

            //Abfrage ob der Ort ein Monster enthält

            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "Du siehst ein " + newLocation.MonsterLivingHere.Name + Environment.NewLine;


                // Erstellt ein Monster und nutzt die Welt.Monster einträge
                Monster standardMonster = Welt.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                cboWaffen.Visible = true;
                cboPotions.Visible = true;
                btnUseWaffe.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWaffen.Visible = false;
                cboPotions.Visible = false;
                btnUseWaffe.Visible = false;
                btnUsePotion.Visible = false;
            }

            // Refresh Spielers Inventar
            UpdateInventoryListInUI();

            // Refresh Spielers Liste
            UpdateQuestListInUI();

            // Refresh pSpielers Waffenbox
            UpdateWeaponListInUI();

            // Refresh Spielers Heiltrankbox
            UpdatePotionListInUI();

        }

    
    private void UpdateInventoryListInUI()
    {
        // Ruft Inventar ab
        dgvInventory.RowHeadersVisible = false;

        dgvInventory.ColumnCount = 2;
        dgvInventory.Columns[0].Name = "Name";
        dgvInventory.Columns[0].Width = 197;
        dgvInventory.Columns[1].Name = "Quantity";

        dgvInventory.Rows.Clear();

        foreach (InventoryItem inventoryItem in _spieler.Inventory)
        {
            if (inventoryItem.Quantity > 0)
            {
                dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
            }
        }
    }

    private void UpdateQuestListInUI()
    {
        // Ruft Questlog ab
        dgvQuests.RowHeadersVisible = false;

        dgvQuests.ColumnCount = 2;
        dgvQuests.Columns[0].Name = "Name";
        dgvQuests.Columns[0].Width = 197;
        dgvQuests.Columns[1].Name = "Done?";

        dgvQuests.Rows.Clear();

        foreach (SpielerQuest playerQuest in _spieler.Quests)
        {
            dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
        }
    }

    private void UpdateWeaponListInUI()
    {
        List<Weapon> weapons = new List<Weapon>();

        foreach (InventoryItem inventoryItem in _spieler.Inventory)
        {
            if (inventoryItem.Details is Weapon)
            {
                if (inventoryItem.Quantity > 0)
                {
                    weapons.Add((Weapon)inventoryItem.Details);
                }
            }
        }

        if (weapons.Count == 0)
        {
            // Wenn der SPieler keine Waffen hat
            cboWaffen.Visible = false;
            btnUseWaffe.Visible = false;
        }
        else
        {
            cboWaffen.DataSource = weapons;
            cboWaffen.DisplayMember = "Name";
            cboWaffen.ValueMember = "ID";

            cboWaffen.SelectedIndex = 0;
        }
    }

    private void UpdatePotionListInUI()
    {
        // Ruft Liste HEiltränke
        List<HealingPotion> healingPotions = new List<HealingPotion>();

        foreach (InventoryItem inventoryItem in _spieler.Inventory)
        {
            if (inventoryItem.Details is HealingPotion)
            {
                if (inventoryItem.Quantity > 0)
                {
                    healingPotions.Add((HealingPotion)inventoryItem.Details);
                }
            }
        }

        if (healingPotions.Count == 0)
        {
            // Spieler hat keine Heiltränke also zeige nicht 
            cboPotions.Visible = false;
            btnUsePotion.Visible = false;
        }
        else
        {
            cboPotions.DataSource = healingPotions;
            cboPotions.DisplayMember = "Name";
            cboPotions.ValueMember = "ID";

            cboPotions.SelectedIndex = 0;

        }
    }

    private void btnUseWaffe_Click(object sender, EventArgs e)
    {
        // Gibt mir die aktuelle Waffe aus
        Weapon currentWeapon = (Weapon)cboWaffen.SelectedItem;
        // Bestimmt den Schaden den wir an den Spieler machen
        int damageToMonster = RandomNumbers.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);
        // Fügt den Schaden zu den Leben des Monsters
        _currentMonster.CurrentHitPoints -= damageToMonster;
        // Nachricht
        rtbMessages.Text += "Du triffst " + _currentMonster.Name + " machst " + damageToMonster.ToString() + " Schaden." + Environment.NewLine;
        // Abfrage ob Monster tod ist
        if (_currentMonster.CurrentHitPoints <= 0)
        {
            // Monster ist Tod
            rtbMessages.Text += Environment.NewLine;
            rtbMessages.Text += "Du besiegst das " + _currentMonster.Name + Environment.NewLine;

            // Gibt dem Spieler EXP für das Töten des Monsters
            _spieler.ExperiencePoints += _currentMonster.RewardExperiencePoints;
            rtbMessages.Text += "Du erhälst " + _currentMonster.RewardExperiencePoints.ToString() + " Erfahrungspunkte" + Environment.NewLine;

            // Gibt SPieler GOld
            _spieler.Gold += _currentMonster.RewardGold;
            rtbMessages.Text += "Du erhälst " + _currentMonster.RewardGold.ToString() + " Gold" + Environment.NewLine;
            // Bekommst zufälligen Loot

            List<InventoryItem> lootedItems = new List<InventoryItem>();
            // Fügt Items zu Liste hinzu nach Dropchance
            foreach (LootItem lootItem in _currentMonster.LootTable)
            {
                if (RandomNumbers.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                }
            }
            // Wenn kein Item dabei sit
            if (lootedItems.Count == 0)
            {
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (lootItem.IsDefaultItem)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
            }
            // Loot Item wird hinzugeüft
            foreach (InventoryItem inventoryItem in lootedItems)
            {
                _spieler.AddItemToInventory(inventoryItem.Details);
                if (inventoryItem.Quantity == 1)
                {
                    rtbMessages.Text += "Du erhälst " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                }
                else
                {
                    rtbMessages.Text += "Du erhälst " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                }
            }
            // Refresh Spieler Information und Controls
            lblHitPoints.Text = _spieler.CurrentHitPoints.ToString();
            lblGold.Text = _spieler.Gold.ToString();
            lblExperience.Text = _spieler.ExperiencePoints.ToString();
            lblLevel.Text = _spieler.Level.ToString();

            UpdateInventoryListInUI();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();

            // Nachricht ohne Text 
            rtbMessages.Text += Environment.NewLine;
            // Spieler bewegt sich im Ort weiter
            MoveTo(_spieler.CurrentLocation);
        }
        else
        {
            // Monster lebt noch
            // Bestimmt wie viel Schaden das Monster den Spieler macht
            int damageToPlayer = RandomNumbers.NumberBetween(0, _currentMonster.MaximumDamage);
            // Nachricht
            rtbMessages.Text += "Die" + _currentMonster.Name + " fügt dir " + damageToPlayer.ToString() + " Punkte Schaden zu." + Environment.NewLine;
            // Zieht Schaden von Spieler ab
            _spieler.CurrentHitPoints -= damageToPlayer;
            // Refresh Spielers UI
            lblHitPoints.Text = _spieler.CurrentHitPoints.ToString();
            if (_spieler.CurrentHitPoints <= 0)
            {
                // Nachricht
                rtbMessages.Text += "Die " + _currentMonster.Name + " Tötet dich." + Environment.NewLine;
                // Bringt den Spieler nach Home
                MoveTo(Welt.LocationByID(Welt.LOCATION_ID_HOME));
            }
        }
    }

    private void btnUsePotion_Click(object sender, EventArgs e)
    {
        // Zeigt die aktuelle Poiton an
        HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;
        // Heilt den Spieler um so und so Leben
        _spieler.CurrentHitPoints = (_spieler.CurrentHitPoints + potion.AmountToHeal);
        // Leben kann nicht max Leben überschreiten
        if (_spieler.CurrentHitPoints > _spieler.MaximumHitPoints)
        {
            _spieler.CurrentHitPoints = _spieler.MaximumHitPoints;
        }
        // Entfenrt Heiltrank vom Inventar
        foreach (InventoryItem ii in _spieler.Inventory)
        {
            if (ii.Details.ID == potion.ID)
            {
                ii.Quantity--;
                break;
            }
        }

        // Nachricht
        rtbMessages.Text += "Du saufst einen " + potion.Name + Environment.NewLine;

        // Monster ist dran für den Kampf
        // Bestimmt den Schaden an den Spieler
        int damageToPlayer = RandomNumbers.NumberBetween(0, _currentMonster.MaximumDamage);

        // Nachricht
        rtbMessages.Text += "Die " + _currentMonster.Name + " fügt dir " + damageToPlayer.ToString() + " Punkte Schaden zu." + Environment.NewLine;

        // Zieht Schaden von Leben ab
        _spieler.CurrentHitPoints -= damageToPlayer;

        if (_spieler.CurrentHitPoints <= 0)
        {
            // Nachricht
            rtbMessages.Text += "Die " + _currentMonster.Name + " Tötet dich." + Environment.NewLine;

            // Bringt Spieler nach Home
            MoveTo(Welt.LocationByID(Welt.LOCATION_ID_HOME));
        }
        // Refresh Spielers UI und Data
        lblHitPoints.Text = _spieler.CurrentHitPoints.ToString();

        UpdateInventoryListInUI();
        UpdatePotionListInUI();
    }
  }
}





