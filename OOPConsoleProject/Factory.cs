namespace OOPConsoleProject
{
    //상점에서 살 수 있는 아이템들
    public class Factory
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
            else if (name == "맛있는 물")
            {
                return new Drinking("맛있는 물", 50);
            }
            else if (name == "미네랄 사이다")
            {
                return new Drinking("미네랄 사이다", 50);
            }
            else if (name == "후르츠밀크")
            {
                return new Drinking("후르츠밀크", 50);
            }
            else
            {
                return null;
            }
        }

        public static DefensiveGear InstantiateGear(string name)
        {
            if (name == "진화의 휘석")
            {
                return new Gear("진화의 휘석", 20);
            }
            else if (name == "돌격 조끼")
            {
                return new Gear("돌격 조끼", 30);
            }
            else if (name == "은밀 망토")
            {
                return new Gear("은밀 망토", 40);
            }
            else
            {
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

    public class DefensiveGear
    {
        public string name { get; set; }
        public int defensivePower { get; set; }

        public DefensiveGear (string name, int defensivePower)
        {
            this.name = name;
            this.defensivePower = defensivePower;
        }
    }

    public class Potion : Item
    {
        public Potion(string name, int hp) : base(name, hp)
        {
        }
    }

    public class Drinking : Item
    {
        public Drinking(string name, int hp) : base(name, hp)
        {

        }
    }

    public class Gear : DefensiveGear
    {
        public Gear(string name, int defensivePower) : base(name, defensivePower)
        {

        }
    }
}
