using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class MapScene : Scene
    {
        private char[,] maze;
        private int playerX;
        private int playerY;
        public class Point
        {
            public int x;
            public int y;

        }

        private List<(int x, int y)> monsters;
        private List<(int x, int y)> goal;
        private Player player;

        public MapScene(Game game, Player player) : base(game)
        {
            InitializeMaze();
            InitializeMonsters();
            InitializeGoal();
            playerX = 1;
            playerY = 1;
            this.game = game;
            this.player = player;
        }

        private void InitializeMaze()
        {
            maze = new char[,]
            {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#', '#', ' ', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', ' ', '#', '#'},
        {'#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#'}
            };
        }



        private void InitializeMonsters()
        {
            monsters = new List<(int x, int y)>
            {
                (3, 2)
            };
        }

        private void InitializeGoal()
        {
            goal = new List<(int x, int y)>
            {
                (4, 4)
            };
        }

        public override void Enter()
        {
            playerX = 1;
            playerY = 1;
        }

        public override void Exit()
        {

        }
        public override void Input()
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1)
            {
                game.ChangeScene(SceneType.Shop);
            }
            else if (key == ConsoleKey.D2)
            {
                game.ChangeScene(SceneType.Inventory);
            }
            else if (key == ConsoleKey.D0)
            {
                Console.Clear();
                UseInventory();
            }
            else
            {
                Move(key);
            }
        }

        private bool isInitialized = false; 

        public override void Render()
        {
            Console.Clear();

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (i == playerY && j == playerX)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("P ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("캐릭터는 방향키로 움직입니다.");
            Console.WriteLine("[ 1번: 상점가기 | 2번: 인벤토리열기 ]");
            Console.WriteLine("[ 0번: 포션 먹기 ]");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===================");
            Console.ResetColor();
            Console.WriteLine($"이름 : {game.Player.Name}");
            Console.WriteLine($"캐릭터 : {game.Player.Job}");
            Console.WriteLine($"포켓몬 : {SelectScene.selectedPoketMonster}");
            Console.WriteLine($"체력 : {game.Player.CurHP}");
            Console.WriteLine($"공격 : {game.Player.Attack}");
            Console.WriteLine($"방어 : {game.Player.Defense}");
            Console.WriteLine($"Gold : {game.player.Gold} G");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===================");
            Console.ResetColor();
            Console.WriteLine();
        }


        public override void Update()
        {
            CheckForMonster();
            CheckForGoal();
        }

        private void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
            }
        }

        private void MoveUp()
        {
            Point next = new Point() { x = playerX, y = playerY - 1 };
            if (IsValidMove(next.x, next.y))
            {
                playerX = next.x;
                playerY = next.y;
            }
        }

        private void MoveDown()
        {
            Point next = new Point() { x = playerX, y = playerY + 1 };
            if (IsValidMove(next.x, next.y))
            {
                playerX = next.x;
                playerY = next.y;
            }
        }

        private void MoveLeft()
        {
            Point next = new Point() { x = playerX - 1, y = playerY };
            if (IsValidMove(next.x, next.y))
            {
                playerX = next.x;
                playerY = next.y;
            }
        }

        private void MoveRight()
        {
            Point next = new Point() { x = playerX + 1, y = playerY };
            if (IsValidMove(next.x, next.y))
            {
                playerX = next.x;
                playerY = next.y;
            }
        }

        private bool IsValidMove(int x, int y)
        {
            if (y >= 0 && y < maze.GetLength(0) && x >= 0 && x < maze.GetLength(1) && maze[y, x] == ' ')
            {
                return true;
            }
            return false;
        }

        private void CheckForMonster()
        {
            foreach (var monster in monsters)
            {
                if (playerX == monster.x && playerY == monster.y)
                {
                    game.ChangeScene(SceneType.Battle);
                    break;
                }
            }
        }

        private void CheckForGoal()
        {
            foreach (var goal in goal)
            {
                if (playerX == goal.x && playerY == goal.y)
                {
                    game.ChangeScene(SceneType.Map1);
                }
            }
        }

        public void UseInventory()
        {
            InventoryScene inventoryScene = new InventoryScene(game, player);
            inventoryScene.ShowInventory();
            Console.WriteLine();
            inventoryScene.PromptPotionSelection();
        }
    }
}