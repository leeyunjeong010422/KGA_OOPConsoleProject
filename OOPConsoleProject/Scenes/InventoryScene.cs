using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game)
        {

        }

        public override void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("인벤토리를 열고 있습니다...");
            Thread.Sleep(2000);
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
            
        }
    }
}