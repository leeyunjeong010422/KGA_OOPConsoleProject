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
            Console.WriteLine("    게임을 시작하려면 아무키나 누르세요    ");
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.Select);
        }
    }
}
