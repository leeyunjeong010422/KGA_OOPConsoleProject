using OOPConsoleProject.VillainMonsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Players
{
    public class BOM : Player
    {
        public BOM(string name) : base()
        {
            this.name = name;
            this.job = Job.봄이;
            this.maxHP = 100;
            this.curHP = maxHP;
            this.attack = 20;
            this.defense = 70;
            this.gold = 2000;
        }
    }
}

