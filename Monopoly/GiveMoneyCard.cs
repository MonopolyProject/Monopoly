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
    public class GiveMoneyCard: Card
    {
        protected int amountPerPlayer;
        public GiveMoneyCard() { }

        public GiveMoneyCard(String name, int amountPerPlayer)
        {
            this.name = name;
            this.amountPerPlayer = amountPerPlayer;
        }

        public override void drawCard(Player p, List<Player> otherP, Board b)
        {
            p.addMoney(this.amountPerPlayer * otherP.Count);
            for (int i = 0; i < otherP.Count; i++)
            {
                otherP[i].addMoney(-this.amountPerPlayer);
            }
        }
    }
}
