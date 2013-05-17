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
    public class MoveCard: Card
    {
        protected int newLocation;
        protected bool passGo;

        public MoveCard() { }

        public MoveCard(String name, int newLocation, bool passGo)
        {
            this.name = name;
            this.newLocation = newLocation;
            this.passGo = passGo;
        }

        public override void drawCard(Player p, List<Player> otherP, Board b)
        {
            int loc = p.getLocation();
            p.move(-p.getLocation() + this.newLocation, false);
            if (loc > p.getLocation() && this.passGo) { p.addMoney(200); }
            b.updatePlayerPosition();
        }
    }
}
