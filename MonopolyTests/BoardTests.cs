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
    }
}
