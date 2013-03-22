using System;
using Monopoly;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApplication2;

namespace MonopolyTests
{
    [TestFixture()]
    public class BoardTest
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
        public void TestRollingDie()
        {
            Board board = new WindowsFormsApplication2.Board();
            List<int> die = board.roll();
            Assert.Less(die[0],6);
            Assert.Greater(die[0],1);
            Assert.Less(die[1], 6);
            Assert.Greater(die[1], 1);
        }



    }
}
