using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly;
using System.Threading;
using System.Globalization;

namespace WindowsFormsApplication2
{
    public partial class Board : Form
    {
        public Board(bool test = true){

            InitializeComponent();
            if (test) this.players = Populators.populatePlayers();
        }


        private void language_Click_1(object sender, EventArgs e)
        {
            this.language = "en-US";
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            initText();
        }

        private void language_Click_2(object sender, EventArgs e)
        {
            this.language = "zh-CN";
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            initText();

        }
        public void initText()
        {
            this.ChanceDeck = Populators.populateChance();
            this.CommunityChestDeck = Populators.populateCommunity();
            this.cells = Populators.populateCells(banker);
            this.Controlled.Text = Resource1.Control;
            this.Text = Resource1.Board;
            this.payFine.Text = Resource1.payFine;
            this.player1Label.Text = Resource1.p1Label;
            this.player2Label.Text = Resource1.p2Label;
            this.MagProper.Text = Resource1.magProper;
            this.Trade.Text = Resource1.trade;
            this.TurnEnds.Text = Resource1.endTurn;
            this.rollDie.Text = Resource1.roll;
            this.taxLabel2.Text = Resource1.luxuryTax;
            this.chanceLabel3.Text = Resource1.chance;
            this.controllBoard.Text = Resource1.controlBoard;
            this.marvinGardens.Name = Resource1.marvinGardens;
            this.ventnorAvenue.Name = Resource1.ventnorAvenue;
            this.illinoisAvenue.Name = Resource1.illinoisAvenue;
            this.indianaAvenue.Name = Resource1.indianaAvenue;
            this.newYorkAvenue.Name = Resource1.newYorkAvenue;
            this.tennesseeAvenue.Name = Resource1.tennesseeAvenue;
            this.virginiaAvenue.Name = Resource1.virginiaAvenue;
            this.statesAvenue.Name = Resource1.statesAvenue;
            this.goLabel.Text = Resource1.go;
            this.parkingLabel.Text = Resource1.freeParking;
            this.chestLabel1.Text = Resource1.communityChest;
            this.chestLabel2.Text = Resource1.communityChest;
            this.chestLabel3.Text = Resource1.communityChest;
            this.waterWorksLabel.Text = Resource1.waterWork;
            this.chanceLabel1.Text = Resource1.chance;
            this.railReadLabel.Text = Resource1.readingRailroad;
            this.taxLabel1.Text = Resource1.incomeTax;
            this.jailLabel.Text = Resource1.Jail;
            this.chanceLabel2.Text = Resource1.chance;
            this.eCompanyLabel.Text = Resource1.electricCompany;
            this.railPennLabel.Text = Resource1.pennRailroad;
            this.railBOLabel.Text = Resource1.bo;
            this.goToJailLabel.Text = Resource1.toJ;
            this.railShortLabel.Text = Resource1.shortLine;
            this.chanceLabel3.Text = Resource1.chance;
            this.taxLabel2.Text = Resource1.luxuryTax;
            this.BuyProper.Text = Resource1.buy;
            this.BuyProper.Enabled = false;
            this.TurnEnds.Enabled = false;
            this.payFine.Enabled = false;
        }

        private void language_Confirm(object sender, EventArgs e)
        {
            this.languageMenu.Hide();
            this.noPlayersSelect();
        }

        private void noPlayers_Click_1(object sender, EventArgs e)
        {
            this.numberOfPlayers = 2;
        }

        private void noPlayers_Click_2(object sender, EventArgs e)
        {
            this.numberOfPlayers = 3;
        }

        private void noPlayers_Click_3(object sender, EventArgs e)
        {
            this.numberOfPlayers = 4;
        }

        private void noPlayers_Confirm(object sender, EventArgs e)
        {
            if (this.numberOfPlayers < 4) this.ovalShape4.Dispose();
            if (this.numberOfPlayers < 3) this.ovalShape3.Dispose();
            this.noPlayersMenu.Hide();
            this.generatePlayers();
        }

        private void newPlayer_Confirm(object sender, EventArgs e)
        {
            String name = (this.nameBox.Text);
            this.players.Add(new Player(name));
            this.playerCreationMenu.Hide();
            this.activePlayer++;
            if (this.activePlayer < this.numberOfPlayers) this.generatePlayers();
            else { this.activePlayer = 0; System.Diagnostics.Debug.Write(this.players.Count.ToString() + " players"); }
        }

        private void rollDie_Click_1(object sender, EventArgs e)
        {
            this.movePlayer();
            this.updateDieLabels();
        }

        private void buy_Click_1(object sender, EventArgs e)
        {
            this.buyProperty();
            this.BuyProper.Enabled = false;

        }

        private void incomeTaxTenPercent(object sender, EventArgs e)
        {
            IncomeTax tax = (IncomeTax)this.cells[getPlayer().getLocation()];
            tax.effect(getPlayer(), false);
        }

        private void incomeTaxDefault(object sender, EventArgs e)
        {
            IncomeTax tax = (IncomeTax)this.cells[getPlayer().getLocation()];
            tax.effect(getPlayer(), true);
        }


        private void endTurn_Click_1(object sender, EventArgs e)
        {
            this.endTurn();
        }

        private void trade_Click_1(object sender, EventArgs e) 
        {
            this.tradeProperties();
        }


        private void manage_Click_1(object sender, EventArgs e)
        {
            this.manageProperties();
        }

        private void manageConfirm_Click_Morgage(object sender, EventArgs e)
        {
            List<Property> props = new List<Property>();
            Player currentPlayer = this.players[this.activePlayer];
            for (int i = 0; i < this.properties.Items.Count; i++)
            {
                if (this.properties.GetSelected(i)) { props.Add(currentPlayer.deeds[i]); }

            }

            String message = this.mortgageProperties(currentPlayer, props);
            MessageBox.Show(message, "Mortgaging", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.properties.ClearSelected();
            this.manageList.Close();
        }

        private void manageConfirm_Click_BuyHouse(object sender, EventArgs e)
        {
            foreach (int i in this.properties.CheckedIndices)
            {
                string message = this.buyHouse(this.getPlayer().deeds[i], this.getPlayer());
                MessageBox.Show(message, "Houses n stuff", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void manageCancel_Click_1(object sender, EventArgs e)
        {
            this.manageList.Close();
        }

        private void manageSelectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < this.properties.Items.Count; i++) this.properties.SetItemChecked(i, true);
        }

        private void manageDeselectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < this.properties.Items.Count; i++) this.properties.SetItemChecked(i, false);
        }

        private void confirm_Click_1(object sender, EventArgs e)
        {
            List<int> indexSelected = new List<int>();
            for (int i = 0; i < this.properties.Items.Count; i++)
            {
                if (this.properties.GetSelected(i)) indexSelected.Add(i);
            }
            int price = Convert.ToInt32(this.tradePrice.Text);
            List<Property> propertySelected = new List<Property>();
            for (int k = 0; k < indexSelected.Count; k++)
            {
                propertySelected.Add(this.players[this.activePlayer].deeds[indexSelected[k]]);
            }
            this.trade(this.getPlayer(), this.players[this.players.Count - this.activePlayer - 1], propertySelected, price);
            this.propertyList.Close();
        }
        private void cancel_Click_1(object sender, EventArgs e)
        {
            this.propertyList.Close();
        }

        private void payFine_Click_1(object sender, EventArgs e)
        {
            this.payJailFine();
        }

        private void controlled_confirm_Click_1(object sender, EventArgs e)
        {
            controlledMove();
            this.controllBoard.Close();
        }
        private void controlled_roll_Click_1(object sender, EventArgs e)
        {
            controlledRoll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GiveCardWindow(this).Show();
        }

    }
}
