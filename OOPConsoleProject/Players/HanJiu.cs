using OOPConsoleProject.VillainMonsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Players
{
    public class HanJiu : Player
    {
        public HanJiu(string name) : base()
        {
            this.name = name;
            this.job = Job.한지우;
            this.maxHP = 100;
            this.curHP = maxHP;
            this.attack = 70;
            this.defense = 20;
            this.gold = 10000;
        }
    }
}
