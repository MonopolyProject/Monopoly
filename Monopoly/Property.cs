using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //site with all property information we need
    //http://www.researchmaniacs.com/Games/Monopoly/Properties.html
    public class Property: Cell
    {
        private String name;
        private int position;
        private int buy;
        private int sell;
        private int[] rents;
        private int numHouses = 0;//5 houses = 1 hotel on a normal property
        private int houseCost;
        private Player owner;

        public Property(String name, int position, Player owner, int cost, int mortgage, int[] rents, int houseCost)
        {
            this.buy = cost;
            this.owner = owner;
            this.rents = rents;
            this.sell = mortgage;
            this.name = name;
            this.position = position;
            this.houseCost = houseCost;

        }

        public void effect (Player landedOn)
        {



        }

        public String getName() { return this.name; }

        public Player getOwner() { return this.owner; }

        public void changeOwner(Player newOwner) { this.owner = newOwner; }
       
        public int getPos() { return this.position; }

        public int getBuy() { return this.buy; }

        public int getSell() { return this.sell; }

        public int getRent() { return this.rents[this.numHouses]; }

        public void addHouse()
        {
            if (numHouses < 5) numHouses++;
        }

        public int getNumHouses() { return this.numHouses; }

        public int getHouseCost() { return this.houseCost; }

    }
}
