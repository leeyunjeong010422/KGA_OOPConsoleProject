namespace OOPConsoleProject.Scenes
{
    public class ReturnScene : Scene
    {
        private string input;
        public ReturnScene(Game game) : base(game)
        {

        }

        public override void Enter()
        {
            input = 0.ToString();
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
            Console.WriteLine("마을로 돌아가시겠습니까? ");
            Console.WriteLine("이전 마을로 이동하게 됩니다. ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[ 1. 네 | 2. 아니오(인벤토리로 돌아가게 됩니다.) ]: ");
            Console.ResetColor();
        }

        public override void Update()
        {
            if (input == "1")
            {
                game.ChangeScene(SceneType.MapScene, Maps.Map1());
            }
            else if (input == "2")
            {
                game.ChangeScene(SceneType.Inventory);
            }
        }
    }
}
