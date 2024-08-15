using OOPConsoleProject.VillainMonsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Players
{
    public class ChoeIseul : Player
    {
        public ChoeIseul(string name) : base()
        {
            this.name = name;
            this.job = Job.최이슬;
            this.maxHP = 100;
            this.curHP = maxHP;
            this.attack = 50;
            this.defense = 20;
            this.gold = 2000;
        }
    }
}

