using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Scenes
{
    public class BattleScene : Scene
    {
        public enum State { Choice, Attack, Escape, Exit }
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
                Console.Write("무엇을 하시겠습니까? [1. 공격, 2. 도망(50% 확률)]: ");
            }
            else if (curState == State.Attack)
            {
                Console.WriteLine($"{game.Player.Name}이(가) {currentMonster.name}을 공격했습니다.");
                Thread.Sleep(1000);
                
                currentMonster.hp -= game.Player.Attack;
                Console.WriteLine($"{currentMonster.name}의 남은 체력: {currentMonster.hp}");                

                if (currentMonster.hp < 0)
                {
                    Console.WriteLine($"{currentMonster.name}이 쓰려졌습니다!");
                    curState = State.Choice;
                }
                else
                {
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    game.Player.MaxHP -= currentMonster.attack;
                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.MaxHP}");

                    if (game.Player.MaxHP < 0)
                    {
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.WriteLine("게임 오버!");
                    }
                    curState = State.Choice;
                }
            }
            else if (curState == State.Escape)
            {
                Console.WriteLine($"{game.Player.Name}이 도망치려 합니다.");
                bool escape = random.Next(0, 2) == 0;

                if (escape)
                {
                    Console.WriteLine("도망에 성공했습니다!");
                    Exit();
                }
                else
                {
                    Console.WriteLine("도망에 실패했습니다!");
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    game.Player.MaxHP -= currentMonster.attack;
                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.MaxHP}");

                    if (game.Player.MaxHP < 0)
                    {
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.WriteLine("게임 오버!");
                    }
                    curState = State.Choice;

                }
            }
        }

        public override void Update()
        {
            if (curState == State.Choice)
            {
                if (input == string.Empty)
                    return;

                if (input == "1")
                {
                    curState = State.Attack;
                }
                else if (input == "2")
                {
                    curState = State.Escape;
                }
                else
                {
                    Console.Write("1 또는 2를 입력하세요: ");
                }
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
