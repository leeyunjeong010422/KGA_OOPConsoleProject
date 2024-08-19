using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class TitleScene : Scene
    {
        public TitleScene(Game game) : base(game)
        {

        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            Console.ReadKey();
        }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           。　♡ 。　　♡。　　♡");
            Console.WriteLine("           ♡。　＼　　｜　　／。　♡");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("             게임시작하기 (Enter) ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           ♡。　／　　｜　　＼。　♡");
            Console.WriteLine("           。　♡。 　　。　　♡。");
            Console.ResetColor();
            Console.WriteLine();

            //Console.WriteLine("<시간 부족으로 구현하지 못한 것>");
            //Console.WriteLine("- 포켓몬마다 공격력 다르게 설정 후 포켓몬 설정시 해당 포켓몬으로 공격력 적용시키기");
            //Console.WriteLine("- 방어력이 존재하지만 방어력을 사용하진 않음");
            //Console.WriteLine("     --> 추후에 방어력에 따른 hp 감소량 다르게 하기 ");
            //Console.WriteLine("     --> 예를 들어 같은 50의 데미지를 받는데 방어력이 더 높은 캐릭터는 hp가 30만 줄어든다");
            //Console.WriteLine("- 맵에서 해당 몬스터를 죽이면 그 몬스터가 사라지고 사라진 장소로 돌아오기");
            //Console.WriteLine("     --> 현재 몬스터가 사라지진 않고 몬스터를 죽이고 돌아오면 맵 시작점으로 돌아감");
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.GameIntroduction);
        }
    }
}
