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

            MoveTo(Welt.LocationByID(Welt.LOCATION_ID_HOME));

            _spieler = new Spieler(10, 10, 20, 0, 1);
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



            Location location = new Location(1, "Home", "Das ist dein Zuhause");
            location.ID = 1;
            location.Name = "Home";
            location.Description = "Das ist dein Zuhause";

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
            //Braucht der Ort eine spezifisches Item
            if (newLocation.ItemRequiredToEnter != null)
            {
                // Prüft ob das Item im Inventar ist
                bool playerHasRequiredItem = false;

                foreach (InventoryItem ii in _spieler.Inventory)
                {
                    if (ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        // Item gefunden
                        playerHasRequiredItem = true;
                        break; // Schließt foreach 
                    }
                }

                if (!playerHasRequiredItem)
                {
                    // Wenn das passende Item nicht gefunden wurde, schreibe Nachricht und unterbreche bewegung.
                    rtbMessages.Text += "Du benötigst Item " + newLocation.ItemRequiredToEnter.Name + " um dieses Gebiet freizuschalten." + Environment.NewLine;
                    return;
                }
            }


        }

    }
}
