using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Monopoly
{
    public class Populators
    {
        public static List<Cell> populateCells(Player banker)
        {
            List<Cell> cells = new List<Cell>();
            List<Cell> orderedCells = new List<Cell>();

            Property mediterr = new Property("Mediterranean Avenue", 1, banker, 60, 30, new int[] { 2, 10, 30, 90, 160, 250 }, 50);
            Property baltic = new Property("Baltic Avenue", 3, banker, 60, 30, new int[] { 4, 20, 60, 180, 320, 450 }, 50);
            mediterr.setColorGroup(new Property[] { baltic });
            baltic.setColorGroup(new Property[] { mediterr });

            Property oriental = new Property("Oriental Avenue", 6, banker, 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }, 50);
            Property vermont = new Property("Vermont Avenue", 8, banker, 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }, 50);
            Property connecticut = new Property("Connecticut Avenue", 9, banker, 120, 60, new int[] { 8, 40, 100, 300, 450, 600 }, 50);
            oriental.setColorGroup(new Property[] { vermont, connecticut });
            vermont.setColorGroup(new Property[] { oriental, connecticut });
            connecticut.setColorGroup(new Property[] { vermont, oriental });


            Property charles = new Property("St. Charles Place", 11, banker, 140, 70, new int[] { 10, 50, 150, 250, 625, 750 }, 100);
            Property states = new Property("States Avenue", 13, banker, 140, 70, new int[] { 10, 50, 150, 250, 625, 750 }, 100);
            Property virginia = new Property("Virginia Avenue", 14, banker, 160, 80, new int[] { 12, 60, 180, 500, 700, 900 }, 100);
            charles.setColorGroup(new Property[] { virginia, states });
            states.setColorGroup(new Property[] { charles, connecticut });
            virginia.setColorGroup(new Property[] { charles, states });

            Property james = new Property("St. James Place", 16, banker, 180, 90, new int[] { 14, 70, 200, 550, 750, 950 }, 100);
            Property tennessee = new Property("Tennessee Avenue", 18, banker, 180, 90, new int[] { 14, 70, 200, 550, 750, 950 }, 100);
            Property newyork = new Property("New York Avenue", 19, banker, 200, 100, new int[] { 16, 80, 220, 600, 800, 1000 }, 100);
            james.setColorGroup(new Property[] { newyork, tennessee });
            tennessee.setColorGroup(new Property[] { james, newyork });
            newyork.setColorGroup(new Property[] { james, tennessee });

            Property kentucky = new Property("Kentucky Avenue", 21, banker, 220, 110, new int[] { 18, 90, 250, 700, 875, 1050 }, 150);
            Property indiana = new Property("Indiana Avenue", 23, banker, 220, 110, new int[] { 18, 90, 250, 700, 875, 1050 }, 150);
            Property illinois = new Property("Illinois Avenue", 24, banker, 240, 120, new int[] { 20, 100, 300, 750, 925, 1100 }, 150);
            kentucky.setColorGroup(new Property[] { illinois, indiana });
            indiana.setColorGroup(new Property[] { kentucky, illinois });
            illinois.setColorGroup(new Property[] { kentucky, indiana });


            Property atlantic = new Property("Atlantic Avenue", 26, banker, 260, 130, new int[] { 22, 110, 330, 800, 975, 1150 }, 150);
            Property ventnor = new Property("Ventnor Avenue", 27, banker, 260, 130, new int[] { 22, 110, 330, 800, 975, 1150 }, 150);
            Property marvin = new Property("Marvin Gardens", 29, banker, 280, 140, new int[] { 24, 120, 360, 850, 1025, 1200 }, 150);
            atlantic.setColorGroup(new Property[] { ventnor, marvin });
            ventnor.setColorGroup(new Property[] { atlantic, marvin });
            marvin.setColorGroup(new Property[] { atlantic, ventnor });

            Property pacific = new Property("Pacific Avenue", 31, banker, 300, 150, new int[] { 26, 130, 390, 900, 1100, 1275 }, 200);
            Property carolina = new Property("North Carolina Avenue", 32, banker, 300, 150, new int[] { 26, 130, 390, 900, 1100, 1275 }, 200);
            Property penn = new Property("Pennsylvania Avenue", 34, banker, 320, 160, new int[] { 28, 150, 450, 1000, 1200, 1400 }, 200);
            pacific.setColorGroup(new Property[] { carolina, penn });
            carolina.setColorGroup(new Property[] { pacific, penn });
            penn.setColorGroup(new Property[] { pacific, carolina });

            Property park = new Property("Park Place", 37, banker, 350, 175, new int[] { 35, 175, 500, 1100, 1300, 1500 }, 200);
            Property boardwalk = new Property("Boardwalk", 39, banker, 400, 200, new int[] { 50, 200, 600, 1400, 1700, 2000 }, 200);
            park.setColorGroup(new Property[] { boardwalk });
            boardwalk.setColorGroup(new Property[] { park });

            Railroad readingRR = new Railroad("Reading Railroad", 5, banker, 200, 100);
            Railroad pennRR = new Railroad("Pennsylvania Railroad", 15, banker, 200, 100);
            Railroad boRR = new Railroad("B&O Railroad", 25, banker, 200, 100);
            Railroad shortRR = new Railroad("Short Line", 35, banker, 200, 100);

            Utility electric = new Utility("Electric Company", 12, banker, 150, 75);
            Utility water = new Utility("Water Works", 28, banker, 150, 75);

            FreeParking parking = new FreeParking("Free Parking", 20);
            Jail jail = new Jail("Jail", 10);
            CellGoToJail jailGo = new CellGoToJail("Placeholder", 30);
            FreeParking go = new FreeParking("Go", 0);

            IncomeTax income = new IncomeTax("Income Tax", 4);
            LuxuryTax Luxury = new LuxuryTax("Luxury Tax", 38);

            CardCell cchest1 = new CardCell("Community Chest", 2);
            CardCell cchest2 = new CardCell("Community Chest", 17);
            CardCell cchest3 = new CardCell("Community Chest", 33);

            CardCell chance1 = new CardCell("Chance", 7);
            CardCell chance2 = new CardCell("Chance", 22);
            CardCell chance3 = new CardCell("Chance", 36);

            cells.Add(go); cells.Add(mediterr); cells.Add(cchest1); cells.Add(baltic); cells.Add(income); cells.Add(readingRR); cells.Add(oriental); cells.Add(chance1); cells.Add(vermont);
            cells.Add(connecticut); cells.Add(jail); cells.Add(charles); cells.Add(electric); cells.Add(states); cells.Add(virginia); cells.Add(pennRR); cells.Add(james); cells.Add(cchest2);
            cells.Add(tennessee); cells.Add(newyork); cells.Add(parking); cells.Add(kentucky); cells.Add(chance2); cells.Add(indiana); cells.Add(illinois); cells.Add(boRR); cells.Add(atlantic);
            cells.Add(ventnor); cells.Add(water); cells.Add(marvin); cells.Add(jailGo); cells.Add(pacific); cells.Add(carolina); cells.Add(cchest3); cells.Add(penn); cells.Add(shortRR);
            cells.Add(chance3); cells.Add(park); cells.Add(Luxury); cells.Add(boardwalk);

            return cells;
        }

        public static List<Card> populateCommunity()
        {
            List<Card> deck = new List<Card>();
            deck.Add(new MoveCard("Advance to GO: Collect $200", 0, true));
            deck.Add(new MoneyCard("Bank Error in your Favor: Collect $75", 75));
            deck.Add(new MoneyCard("Doctor's Fee: pay $50", 50));
            deck.Add(new GetOutOfJailFreeCard("Get Out of Jail Free"));
            deck.Add(new MoveCard("Go to Jail. Do not pass GO, do not collect $200", 10, false));
            deck.Add(new GiveMoneyCard("It's your birthday, each player pays you $10", 10));
            deck.Add(new GiveMoneyCard("Grand Opera Night, each player pays you $50", 50));
            deck.Add(new MoneyCard("Income Tax refund, collect $20", 20));
            deck.Add(new MoneyCard("Life Insurance Matures, collect $100", 100));
            deck.Add(new MoneyCard("Pay Hospital fees of $100", -100));
            deck.Add(new MoneyCard("Pay school fees of $50", -50));
            deck.Add(new MoneyCard("Receive $25 consultancy fee", 25));
            deck.Add(new RepairCard("You are assessed for Street Repairs: pay $40/house and $115/hotel", 40, 115));
            deck.Add(new MoneyCard("Won second prize in Beauty Contest, collect $10", 10));
            deck.Add(new MoneyCard("Distant Uncle passes away, inherit $100", 100));
            deck.Add(new MoneyCard("Collect $50 from stock sales", 50));
            deck.Add(new MoneyCard("Holiday fund matures, collect $100", 100));


            return deck;

        }

        public static List<Card> populateChance()
        {
            List<Card> deck = new List<Card>();
            deck.Add(new MoneyCard("Pay poor tax of $15", -15));
            deck.Add(new MoneyCard("Bank pays you dividend of $50", 50));
            deck.Add(new MoveCard("Advance to GO, collect $200", 0, true));
            deck.Add(new MoveCard("Advance to Illinois Avenue, collect $200 if you pass GO", 24, true));
            deck.Add(new NearestUtilityCard("Advance to nearest Utility. If owned, pay 10x rolled otherwise you may buy the property, collect $200 if you pass GO"));
            deck.Add(new NearestRailroadCard("Advance to nearest Railroad. If owned, pay 2x rent otherwise you may buy the property, collect $200 if you pass GO"));
            deck.Add(new MoveCard("Advance to St. Charles Place, collect $200 if you pass GO", 11, true));
            deck.Add(new GetOutOfJailFreeCard("Get out of Jail Free"));
            deck.Add(new MoveCard("Go directly to Jail. Do not pass GO, do not collect $200", 10, false));
            deck.Add(new RepairCard("Make repairs on all properties, pay $25/house and $100/hotel", 25, 110));
            deck.Add(new MoveCard("Take a trip on the Reading Railroad, collect $200 if you pass GO", 5, true));
            deck.Add(new MoveCard("Take a walk on Boardwalk", 39, true));
            deck.Add(new GiveMoneyCard("You've been elected Chariman of the board, pay each player $50", -50));
            deck.Add(new MoneyCard("Your building Loan Matures, collect $150", 150));
            deck.Add(new MoneyCard("You won Crossword Competition, collect $100", 100));

            return deck;

        }

        public static List<Player> populatePlayers()
        {
            Player player0 = new Player("Ed");
            Player player1 = new Player("Tomato");
            List<Player> players = new List<Player>();
            players.Add(player0);
            players.Add(player1);
            return players;

        }

        public static List<Point> populateLocations()
        {
            List<Point> locationSet = new List<Point>();
            int x = 58;
            int y = 848;
            int i;
            locationSet.Add(new Point(x, y));
            for (i = 0; i < 10; i++)
            {
                if (i % 10 == 0)
                {
                    y -= 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    y -= 70;
                    locationSet.Add(new Point(x, y));
                }
            }
            x = 120;
            y = 50;
            for (i = 10; i < 20; i++)
            {
                if (i % 10 == 0)
                {
                    x += 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    x += 70;
                    locationSet.Add(new Point(x, y));
                }
            }
            x = 910;
            y = 120;
            for (i = 20; i < 30; i++)
            {
                if (i % 10 == 0)
                {
                    y += 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    y += 70;
                    locationSet.Add(new Point(x, y));
                }
            }

            x = 840;
            y = 910;
            for (i = 10; i < 19; i++)
            {
                if (i % 10 == 0)
                {
                    x -= 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    x -= 70;
                    locationSet.Add(new Point(x, y));
                }
            }

            return locationSet;

        }
    }
}
