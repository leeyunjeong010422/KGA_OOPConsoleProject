using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class MapScene1 : MapSceneBase
    {
        public MapScene1(Game game, Player player) : base(game, player) { }

        protected override void InitializeMaze()
        {
            maze = new char[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#'},
                {'#', ' ', '#', ' ', ' ', ' ', '#', '#', ' ', '#', ' ', '#', ' ', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#'},
                {'#', ' ', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', '#', '#', '#', ' ', '#', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#'}
            };
        }

        protected override void InitializeMonsters()
        {
            monsters = new List<(int x, int y)>
            {
                (3, 3), (7, 5), (10, 3), (16, 5), (25, 2)
            };
        }

        protected override void InitializeGoal()
        {
            goal = new List<(int x, int y)>
            {
                (28, 6)
            };
        }

        protected override void InitializePotion()
        {
            potion = new List<(int x, int y)>
            {
                (1, 3), (11, 3), (21, 1)
            };
        }

        public override void Exit()
        {

        }

        protected override void CheckForGoal()
        {
            foreach (var goal in goal)
            {
                if (playerX == goal.x && playerY == goal.y)
                {
                    game.ChangeScene(SceneType.Map2);
                    break;
                }
            }
        }

        protected override void MapName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<관동지방>");
            Console.ResetColor();
        }
    }
}
