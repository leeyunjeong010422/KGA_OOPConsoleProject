namespace OOPConsoleProject
{
    public class ItemFactory
    {
        public static Item Instantiate(string name)
        {
            if (name == "초급포션")
            {
                return new Potion("초급포션", 30);
            }
            else if (name == "중급포션")
            {
                return new Potion("중급포션", 50);
            }
            else if (name == "고급포션")
            {
                return new Potion("고급포션", 70);
            }
            else
            {
                Console.WriteLine("해당 이름의 아이템이 없습니다.");
                return null;
            }
        }
    }

    public class Item
    {
        public string name { get; set; }
        public int hp { get; set; }

        public Item(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }
    }

    public class Potion : Item
    {
        public Potion(string name, int hp) : base(name, hp)
        {
        }
    }
}
