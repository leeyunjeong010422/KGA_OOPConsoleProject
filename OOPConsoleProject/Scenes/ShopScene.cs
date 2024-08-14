using OOPConsoleProject.Players;

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
            curState = State.Buying;
        }

        public override void Exit()
        {
            Console.WriteLine("아무 키나 눌러서 상점을 나가세요.");
            curState = State.Exit;
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
                Console.WriteLine("아무 키나 눌러서 메인으로 돌아가세요.");
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
                    Exit();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    break;
            }
        }

        private void ShowPotionOptions()
        {
            Console.Clear();
            Console.WriteLine("구입할 물건을 선택하세요");
            Console.WriteLine("1. 초급포션 - 1000골드");
            Console.WriteLine("2. 중급포션 - 2000골드");
            Console.WriteLine("3. 고급포션 - 3000골드");
            Console.WriteLine("4. 맛있는 물 - 2000골드");
            Console.WriteLine("5. 미네랄 사이다 - 2000골드");
            Console.WriteLine("6. 후르츠밀크 - 2000골드");
            Console.Write("구입할 포션 번호: ");
            string potionInput = Console.ReadLine();
            BuyPotion(potionInput);
        }

        private void BuyPotion(string potionInput)
        {
            int price = 0;
            string itemName = "";

            switch (potionInput)
            {
                case "1":
                    itemName = "초급포션";
                    price = 1000;
                    break;
                case "2":
                    itemName = "중급포션";
                    price = 2000;
                    break;
                case "3":
                    itemName = "고급포션";
                    price = 3000;
                    break;
                case "4":
                    itemName = "맛있는 물";
                    price = 2000;
                    break;
                case "5":
                    itemName = "미네랄 사이다";
                    price = 2000;
                    break;
                case "6":
                    itemName = "후르츠밀크";
                    price = 2000;
                    break;
                default:
                    Console.WriteLine("잘못된 번호입니다.");
                    return;
            }

            if (player.Gold >= 0)
            {
                Item potion = ItemFactory.Instantiate(itemName);
                if (potion != null)
                {
                    game.player.Gold -= price;
                    player.AddItemToInventory(potion);
                    Console.WriteLine($"{itemName}을(를) 구매하였습니다.");
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
