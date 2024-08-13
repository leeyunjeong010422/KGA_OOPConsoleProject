using OOPConsoleProject.Interface;
using System.Numerics;

namespace OOPConsoleProject.Players
{
    public class Player : Inventory
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
        private Game game;
        public Player(Game game)
        {
            this.game = game;
        }

        public Player()
        {
            Gold = 10000;
            MaxHP = 100;
            CurHP = MaxHP;
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
            Console.WriteLine($" 골드 : {Gold,+5} G");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine("<인벤토리>");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.name} (회복량: {item.hp})");
            }
        }
        public void PromptPotionSelection()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("인벤토리에 포션이 없습니다.");
                game?.EndBattle();
                return;
            }

            Console.WriteLine("사용할 포션을 선택하세요");

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i].name} (회복량: {inventory[i].hp})");
            }
            Console.WriteLine("0. 사용하지 않고 나가기");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D0)
            {
                Console.WriteLine("포션 사용이 취소되었습니다.");
                game.EndBattle();
                return;
            }

            int index = (int)key - (int)ConsoleKey.D1;

            if (index >= 0 && index < inventory.Count)
            {
                UsePotion(index);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                PromptPotionSelection();
            }
        }

        public void UsePotion(int index)
        {
            if (index >= 0 && index < inventory.Count)
            {
                var potion = inventory[index];
                CurHP += potion.hp;

                if (CurHP > MaxHP)
                {
                    CurHP = MaxHP;
                }

                inventory.RemoveAt(index);
                Console.WriteLine($"{potion.name}을(를) 사용했습니다. 현재 체력: {CurHP}");
                Console.WriteLine();
                ShowInventory();
            }
            else
            {
                Console.WriteLine("잘못된 포션 인덱스입니다.");
            }
        }

    }
}
