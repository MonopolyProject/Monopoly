using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Utility: Property
    {
        public static readonly int OWN_ONE_UTILITY = 4;
        public static readonly int OWN_TWO_UTILITY = 10;


        public Utility(String name, int position, Player owner, int cost, int mortgage)
        {
            this.buy = cost;
            this.owner = owner;
            this.owner.addDeed(this);
            this.mortgage = mortgage;
            this.name = name;
            this.position = position;
        }

        public override int getRent()
        {
            int count = this.owner.countType(typeof(Utility));
            if (count == 1)
                return OWN_ONE_UTILITY;
            else if (count == 2)
                return OWN_TWO_UTILITY;
            else
                return 0;
                
        }

        public override int addHouse() { return -1; }
    }
}
