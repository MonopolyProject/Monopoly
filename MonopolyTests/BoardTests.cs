using System;
using Monopoly;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApplication2;

namespace MonopolyTests
{
    [TestFixture()]
    public class BoardTests
    {
        [Test()]
        public void TestThatBoardInitializes()
        {
            Board board = new WindowsFormsApplication2.Board();
            Assert.IsNotNull(board);
        }
        [Test()]
        public void TestBoardInitializePlayer()
        {
            Board board = new WindowsFormsApplication2.Board();
            Assert.IsNotNull(board.getPlayer());

        }
        [Test()]
        public void TestBoardPopulateLocations()
        {
            Board board = new WindowsFormsApplication2.Board();
            Assert.IsNotNull(board.locations);
            Assert.AreEqual(40, board.locations.Count);
        }
        [Test()]
        public void TestRollingDie()
        {
            Board board = new WindowsFormsApplication2.Board();
            List<int> die = board.roll();
            Assert.Less(die[0],6);
            Assert.Greater(die[0],0);
            Assert.Less(die[1], 6);
            Assert.Greater(die[1], 0);
        }

        [Test()]
        public void TestMovePlayer()
        {
            Board board = new WindowsFormsApplication2.Board();
            int position = board.movePlayer();
            Assert.AreEqual(position, board.getPlayer().getLocation());
        }

        [Test()]
        public void TestPlayerShapePosition()
        {
            Board board = new WindowsFormsApplication2.Board();
            for (int i = 0; i < 12; i++)
            {
                int position = board.movePlayer();
                Assert.AreEqual(board.getPlayerShape().Location, board.locations[board.getPlayer().getLocation()]);
            }
        }

        [Test()]
        public void TestBuyDisplay()
        {
            Board board = new WindowsFormsApplication2.Board();
            board.buyDisplay();
            Assert.True(board.getBuy().Enabled);
            Assert.True(board.getEndTurn().Enabled);
            Assert.False(board.getRollDie().Enabled);
        }

        [Test()]
        public void TestEndTurn()
        {
            Board board = new WindowsFormsApplication2.Board();
            int active = board.getActivePlayer();
            board.endTurn();
            Assert.AreEqual(active + 1, board.getActivePlayer());
            board.endTurn();
            Assert.AreEqual(0, board.getActivePlayer());
            Assert.False(board.getBuy().Enabled);
            Assert.False(board.getEndTurn().Enabled);
            Assert.True(board.getRollDie().Enabled);
        }
        
        [Test()]
        public void TestBuyProperty()
        {
            Board board = new WindowsFormsApplication2.Board();
            var p = board.getPlayer();
            p.move(6);
            Assert.AreEqual(6, p.getLocation());
            Property prop = (Property) board.getCellAt(p.getLocation());

            Assert.False(p.getDeeds().Contains(prop));
            int houseCost = prop.getBuy();
            board.buyProperty();
            Assert.True(p.getDeeds().Contains(prop));
            int newMoney = 1500 - houseCost;
            Assert.AreEqual(newMoney, p.getMoney());
            Assert.AreEqual(1, prop.getNumHouses());

            houseCost = prop.getHouseCost();
            board.buyProperty();
            Assert.AreEqual(newMoney - houseCost, p.getMoney());
            Assert.AreEqual(2, prop.getNumHouses());

            p.addMoney(-p.getMoney());
            board.buyProperty();
            Assert.AreEqual(0, p.getMoney());
            Assert.AreEqual(2, prop.getNumHouses());
        }
    }
}
