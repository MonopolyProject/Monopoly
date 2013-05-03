using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2;

namespace Monopoly
{
    public abstract class Card
    {
        protected String name;

        public String getName() { return this.name; }

        public abstract void drawCard(Player p, List<Player> otherP, Board b);
    }
}
