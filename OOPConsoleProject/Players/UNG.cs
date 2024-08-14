using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Players
{
    public class UNG : Player
    {
        public UNG(string name) : base()
        {
            this.name = name;
            this.job = Job.웅이;
            this.maxHP = 100;
            this.curHP = maxHP;
            this.attack = 30;
            this.defense = 50;
            this.gold = 10000;
        }
    }
}

