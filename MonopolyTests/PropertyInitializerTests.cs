using System;
using Monopoly;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApplication2;

namespace MonopolyTests
{
    [TestFixture()]
    public class PropertyInitializerTests
    {
        [Test()]
        public void testReturnsNotNull()
        {
            Assert.NotNull(PropertyInitializer.populateCells(new Player("Ed")));
        }

        [Test()]
        public void TestContainsCorrectNumberCells()
        {
            Assert.AreEqual(40, PropertyInitializer.populateCells(new Player("Ed")).Count); 
        }

        [Test()]
        public void TestContainsCorrectNumberTypes()
        {
            List<Cell> cs =  PropertyInitializer.populateCells(new Player("Ed"));
            int properties = 0, railroads = 0, utilities = 0, freeparking = 0, itax = 0, ltax = 0, chest = 0, chance = 0, jail = 0, gotojail = 0;
            
            foreach (Cell c in cs)
            {
          
                if (c is Railroad) railroads++;
                else if (c is Utility) utilities++;
                else if (c is IncomeTax) itax++;
                else if (c is LuxaryTax) ltax++;
                else if (c is CommunityChest) chest++;
                else if (c is Jail) jail++;
                else if (c is CellGoToJail) gotojail++;
                else if (c is FreeParking) freeparking++;
                else if (c is Property) properties++; 

            }

            Assert.AreEqual(22, properties);
            Assert.AreEqual(4, railroads);
            Assert.AreEqual(2, utilities);
            Assert.AreEqual(3, chance);//need to implement chance
            Assert.AreEqual(3, chest);
            Assert.AreEqual(2, freeparking);//go is considered free parking because doesnt do anything when landed on.
            Assert.AreEqual(1, itax);
            Assert.AreEqual(1, ltax);
            Assert.AreEqual(1, jail);
            Assert.AreEqual(1, gotojail);

        }
    }
}
