using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void buy_Click_1(object sender, EventArgs e)
        {

            this.buyProperty();
            this.BuyProper.Enabled = false;

        }

        private void endTurn_Click_1(object sender, EventArgs e)
        {
            this.endTurn();
        }
    }
}
