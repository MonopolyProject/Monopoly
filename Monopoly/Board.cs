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

namespace WindowsFormsApplication2
{
    public partial class Board : Form
    {
        public Board()
        {
            InitializeComponent();
        }

        private void rectangleShape37_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape27_Click(object sender, EventArgs e)
        {

        }

        private void chest1_Click(object sender, EventArgs e)
        {

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
            this.buyHouse((Property)cells[this.getPlayer().getLocation()], this.getPlayer());
        }

        private void manageCancel_Click_1(object sender, EventArgs e)
        {
            this.manageList.Close();
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
        private void payfine_Click_1(object sender, EventArgs e)
        {
            this.payJailFine();
        }

        private void controlled_confirm_Click_1(object sender, EventArgs e)
        {
            controlledMove();
        }
        private void controlled_roll_Click_1(object sender, EventArgs e)
        {
            controlledRoll();
        }

    }
}
