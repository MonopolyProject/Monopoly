using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CommunityChest : Cell
    {
        public CommunityChest()
        {
            this.name = "Community Chest";
            this.position = 2;
        }

        public CommunityChest(int pos)
        {
            this.name = "Community Chest";
            this.position = pos;
        }

        public void effect(Player p, Card c)
        {
            c.drawCard(p);
        }
    }
}
