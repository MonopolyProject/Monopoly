﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        string Name;
        int money;
        int location;
        int payForRound;
        bool collectAtGo;
        public List<Property> deeds = new List<Property>();
        public int doubleCounter = 0;
        public Player(string Name)
        {
            this.Name = Name;
            this.location = 0;
            this.money = 1300;
        }
        public int move(int distance, bool passGo = true) {
            if(passGo && this.location == 0 && distance > 0) {
                this.addMoney(200);
                passGo = false;
            }
            this.location += distance;
            if (passGo && this.location > 40) { this.addMoney(200); }
            this.location = this.location % 40;
            return this.location;
        }

        public string getName()
        {
            return this.Name;
        }

        public int getMoney()
        {
            return this.money;
        }

        public int getLocation() {
            return this.location;
        }

        public void addMoney(int amount)
        {
            this.money = this.money + amount;
            if(amount<0) {
                this.payForRound = -amount;
            }
        }

        public void setPayForRound(int amount)
        {
            this.payForRound = amount;
        }

        public int getPayForRound()
        {
            return this.payForRound;
        }

        public bool hasDeed(Property lookFor) { return this.deeds.Contains(lookFor); }
        public bool hasDeeds(List<Property> possibleDeeds)
        {
            foreach (Property prop in possibleDeeds)
            {
                if (!this.deeds.Contains(prop)) return false;
            }
            return true;
        }

        public void addDeed(Property prop) { this.deeds.Add(prop); }
        public void removeDeed(Property prop) { this.deeds.Remove(prop); }
        public List<Property> getDeeds() { return this.deeds; }

        public bool Equals(Player p)
        {
            if (this.getName() == p.getName()) return true;
            return false;
        }

        public int countType(Type t)
        {
            int count = 0;
            foreach (Property p in this.getDeeds())
            {
                if (p.GetType().Equals(t)) count++;
            }
            return count;
        }
    }
}
