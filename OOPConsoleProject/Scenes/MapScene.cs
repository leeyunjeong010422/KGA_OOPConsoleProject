using System;
using System.Collections.Generic;

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

        public MapScene(Game game) : base(game)
        {
            InitializeMaze();
            InitializeMonsters();
            InitializeGoal();
            playerX = 1; 
            playerY = 1; 
        }

        private void InitializeMaze()
        {
            maze = new char[,]
            {
                {'#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', '#', '#', '#'},
                {'#', ' ', '#', ' ', '#', '#'},
                {'#', ' ', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', ' ', '#'}
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
            Move(key);
        }

        public override void Render()
        {
            Console.Clear();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (i == playerY && j == playerX)
                        Console.Write("P ");
                    else
                        Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }
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
    }   
}
