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
            while(b.getCellAt(i).GetType() != typeof(Utility)) {
                i = (i+i)%40;
            }
            p.move(-p.getLocation() + i);
            Utility u = (Utility)b.getCellAt(i);
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
