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
    public class MoneyCard: Card
    {
        protected int amount;

        public MoneyCard() { }

        public MoneyCard(String name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

        public int getAmount()
        {
            return this.amount;
        }
        
        public override void drawCard(Player p)
        {
            p.addMoney(this.amount);
        }
    }
}
