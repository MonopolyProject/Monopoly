using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface Cell
    {

        void effect(Player landedOn);
        

    }
}
