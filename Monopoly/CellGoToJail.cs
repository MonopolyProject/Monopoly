using Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CellGoToJail:Special
    {
        public CellGoToJail(string name, int position)
        {
            this.name = name;
            this.position = position;
        }

        public static void goToJail(Player player)
        {
            player.move(40- player.getLocation());
            player.move(10);
        }

        public override void effect(Player landedOn)
        {

        }
    }
}
