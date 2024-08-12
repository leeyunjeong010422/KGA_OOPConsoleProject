using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Scenes
{
    public class BattleScene : Scene
    {
        public enum State { Choice, Attack, Escape }
        private State curState;

        private string input;
        private string nameInput;       

        private VillainMonster currentMonster;
        private Random random;
        public BattleScene(Game game) : base(game)
        {
            random = new Random();
        }

        public override void Enter()
        {
            RandomMonster();
            Console.WriteLine($"{currentMonster.name}을 마주쳤습니다!");
            Console.WriteLine("전투가 시작됩니다!");
            Thread.Sleep(2000);
            DisplayRandomMonster();
            curState = State.Choice;

        }

        public override void Exit()
        {
            Console.WriteLine("전투가 종료되었습니다!");
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Choice)
            {
                Console.Write("무엇을 하시겠습니까? [1. 공격, 2. 도망]: ");
            }
            else if (curState == State.Attack)
            {

            }
            else if (curState == State.Escape)
            {

            }

        }

        public override void Update()
        {
            if (curState == State.Choice)
            {
                if (input == string.Empty)
                    return;

                nameInput = input;
            }
        }

        private void RandomMonster()
        {
            var villainTypes = Enum.GetValues(typeof(VillainType));
            VillainType randomVillainType = (VillainType)villainTypes.GetValue(random.Next(villainTypes.Length));
            currentMonster = VillainMonsterFactory.Create<VillainMonster>(randomVillainType);

        }

        private void DisplayRandomMonster()
        {
            Console.WriteLine("===================");
            Console.WriteLine($"이름 : {currentMonster.name}");
            Console.WriteLine($"체력 : {currentMonster.hp}");
            Console.WriteLine($"공격력 : {currentMonster.attack}");
            Console.WriteLine($"방어력 : {currentMonster.defense}");
            Console.WriteLine("===================");
        }

        
    }
}
