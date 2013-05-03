using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2;

namespace Monopoly
{
    //site with all card information we need
    //http://www.researchmaniacs.com/Games/Monopoly/Properties.html
    public class RepairCard: Card
    {
        public RepairCard() { }

        public RepairCard(String name)
        {
            this.name = name;
        }

        public override void drawCard(Player p, List<Player> otherP, Board b)
        {
            int houses = 0;
            int hotels = 0;
            for (int i = 0; i < p.getDeeds().Count; i++)
            {
                if (p.getDeeds()[i].getNumHouses() == 5) { hotels++; }
                else { houses += p.getDeeds()[i].getNumHouses(); }
            }
        }
    }
}
