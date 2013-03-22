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
    }
}
