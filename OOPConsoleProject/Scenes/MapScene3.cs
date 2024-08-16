using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class MapScene3 : MapSceneBase
    {
        public MapScene3(Game game, Player player) : base(game, player) { }

        protected override void InitializeMaze()
        {
            maze = new char[,]
           {
             {'#', '#', '#', '#', '#', '#', '#', '#'},
             {'#', ' ', ' ', ' ', '#', ' ', ' ', '#'},
             {'#', ' ', '#', ' ', '#', '#', ' ', '#'},
             {'#', ' ', ' ', ' ', ' ', ' ', '#', '#'},
             {'#', ' ', '#', '#', '#', ' ', '#', '#'},
             {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
             {'#', '#', '#', '#', '#', '#', ' ', '#'}
           };
        }

        protected override void InitializeMonsters()
        {
            monsters = new List<(int x, int y)>
            {
                (3, 3)
            };
        }

        protected override void InitializeGoal()
        {
            goal = new List<(int x, int y)>
            {
                (6, 6)
            };
        }

        protected override void InitializePotion()
        {
            potion = new List<(int x, int y)>
            {
                (2, 1)
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
                    game.ChangeScene(SceneType.Clear);
                    break;
                }
            }
        }

        protected override void MapName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<호연지방>");
            Console.ResetColor();
        }
    }
}
