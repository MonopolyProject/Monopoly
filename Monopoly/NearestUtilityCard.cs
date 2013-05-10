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
    public class NearestUtilityCard : Card
    {
        public NearestUtilityCard() { }

        public NearestUtilityCard(String name)
        {
            this.name = name;
        }

        public override void drawCard(Player p, List<Player> otherP, Board b)
        {
            int i = p.getLocation();
            int loc = 0;
            if (i < 12 || i >= 28) { loc = 12; }
            else { loc = 28; }
            p.move(-p.getLocation() + loc);
            Utility u = (Utility)b.getCellAt(loc);
            if(u.getOwner() == b.getBanker()) {
                b.buyDisplay();
            } else {
                int amount = 0;
                Random die = new Random();
                amount += die.Next(5)+1;
                amount += die.Next(5)+1;
                amount *= 10;
                p.addMoney(-amount);
                u.getOwner().addMoney(amount);
            }
        }
    }
}
