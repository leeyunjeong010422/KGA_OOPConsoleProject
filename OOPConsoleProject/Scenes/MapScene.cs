﻿using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public struct Point
    {
        public int x;
        public int y;
    }
    public class MapScene : Scene
    {
        private char[,] maze;
        private int playerX;
        private int playerY;
        private List<(int x, int y)> monsters;
        private List<(int x, int y)> goals;
        private List<(int x, int y)> potions;
        private Player player;
        private string mapName;
        private MapData mapData;

        private int currentMapIndex = 0;
        private static readonly List<Func<MapData>> maps = new List<Func<MapData>>
        {
            Maps.Map1,
            Maps.Map2,
            Maps.Map3
        };

        public MapScene(Game game, Player player) : base(game)
        {
            this.player = player;
            LoadMap(currentMapIndex);
        }

        public void SetMapData(MapData data)
        {
            mapData = data;
        }

        private void LoadMap(int index)
        {
            var mapData = maps[index]();
            this.maze = mapData.Maze;
            this.monsters = mapData.Monsters;
            this.goals = mapData.Goals;
            this.potions = mapData.Potions;
            this.mapName = mapData.MapName;
            playerX = 1;
            playerY = 1;
        }

        public override void Enter()
        {
            playerX = 1;
            playerY = 1;
        }

        public override void Render()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mapName);
            Console.ResetColor();

            char[,] displayMaze = (char[,])maze.Clone();

            foreach (var p in potions)
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
                        Console.Write(displayMaze[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
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

        protected virtual void CheckForGoal()
        {
            foreach (var goal in goals)
            {
                if (playerX == goal.x && playerY == goal.y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{mapName} 탈출에 성공하였습니다!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    LoadNextMap();
                    break;
                }
            }
        }

        private void LoadNextMap()
        {
            currentMapIndex++;
            if (currentMapIndex < maps.Count)
            {
                LoadMap(currentMapIndex);
            }
            else
            {
                Console.WriteLine("모든 맵을 클리어했습니다!");
                game.ChangeScene(SceneType.Clear);
            }
        }

        private void CheckForPotion()
        {
            for (int i = 0; i < potions.Count; i++)
            {
                if (playerX == potions[i].x && playerY == potions[i].y)
                {
                    player.AddPotionToInventory(new Potion("초급 포션", 30));

                    potions.RemoveAt(i);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("초급포션을 획득했습니다! 인벤토리에 추가되었습니다.");
                    Console.ResetColor();
                    Thread.Sleep(2000);

                    break;
                }
            }
        }

        public override void Exit()
        {

        }
    }
}
