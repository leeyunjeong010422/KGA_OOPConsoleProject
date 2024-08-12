using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Scenes
{
    public class BattleScene : Scene
    {
        public enum State { Choice, Attack, Escape, PoketMonsterSelection }
        private State curState;

        private string input;
        private string nameInput;
        private Job currentJob;
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
            else if (curState == State.PoketMonsterSelection)
            {
                DisplayPoketMonsters(currentJob);
                Console.Write("포켓몬 번호 입력: ");
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
                curState = State.PoketMonsterSelection;
            }
            else if (curState == State.PoketMonsterSelection)
            {
                if (int.TryParse(input, out int selectedMonsterIndex))
                {
                    HandleMonsterSelection(selectedMonsterIndex);
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

        private void DisplayPoketMonsters(Job job)
        {
            Console.WriteLine("선택한 직업에 따른 포켓몬 목록:");

            switch (job)
            {
                case Job.HanJiu:
                    foreach (var monster in Enum.GetValues(typeof(JiuPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                case Job.ChoeIseul:
                    foreach (var monster in Enum.GetValues(typeof(IseulPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                case Job.UNG:
                    foreach (var monster in Enum.GetValues(typeof(UngPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                case Job.BOM:
                    foreach (var monster in Enum.GetValues(typeof(BomPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
            }
        }

        private void HandleMonsterSelection(int monsterIndex)
        {
            // 선택된 포켓몬에 대한 처리 로직을 여기에 작성합니다.
            Console.WriteLine($"선택한 포켓몬 번호: {monsterIndex}");
            // 선택된 포켓몬으로 전투 진행 등 추가 로직을 작성합니다.
        }
    }
}
