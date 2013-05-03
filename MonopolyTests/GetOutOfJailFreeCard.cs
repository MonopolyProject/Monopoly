using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class GetOutOfJailFreeCardTests
    {
        [Test()]
        public void testMoneyCardProperties()
        {
            GetOutOfJailFreeCard c = new GetOutOfJailFreeCard("G");
            Assert.AreEqual(c.getName(), "G");
        }

        [Test()]
        public void testCardEffect()
        {
            GetOutOfJailFreeCard c = new GetOutOfJailFreeCard("G");
            Player ed = new Player("Ed");
            Assert.False(ed.hasGetOutOfJailFree());
            c.drawCard(ed, null, null);
            Assert.True(ed.hasGetOutOfJailFree());
        }
    }
}
