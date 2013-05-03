using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2;

namespace Monopoly
{
    //site with all property information we need
    //http://www.researchmaniacs.com/Games/Monopoly/Properties.html
    public class Property: Cell
    {
        protected int buy;
        protected int mortgage;
        protected int[] rents;
        protected int numHouses = 0;//5 houses = 1 hotel on a normal property
        protected int houseCost;
        protected Property[] colorGroup;
        protected Player owner;
        protected bool mortgaged = false;

        public Property() { }

        public Property(String name, int position, Player owner, int cost, int mortgage, int[] rents, int houseCost)
        {
            this.buy = cost;
            this.owner = owner;
            this.owner.addDeed(this);
            this.rents = rents;
            this.mortgage = mortgage;
            this.name = name;
            this.position = position;
            this.houseCost = houseCost;
        }


        public Player getOwner() { return this.owner; }

        public void changeOwner(Player newOwner) 
        {
            this.owner.removeDeed(this);
            this.owner = newOwner;
            this.owner.addDeed(this);
        }

        public int getBuy() { return this.buy; }

        public int getMortgage() { return this.mortgage; }

        public virtual int getRent() {
            if (!this.mortgaged)
            {
                if (this.isMonopoly() && this.numHouses == 0) return 2 * this.rents[this.numHouses];
                return this.rents[this.numHouses];
            }
            return 0;
        }

        public virtual int addHouse()
        {
            if (this.numHouses == 5) return -1;
            if (this.mortgaged) return -2;
            if (!this.isMonopoly()) return -3;
            foreach (Property p in colorGroup) if (p.getNumHouses() < this.numHouses) return -4;
            this.numHouses++;
            return this.numHouses;
        }

        public int removeHouse()
        {
            if(this.numHouses == 0) return 99;
            foreach (Property p in colorGroup) if (p.getNumHouses() > this.numHouses) return 98;
            this.numHouses--;
            return this.numHouses;
        }

        public int getNumHouses() { return this.numHouses; }

        public int getHouseCost() { return this.houseCost; }

        public void mortgageProperty() {
            if (this.canMortgage())
            {
                this.mortgaged = true;
            }
        }

        public bool canMortgage()
        {
            foreach (Property p in colorGroup) if (p.getNumHouses() != 0) return false;
            return this.numHouses == 0 && !this.mortgaged;
        }

        public void liftMortgage()
        {
            this.mortgaged = false;
        }

        public bool isMortgaged() { return this.mortgaged; }

        public int getPayMortgage() { return (int) (this.mortgage *1.1); }

        public bool isMonopoly()
        {
            foreach (Property p in colorGroup) if (!this.owner.Equals(p.owner)) return false;
            return true;
        }
        public void setColorGroup(Property[] group)
        {
            this.colorGroup = group;
        }

        public void setHouses(int newamount) { this.numHouses = newamount; }
    }
}
