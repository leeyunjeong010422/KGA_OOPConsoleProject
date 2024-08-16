namespace OOPConsoleProject.PoketMonsters
{
    //선택한 포켓몬 별로 hp 감소하는 기능 구현 X
    //현재 초기 설정한 30으로 모두 동일하게 감소
    public class PoketMonster
    {
        protected int attack = 30;
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

    }

    public class JiuPoketMonster : PoketMonster
    {
        public JiuPoketMonster()
        {
            Attack = 40;
        }
    }

    public class IseulPoketMonster : PoketMonster
    {
        public IseulPoketMonster()
        {
            Attack = 35;
        }
    }

    public class UngPoketMonster : PoketMonster
    {
        public UngPoketMonster()
        {
            Attack = 50;
        }
    }

    public class BomPoketMonster : PoketMonster
    {
        public BomPoketMonster()
        {
            Attack = 45;
        }
    }


}

