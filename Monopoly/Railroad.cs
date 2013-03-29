using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Railroad: Cell
    {
        private String name;
        private int position;
        private int buy;
        private int sell;
        private int[] rents;
        private int numHouses = 0;//5 houses = 1 hotel on a normal property
        private Player owner;

        public Railroad(String name, int position, Player owner, int cost, int mortgage, int[] rents)
        {
            this.buy = cost;
            this.owner = owner;
            this.rents = rents;
            this.sell = mortgage;
            this.name = name;
            this.position = position;
        }
    }
}
