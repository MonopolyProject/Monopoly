using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class LuxaryTaxTests
    {
        [Test()]
        public void TestInitializes()
        {
            Assert.NotNull(new LuxaryTax("Luxary Tax", 38));
        }

        [Test()]
        public void TestValuesStick()
        {
            LuxaryTax lt = new LuxaryTax("Luxary Tax", 38);
            Assert.AreEqual("Luxary Tax", lt.getName());
            Assert.AreEqual(38, lt.getPos());
        }


        [Test()]
        public void TestTaxDeductsFromPlayer()
        {
            LuxaryTax lt = new LuxaryTax("Luxary Tax", 38);
            Player p = new Player("Eddy");
            Assert.AreEqual(1300, p.getMoney());
            lt.effect(p);
            Assert.AreEqual(1300 - 75, p.getMoney());
        }

        [Test()]
        public void TestWorksInCellList()
        {
            Player p = new Player("Eddy");
            LuxaryTax lt = new LuxaryTax("Luxary Tax", 38);
            Property prop = new Property("TEST", 0, p, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            List<Cell> cells = new List<Cell>();
            cells.Add(prop);
            cells.Add(lt);
            foreach (Cell c in cells)
            {
                if (c.GetType().Equals(typeof(LuxaryTax)))
                    ((LuxaryTax)c).effect(p);
            }
            Assert.AreEqual(1300 - 75, p.getMoney());
        }
    }
}
