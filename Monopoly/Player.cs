using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        int location;
        List<Property> deeds = new List<Property>();

        public Player()
        {
            this.location = 0;
        }
        public int move(int distance) {
            this.location += distance;
            this.location = this.location % 40;
            return this.location;
        }
        public int getLocation() {
            return this.location;
        }

        public bool hasDeed(Property lookFor) { return this.deeds.Contains(lookFor); }
        public bool haveDeeds(List<Property> possibleDeeds)
        {
            foreach (Property prop in possibleDeeds)
            {
                if (!this.deeds.Contains(prop)) return false;
            }
            return true;
        }

        public void addDeed(Property prop) { this.deeds.Add(prop); }
        public List<Property> getDeeds() { return this.deeds; }
    }
}
