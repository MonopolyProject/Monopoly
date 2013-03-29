using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        string Name;
        int money;
        int location;
        int payForRound;
        public List<Property> deeds = new List<Property>();

        public Player(string Name)
        {
            this.Name = Name;
            this.location = 0;
            this.money = 1500;
        }
        public int move(int distance) {
            this.location += distance;
            this.location = this.location % 40;
            return this.location;
        }

        public string getName()
        {
            return this.Name;
        }

        public int getMoney()
        {
            return this.money;
        }

        public int getLocation() {
            return this.location;
        }

        public void addMoney(int amount)
        {
            this.money = this.money + amount;
            if(amount<0) {
                this.payForRound = -amount;
            }
        }

        public void setPayForRound(int amount)
        {
            this.payForRound = amount;
        }

        public int getPayForRound()
        {
            return this.payForRound;
        }

        public bool hasDeed(Property lookFor) { return this.deeds.Contains(lookFor); }
        public bool hasDeeds(List<Property> possibleDeeds)
        {
            foreach (Property prop in possibleDeeds)
            {
                if (!this.deeds.Contains(prop)) return false;
            }
            return true;
        }

        public void addDeed(Cell prop) { this.deeds.Add((Property) prop); }
        public void removeDeed(Property prop) { this.deeds.Remove(prop); }
        public List<Property> getDeeds() { return this.deeds; }
    }
}
