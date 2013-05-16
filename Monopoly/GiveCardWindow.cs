using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class GiveCardWindow : Form
    {
        public GiveCardWindow()
        {
            InitializeComponent();
        }

        private WindowsFormsApplication2.Board b;
        private List<RadioButton> playerButtons = new List<RadioButton>();
        private List<RadioButton> chanceButtons = new List<RadioButton>();
        private List<RadioButton> commButtons = new List<RadioButton>();
        public GiveCardWindow(WindowsFormsApplication2.Board b)
        {
            this.b = b;
            InitializeComponent();
            this.setUp();
        }

        private void give_Click(object sender, EventArgs e)
        {
            //FIND PLAYER
            Player selectedP = b.getPlayers()[0];
            List<Player> ps = new List<Player>();
            ps.AddRange(b.getPlayers());
            for (int i = 0; i < this.playerButtons.Count; i ++)
            {
                if (this.playerButtons[i].Checked)
                {
                    selectedP = b.getPlayers()[i];
                    ps.Remove(selectedP);
                }
            }

            
            //CHANCE
            Card selectedC;
            CardCell cc;
            for (int i = 0; i < this.chanceButtons.Count; i++)
            {
                if (this.chanceButtons[i].Checked) 
                { 
                    selectedC = b.getChance()[i];
                    cc = (CardCell)b.getCellAt(7);
                    cc.effect(selectedP, selectedC, ps, this.b);
                    MessageBox.Show(selectedC.getName(), "Chance Chest Card!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b.updatePlayerLabels();
                }
            }

            //COMMUNITY
            for (int i = 0; i < this.commButtons.Count; i++)
            {
                if (this.commButtons[i].Checked)
                {
                    selectedC = b.getCommunity()[i];
                    cc = (CardCell)b.getCellAt(2);
                    cc.effect(selectedP, selectedC, ps, this.b);
                    MessageBox.Show(selectedC.getName(), "Community Chest Card!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b.updatePlayerLabels();
                }
            }
            this.Close();
        }

    }
}
