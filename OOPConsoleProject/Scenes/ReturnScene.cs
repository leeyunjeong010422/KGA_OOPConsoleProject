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
            Console.WriteLine("어느 마을로 돌아가시겠습니까?");
            Console.WriteLine("* 마지막 마을은 이동할 수 없습니다 *");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[ 1. 관동지방 | 2. 성도지방 ]: ");
            Console.ResetColor();
        }

        public override void Update()
        {
            if (input == "1")
            {
                game.ChangeScene(SceneType.Map);
            }
            else if (input == "2")
            {
                game.ChangeScene(SceneType.Map1);
            }
        }
    }
}
