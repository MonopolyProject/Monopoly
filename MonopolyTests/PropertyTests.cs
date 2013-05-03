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
    class PropertyTests
    {
        [Test()]
        public void testInitializes()
        {
            Player p1 = new Player("Ed");
            var prop = new Property("Board Walk", 39, p1, 1, 2, new int[] {1}, 1);
            Assert.NotNull(prop);
        }

        [Test()]
        public void testValuesStore()
        {
            Player p1 = new Player("Ed");
            var prop = new Property("Board Walk", 39, p1, 1, 2, new int[] {1}, 1);
            prop.setColorHouses(new Property[] {new Property ("SAME COLOR BUT NOT OWNED", 39, new Player("TROLL"), 1, 2, new int[] {1}, 1)});
            Assert.AreEqual("Board Walk", prop.getName());
            Assert.AreEqual(39, prop.getPos());
            Assert.AreEqual(p1, prop.getOwner());
            Assert.AreEqual(1, prop.getBuy());
            Assert.AreEqual(2, prop.getMortgage());
            Assert.AreEqual(1, prop.getRent());
            Assert.AreEqual(0, prop.getNumHouses());
            Assert.AreEqual(1, prop.getHouseCost());

        }

        [Test()]
        public void testChangingPlayer()
        {
            Player p1 = new Player("Ed");
            var prop = new Property("Board Walk", 39, p1, 1, 2, new int[] { 1 }, 1); 
            Assert.AreEqual(p1, prop.getOwner());

            Player p2 = new Player("Tomato");
            prop.changeOwner(p2);
            Assert.AreEqual(p2, prop.getOwner());
            Assert.AreNotSame(p1, prop.getOwner());
        }


        [Test()]
        public void testAddPass()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i + 1, boardwalk.addHouse());
                Assert.AreEqual(i + 1, parkplace.addHouse());
            }
        }

        [Test()]
        public void testAddFailNotMonopoly()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, new Player("Ed"), 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, new Player("Andy"), 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            Assert.AreEqual(-3, boardwalk.addHouse());
        }

        [Test()]
        public void testAddFailTooManyHouses()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });
            for (int i = 0; i < 5; i++)
            {
                boardwalk.addHouse();
                parkplace.addHouse();
            }

            Assert.AreEqual(-1, boardwalk.addHouse());
        }

        [Test()]
        public void testAddFailMortgaged()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });
            Assert.False(boardwalk.isMortgaged());
            boardwalk.mortgageProperty();
            Assert.True(boardwalk.isMortgaged());
            Assert.AreEqual(-2, boardwalk.addHouse());
        }

        [Test()]
        public void testAddUnevenBuild()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });

            boardwalk.addHouse();
            Assert.AreEqual(-4, boardwalk.addHouse());
        }


        [Test()]
        public void testRemovingHousesSuccess()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });

            Assert.AreEqual(1, boardwalk.addHouse());
            Assert.AreEqual(0, boardwalk.removeHouse());

        }

        [Test()]
        public void testRemovingHousesFailNoHouses()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });

            Assert.AreEqual(99, boardwalk.removeHouse());

        }

        [Test()]
        public void testRemovingHousesFailRemoveUneven()
        {
            Player p = new Player("Ed");
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, p, 400, 200, rents, 200);
            var parkplace = new Property("Park Place", 39, p, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { parkplace });
            parkplace.setColorHouses(new Property[] { boardwalk });

            boardwalk.addHouse();
            parkplace.addHouse();
            parkplace.addHouse();

            Assert.AreEqual(98, boardwalk.removeHouse());


        }

        [Test()]
        public void testGettingRentSuccess()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            Player ed = new Player("Ed");
            var boardwalk = new Property("Board Walk", 39, ed, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] {new Property ("SAME COLOR BUT NOT OWNED", 39, new Player("TROLL"), 1, 2, new int[] {1}, 1)});
            
            for(int i = 0; i < 5;  i++){
                Assert.AreEqual(rents[i], boardwalk.getRent());
                boardwalk.setHouses(i + 1);
            }
        }

        [Test()]
        public void testGettingRentDoubleNoHousesMonopoly()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            Player ed = new Player("Ed");
            var boardwalk = new Property("Board Walk", 39, ed, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { new Property("SAME COLOR BUT OWNED", 39, ed, 1, 2, new int[] { 1 }, 1) });

            Assert.True(boardwalk.isMonopoly());
            Assert.AreEqual(2 * rents[0], boardwalk.getRent());
        }

        [Test()]
        public void testGettingRentFailMortgaged()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            Player ed = new Player("Ed");
            var boardwalk = new Property("Board Walk", 39, ed, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { new Property("SAME COLOR BUT NOT OWNED", 39, new Player("Troll"), 1, 2, new int[] { 1 }, 1) });

            boardwalk.mortgageProperty();
            Assert.True(boardwalk.isMortgaged());
            Assert.AreEqual(0, boardwalk.getRent());
        }

        [Test()]
        public void testPlacingAndLiftingMortgage()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            Player ed = new Player("Ed");
            var boardwalk = new Property("Board Walk", 39, ed, 400, 200, rents, 200);
            boardwalk.setColorHouses(new Property[] { });
            ed.addMoney(500);
            Assert.IsFalse(boardwalk.isMortgaged());
            Assert.IsTrue(boardwalk.canMortgage());
            boardwalk.mortgageProperty();
            Assert.IsTrue(boardwalk.isMortgaged());
            Assert.IsFalse(boardwalk.canMortgage());

            Assert.AreEqual(0, boardwalk.getRent());

            boardwalk.liftMortgage();
            Assert.IsFalse(boardwalk.isMortgaged());

            
        }

        [Test()]
        public void testMorgagePayment()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, new Player("Ed"), 400, 200, rents, 200);
            Assert.AreEqual((int) (200 * 1.1), boardwalk.getPayMortgage());
        }
    }
}
