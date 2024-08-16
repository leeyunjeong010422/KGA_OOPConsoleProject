using OOPConsoleProject.Players;
using OOPConsoleProject.VillainMonsters;

namespace OOPConsoleProject.Scenes
{
    public abstract class MapSceneBase : Scene
    {
        protected char[,] maze;
        protected int playerX;
        protected int playerY;

        public class Point
        {
            public int x;
            public int y;
        }

        protected List<(int x, int y)> monsters;
        protected List<(int x, int y)> goal;
        protected List<(int x, int y)> potion;
        protected Player player;

        public MapSceneBase(Game game, Player player) : base(game)
        {
            InitializeMaze();
            InitializeMonsters();
            InitializeGoal();
            InitializePotion();

            playerX = 1;
            playerY = 1;
            this.player = player;
        }

        protected abstract void InitializeMaze(); 

        protected abstract void InitializeMonsters(); 

        protected abstract void InitializeGoal(); 

        protected abstract void InitializePotion();

        protected abstract void CheckForGoal();

        protected abstract void MapName();

        public override void Enter()
        {
            playerX = 1;
            playerY = 1;
        }

        public override void Render()
        {
            Console.Clear();

            MapName();

            char[,] displayMaze = (char[,])maze.Clone();

            foreach (var p in potion)
            {
                displayMaze[p.y, p.x] = 'X';
            }

            foreach (var m in monsters)
            {
                displayMaze[m.y, m.x] = 'M';
            }

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
                    else if (displayMaze[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X ");
                        Console.ResetColor();
                    }
                    else if (displayMaze[i, j] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("M ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(maze[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[ 1번: 상점가기 | 2번: 인벤토리 (포션 먹기, 장비 착용 가능) ]");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("========================================================");
            Console.ResetColor();
            Console.WriteLine($" 이름 : {game.Player.Name,-6} 캐릭터 : {game.Player.Job,-6} 포켓몬: {SelectScene.selectedPoketMonster}");
            Console.WriteLine($" 체력 : {game.Player.CurHP,+3} / {game.Player.MaxHP}");
            Console.WriteLine($" 공격력 : {game.Player.Attack,-3} 방어력 : {game.Player.Defense,-3}");
            Console.WriteLine($" 골드 : {game.player.Gold,+5} G");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("========================================================");
            Console.ResetColor();
            Console.WriteLine();
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
            else
            {
                Move(key);
            }
        }

        public override void Update()
        {
            CheckForMonster();
            CheckForGoal();
            CheckForPotion();
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
            return y >= 0 && y < maze.GetLength(0) && x >= 0 && x < maze.GetLength(1) && maze[y, x] == ' ';
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

        protected void CheckForMonsterRemove()
        {
            monsters.RemoveAll(m => m.x == playerX && m.y == playerY);
        }   

        private void CheckForPotion()
        {
            for (int i = 0; i < potion.Count; i++)
            {
                if (playerX == potion[i].x && playerY == potion[i].y)
                {
                    player.AddPotionToInventory(new Potion("초급 포션", 30));

                    potion.RemoveAt(i);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("초급포션을 획득했습니다! 인벤토리에 추가되었습니다.");
                    Console.ResetColor();
                    Thread.Sleep(2000);

                    break;
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
