using OOPConsoleProject.PoketMonsters;
using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Scenes
{
    public class BattleScene : Scene
    {
        public enum State { Choice, CharAttack, PoketAttack, Escape, Exit }
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
            Console.WriteLine($"{currentMonster.name}을 마주쳤습니다!");
            DisplayRandomMonster();
            Console.WriteLine("전투가 시작됩니다! 잠시만 기다려주세요...");
            Thread.Sleep(4000);
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
                Console.Write("[ 1. 캐릭터로 공격하기 | 2. 포켓몬으로 공격하기 | 3. 도망(50% 확률) ]: ");
            }
            else if (curState == State.CharAttack)
            {
                Console.WriteLine($"{game.Player.Name}이(가) {currentMonster.name}을 공격했습니다.");
                Thread.Sleep(1000);

                currentMonster.hp -= game.Player.Attack;
                Console.WriteLine($"{currentMonster.name}의 남은 체력: {currentMonster.hp}");

                if (currentMonster.hp <= 0) 
                {
                    currentMonster.hp = 0;
                    Console.WriteLine($"{currentMonster.name}이 쓰러졌습니다!");
                }
                else
                {
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    game.Player.CurHP -= currentMonster.attack;  
                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.CurHP}");

                    if (game.Player.CurHP <= 0) 
                    {
                        game.Player.CurHP = 0;
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.WriteLine("게임 오버!");
                        game.ChangeScene(SceneType.GameOver);
                    }
                    curState = State.Choice;
                }
            }
            else if (curState == State.PoketAttack)
            {
                Console.WriteLine($"{SelectScene.selectedPoketMonster}이(가) {currentMonster.name}을 공격했습니다.");
                Thread.Sleep(1000);

                currentMonster.hp -= game.PoketMonster.Attack;
                Console.WriteLine($"{currentMonster.name}의 남은 체력: {currentMonster.hp}");

                if (currentMonster.hp <= 0)
                {
                    currentMonster.hp = 0;
                    Console.WriteLine($"{currentMonster.name}이 쓰러졌습니다!");
                }
                else
                {
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    game.Player.CurHP -= currentMonster.attack; 
                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.CurHP}");

                    if (game.Player.CurHP <= 0) 
                    {
                        game.Player.CurHP = 0;
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.WriteLine("게임 오버!");
                        game.ChangeScene(SceneType.GameOver);
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
                    game.ChangeScene(SceneType.Map);
                }
                else
                {
                    Console.WriteLine("도망에 실패했습니다!");
                    Console.WriteLine($"{currentMonster.name}이 반격했습니다!");
                    game.Player.CurHP -= currentMonster.attack;
                    Console.WriteLine($"{game.Player.Name}의 남은 체력: {game.Player.CurHP}");

                    if (game.Player.CurHP <= 0) 
                    {
                        game.Player.CurHP = 0;
                        Console.WriteLine($"{game.Player.Name}이(가) 쓰러졌습니다!");
                        Console.WriteLine("게임 오버!");
                        game.ChangeScene(SceneType.GameOver);
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
                else
                {
                    Console.Write("1 ~ 3을 입력하세요: ");
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
