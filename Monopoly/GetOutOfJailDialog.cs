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
    public partial class GetOutOfJailDialog : Form
    {
        public GetOutOfJailDialog()
        {
            InitializeComponent();
        }
        private Player chosenone;
        public GetOutOfJailDialog(Player chosenone)
        {
            InitializeComponent();
            this.chosenone = chosenone;
        }
        private void yes_Click(object sender, EventArgs e)
        {
            this.chosenone.setGetOutOfJailFree(false);
            this.chosenone.goToJail(false);
            this.Close();
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
