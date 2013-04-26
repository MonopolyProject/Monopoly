using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    public class IncomeTaxTests
    {
        [Test()]
        public void TestInitializes()
        {
            Assert.NotNull(new IncomeTax("Income Tax", 4));
        }

        [Test()]
        public void TestValuesStick()
        {
            IncomeTax it = new IncomeTax("Income Tax", 4);
            Assert.AreEqual("Income Tax", it.getName());
            Assert.AreEqual(4, it.getPos());
        }

        [Test()]
        public void Test200TaxDeducts()
        {
            IncomeTax it = new IncomeTax("Income Tax", 4);
            Player p = new Player("Eddy");

            Assert.AreEqual(1300, p.getMoney());
            it.effect(p, true);
            Assert.AreEqual(1300 - 200, p.getMoney());
        }

        [Test()]
        public void TestPercentageTaxDeducts()
        {
            IncomeTax it = new IncomeTax("Income Tax", 4);
            Player p = new Player("Eddy");

            Assert.AreEqual(1300, p.getMoney());
            int totalWorth = 1300;

            it.effect(p, false);
            Assert.AreEqual(1300 - totalWorth/10, p.getMoney());
        }


        [Test()]
        public void TestEffectDefaultsTo200()
        {
            IncomeTax it = new IncomeTax("Income Tax", 4);
            Player p = new Player("Eddy");

            Assert.AreEqual(1300, p.getMoney());

            it.effect(p);
            Assert.AreEqual(1300 - 200, p.getMoney());
        }
    }
}
