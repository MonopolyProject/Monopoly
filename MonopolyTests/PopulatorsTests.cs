using System;
using Monopoly;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApplication2;

namespace MonopolyTests
{
    [TestFixture()]
    public class PopulatorsTests
    {
        [Test()]
        public void testReturnsNotNull()
        {
            Assert.NotNull(Populators.populateCells(new Player("Ed")));
        }

        [Test()]
        public void TestContainsCorrectNumberCells()
        {
            Assert.AreEqual(40, Populators.populateCells(new Player("Ed")).Count); 
        }

        [Test()]
        public void TestContainsCorrectNumberTypes()
        {
            List<Cell> cs = Populators.populateCells(new Player("Ed"));
            int properties = 0, railroads = 0, utilities = 0, freeparking = 0, itax = 0, ltax = 0, card = 0, jail = 0, gotojail = 0;
            
            foreach (Cell c in cs)
            {
          
                if (c is Railroad) railroads++;
                else if (c is Utility) utilities++;
                else if (c is IncomeTax) itax++;
                else if (c is LuxuryTax) ltax++;
                else if (c is CardCell) card++;
                else if (c is Jail) jail++;
                else if (c is CellGoToJail) gotojail++;
                else if (c is FreeParking) freeparking++;
                else if (c is Property) properties++; 

            }

            Assert.AreEqual(22, properties);
            Assert.AreEqual(4, railroads);
            Assert.AreEqual(2, utilities);
            Assert.AreEqual(6, card);
            Assert.AreEqual(2, freeparking);//go is considered free parking because doesnt do anything when landed on.
            Assert.AreEqual(1, itax);
            Assert.AreEqual(1, ltax);
            Assert.AreEqual(1, jail);
            Assert.AreEqual(1, gotojail);

        }
    }
}
