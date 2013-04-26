using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class UtilityTests
    {

        [Test()]
        public void testInitializes()
        {
            Utility electric = new Utility("Electric Company", 12, new Player("Ben"), 150, 75);
            Assert.NotNull(electric);
        }

        [Test()]
        public void testValues()
        {
            Player playah = new Player("Ben");
            Utility e = new Utility("Electric Company", 12, playah, 150, 75);
            Assert.AreEqual("Electric Company", e.getName());
            Assert.AreEqual(12, e.getPos());
            Assert.AreEqual(playah, e.getOwner());
            Assert.AreEqual(150, e.getBuy());
            Assert.AreEqual(75, e.getMortgage());
            Assert.AreEqual(0, e.getHouseCost());
        }

        [Test()]
        public void testAddHouseFail()
        {
            Player playah = new Player("Ben");
            Utility e = new Utility("Electric Company", 12, playah, 150, 75);

            Assert.AreEqual(0, e.getNumHouses());

            Assert.AreEqual(-1, e.addHouse());
            Assert.AreEqual(-1, e.addHouse());
            Assert.AreEqual(-1, e.addHouse());

            Assert.AreEqual(99, e.removeHouse());
            Assert.AreEqual(0, e.getNumHouses());
        }

        [Test()]
        public void testGettingRent()
        {
            Player playah = new Player("Ben");

            Utility e = new Utility("Electric Company", 12, playah, 150, 75);
            Assert.AreEqual(Utility.OWN_ONE_UTILITY, e.getRent());

            Utility w = new Utility("Water Works", 28, playah, 150, 75);
            Assert.AreEqual(Utility.OWN_TWO_UTILITY, e.getRent());



        }
    }
}
