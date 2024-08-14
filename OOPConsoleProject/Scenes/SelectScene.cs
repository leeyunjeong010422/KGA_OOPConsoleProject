using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class SelectScene : Scene
    {
        public enum State { Name, Job, PoketMonsterSelection, Confirm }
        private State curState;
        private Job currentJob;
        public static object selectedPoketMonster;

        private string input;
        private string nameInput;
        private Player player;

        public SelectScene(Game game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
        }

        public override void Enter()
        {
            curState = State.Name;
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Name)
            {
                Console.Write("캐릭터의 이름을 입력하세요: ");
            }
            else if (curState == State.Job)
            {
                Console.WriteLine("플레이할 캐릭터를 선택하세요.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. 한지우");
                Console.WriteLine("2. 최이슬");
                Console.WriteLine("3. 웅이");
                Console.WriteLine("4. 봄이");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("입력: ");
            }
            else if (curState == State.PoketMonsterSelection)
            {
                DisplayPoketMonsters(currentJob);
                Console.WriteLine();
                Console.Write("사용할 포켓몬 번호 입력: ");                
            }

            else if (curState == State.Confirm)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("===================");
                Console.ResetColor();
                Console.WriteLine($"이름 : {game.Player.Name}");
                Console.WriteLine($"캐릭터 : {game.Player.Job}");
                Console.WriteLine($"포켓몬 : {selectedPoketMonster}");
                Console.WriteLine($"체력 : {game.Player.MaxHP}");
                Console.WriteLine($"공격 : {game.Player.Attack}");
                Console.WriteLine($"방어 : {game.Player.Defense}");
                Console.WriteLine($"Gold : {game.Player.Gold} G");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("===================");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("이대로 플레이 하시겠습니까? [네(Y) | 아니오(N)]: ");
            }
        }

        public override void Update()
        {
            if (curState == State.Name)
            {
                if (input == string.Empty)
                    return;

                nameInput = input;
                curState = State.Job;
            }
            else if (curState == State.Job)
            {
                if (int.TryParse(input, out int jobIndex) && Enum.IsDefined(typeof(Job), jobIndex))
                {
                    currentJob = (Job)jobIndex;
                    switch (currentJob)
                    {
                        case Job.한지우:
                            game.Player = new HanJiu(nameInput);
                            break;
                        case Job.최이슬:
                            game.Player = new ChoeIseul(nameInput);
                            break;
                        case Job.웅이:
                            game.Player = new UNG(nameInput);
                            break;
                        case Job.봄이:
                            game.Player = new BOM(nameInput);
                            break;
                    }
                    curState = State.PoketMonsterSelection;
                }
            }
            else if(curState == State.PoketMonsterSelection)
            {
                if (int.TryParse(input, out int monsterIndex))
                {
                    if (monsterIndex >= 1 && monsterIndex <= 3)
                    {
                        selectedPoketMonster = GetPoketMonster(currentJob, monsterIndex);
                        curState = State.Confirm;
                    }
                }
            }

            else if (curState == State.Confirm)
            {
                switch (input)
                {
                    case "Y":
                    case "y":
                    case "네":
                        game.ChangeScene(SceneType.Map);
                        break;
                    case "N":
                    case "n":
                    case "아니오":
                        curState = State.Name;
                        break;
                    default:
                        break;
                }
            }
        }

        private object GetPoketMonster(Job job, int monsterIndex)
        {
            switch (job)
            {
                case Job.한지우:
                    return (JiuPoketMonster)monsterIndex; 
                case Job.최이슬:
                    return (IseulPoketMonster)monsterIndex; 
                case Job.웅이:
                    return (UngPoketMonster)monsterIndex; 
                case Job.봄이:
                    return (BomPoketMonster)monsterIndex; 
                default:
                    return null;
            }
        }

        private void DisplayPoketMonsters(Job job)
        {
            Console.WriteLine($"<선택한 캐릭터[{game.Player.Job}]에 따른 포켓몬 목록>");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (job)
            {
                case Job.한지우:
                    foreach (var monster in Enum.GetValues(typeof(JiuPoketMonster)))
                    {
                        Console.WriteLine($"{(int)monster}. {monster}");
                    }
                    break;
                case Job.최이슬:
                    foreach (var monster in Enum.GetValues(typeof(IseulPoketMonster)))
                    {
                        Console.WriteLine($"{(int)monster}. {monster}");
                    }
                    break;
                case Job.웅이:
                    foreach (var monster in Enum.GetValues(typeof(UngPoketMonster)))
                    {
                        Console.WriteLine($"{(int)monster}. {monster}");
                    }
                    break;
                case Job.봄이:
                    foreach (var monster in Enum.GetValues(typeof(BomPoketMonster)))
                    {
                        Console.WriteLine($"{(int)monster}. {monster}");
                    }
                    break;
                    
            }
            Console.ResetColor();
        }
    }
}