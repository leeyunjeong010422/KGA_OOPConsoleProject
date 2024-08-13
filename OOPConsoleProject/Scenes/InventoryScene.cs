using OOPConsoleProject.Players;

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
            Console.Clear();
            Console.WriteLine("인벤토리를 열고 있습니다.");
            Thread.Sleep(2000);
            Console.Clear();
            player.ShowInventory();
            Console.WriteLine();
            player.PromptPotionSelection();
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
