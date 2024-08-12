using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.VillainMonsters
{

    public class VillainMonsterFactory
    {
        public static T Create<T>(VillainType villainMonster) where T : VillainMonster, new()
        {
            T villain = new T();

            if(villainMonster == VillainType.Rocket)
            {
                villain.name = "로켓단";
                villain.hp = 100;
                villain.attack = 20;
                villain.defense = 10;
            }
            else if (villainMonster == VillainType.Magma)
            {
                villain.name = "마그마단";
                villain.hp = 100;
                villain.attack = 20;
                villain.defense = 10;
            }
            else if(villainMonster == VillainType.Aqua)
            {
                villain.name = "아쿠아단";
                villain.hp = 100;
                villain.attack = 20;
                villain.defense = 10;
            }
            else if(villainMonster == VillainType.Galactic)
            {
                villain.name = "갤럭시단";
                villain.hp = 100;
                villain.attack = 20;
                villain.defense = 10;
            }
            return villain;
        }
    }
    public class VillainMonster
    {
        public string name;
        public int hp;
        public int attack;
        public int defense;
    }
}
