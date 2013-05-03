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
    public class GetOutOfJailFreeCard: Card
    {

        public GetOutOfJailFreeCard() { }

        public GetOutOfJailFreeCard(String name)
        {
            this.name = name;
        }

        public override void drawCard(Player p, List<Player> otherP, Board b)
        {
            p.setGetOutOfJailFree(true);
        }
    }
}
