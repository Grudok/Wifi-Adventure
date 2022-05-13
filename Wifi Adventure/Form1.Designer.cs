namespace Wifi_Adventure
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.cboWaffen = new System.Windows.Forms.ComboBox();
            this.btnUseWaffe = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnNord = new System.Windows.Forms.Button();
            this.btnOst = new System.Windows.Forms.Button();
            this.btnSüd = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Level:";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(110, 19);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(0, 13);
            this.lblHitPoints.TabIndex = 0;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(110, 99);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 0;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(110, 45);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 13);
            this.lblGold.TabIndex = 0;
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(110, 73);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(0, 13);
            this.lblExperience.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gold:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Aktion auswählen";
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(369, 593);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 21);
            this.cboPotions.TabIndex = 2;
            // 
            // cboWaffen
            // 
            this.cboWaffen.FormattingEnabled = true;
            this.cboWaffen.Location = new System.Drawing.Point(369, 559);
            this.cboWaffen.Name = "cboWaffen";
            this.cboWaffen.Size = new System.Drawing.Size(121, 21);
            this.cboWaffen.TabIndex = 2;
            // 
            // btnUseWaffe
            // 
            this.btnUseWaffe.Location = new System.Drawing.Point(620, 559);
            this.btnUseWaffe.Name = "btnUseWaffe";
            this.btnUseWaffe.Size = new System.Drawing.Size(75, 23);
            this.btnUseWaffe.TabIndex = 3;
            this.btnUseWaffe.Text = "Benutze";
            this.btnUseWaffe.UseVisualStyleBackColor = true;
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(620, 593);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 21);
            this.btnUsePotion.TabIndex = 3;
            this.btnUsePotion.Text = "Benutze";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(412, 457);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(78, 27);
            this.btnWest.TabIndex = 3;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // btnNord
            // 
            this.btnNord.Location = new System.Drawing.Point(493, 433);
            this.btnNord.Name = "btnNord";
            this.btnNord.Size = new System.Drawing.Size(75, 29);
            this.btnNord.TabIndex = 3;
            this.btnNord.Text = "Nord";
            this.btnNord.UseVisualStyleBackColor = true;
            this.btnNord.Click += new System.EventHandler(this.btnNord_Click);
            // 
            // btnOst
            // 
            this.btnOst.Location = new System.Drawing.Point(574, 457);
            this.btnOst.Name = "btnOst";
            this.btnOst.Size = new System.Drawing.Size(78, 27);
            this.btnOst.TabIndex = 3;
            this.btnOst.Text = "Ost";
            this.btnOst.UseVisualStyleBackColor = true;
            this.btnOst.Click += new System.EventHandler(this.btnOst_Click);
            // 
            // btnSüd
            // 
            this.btnSüd.Location = new System.Drawing.Point(493, 487);
            this.btnSüd.Name = "btnSüd";
            this.btnSüd.Size = new System.Drawing.Size(75, 24);
            this.btnSüd.TabIndex = 3;
            this.btnSüd.Text = "Süd";
            this.btnSüd.UseVisualStyleBackColor = true;
            this.btnSüd.Click += new System.EventHandler(this.btnSüd_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(347, 19);
            this.rtbLocation.MaximumSize = new System.Drawing.Size(360, 105);
            this.rtbLocation.MinimumSize = new System.Drawing.Size(360, 105);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(360, 105);
            this.rtbLocation.TabIndex = 4;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(347, 130);
            this.rtbMessages.MaximumSize = new System.Drawing.Size(360, 286);
            this.rtbMessages.MinimumSize = new System.Drawing.Size(360, 286);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(360, 286);
            this.rtbMessages.TabIndex = 4;
            this.rtbMessages.Text = "";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Enabled = false;
            this.dgvInventory.Location = new System.Drawing.Point(12, 131);
            this.dgvInventory.MaximumSize = new System.Drawing.Size(321, 309);
            this.dgvInventory.MinimumSize = new System.Drawing.Size(321, 309);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(321, 309);
            this.dgvInventory.TabIndex = 5;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(16, 446);
            this.dgvQuests.MaximumSize = new System.Drawing.Size(312, 189);
            this.dgvQuests.MinimumSize = new System.Drawing.Size(312, 189);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.Size = new System.Drawing.Size(312, 189);
            this.dgvQuests.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnSüd);
            this.Controls.Add(this.btnOst);
            this.Controls.Add(this.btnNord);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWaffe);
            this.Controls.Add(this.cboWaffen);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mein Spiel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.ComboBox cboWaffen;
        private System.Windows.Forms.Button btnUseWaffe;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnNord;
        private System.Windows.Forms.Button btnOst;
        private System.Windows.Forms.Button btnSüd;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
    }
}

