﻿using System;
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
            Player p1 = new Player();
            var prop = new Property("Board Walk", 39, p1, 1, 2, new int[] {1}, 1);
            Assert.NotNull(prop);
        }

        [Test()]
        public void testValuesStore()
        {
            Player p1 = new Player();
            var prop = new Property("Board Walk", 39, p1, 1, 2, new int[] {1}, 1);
            Assert.AreEqual("Board Walk", prop.getName());
            Assert.AreEqual(39, prop.getPos());
            Assert.AreEqual(p1, prop.getOwner());
            Assert.AreEqual(1, prop.getBuy());
            Assert.AreEqual(2, prop.getSell());
            Assert.AreEqual(1, prop.getRent());
            Assert.AreEqual(0, prop.getNumHouses());
            Assert.AreEqual(1, prop.getHouseCost());

        }

        [Test()]
        public void testChangingPlayer()
        {
            Player p1 = new Player();
            var prop = new Property("Board Walk", 39, p1, 1, 2, new int[] { 1 }, 1); 
            Assert.AreEqual(p1, prop.getOwner());

            Player p2 = new Player();
            prop.changeOwner(p2);
            Assert.AreEqual(p2, prop.getOwner());
            Assert.AreNotSame(p1, prop.getOwner());
        }

        [Test()]
        public void testAddingHouses()
        {
            int[] rents = { 50, 200, 600, 1400, 1700, 200 };
            var boardwalk = new Property("Board Walk", 39, new Player(), 400, 200, rents, 200);
            Assert.AreEqual(0, boardwalk.getNumHouses());

            boardwalk.addHouse();
            Assert.AreEqual(1, boardwalk.getNumHouses());
            Assert.AreEqual(rents[1], boardwalk.getRent());

            boardwalk.addHouse();
            boardwalk.addHouse();
            boardwalk.addHouse();
            boardwalk.addHouse();
            Assert.AreEqual(5, boardwalk.getNumHouses());
            Assert.AreEqual(rents[5], boardwalk.getRent());

            boardwalk.addHouse();
            Assert.AreEqual(5, boardwalk.getNumHouses());
            Assert.AreEqual(rents[5], boardwalk.getRent());
        }



    }
}