using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    internal class ClearScene : Scene
    {
        private string input;
        public ClearScene(Game game) : base(game)
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
            Console.Clear();
            Console.WriteLine("게임 클리어!");
        }

        public override void Update()
        {

        }
    }
}
