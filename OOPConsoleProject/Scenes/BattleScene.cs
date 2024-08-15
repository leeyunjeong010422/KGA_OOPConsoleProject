using OOPConsoleProject.PoketMonsters;
using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Scenes
{
    public class BattleScene : Scene
    {
        public enum State { Choice, CharAttack, PoketAttack, Escape }
        private State curState;

        private string input;
        private string nameInput;

        public VillainMonster currentMonster;
        public PoketMonster PoketMonster;
        private Random random;

        public BattleScene(Game game) : base(game)
        {
            random = new Random();
        }

        public override void Enter()
        {
            RandomMonster();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{currentMonster.name}을 마주쳤습니다!");
            Console.ResetColor();
            Console.WriteLine();
            DisplayRandomMonster();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("곧 전투가 시작됩니다!");
            Console.ResetColor();
            Console.WriteLine("[ 적의 정보를 다 확인하였으면 아무 키나 눌러 전투를 시작하세요! ]");
            Console.ReadKey();
            curState = State.Choice;

        }

        public override void Exit()
        {
            //Console.WriteLine("전투가 종료되었습니다!");
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
                Console.WriteLine("무엇을 하시겠습니까?");
                Console.Write("[ 1. 캐릭터로 공격하기 | 2. 포켓몬으로 공격하기 | 3. 도망치기(50% 확률) ]: ");
            }
            else if (curState == State.CharAttack)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{game.Player.Name}이(가) {currentMonster.name}을 공격했습니다!");
                Console.ResetColor();
                Thread.Sleep(1000);

                currentMonster.hp -= game.Player.Attack;

                if (currentMonster.hp <= 0)
                {
                    currentMonster.hp = 0;
                }

                Console.WriteLine($"{currentMonster.name}의 남은 체력: {currentMonster.hp}");
                Thread.Sleep(1000);
                Console.WriteLine();

                if (currentMonster.hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{currentMonster.name}이 쓰러졌습니다!");
                    Console.ResetColor();
                    game.Player.Gold += 2000;
                    // Console.WriteLine($"현재 골드: {game.Player.Gold}");
                    Console.Write("몬스터 처치 보상으로 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("2000 Gold");
                    Console.ResetColor();
                    Console.WriteLine("를 획득하셨습니다.");
                    Console.WriteLine();
                    
                    Console.WriteLine("[ 다음으로 넘어가려면 아무 키나 누르세요. ]");
                    game.EndBattle();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    Console.ResetColor();

                    game.Player.CurHP -= currentMonster.attack;

                    if (game.Player.CurHP <= 0)
                    {
                        game.Player.CurHP = 0;
                    }

                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.CurHP}");
                    Console.WriteLine();

                    if (game.Player.CurHP <= 0)
                    {
                        game.Player.CurHP = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine("[ 게임 오버! ]");
                        Console.WriteLine();
                    }
                    Console.WriteLine("[ 다음으로 넘어가려면 아무 키나 누르세요. ]");
                    curState = State.Choice;
                }
            }
            else if (curState == State.PoketAttack)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{SelectScene.selectedPoketMonster}이(가) {currentMonster.name}을 공격했습니다.");
                Console.ResetColor();
                Thread.Sleep(1000);

                currentMonster.hp -= game.PoketMonster.Attack;

                if (currentMonster.hp <= 0)
                {
                    currentMonster.hp = 0;
                }

                Console.WriteLine($"{currentMonster.name}의 남은 체력: {currentMonster.hp}");
                Thread.Sleep(1000);
                Console.WriteLine();

                if (currentMonster.hp <= 0)
                {
                    currentMonster.hp = 0;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine($"{currentMonster.name}이 쓰러졌습니다!");
                    Console.ResetColor();
                    game.Player.Gold += 2000;
                    Console.Write("몬스터 처치 보상으로 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("2000 Gold");
                    Console.ResetColor();
                    Console.WriteLine("를 획득하셨습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[ 다음으로 넘어가려면 아무 키나 누르세요. ]");
                    game.EndBattle();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    Console.ResetColor();

                    game.Player.CurHP -= currentMonster.attack;

                    if (game.Player.CurHP <= 0)
                    {
                        game.Player.CurHP = 0;
                    }

                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.CurHP}");
                    Console.WriteLine();

                    if (game.Player.CurHP <= 0)
                    {
                        game.Player.CurHP = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine("[ 게임 오버! ]");
                        Console.WriteLine();
                    }
                    Console.WriteLine("[ 다음으로 넘어가려면 아무 키나 누르세요. ]");
                    curState = State.Choice;
                }

            }
            else if (curState == State.Escape)
            {
                Console.WriteLine($"{game.Player.Name}이 도망치려 합니다.");
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.WriteLine("도망칠 수 있는 확률은 50% 입니다.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("(도망치는 중...)");
                Thread.Sleep(2000);
                Console.ResetColor();
                bool escape = random.Next(0, 2) == 0;

                if (escape)
                {
                    Console.Clear();
                    Console.Write("도망에 ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("성공");
                    Console.ResetColor();
                    Console.WriteLine("하였습니다!");
                    Console.WriteLine();
                    Console.WriteLine("[ 다음으로 넘어가려면 아무 키나 누르세요. ]");
                    game.EndBattle();
                }
                else
                {
                    Console.Clear();
                    Console.Write("도망에 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("실패");
                    Console.ResetColor();
                    Console.WriteLine("하였습니다!");
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    Console.WriteLine($"도망치다 {currentMonster.name}에게 붙잡혔습니다!");
                    Thread.Sleep(1000);
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    Thread.Sleep(1000);
                    Console.ResetColor();

                    game.Player.CurHP -= currentMonster.attack;

                    if (game.Player.CurHP < 0)
                    {
                        game.Player.CurHP = 0;
                    }

                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.CurHP}");

                    if (game.Player.CurHP <= 0)
                    {
                        game.Player.CurHP = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine("[ 게임 오버! ]");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("[ 다음으로 넘어가려면 아무 키나 누르세요. ]");
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
                    curState = State.CharAttack;
                }
                else if (input == "2")
                {
                    curState = State.PoketAttack;
                }
                else if (input == "3")
                {
                    curState = State.Escape;
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
