﻿using Monopoly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
namespace WindowsFormsApplication2
{
    public partial class Board
    {
        private static Player banker = new Player("banker");
        public List<Point> locations = Populators.populateLocations();
        public String language;
        private List<Player> players = new List<Player>();
        private List<Cell> cells =  Populators.populateCells(banker);
        private List<Card> CommunityChestDeck = Populators.populateCommunity();
        private List<Card> ChanceDeck  = Populators.populateChance();
        public int numberOfPlayers;
        private int activePlayer = 0;
        CheckedListBox properties;
        Form propertyList;
        Form manageList;
        List<int> diceRoll = new List<int>();
        TextBox tradePrice = new TextBox();
        Property propertyToAdd;
        Form controllBoard = new Form();
        TextBox numberToRoll = new TextBox();
        Form languageMenu;
        Form noPlayersMenu;
        Form playerCreationMenu;
        TextBox nameBox;

        public List<Player> getPlayers() { return this.players; }
        public List<Card> getChance() { return this.ChanceDeck; }
        public List<Card> getCommunity() { return this.CommunityChestDeck; }

        private System.ComponentModel.IContainer components = null;

        public void languageSelect()
        {
            this.languageMenu = new Form();
            this.languageMenu.Width = 300;
            this.languageMenu.Height = 150;
            this.languageMenu.StartPosition = FormStartPosition.CenterScreen;
            this.languageMenu.Text = "Select a Language";
         //   Label menu = new Label();
           // menu.Width = 100;
           // menu.Height = 20;
           // menu.Text = "Select a Language";
            RadioButton radioButton1 = new RadioButton();
            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(10, 30);
            radioButton1.Name = "English";
            radioButton1.Size = new System.Drawing.Size(100, 10);
            radioButton1.TabIndex = 35;
            radioButton1.TabStop = true;
            radioButton1.Text = "English";
            radioButton1.UseVisualStyleBackColor = true;
            RadioButton radioButton2 = new RadioButton();
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(10, 45);
            radioButton2.Name = "Chinese";
            radioButton2.Size = new System.Drawing.Size(100, 10);
            radioButton2.TabIndex = 35;
            radioButton2.TabStop = true;
            radioButton2.Text = "Chinese";
            radioButton2.UseVisualStyleBackColor = true;

            RadioButton confirm = new RadioButton();
            confirm.AutoSize = true;
            confirm.Location = new System.Drawing.Point(10, 60);
            confirm.Name = "Confirm";
            confirm.Size = new System.Drawing.Size(100, 10);
            confirm.TabIndex = 35;
            confirm.TabStop = true;
            confirm.Text = "Confirm";
            confirm.UseVisualStyleBackColor = true;

            this.languageMenu.Location = new System.Drawing.Point(5, 5);

            radioButton1.Click += new System.EventHandler(language_Click_1);
            radioButton2.Click += new System.EventHandler(language_Click_2);
            confirm.Click += new System.EventHandler(language_Confirm);

         //   this.languageMenu.Controls.Add(menu);
            this.languageMenu.Controls.Add(radioButton1);
            this.languageMenu.Controls.Add(radioButton2);
            this.languageMenu.Controls.Add(confirm);
            this.languageMenu.AutoSize = true;
            languageMenu.ShowDialog();
        }

        public void noPlayersSelect()
        {
            this.noPlayersMenu = new Form();
            this.noPlayersMenu.Width = 125;
            this.noPlayersMenu.Height = 200;
            this.noPlayersMenu.StartPosition = FormStartPosition.CenterScreen;
            Label menu = new Label();
            menu.Width = 200;
            menu.Height = 20;
            menu.Text = Resource1.NumOfPlayers;
            RadioButton radioButton1 = new RadioButton();
            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(10, 30);
            radioButton1.Name = "2 Players";
            radioButton1.Size = new System.Drawing.Size(100, 10);
            radioButton1.TabIndex = 35;
            radioButton1.TabStop = true;
            radioButton1.Text = Resource1.twoPlayers;
            radioButton1.UseVisualStyleBackColor = true;
            RadioButton radioButton2 = new RadioButton();
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(10, 45);
            radioButton2.Name = "3 Players";
            radioButton2.Size = new System.Drawing.Size(100, 10);
            radioButton2.TabIndex = 35;
            radioButton2.TabStop = true;
            radioButton2.Text = Resource1.threePlayers;
            RadioButton radioButton3 = new RadioButton();
            radioButton3.AutoSize = true;
            radioButton3.Location = new System.Drawing.Point(10, 60);
            radioButton3.Name = "4 Players";
            radioButton3.Size = new System.Drawing.Size(100, 10);
            radioButton3.TabIndex = 35;
            radioButton3.TabStop = true;
            radioButton3.Text = Resource1.fourPlayers;
            radioButton3.UseVisualStyleBackColor = true;

            RadioButton confirm = new RadioButton();
            confirm.AutoSize = true;
            confirm.Location = new System.Drawing.Point(10, 75);
            confirm.Name = "Confirm";
            confirm.Size = new System.Drawing.Size(100, 10);
            confirm.TabIndex = 35;
            confirm.TabStop = true;
            confirm.Text = Resource1.confirm;
            confirm.UseVisualStyleBackColor = true;
            this.noPlayersMenu.Location = new System.Drawing.Point(5, 5);
            
            radioButton1.Click += new System.EventHandler(noPlayers_Click_1);
            radioButton2.Click += new System.EventHandler(noPlayers_Click_2);
            radioButton3.Click += new System.EventHandler(noPlayers_Click_3);
            confirm.Click += new System.EventHandler(noPlayers_Confirm);

            this.noPlayersMenu.Controls.Add(menu);
            this.noPlayersMenu.Controls.Add(radioButton1);
            this.noPlayersMenu.Controls.Add(radioButton2);
            this.noPlayersMenu.Controls.Add(radioButton3);
            this.noPlayersMenu.Controls.Add(confirm);
            this.noPlayersMenu.ShowDialog();
        }

        public void generatePlayers()
        {
            this.playerCreationMenu = new Form();
            this.playerCreationMenu.Width = 250;
            this.playerCreationMenu.Height = 125;
            this.playerCreationMenu.StartPosition = FormStartPosition.CenterScreen;
            this.nameBox = new TextBox();
            nameBox.Width = 200;
            nameBox.Height = 20;
            nameBox.Text = String.Format(Resource1.enterPlayerName, activePlayer + 1);
            nameBox.Location = new System.Drawing.Point(10, 20);

            Button confirm = new Button();
            confirm.AutoSize = true;
            confirm.Location = new System.Drawing.Point(10, 50);
            confirm.Name = "Confirm";
            confirm.Size = new System.Drawing.Size(100, 10);
            confirm.TabIndex = 35;
            confirm.TabStop = true;
            confirm.Text = Resource1.confirm;
            confirm.UseVisualStyleBackColor = true;
            this.noPlayersMenu.Location = new System.Drawing.Point(5, 5);

            confirm.Click += new System.EventHandler(newPlayer_Confirm);

            this.playerCreationMenu.Controls.Add(nameBox);
            this.playerCreationMenu.Controls.Add(confirm);
            this.playerCreationMenu.ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public Player getPlayer()
        {
            return this.players[this.activePlayer];
        }

        public Microsoft.VisualBasic.PowerPacks.OvalShape getPlayerShape()
        {
            if (this.activePlayer == 0) return this.ovalShape1;
            else if(this.activePlayer == 1) return this.ovalShape2;
            else if(this.activePlayer == 2) return this.ovalShape3;
            else return this.ovalShape4;
        }

        public Microsoft.VisualBasic.PowerPacks.OvalShape getPlayerShape(int p)
        {
            if (p == 0) return this.ovalShape1;
            else if (p == 1) return this.ovalShape2;
            else if (p == 2) return this.ovalShape3;
            else return this.ovalShape4;
        }

        public List<int> roll()
        {
            List<int> dice = new List<int>();
            Random die = new Random();
            dice.Add(die.Next(5) + 1);
            dice.Add(die.Next(5) + 1);
            this.diceRoll = dice;
            return dice;
        }

        public int movePlayer(bool setDice = false)
        {
            System.Diagnostics.Debug.Write(this.language);
            System.Diagnostics.Debug.Write(this.CommunityChestDeck[0].getName());
            if (!setDice) { this.roll(); }
            List<int> die = this.diceRoll;

            if (die[0] == die[1])
            {
                this.getPlayer().doubleCounter++;

            }
            else
            {
                this.getPlayer().doubleCounter = 0;
            }

            if (this.getPlayer().inJail() && this.getPlayer().doubleCounter == 0)
            {
                this.getPlayer().inJailCounter++;
                this.TurnEnds.Enabled = true;
                this.rollDie.Enabled = false;
                this.payFine.Enabled = true;
                ((Jail)this.cells[10]).effect(this.getPlayer());
                this.getPlayer().goToJail();
                return 10;
            }
            else
            {
                if (this.getPlayer().doubleCounter == 3)
                {
                    System.Diagnostics.Debug.Write("3 Doubles -> Jail");
                    this.getPlayer().move(-this.getPlayer().getLocation() + 10);
                    this.getPlayer().goToJail();
                    return 10;
                }
                this.getPlayer().goToJail(false);
                this.getPlayer().inJailCounter = 0;
                this.getPlayer().move(die[0] + die[1]);
                this.updatePlayerPosition();
                int newPosition = this.getPlayer().getLocation();
                this.cellEffect(newPosition);
                this.TurnEnds.Enabled = true;
                this.rollDie.Enabled = false;
                System.Diagnostics.Debug.Write("Die 1: " + die[0] + " Die 2: " + die[1] + "\nNew Location: " + newPosition + "\n");
                return newPosition;
            }
        }



        public void cellEffect(int position)
        {
            updatePlayerLabels();

            Cell cell = this.cells[position];
            if (cell is Property)
            {
                Property p = (Property)cell;
                if (p.getOwner() == banker)
                {
                    this.buyDisplay();
                }
            }
            else if (cell is Special)
            {
                if (cell is IncomeTax)
                {
                    new IncomeTaxWindow(this.getPlayer(), (IncomeTax)cell, this).initialize();
                    this.updatePlayerLabels();
                }
                else
                    ((Special)cell).effect(this.getPlayer());
            }
            else if (cell is CardCell)
            {
                CardCell cc = (CardCell)cell;
                List<Player> ps = new List<Player>();
                ps.AddRange(this.players);
                ps.Remove(this.getPlayer());
                Card c = null;
                if (cc.getName() == "Community Chest")
                {
                    c = CommunityChestDeck[0];
                    CommunityChestDeck.Remove(c);
                    CommunityChestDeck.Add(c);
                    MessageBox.Show(c.getName(), "Community Chest Card!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    c = ChanceDeck[0];
                    ChanceDeck.Remove(c);
                    ChanceDeck.Add(c);
                    MessageBox.Show(c.getName(), "Chance Card!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cc.effect(this.getPlayer(), c, ps, this);
            }
            this.updatePlayerLabels();
        }

        public void determinePlayerLabels()
        {
            if (this.numberOfPlayers < 4)
            {
                this.player4Label.Hide();
            }
            if (this.numberOfPlayers < 3)
            {
                this.player3Label.Hide();
            }
        }

        public void updatePlayerLabels()
        {
            try
            {
                this.player1Label.Text = this.players[0].getName() + ": $" + this.players[0].getMoney();
                this.player2Label.Text = this.players[1].getName() + ": $" + this.players[1].getMoney();
                this.player3Label.Text = this.players[2].getName() + ": $" + this.players[2].getMoney();
                this.player4Label.Text = this.players[3].getName() + ": $" + this.players[3].getMoney();
            }
            catch
            {

            }
            switch (this.activePlayer)
            {
                case 0:
                    this.player1Label.ForeColor = ovalShape1.FillColor;
                    this.player2Label.ForeColor = Color.Black;
                    this.player3Label.ForeColor = Color.Black;
                    this.player4Label.ForeColor = Color.Black;
                    break;

                case 1:
                    this.player1Label.ForeColor = Color.Black;
                    this.player2Label.ForeColor = ovalShape2.FillColor;
                    this.player3Label.ForeColor = Color.Black;
                    this.player4Label.ForeColor = Color.Black;
                    break;

                case 2:
                    this.player1Label.ForeColor = Color.Black;
                    this.player2Label.ForeColor = Color.Black;
                    this.player3Label.ForeColor = ovalShape3.FillColor;
                    this.player4Label.ForeColor = Color.Black;
                    break;

                default:
                    this.player1Label.ForeColor = Color.Black;
                    this.player2Label.ForeColor = Color.Black;
                    this.player3Label.ForeColor = Color.Black;
                    this.player4Label.ForeColor = ovalShape4.FillColor;
                    break;
            }

        }

        private void updateDieLabels()
        {
            this.die1text.Text = this.diceRoll[0] + "";
            this.die2text.Text = this.diceRoll[1] + "";
        }


        public void buyDisplay()
        {
            
            this.BuyProper.Enabled = true;
            this.TurnEnds.Enabled = true;
            this.rollDie.Enabled = false;        

        }

        public void buyProperty()
        {
            propertyToAdd = (Property)this.cells[this.getPlayer().getLocation()];
            if (propertyToAdd.getOwner().getName() == "banker" && this.getPlayer().getMoney() >= propertyToAdd.getBuy())
            {
         
                propertyToAdd.changeOwner(this.getPlayer());
                this.getPlayer().addMoney(-propertyToAdd.getBuy());
                
            }
            else if (this.getPlayer().getMoney() >= propertyToAdd.getHouseCost()&&this.getPlayer().hasDeed(propertyToAdd))
            {
                int newHouseNum = propertyToAdd.addHouse();
                if (newHouseNum > 0)
                {
                    this.getPlayer().addMoney(-propertyToAdd.getHouseCost());
                    //this.houseNumbers[this.getPlayer().getLocation()].Text = newHouseNum.ToString();
                }
            }
            else if (this.getPlayer().getMoney() >= propertyToAdd.getHouseCost())
            {
                System.Diagnostics.Debug.Write(this.getPlayer().getName() + " doesnt have enough money\n");
            }
            if (this.getPlayer().deeds.Count > 0)
            {
                System.Diagnostics.Debug.Write(this.getPlayer().getName() + " has " + this.getPlayer().deeds[this.getPlayer().deeds.Count - 1].getName() + "\n");
            }
            System.Diagnostics.Debug.Write(this.getPlayer().getName() + " has " + this.getPlayer().getMoney() + "dollars\n");
            System.Diagnostics.Debug.Write(propertyToAdd +" has " + propertyToAdd.getNumHouses() + "houses\n");
        }

        public void endTurn()
        {

            this.rent();
            int player = this.activePlayer;
            this.activePlayer++;
            this.activePlayer = this.activePlayer % (this.players.Count);
            this.rollDie.Enabled = true;
            this.BuyProper.Enabled = false;
            this.TurnEnds.Enabled = false;
            this.payFine.Enabled = false;
            if (this.getPlayer().getMoney() <= 0)
            {
                removePlayer(player);
            }
            if (this.players.Count == 1) { this.players[0].win(); }
            updatePlayerLabels();
            if (this.getPlayer().inJail() && this.getPlayer().getOutOfFailFreeCard())
            {
                new GetOutOfJailDialog(this.getPlayer()).Show();
            }
        }

        public void removePlayer(int i) {
            System.Diagnostics.Debug.Write("player lost");
            this.players.Remove(this.players[i]);
            if (i == 0) { this.player1Label.Dispose(); this.ovalShape1.Dispose(); }
            if (i == 1) { this.player2Label.Dispose(); this.ovalShape2.Dispose(); }
            if (i == 2) { this.player3Label.Dispose(); this.ovalShape3.Dispose(); }
            if (i == 3) { this.player4Label.Dispose(); this.ovalShape4.Dispose(); }
        }

        public void rent()
        {
            var cell = this.getCellAt(this.getPlayer().getLocation());
            if (cell.GetType() == typeof(Property) || cell.GetType() == typeof(Railroad))
            {
                Property prop = (Property) cell;
               // Console.WriteLine(prop.getName());
                if (!(banker.hasDeed(prop) || this.getPlayer().hasDeed(prop)))
                {
                    Player owner = prop.getOwner();
                  //  Console.WriteLine(owner.getName());
                    if (owner.Equals(banker)) { return; }
                    int rent = prop.getRent();
                  //  Console.WriteLine(rent);
                    owner.addMoney(rent);
                    this.getPlayer().addMoney(-rent);
                    return;
                }
            } else if(cell.GetType() == typeof(Utility)) {
                Utility util = (Utility) cell;
                int rent = (this.diceRoll[0] + this.diceRoll[1]) * util.getRent();
                util.getOwner().addMoney(rent);
                this.getPlayer().addMoney(-rent);
                return;
            }
        }

        public void setDiceRoll(List<int> roll)
        {
            this.diceRoll = roll;
        }

        public Player getBanker() { return banker; }


        public void updatePlayerPosition()
        {
                if (this.getPlayer().getLocation() == 30 || this.getPlayer().doubleCounter == 3)
                {
                    Monopoly.CellGoToJail.goToJail(this.getPlayer());
                    this.getPlayer().doubleCounter = 0;
                }
                this.getPlayerShape().Location = this.locations[this.getPlayer().getLocation()];
        }

        public void trade(Player from, Player to, List<Property> propertySelected, int price)
        {
            if (price < 0 || price > from.getMoney()) { return; }
            for (int j = 0; j < propertySelected.Count; j++)
            {
                if (!from.getDeeds().Contains(propertySelected[j])) { return; }
            }
            for (int k = 0; k < propertySelected.Count; k++)
            {
                propertySelected[k].changeOwner(to);
                from.deeds.Remove(propertySelected[k]);
            }
            to.addMoney(price);
            from.addMoney(-price);
        }

        public String mortgageProperties(Player currentPlayer, List<Property> selected)
        {
            int totalMortgage = 0;
            Property problem = new Property("ERROR", -1, new Player("ERROR"), -1, -1, null, -1);
            foreach (Property p in selected)
            {
                if (p.getNumHouses() != 0)
                {
                    return "ERROR: You have too many houses on " + p.getName() + ", sell them off before mortgaging";
                } if (p.isMortgaged())
                {
                    return "ERROR: You have already mortgaged " + p.getName();
                }
                totalMortgage += p.getMortgage();
            }

            if (selected.Count == 0)
                return "ERROR: You did not select any properties";
            else
            {
                currentPlayer.addMoney(totalMortgage);
                for (int i = 0; i < selected.Count; i++)
                {
                    currentPlayer.deeds[i].mortgageProperty();
                }
                return "SUCCESS: You now have $" + currentPlayer.getMoney();
            }
        }

        public void controlledRoll()
        {
            controllBoard.Width = 310;
            controllBoard.Height = 110;
            this.controllBoard.StartPosition = FormStartPosition.CenterScreen;
            
            numberToRoll.Text = "";
            numberToRoll.Location = new System.Drawing.Point(5, 10);
            numberToRoll.Width = 200;
            numberToRoll.Select(0, numberToRoll.Text.Length);

            Button confirm = new Button();
            confirm.Text = Resource1.confirm;
            confirm.Location = new System.Drawing.Point(5, 40);
            confirm.Click += new System.EventHandler(controlled_confirm_Click_1);
            controllBoard.Controls.Add(confirm);
            controllBoard.Controls.Add(numberToRoll);
            controllBoard.ShowDialog();
        }

        public void controlledMove()
        {
           int steps = Convert.ToInt32(this.numberToRoll.Text);
           this.getPlayer().move(steps);
           this.updatePlayerPosition();
           int newPosition = this.getPlayer().getLocation();
           this.cellEffect(newPosition);
           this.TurnEnds.Enabled = true;
           this.rollDie.Enabled = false;
           
        }

        public void tradeProperties()
        {
           
            propertyList = new Form();
            propertyList.Width = 300;
            propertyList.Height = 600;
            propertyList.Text = Resource1.selectProperty;
            List<Property> initialList = this.players[this.activePlayer].deeds;
            properties = new CheckedListBox();
            properties.Width = 300;
            properties.Height = 300;
            for (int i = 0; i < initialList.Count; i++)
            { 
                properties.Items.Add(initialList[i].getName());
            }
            propertyList.Controls.Add(properties);
            tradePrice.Text = Resource1.tradePrice;
            tradePrice.Location = new System.Drawing.Point(5,305);
            tradePrice.Size = new System.Drawing.Size(290, 350);
            Button confirm = new Button();
            confirm.Text = Resource1.confirm;
            confirm.Location = new System.Drawing.Point(5, 450);
            
            confirm.Click += new System.EventHandler(confirm_Click_1);
            Button cancel = new Button();
            cancel.Text = Resource1.cancel;
            cancel.Location = new System.Drawing.Point(150, 450);
            cancel.Click += new System.EventHandler(cancel_Click_1);
            Label player1Money = new Label();
            Label player2Money = new Label();
            player1Money.Text = Resource1.player1Trade + this.players[0].getMoney();
            player2Money.Text = "Player2: " + this.players[1].getMoney();
            player1Money.Location = new System.Drawing.Point(50, 370);
            player2Money.Location = new System.Drawing.Point(50, 400);

            propertyList.Controls.Add(tradePrice);
            propertyList.Controls.Add(confirm);
            propertyList.Controls.Add(cancel);
            propertyList.Controls.Add(player1Money);
            propertyList.Controls.Add(player2Money);
            propertyList.ShowDialog();

        }

        public String buyHouse(Property p, Player player)

        {

            String message = "";
            switch (p.addHouse())
            {
                case -1:
                    message = Resource1.message1;
                    break;
                case -2:
                    message = p.getName() + Resource1.message2;
                    break;
                case -3:
                    message = Resource1.message3_1 + p.getName() + Resource1.message3_2;
                    break;
                case -4:
                    message = Resource1.message4;
                    break;
                default:
                    player.addMoney(-p.getHouseCost());
                    message = Resource1.message5 + p.getName();
                    updateHouseNumber(p);
                    break;
            }
            this.updatePlayerLabels();
            return message;
        }

        public void updateHouseNumber(Property p)

        {
           
            int pos = p.getPos();
            if (p.getNumHouses() != 0 && p.getNumHouses() < 5)
            {

                PictureBox houseImg = new PictureBox();
                houseImg.BackColor = System.Drawing.Color.Transparent;
                houseImg.Image = global::Monopoly.Properties.Resources.images;
                houseImg.Name = "pictureBox1";
                houseImg.Size = new System.Drawing.Size(20, 18);
                houseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                houseImg.TabIndex = 35;
                houseImg.TabStop = false;
                if (pos < 10)
                {
                    houseImg.Location = new System.Drawing.Point(this.locations[pos].X + 15 + 20 * p.getNumHouses(), this.locations[pos].Y);
                }
                if (pos < 30 && pos > 20)
                {
                    houseImg.Location = new System.Drawing.Point(this.locations[pos].X - 15 - 20 * p.getNumHouses(), this.locations[pos].Y);
                }
                if (pos < 20 && pos > 10)
                {
                    houseImg.Location = new System.Drawing.Point(this.locations[pos].X - 20 + 15, this.locations[pos].Y + 30 + 18 * p.getNumHouses());
                }
                if (pos > 30)
                    houseImg.Location = new System.Drawing.Point(this.locations[pos].X - 20 + 15, this.locations[pos].Y - 100 + 18 * p.getNumHouses());
                this.Controls.Add(houseImg);
            }
            else if (p.getNumHouses() == 5)
            {
                PictureBox houseImg = new PictureBox();
                houseImg.BackColor = System.Drawing.Color.Transparent;
                houseImg.Image = global::Monopoly.Properties.Resources.Kuvvat_hotel;

                houseImg.Name = "pictureBox1";

                houseImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                houseImg.TabIndex = 35;
                houseImg.TabStop = false;
                houseImg.BringToFront();
                if (pos < 10 || (pos < 30 && pos > 20))
                {
                    houseImg.Size = new System.Drawing.Size(90, 70);
                    if (pos < 10)
                        houseImg.Location = new System.Drawing.Point(this.locations[pos].X + 33, this.locations[pos].Y - 28);
                    else
                    {
                        houseImg.Location = new System.Drawing.Point(this.locations[pos].X - 100, this.locations[pos].Y - 20);
                    }
                }
                else
                {

                    houseImg.Size = new System.Drawing.Size(70, 90);
                    if (pos < 20 && pos > 10)
                        houseImg.Location = new System.Drawing.Point(this.locations[pos].X - 20, this.locations[pos].Y + 40);
                    else
                        houseImg.Location = new System.Drawing.Point(this.locations[pos].X - 20, this.locations[pos].Y - 100);
                }

                this.Controls.Add(houseImg);
                houseImg.BringToFront();
            }
        }

        public void payJailFine()
        {
            this.getPlayer().payJailFine();
            System.Diagnostics.Debug.Write("boardfine\n");
        }

        public void manageProperties()
        {
            manageList = new Form();
            manageList.Width = 300;
            manageList.Height = 400;
            manageList.Text = Resource1.selectProperty;
            List<Property> initialList = this.players[this.activePlayer].deeds;
            properties = new CheckedListBox();
            properties.Width = 300;
            properties.Height = 300;
            for (int i = 0; i < initialList.Count; i++)
            {
                properties.Items.Add(initialList[i].getName());
            }
            manageList.Controls.Add(properties);


            Button morgage = new Button();
            morgage.Text = Resource1.morgage;
            morgage.Location = new System.Drawing.Point(5, 300);
            morgage.Click += new System.EventHandler(manageConfirm_Click_Morgage);

            Button buyhouse = new Button();
            buyhouse.Text = Resource1.buyHouse;
            buyhouse.Location = new System.Drawing.Point(5, 330);
            buyhouse.Click += new System.EventHandler(manageConfirm_Click_BuyHouse);

            Button cancel = new Button();
            cancel.Text = Resource1.cancel;
            cancel.Location = new System.Drawing.Point(200, 300);
            cancel.Click += new System.EventHandler(manageCancel_Click_1);

            Button select = new Button();
            select.Text = Resource1.selectAll;
            select.Location = new System.Drawing.Point(200, 300);
            select.Click += new System.EventHandler(manageSelectAll);


            Button deselect = new Button();
            deselect.Text = Resource1.deselectAll;
            deselect.Location = new System.Drawing.Point(200, 270);
            deselect.Click += new System.EventHandler(manageDeselectAll);

            manageList.Controls.Add(morgage);
            manageList.Controls.Add(buyhouse);
            manageList.Controls.Add(cancel);
            manageList.Controls.Add(select);
            manageList.Controls.Add(deselect);
            manageList.ShowDialog();

        }




        public System.Windows.Forms.Button getRollDie()
        {
            return this.rollDie;
        }

        public System.Windows.Forms.Button getBuy()
        {
            return this.BuyProper;
        }

        public System.Windows.Forms.Button getEndTurn()
        {
            return this.BuyProper;
        }

        public int getActivePlayer()
        {
            return this.activePlayer;
        }

        public Cell getCellAt(int location)
        {
            return this.cells[location];
        }
        
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.die2square = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.die1box = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShape2 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShape3 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShape4 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.marvinGardens = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.ventnorAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.illinoisAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.indianaAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.newYorkAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.tennesseeAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.virginiaAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.statesAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.orientalAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.vermontAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.balticAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.waterWorks = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.atlanticAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.boRailroad = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chance2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape24 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chance1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.readingRailroad = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.incomeTax = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.communityChest1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.mediteraneanAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.connecticutAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.goYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.gotoJailYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.boardwalk = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shortLine = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chance3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.parkPlace = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.luxuryTax = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.pacificAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.northCarolinaAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.communityChest3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectanglepennsylvaniaAvenueShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape15 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.communityChest2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.electricCompany = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.PennsylvaniaRailroad = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.stCharlesPlace = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.freeParkingYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.jailYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.goLabel = new System.Windows.Forms.Label();
            this.parkingLabel = new System.Windows.Forms.Label();
            this.chestLabel1 = new System.Windows.Forms.Label();
            this.chestLabel2 = new System.Windows.Forms.Label();
            this.chestLabel3 = new System.Windows.Forms.Label();
            this.waterWorksLabel = new System.Windows.Forms.Label();
            this.chanceLabel1 = new System.Windows.Forms.Label();
            this.railReadLabel = new System.Windows.Forms.Label();
            this.taxLabel1 = new System.Windows.Forms.Label();
            this.jailLabel = new System.Windows.Forms.Label();
            this.chanceLabel2 = new System.Windows.Forms.Label();
            this.eCompanyLabel = new System.Windows.Forms.Label();
            this.railPennLabel = new System.Windows.Forms.Label();
            this.railBOLabel = new System.Windows.Forms.Label();
            this.goToJailLabel = new System.Windows.Forms.Label();
            this.railShortLabel = new System.Windows.Forms.Label();
            this.chanceLabel3 = new System.Windows.Forms.Label();
            this.taxLabel2 = new System.Windows.Forms.Label();
            this.rollDie = new System.Windows.Forms.Button();
            this.payText = new System.Windows.Forms.TextBox();
            this.BuyProper = new System.Windows.Forms.Button();
            this.TurnEnds = new System.Windows.Forms.Button();
            this.Trade = new System.Windows.Forms.Button();
            this.MagProper = new System.Windows.Forms.Button();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.payFine = new System.Windows.Forms.Button();
            this.die1text = new System.Windows.Forms.Label();
            this.die2text = new System.Windows.Forms.Label();
            this.Controlled = new System.Windows.Forms.Button();
            this.player3Label = new System.Windows.Forms.Label();
            this.player4Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.die2square,
            this.die1box,
            this.ovalShape1,
            this.ovalShape2,
            this.ovalShape3,
            this.ovalShape4,
            this.marvinGardens,
            this.ventnorAvenue,
            this.illinoisAvenue,
            this.indianaAvenue,
            this.newYorkAvenue,
            this.tennesseeAvenue,
            this.virginiaAvenue,
            this.statesAvenue,
            this.orientalAvenue,
            this.vermontAvenue,
            this.balticAvenue,
            this.waterWorks,
            this.atlanticAvenue,
            this.boRailroad,
            this.chance2,
            this.rectangleShape24,
            this.chance1,
            this.readingRailroad,
            this.incomeTax,
            this.communityChest1,
            this.mediteraneanAvenue,
            this.connecticutAvenue,
            this.goYOLO,
            this.gotoJailYOLO,
            this.boardwalk,
            this.shortLine,
            this.chance3,
            this.parkPlace,
            this.luxuryTax,
            this.pacificAvenue,
            this.northCarolinaAvenue,
            this.communityChest3,
            this.rectanglepennsylvaniaAvenueShape2,
            this.rectangleShape15,
            this.communityChest2,
            this.electricCompany,
            this.PennsylvaniaRailroad,
            this.stCharlesPlace,
            this.freeParkingYOLO,
            this.jailYOLO});
            this.shapeContainer1.Size = new System.Drawing.Size(987, 944);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // die2square
            // 
            this.die2square.BorderWidth = 3;
            this.die2square.Location = new System.Drawing.Point(524, 603);
            this.die2square.Name = "die2square";
            this.die2square.Size = new System.Drawing.Size(75, 75);
            // 
            // die1box
            // 
            this.die1box.BorderWidth = 3;
            this.die1box.Location = new System.Drawing.Point(379, 603);
            this.die1box.Name = "die1box";
            this.die1box.Size = new System.Drawing.Size(75, 75);
            // 
            // ovalShape1
            // 
            this.ovalShape1.AccessibleDescription = "Player1";
            this.ovalShape1.AccessibleName = "Player1";
            this.ovalShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalShape1.FillColor = System.Drawing.Color.DarkViolet;
            this.ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent60;
            this.ovalShape1.Location = new System.Drawing.Point(30, 840);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(25, 25);
            // 
            // ovalShape2
            // 
            this.ovalShape2.AccessibleDescription = "Player2";
            this.ovalShape2.AccessibleName = "Player2";
            this.ovalShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShape2.FillColor = System.Drawing.Color.Blue;
            this.ovalShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent90;
            this.ovalShape2.Location = new System.Drawing.Point(30, 865);
            this.ovalShape2.Name = "ovalShape2";
            this.ovalShape2.Size = new System.Drawing.Size(25, 24);
            // 
            // ovalShape3
            // 
            this.ovalShape3.AccessibleDescription = "Player3";
            this.ovalShape3.AccessibleName = "Player3";
            this.ovalShape3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShape3.FillColor = System.Drawing.Color.Red;
            this.ovalShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent90;
            this.ovalShape3.Location = new System.Drawing.Point(60, 840);
            this.ovalShape3.Name = "ovalShape3";
            this.ovalShape3.Size = new System.Drawing.Size(25, 24);
            // 
            // ovalShape4
            // 
            this.ovalShape4.AccessibleDescription = "Player4";
            this.ovalShape4.AccessibleName = "Player4";
            this.ovalShape4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalShape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShape4.FillColor = System.Drawing.Color.Green;
            this.ovalShape4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent90;
            this.ovalShape4.Location = new System.Drawing.Point(60, 865);
            this.ovalShape4.Name = "ovalShape4";
            this.ovalShape4.Size = new System.Drawing.Size(25, 24);
            // 
            // marvinGardens
            // 
            this.marvinGardens.BackColor = System.Drawing.Color.Yellow;
            this.marvinGardens.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.marvinGardens.Location = new System.Drawing.Point(810, 740);
            this.marvinGardens.Name = "";
            this.marvinGardens.Size = new System.Drawing.Size(90, 70);
            // 
            // ventnorAvenue
            // 
            this.ventnorAvenue.BackColor = System.Drawing.Color.Yellow;
            this.ventnorAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ventnorAvenue.Location = new System.Drawing.Point(810, 600);
            this.ventnorAvenue.Name = "";
            this.ventnorAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // illinoisAvenue
            // 
            this.illinoisAvenue.BackColor = System.Drawing.Color.Red;
            this.illinoisAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.illinoisAvenue.Location = new System.Drawing.Point(810, 390);
            this.illinoisAvenue.Name = "";
            this.illinoisAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // indianaAvenue
            // 
            this.indianaAvenue.BackColor = System.Drawing.Color.Red;
            this.indianaAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.indianaAvenue.Location = new System.Drawing.Point(810, 320);
            this.indianaAvenue.Name = "";
            this.indianaAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // newYorkAvenue
            // 
            this.newYorkAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.newYorkAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.newYorkAvenue.Location = new System.Drawing.Point(740, 90);
            this.newYorkAvenue.Name = "";
            this.newYorkAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // tennesseeAvenue
            // 
            this.tennesseeAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tennesseeAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.tennesseeAvenue.Location = new System.Drawing.Point(670, 90);
            this.tennesseeAvenue.Name = "";
            this.tennesseeAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // virginiaAvenue
            // 
            this.virginiaAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.virginiaAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.virginiaAvenue.Location = new System.Drawing.Point(391, 90);
            this.virginiaAvenue.Name = "";
            this.virginiaAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // statesAvenue
            // 
            this.statesAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.statesAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.statesAvenue.Location = new System.Drawing.Point(321, 90);
            this.statesAvenue.Name = "";
            this.statesAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // orientalAvenue
            // 
            this.orientalAvenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.orientalAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.orientalAvenue.Location = new System.Drawing.Point(90, 390);
            this.orientalAvenue.Name = "orientalAvenue";
            this.orientalAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // vermontAvenue
            // 
            this.vermontAvenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.vermontAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.vermontAvenue.Location = new System.Drawing.Point(90, 250);
            this.vermontAvenue.Name = "vermontAvenue";
            this.vermontAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // balticAvenue
            // 
            this.balticAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.balticAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.balticAvenue.Location = new System.Drawing.Point(90, 600);
            this.balticAvenue.Name = "balticAvenue";
            this.balticAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // waterWorks
            // 
            this.waterWorks.Location = new System.Drawing.Point(810, 670);
            this.waterWorks.Name = "waterWorks";
            this.waterWorks.Size = new System.Drawing.Size(90, 70);
            // 
            // atlanticAvenue
            // 
            this.atlanticAvenue.BackColor = System.Drawing.Color.Yellow;
            this.atlanticAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.atlanticAvenue.Location = new System.Drawing.Point(810, 530);
            this.atlanticAvenue.Name = "atlanticAvenue";
            this.atlanticAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // boRailroad
            // 
            this.boRailroad.Location = new System.Drawing.Point(810, 460);
            this.boRailroad.Name = "boRailroad";
            this.boRailroad.Size = new System.Drawing.Size(90, 70);
            // 
            // chance2
            // 
            this.chance2.Location = new System.Drawing.Point(810, 250);
            this.chance2.Name = "chance2";
            this.chance2.Size = new System.Drawing.Size(90, 70);
            // 
            // rectangleShape24
            // 
            this.rectangleShape24.BackColor = System.Drawing.Color.Red;
            this.rectangleShape24.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape24.Location = new System.Drawing.Point(810, 180);
            this.rectangleShape24.Name = "rectangleShape24";
            this.rectangleShape24.Size = new System.Drawing.Size(90, 70);
            // 
            // chance1
            // 
            this.chance1.Location = new System.Drawing.Point(90, 320);
            this.chance1.Name = "chance1";
            this.chance1.Size = new System.Drawing.Size(90, 70);
            // 
            // readingRailroad
            // 
            this.readingRailroad.Location = new System.Drawing.Point(90, 460);
            this.readingRailroad.Name = "readingRailroad";
            this.readingRailroad.Size = new System.Drawing.Size(90, 70);
            // 
            // incomeTax
            // 
            this.incomeTax.Location = new System.Drawing.Point(90, 530);
            this.incomeTax.Name = "incomeTax";
            this.incomeTax.Size = new System.Drawing.Size(90, 70);
            // 
            // communityChest1
            // 
            this.communityChest1.Location = new System.Drawing.Point(90, 670);
            this.communityChest1.Name = "communityChest1";
            this.communityChest1.Size = new System.Drawing.Size(90, 70);
            this.communityChest1.Tag = "";
            // 
            // mediteraneanAvenue
            // 
            this.mediteraneanAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mediteraneanAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.mediteraneanAvenue.Location = new System.Drawing.Point(90, 740);
            this.mediteraneanAvenue.Name = "mediteraneanAvenue";
            this.mediteraneanAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // connecticutAvenue
            // 
            this.connecticutAvenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.connecticutAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.connecticutAvenue.Location = new System.Drawing.Point(90, 180);
            this.connecticutAvenue.Name = "connecticutAvenue";
            this.connecticutAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // goYOLO
            // 
            this.goYOLO.Location = new System.Drawing.Point(90, 810);
            this.goYOLO.Name = "goYOLO";
            this.goYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // gotoJailYOLO
            // 
            this.gotoJailYOLO.Location = new System.Drawing.Point(810, 810);
            this.gotoJailYOLO.Name = "gotoJailYOLO";
            this.gotoJailYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // boardwalk
            // 
            this.boardwalk.BackColor = System.Drawing.Color.Blue;
            this.boardwalk.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.boardwalk.Location = new System.Drawing.Point(180, 810);
            this.boardwalk.Name = "boardwalk";
            this.boardwalk.Size = new System.Drawing.Size(70, 90);
            // 
            // shortLine
            // 
            this.shortLine.Location = new System.Drawing.Point(460, 810);
            this.shortLine.Name = "shortLine";
            this.shortLine.Size = new System.Drawing.Size(70, 90);
            // 
            // chance3
            // 
            this.chance3.Location = new System.Drawing.Point(390, 810);
            this.chance3.Name = "chance3";
            this.chance3.Size = new System.Drawing.Size(70, 90);
            // 
            // parkPlace
            // 
            this.parkPlace.BackColor = System.Drawing.Color.Blue;
            this.parkPlace.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.parkPlace.Location = new System.Drawing.Point(320, 810);
            this.parkPlace.Name = "parkPlace";
            this.parkPlace.Size = new System.Drawing.Size(70, 90);
            // 
            // luxuryTax
            // 
            this.luxuryTax.Location = new System.Drawing.Point(250, 810);
            this.luxuryTax.Name = "luxuryTax";
            this.luxuryTax.Size = new System.Drawing.Size(70, 90);
            // 
            // pacificAvenue
            // 
            this.pacificAvenue.BackColor = System.Drawing.Color.Green;
            this.pacificAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.pacificAvenue.Location = new System.Drawing.Point(740, 810);
            this.pacificAvenue.Name = "pacificAvenue";
            this.pacificAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // northCarolinaAvenue
            // 
            this.northCarolinaAvenue.BackColor = System.Drawing.Color.Green;
            this.northCarolinaAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.northCarolinaAvenue.Location = new System.Drawing.Point(670, 810);
            this.northCarolinaAvenue.Name = "northCarolinaAvenue";
            this.northCarolinaAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // communityChest3
            // 
            this.communityChest3.Location = new System.Drawing.Point(600, 810);
            this.communityChest3.Name = "communityChest3";
            this.communityChest3.Size = new System.Drawing.Size(70, 90);
            // 
            // rectanglepennsylvaniaAvenueShape2
            // 
            this.rectanglepennsylvaniaAvenueShape2.BackColor = System.Drawing.Color.Green;
            this.rectanglepennsylvaniaAvenueShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectanglepennsylvaniaAvenueShape2.Location = new System.Drawing.Point(530, 810);
            this.rectanglepennsylvaniaAvenueShape2.Name = "rectanglepennsylvaniaAvenueShape2";
            this.rectanglepennsylvaniaAvenueShape2.Size = new System.Drawing.Size(70, 90);
            // 
            // rectangleShape15
            // 
            this.rectangleShape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rectangleShape15.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape15.Location = new System.Drawing.Point(530, 90);
            this.rectangleShape15.Name = "rectangleShape15";
            this.rectangleShape15.Size = new System.Drawing.Size(70, 90);
            // 
            // communityChest2
            // 
            this.communityChest2.Location = new System.Drawing.Point(600, 90);
            this.communityChest2.Name = "communityChest2";
            this.communityChest2.Size = new System.Drawing.Size(70, 90);
            // 
            // electricCompany
            // 
            this.electricCompany.Location = new System.Drawing.Point(250, 90);
            this.electricCompany.Name = "electricCompany";
            this.electricCompany.Size = new System.Drawing.Size(70, 90);
            // 
            // PennsylvaniaRailroad
            // 
            this.PennsylvaniaRailroad.Location = new System.Drawing.Point(460, 90);
            this.PennsylvaniaRailroad.Name = "PennsylvaniaRailroad";
            this.PennsylvaniaRailroad.Size = new System.Drawing.Size(70, 90);
            // 
            // stCharlesPlace
            // 
            this.stCharlesPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stCharlesPlace.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.stCharlesPlace.Location = new System.Drawing.Point(180, 90);
            this.stCharlesPlace.Name = "stCharlesPlace";
            this.stCharlesPlace.Size = new System.Drawing.Size(70, 90);
            // 
            // freeParkingYOLO
            // 
            this.freeParkingYOLO.Location = new System.Drawing.Point(810, 90);
            this.freeParkingYOLO.Name = "freeParkingYOLO";
            this.freeParkingYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // jailYOLO
            // 
            this.jailYOLO.Location = new System.Drawing.Point(90, 90);
            this.jailYOLO.Name = "jailYOLO";
            this.jailYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // goLabel
            // 
            this.goLabel.AutoSize = true;
            this.goLabel.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.goLabel.Location = new System.Drawing.Point(105, 839);
            this.goLabel.Name = "goLabel";
            this.goLabel.Size = new System.Drawing.Size(0, 38);
            this.goLabel.TabIndex = 1;
            // 
            // parkingLabel
            // 
            this.parkingLabel.AutoSize = true;
            this.parkingLabel.Font = new System.Drawing.Font("Comic Sans MS", 16F);
            this.parkingLabel.Location = new System.Drawing.Point(812, 107);
            this.parkingLabel.Name = "parkingLabel";
            this.parkingLabel.Size = new System.Drawing.Size(0, 30);
            this.parkingLabel.TabIndex = 2;
            this.parkingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chestLabel1
            // 
            this.chestLabel1.AutoSize = true;
            this.chestLabel1.BackColor = System.Drawing.Color.Transparent;
            this.chestLabel1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chestLabel1.Location = new System.Drawing.Point(96, 689);
            this.chestLabel1.Name = "chestLabel1";
            this.chestLabel1.Size = new System.Drawing.Size(0, 19);
            this.chestLabel1.TabIndex = 3;
            // 
            // chestLabel2
            // 
            this.chestLabel2.AutoSize = true;
            this.chestLabel2.BackColor = System.Drawing.Color.Transparent;
            this.chestLabel2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chestLabel2.Location = new System.Drawing.Point(596, 119);
            this.chestLabel2.Name = "chestLabel2";
            this.chestLabel2.Size = new System.Drawing.Size(0, 19);
            this.chestLabel2.TabIndex = 4;
            this.chestLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chestLabel3
            // 
            this.chestLabel3.AutoSize = true;
            this.chestLabel3.BackColor = System.Drawing.Color.Transparent;
            this.chestLabel3.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chestLabel3.Location = new System.Drawing.Point(596, 839);
            this.chestLabel3.Name = "chestLabel3";
            this.chestLabel3.Size = new System.Drawing.Size(0, 19);
            this.chestLabel3.TabIndex = 5;
            this.chestLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // waterWorksLabel
            // 
            this.waterWorksLabel.AutoSize = true;
            this.waterWorksLabel.BackColor = System.Drawing.Color.Transparent;
            this.waterWorksLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.waterWorksLabel.Location = new System.Drawing.Point(827, 689);
            this.waterWorksLabel.Name = "waterWorksLabel";
            this.waterWorksLabel.Size = new System.Drawing.Size(0, 19);
            this.waterWorksLabel.TabIndex = 6;
            this.waterWorksLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chanceLabel1
            // 
            this.chanceLabel1.AutoSize = true;
            this.chanceLabel1.BackColor = System.Drawing.Color.Transparent;
            this.chanceLabel1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chanceLabel1.Location = new System.Drawing.Point(108, 354);
            this.chanceLabel1.Name = "chanceLabel1";
            this.chanceLabel1.Size = new System.Drawing.Size(0, 19);
            this.chanceLabel1.TabIndex = 7;
            this.chanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railReadLabel
            // 
            this.railReadLabel.AutoSize = true;
            this.railReadLabel.BackColor = System.Drawing.Color.Transparent;
            this.railReadLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railReadLabel.Location = new System.Drawing.Point(106, 480);
            this.railReadLabel.Name = "railReadLabel";
            this.railReadLabel.Size = new System.Drawing.Size(0, 19);
            this.railReadLabel.TabIndex = 8;
            this.railReadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taxLabel1
            // 
            this.taxLabel1.AutoSize = true;
            this.taxLabel1.BackColor = System.Drawing.Color.Transparent;
            this.taxLabel1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.taxLabel1.Location = new System.Drawing.Point(104, 549);
            this.taxLabel1.Name = "taxLabel1";
            this.taxLabel1.Size = new System.Drawing.Size(0, 19);
            this.taxLabel1.TabIndex = 9;
            this.taxLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // jailLabel
            // 
            this.jailLabel.AutoSize = true;
            this.jailLabel.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.jailLabel.Location = new System.Drawing.Point(105, 111);
            this.jailLabel.Name = "jailLabel";
            this.jailLabel.Size = new System.Drawing.Size(0, 38);
            this.jailLabel.TabIndex = 10;
            this.jailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chanceLabel2
            // 
            this.chanceLabel2.AutoSize = true;
            this.chanceLabel2.BackColor = System.Drawing.Color.Transparent;
            this.chanceLabel2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chanceLabel2.Location = new System.Drawing.Point(828, 294);
            this.chanceLabel2.Name = "chanceLabel2";
            this.chanceLabel2.Size = new System.Drawing.Size(0, 19);
            this.chanceLabel2.TabIndex = 11;
            this.chanceLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // eCompanyLabel
            // 
            this.eCompanyLabel.AutoSize = true;
            this.eCompanyLabel.BackColor = System.Drawing.Color.Transparent;
            this.eCompanyLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.eCompanyLabel.Location = new System.Drawing.Point(253, 118);
            this.eCompanyLabel.Name = "eCompanyLabel";
            this.eCompanyLabel.Size = new System.Drawing.Size(0, 19);
            this.eCompanyLabel.TabIndex = 12;
            this.eCompanyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railPennLabel
            // 
            this.railPennLabel.AutoSize = true;
            this.railPennLabel.BackColor = System.Drawing.Color.Transparent;
            this.railPennLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railPennLabel.Location = new System.Drawing.Point(453, 116);
            this.railPennLabel.Name = "railPennLabel";
            this.railPennLabel.Size = new System.Drawing.Size(0, 19);
            this.railPennLabel.TabIndex = 13;
            this.railPennLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railBOLabel
            // 
            this.railBOLabel.AutoSize = true;
            this.railBOLabel.BackColor = System.Drawing.Color.Transparent;
            this.railBOLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railBOLabel.Location = new System.Drawing.Point(826, 480);
            this.railBOLabel.Name = "railBOLabel";
            this.railBOLabel.Size = new System.Drawing.Size(0, 19);
            this.railBOLabel.TabIndex = 14;
            this.railBOLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goToJailLabel
            // 
            this.goToJailLabel.AutoSize = true;
            this.goToJailLabel.BackColor = System.Drawing.Color.Transparent;
            this.goToJailLabel.Font = new System.Drawing.Font("Comic Sans MS", 15F);
            this.goToJailLabel.Location = new System.Drawing.Point(827, 831);
            this.goToJailLabel.Name = "goToJailLabel";
            this.goToJailLabel.Size = new System.Drawing.Size(0, 28);
            this.goToJailLabel.TabIndex = 15;
            this.goToJailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railShortLabel
            // 
            this.railShortLabel.AutoSize = true;
            this.railShortLabel.BackColor = System.Drawing.Color.Transparent;
            this.railShortLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railShortLabel.Location = new System.Drawing.Point(474, 839);
            this.railShortLabel.Name = "railShortLabel";
            this.railShortLabel.Size = new System.Drawing.Size(0, 19);
            this.railShortLabel.TabIndex = 16;
            this.railShortLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chanceLabel3
            // 
            this.chanceLabel3.AutoSize = true;
            this.chanceLabel3.BackColor = System.Drawing.Color.Transparent;
            this.chanceLabel3.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chanceLabel3.Location = new System.Drawing.Point(402, 848);
            this.chanceLabel3.Name = "chanceLabel3";
            this.chanceLabel3.Size = new System.Drawing.Size(0, 19);
            this.chanceLabel3.TabIndex = 17;
            this.chanceLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taxLabel2
            // 
            this.taxLabel2.AutoSize = true;
            this.taxLabel2.BackColor = System.Drawing.Color.Transparent;
            this.taxLabel2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.taxLabel2.Location = new System.Drawing.Point(255, 839);
            this.taxLabel2.Name = "taxLabel2";
            this.taxLabel2.Size = new System.Drawing.Size(0, 19);
            this.taxLabel2.TabIndex = 18;
            this.taxLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rollDie
            // 
            this.rollDie.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollDie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rollDie.Location = new System.Drawing.Point(240, 238);
            this.rollDie.Name = "rollDie";
            this.rollDie.Size = new System.Drawing.Size(220, 76);
            this.rollDie.TabIndex = 19;
            this.rollDie.Text = "Roll";
            this.rollDie.UseVisualStyleBackColor = true;
            this.rollDie.Click += new System.EventHandler(this.rollDie_Click_1);
            // 
            // payText
            // 
            this.payText.Location = new System.Drawing.Point(0, 0);
            this.payText.Name = "payText";
            this.payText.Size = new System.Drawing.Size(100, 20);
            this.payText.TabIndex = 0;
            // 
            // BuyProper
            // 
            this.BuyProper.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyProper.Location = new System.Drawing.Point(530, 238);
            this.BuyProper.Name = "BuyProper";
            this.BuyProper.Size = new System.Drawing.Size(220, 76);
            this.BuyProper.TabIndex = 23;
            this.BuyProper.UseVisualStyleBackColor = true;
            this.BuyProper.Click += new System.EventHandler(this.buy_Click_1);
            // 
            // TurnEnds
            // 
            this.TurnEnds.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnEnds.Location = new System.Drawing.Point(295, 698);
            this.TurnEnds.Name = "TurnEnds";
            this.TurnEnds.Size = new System.Drawing.Size(395, 95);
            this.TurnEnds.TabIndex = 24;
            this.TurnEnds.Text = "End Turn";
            this.TurnEnds.UseVisualStyleBackColor = true;
            this.TurnEnds.Click += new System.EventHandler(this.endTurn_Click_1);
            // 
            // Trade
            // 
            this.Trade.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trade.Location = new System.Drawing.Point(240, 376);
            this.Trade.Name = "Trade";
            this.Trade.Size = new System.Drawing.Size(220, 76);
            this.Trade.TabIndex = 25;
            this.Trade.Text = "Trade";
            this.Trade.UseVisualStyleBackColor = true;
            this.Trade.Click += new System.EventHandler(this.trade_Click_1);
            // 
            // MagProper
            // 
            this.MagProper.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MagProper.Location = new System.Drawing.Point(530, 376);
            this.MagProper.Name = "MagProper";
            this.MagProper.Size = new System.Drawing.Size(220, 76);
            this.MagProper.TabIndex = 27;
            this.MagProper.Text = "Manage";
            this.MagProper.UseVisualStyleBackColor = true;
            this.MagProper.Click += new System.EventHandler(this.manage_Click_1);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(85, 9);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(39, 26);
            this.player1Label.TabIndex = 29;
            this.player1Label.Text = "P1";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Label.Location = new System.Drawing.Point(316, 9);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(39, 26);
            this.player2Label.TabIndex = 30;
            this.player2Label.Text = "P2";
            // 
            // payFine
            // 
            this.payFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payFine.Location = new System.Drawing.Point(241, 499);
            this.payFine.Name = "payFine";
            this.payFine.Size = new System.Drawing.Size(220, 76);
            this.payFine.TabIndex = 31;
            this.payFine.Text = "Pay Fine";
            this.payFine.UseVisualStyleBackColor = true;
            this.payFine.Click += new System.EventHandler(this.payFine_Click_1);
            // 
            // die1text
            // 
            this.die1text.AutoSize = true;
            this.die1text.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.die1text.Location = new System.Drawing.Point(389, 610);
            this.die1text.Name = "die1text";
            this.die1text.Size = new System.Drawing.Size(57, 63);
            this.die1text.TabIndex = 32;
            this.die1text.Text = "0";
            this.die1text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // die2text
            // 
            this.die2text.AutoSize = true;
            this.die2text.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.die2text.Location = new System.Drawing.Point(534, 610);
            this.die2text.Name = "die2text";
            this.die2text.Size = new System.Drawing.Size(57, 63);
            this.die2text.TabIndex = 33;
            this.die2text.Text = "0";
            this.die2text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Controlled
            // 
            this.Controlled.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controlled.Location = new System.Drawing.Point(530, 498);
            this.Controlled.Name = "Controlled";
            this.Controlled.Size = new System.Drawing.Size(220, 76);
            this.Controlled.TabIndex = 34;
            this.Controlled.Text = "Controlled Roll";
            this.Controlled.UseVisualStyleBackColor = true;
            this.Controlled.Click += new System.EventHandler(this.controlled_roll_Click_1);
            // 
            // player3Label
            // 
            this.player3Label.AutoSize = true;
            this.player3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3Label.Location = new System.Drawing.Point(525, 9);
            this.player3Label.Name = "player3Label";
            this.player3Label.Size = new System.Drawing.Size(39, 26);
            this.player3Label.TabIndex = 35;
            this.player3Label.Text = "P3";
            // 
            // player4Label
            // 
            this.player4Label.AutoSize = true;
            this.player4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4Label.Location = new System.Drawing.Point(735, 9);
            this.player4Label.Name = "player4Label";
            this.player4Label.Size = new System.Drawing.Size(39, 26);
            this.player4Label.TabIndex = 36;
            this.player4Label.Text = "P4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Give Cards";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 944);
           // this.Controls.Add(this.button1);///////////////////////////////////////////////////////////////////////////////////DEBUG GIVE CARDS
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.Controlled);
            this.Controls.Add(this.die2text);
            this.Controls.Add(this.die1text);
            this.Controls.Add(this.payFine);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.MagProper);
            this.Controls.Add(this.Trade);
            this.Controls.Add(this.TurnEnds);
            this.Controls.Add(this.BuyProper);
            this.Controls.Add(this.rollDie);
            this.Controls.Add(this.taxLabel2);
            this.Controls.Add(this.chanceLabel3);
            this.Controls.Add(this.railShortLabel);
            this.Controls.Add(this.goToJailLabel);
            this.Controls.Add(this.railBOLabel);
            this.Controls.Add(this.railPennLabel);
            this.Controls.Add(this.eCompanyLabel);
            this.Controls.Add(this.chanceLabel2);
            this.Controls.Add(this.jailLabel);
            this.Controls.Add(this.taxLabel1);
            this.Controls.Add(this.railReadLabel);
            this.Controls.Add(this.chanceLabel1);
            this.Controls.Add(this.waterWorksLabel);
            this.Controls.Add(this.chestLabel3);
            this.Controls.Add(this.chestLabel2);
            this.Controls.Add(this.chestLabel1);
            this.Controls.Add(this.parkingLabel);
            this.Controls.Add(this.goLabel);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Board";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void rollDie_Click(object sender, EventArgs e)
        {
            List<int> die = this.roll();
            int steps = die[0] + die[1];
            this.getPlayer().move(steps);
        }


        #endregion

        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape illinoisAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape indianaAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape newYorkAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape tennesseeAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape virginiaAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape statesAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape orientalAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape vermontAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape balticAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape waterWorks;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape atlanticAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape boRailroad;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape chance2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape24;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape chance1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape readingRailroad;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape incomeTax;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape communityChest1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape mediteraneanAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape connecticutAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape goYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape gotoJailYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape boardwalk;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape shortLine;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape chance3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape parkPlace;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape luxuryTax;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape pacificAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape northCarolinaAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape communityChest3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectanglepennsylvaniaAvenueShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape15;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape communityChest2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape electricCompany;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape PennsylvaniaRailroad;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape stCharlesPlace;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape freeParkingYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape jailYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape marvinGardens;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape ventnorAvenue;
        private System.Windows.Forms.Label goLabel;
        private System.Windows.Forms.Label parkingLabel;
        private System.Windows.Forms.Label chestLabel1;
        private System.Windows.Forms.Label chestLabel2;
        private System.Windows.Forms.Label chestLabel3;
        private System.Windows.Forms.Label waterWorksLabel;
        private System.Windows.Forms.Label chanceLabel1;
        private System.Windows.Forms.Label railReadLabel;
        private System.Windows.Forms.Label taxLabel1;
        private System.Windows.Forms.Label jailLabel;
        private System.Windows.Forms.Label chanceLabel2;
        private System.Windows.Forms.Label eCompanyLabel;
        private System.Windows.Forms.Label railPennLabel;
        private System.Windows.Forms.Label railBOLabel;
        private System.Windows.Forms.Label goToJailLabel;
        private System.Windows.Forms.Label railShortLabel;
        private System.Windows.Forms.Label chanceLabel3;
        private System.Windows.Forms.Label taxLabel2;
        private System.Windows.Forms.Button rollDie;
        private System.Windows.Forms.TextBox payText;
        private System.Windows.Forms.Button BuyProper;
        private System.Windows.Forms.Button TurnEnds;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape4;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape3;
        private System.Windows.Forms.Button Trade;
        private System.Windows.Forms.Button MagProper;
        private Label player1Label;
        private Label player2Label;
        private Button payFine;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape die2square;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape die1box;
        private Label die1text;
        private Label die2text;
        private Button Controlled;
        private Label player3Label;
        private Label player4Label;
        private Button button1;
        
    }

}

