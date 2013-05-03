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
            while(b.getCellAt(i).GetType() != typeof(Railroad)) {
                i = (i+i)%40;
            }
            p.move(-p.getLocation() + i);
            Railroad r = (Railroad) b.getCellAt(i);
            if(r.getOwner() == b.getBanker()) {
                b.buyDisplay();
            } else {
                b.rent();
                b.rent();
            }
        }
    }
}
