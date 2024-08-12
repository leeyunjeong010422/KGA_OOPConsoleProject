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
        public ChoeIseul(string name)
        {
            this.name = name;
            this.job = Job.ChoeIseul;
            this.maxHP = 100;
            this.curHP = maxHP;
            this.attack = 50;
            this.defense = 50;
            this.gold = 10000;
        }

        public override void Skill(VillainMonster monster)
        {

        }
    }
}

