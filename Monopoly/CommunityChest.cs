using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;
using WindowsFormsApplication2;

namespace Monopoly
{
    public class CommunityChest : Cell
    {
        public CommunityChest()
        {
            this.name = "Community Chest";
            this.position = 2;
        }

        public void effect(Player p, Card c, List<Player> otherP, Board b)
        {
            c.drawCard(p, otherP, b);
        }
    }
}
