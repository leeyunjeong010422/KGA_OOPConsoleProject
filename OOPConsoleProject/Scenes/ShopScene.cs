using OOPConsoleProject.Players;
using OOPConsoleProject;

namespace OOPConsoleProject.Scenes
{
    public class ShopScene : Scene
    {
        public enum State { Buying, Inventory, Confirm, Exit }
        private State curState;

        private Game game;
        private Player player;

        public ShopScene(Game game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
        }

        public override void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("상점에 들어갑니다");
            Thread.Sleep(2000);
            curState = State.Buying;
        }

        public override void Exit()
        {
            Console.WriteLine("상점을 나갑니다");
            Console.WriteLine("아무 키나 눌러서 계속하세요");
        }

        public override void Input()
        {
            string input = Console.ReadLine();
            ProcessInput(input);
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Buying)
            {
                Console.Write("[ 1. 물건 구입하기 | 2. 인벤토리 확인하기 | 3. 돌아가기 ]: ");
            }
            else if (curState == State.Confirm)
            {
                Console.WriteLine("메인 메뉴로 돌아갑니다.");
                Console.WriteLine("아무 키나 눌러서 계속하세요");
                curState = State.Buying; 
            }
            else if (curState == State.Exit)
            {
                game.EndBattle();
            }
        }

        public override void Update()
        {

        }   

        private void ProcessInput(string input)
        {
            switch (input)
            {
                case "1":
                    curState = State.Buying; 
                    ShowPotionOptions();
                    break;
                case "2":
                    game.ChangeScene(SceneType.Inventory); 
                    break;
                case "3":
                    curState = State.Exit;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                    break;
            }
        }

        private void ShowPotionOptions()
        {
            Console.Clear();
            Console.WriteLine("구입할 포션을 선택하세요:");
            Console.WriteLine("1. 초급포션 - 1000골드");
            Console.WriteLine("2. 중급포션 - 2000골드");
            Console.WriteLine("3. 고급포션 - 3000골드");
            Console.Write("구입할 포션 번호: ");
            string potionInput = Console.ReadLine();
            BuyPotion(potionInput);
        }

        private void BuyPotion(string potionInput)
        {
            int price = 0;
            string potionName = "";

            switch (potionInput)
            {
                case "1":
                    potionName = "초급포션";
                    price = 1000;
                    break;
                case "2":
                    potionName = "중급포션";
                    price = 2000;
                    break;
                case "3":
                    potionName = "고급포션";
                    price = 3000;
                    break;
                default:
                    Console.WriteLine("잘못된 포션 번호입니다.");
                    return;
            }

            if (player.Gold >= price)
            {
                Item potion = ItemFactory.Instantiate(potionName);
                if (potion != null)
                {
                    player.Gold -= price;
                    player.AddItemToInventory(potion); 
                    Console.WriteLine($"{potionName}을(를) 구매하셨습니다.");  
                    Thread.Sleep(2000);
                    curState = State.Confirm;
                }
            }
            else
            {
                Console.WriteLine("골드가 부족합니다.");
                Thread.Sleep(2000);
            }
        }
    }
}
