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
    public class NearestRailroadCard : Card
    {
        public NearestRailroadCard() { }

        public NearestRailroadCard(String name)
        {
            this.name = name;
        }

        public override void drawCard(Player p, List<Player> otherP, Board b)
        {
            int i = p.getLocation();
            int loc = 0;
            if (i < 5 || i > 35) { loc = 5; }
            else if (i < 15) { loc = 15; }
            else if (i < 25) { loc = 25; }
            else if (i < 35) { loc = 35; }
            p.move(-p.getLocation() + loc);
            Railroad r = (Railroad) b.getCellAt(loc);
            if(r.getOwner() == b.getBanker()) {
                b.buyDisplay();
            } else {
                p.addMoney(-r.getRent());
                r.getOwner().addMoney(r.getRent());
            }
        }
    }
}
