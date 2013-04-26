using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class RailroadTests
    {

        [Test()]
        public void testInitializes()
        {
            Railroad r = new Railroad("Pennsylvania Railroad", 15, new Player("Ben"), 200, 100);
            Assert.NotNull(r);
        }

        [Test()]
        public void testValues()
        {
            Player playah = new Player("Ben");
            Railroad r = new Railroad("Pennsylvania Railroad", 15, playah, 200, 100);
            Assert.AreEqual("Pennsylvania Railroad", r.getName());
            Assert.AreEqual(15, r.getPos());
            Assert.AreEqual(playah, r.getOwner());
            Assert.AreEqual(200, r.getBuy());
            Assert.AreEqual(100, r.getMortgage());
            Assert.AreEqual(0, r.getHouseCost());
        }

        [Test()]
        public void testAddHouseFail()
        {
            Player playah = new Player("Ben");
            Railroad r = new Railroad("Pennsylvania Railroad", 15, playah, 200, 100);

            Assert.AreEqual(0, r.getNumHouses());

            Assert.AreEqual(-1, r.addHouse());
            Assert.AreEqual(-1, r.addHouse());
            Assert.AreEqual(-1, r.addHouse());

            Assert.AreEqual(99, r.removeHouse());
            Assert.AreEqual(0, r.getNumHouses());
        }

        [Test()]
        public void testGettingRent()
        {
            Player playah = new Player("Ben");

            Railroad readingRR = new Railroad("Reading Railroad", 5, playah, 200, 100);
            Assert.AreEqual(25, readingRR.getRent());

            Railroad pennRR = new Railroad("Pennsylvania Railroad", 15, playah, 200, 100);
            Assert.AreEqual(50, readingRR.getRent());
            Railroad boRR = new Railroad("B&O Railroad", 25, playah, 200, 100);
            Assert.AreEqual(100, readingRR.getRent());
            Railroad shortRR = new Railroad("Short Line", 35, playah, 200, 100);
            Assert.AreEqual(200, readingRR.getRent());


            
        }
    }
}
