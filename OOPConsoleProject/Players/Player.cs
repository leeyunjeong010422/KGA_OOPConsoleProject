using OOPConsoleProject.Scenes;
using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Players
{
    public class Player
    {
        protected string name;
        public string Name { get { return name; } }

        protected Job job;
        public Job Job { get { return job; } }

        protected int curHP;
        public int CurHP
        {
            get { return curHP; }
            set { curHP = value; } 
        }

        protected int maxHP;
        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; } 
        }

        protected int attack;
        public int Attack
        {
            get { return attack; }
            set { attack = value; } 
        }

        protected int defense;
        public int Defense
        {
            get { return defense; }
            set { defense = value; } 
        }

        protected int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        public List<Item> inventory;

        public Player()
        {
            Gold = 10000;
            inventory = new List<Item>();
        }

        public void AddItemToInventory(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item.name}가 인벤토리에 추가되었습니다.");
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("==========================================");
            Console.WriteLine($" 이름 : {name,-6} 캐릭터 : {job,-6}");
            Console.WriteLine($" 체력 : {curHP,+3} / {maxHP}  공격 : {attack,-3} / 방어 : {defense,-3}");
            Console.WriteLine($" 골드 : {gold,+5} G");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }
    }
}
