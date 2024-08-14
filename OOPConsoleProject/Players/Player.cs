
using OOPConsoleProject.Scenes;
using System.Numerics;

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
        public int Gold 
        { 
            get { return gold; } 
            set { gold = value; } 
        }

        public List<Item> inventory;
        public List<DefensiveGear> gearInventory;
        private Game game;

        public Player(Game game)
        {
            this.game = game;
        }

        public Player()
        {
            inventory = new List<Item>();
            gearInventory = new List<DefensiveGear>();
        }

        public void AddItemToInventory(Item item)
        {
            inventory.Add(item);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{item.name}을(를) 구매하였습니다.");
            Thread.Sleep(1000);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("인벤토리에 추가되었습니다.");
            Thread.Sleep(1500);
        }

        public void AddGearToInventory(DefensiveGear gear)
        {
            gearInventory.Add(gear);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;           
            Console.WriteLine($"{gear.name}을(를) 구매하였습니다.");
            Thread.Sleep(1000);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"인벤토리에 추가되었습니다.");
            Thread.Sleep(1500);
        }
    }
}
