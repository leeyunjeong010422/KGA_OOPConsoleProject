using OOPConsoleProject.Players;
using OOPConsoleProject.PoketMonsters;
using OOPConsoleProject.Scenes;
using System.Threading;

namespace OOPConsoleProject
{
    public class Game
    {
        private bool isRunning;

        private Scene[] scenes;
        private Scene curScene;
        public Scene CurScene { get { return curScene; } }

        public Player player;
        public Player Player { get { return player; } set { player = value; } }

        private PoketMonster poketMonster;
        public PoketMonster PoketMonster { get { return poketMonster; } set { poketMonster = value; } }

        public Game()
        {
            
        }

     

        public void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            End();
        }

        private Scene prevScene;
        public void ChangeScene(SceneType sceneType)
        {
            if (curScene != null)
            {
                curScene.Exit();
                prevScene = curScene;
            }
            curScene = scenes[(int)sceneType];
            curScene.Enter();
        }

        public void EndBattle()
        {
            //Console.WriteLine($"현재: {curScene}, 이전: {prevScene}");
            if (prevScene != null)
            {
                curScene.Exit();
                curScene = prevScene; 
                curScene.Enter();
            }
            else
            {               
                ChangeScene(SceneType.Title);
            }
        }

        public void Over()
        {
            isRunning = false;
        }

        private void Start()
        {
            player = new Player();
            poketMonster = new PoketMonster();

            isRunning = true;

            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Select] = new SelectScene(this, player);
            scenes[(int)SceneType.Map] = new MapScene(this, player);
            scenes[(int)SceneType.Map1] = new MapScene1(this);
            scenes[(int)SceneType.Battle] = new BattleScene(this);
            scenes[(int)SceneType.Inventory] = new InventoryScene(this, player);
            scenes[(int)SceneType.Shop] = new ShopScene(this, player);
            scenes[(int)SceneType.GameOver] = new GameOverScene(this);

            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
        }

        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }


    }
}
