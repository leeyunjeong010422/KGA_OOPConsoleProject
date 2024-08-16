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
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.GameIntroduction);
        }
    }
}
