using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class GameOverScene : Scene
    {
        public GameOverScene(Game game) : base(game)
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
            Environment.Exit(0);
        }

        public override void Render()
        {
            Console.WriteLine("게임 오버!");
        }

        public override void Update()
        {
            
        }
    }
}
