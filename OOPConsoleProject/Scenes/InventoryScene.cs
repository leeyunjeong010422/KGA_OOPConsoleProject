using OOPConsoleProject.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleProject.Interface;

namespace OOPConsoleProject.Scenes
{
    public class InventoryScene : Scene
    {
        private Game game;
        private Player player;
        public InventoryScene(Game game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
        }

        public override void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("인벤토리를 열고 있습니다...");
            Thread.Sleep(2000);
            player.ShowInventory();
            
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