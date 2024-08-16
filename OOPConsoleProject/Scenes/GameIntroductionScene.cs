using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class GameIntroductionScene : Scene
    {
        public GameIntroductionScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("================== 게임 소개 ==================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("환영합니다!");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("이 게임은 몬스터를 사냥하고 미로를 탐험하는 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("어드벤처 게임");
            Console.ResetColor();
            Console.WriteLine("입니다.");
            Console.Write("다양한 몬스터를 처치하고 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Gold를 획득");
            Console.ResetColor();
            Console.Write("하여 상점에서 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("아이템, 장비를 구입");
            Console.ResetColor();
            Console.WriteLine("할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("<게임 조작법>");
            Console.Write(" - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("방향키 ");
            Console.ResetColor();
            Console.Write("또는 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("WASD 키");
            Console.ResetColor();
            Console.WriteLine("를 사용하여 캐릭터를 이동하세요.");
            Console.WriteLine(" - 몬스터와의 전투에서 승리하고 모든 미로를 클리어하세요.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("주의: ");
            Console.ResetColor();
            Console.WriteLine("몬스터에게 죽지 않도록 조심해야 합니다.");
            Console.WriteLine();
            Console.WriteLine("[ 게임을 시작하려면 아무 키나 눌러주세요 ]");
            Console.ReadKey();
        }


        public override void Exit()
        {
            
        }

        public override void Input()
        {
            
        }

        public override void Render()
        {
            
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.Select);
        }
    }
}

