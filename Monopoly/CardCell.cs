using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;
using WindowsFormsApplication2;

namespace Monopoly
{
    public class CardCell : Cell
    {
        public CardCell(string name, int pos)
        {
            this.name = name;
            this.position = pos;
        }

        public void effect(Player p, Card c, List<Player> otherP, Board b)
        {
            c.drawCard(p, otherP, b);
        }
    }
}
