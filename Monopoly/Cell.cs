using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Cell
    {
        protected String name;
        protected int position;


        public int getPos() { return this.position; }

        public String getName() { return this.name; }

    }
}
