
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
        private Game game;
        public Player(Game game)
        {
            this.game = game;
        }

        public Player()
        {
            inventory = new List<Item>();
        }

        public void AddItemToInventory(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item.name}가 인벤토리에 추가되었습니다.");
        }  
    }
}
