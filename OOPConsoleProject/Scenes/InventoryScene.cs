using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class InventoryScene : Scene
    {
        private Game game;
        private Player player;

        public InventoryScene(Game game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
        }

        public override void Enter()
        {
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("인벤토리를 열고 있습니다.");
            Thread.Sleep(2000);
            player.ShowInventory();
            PromptPotionSelection();
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            // 인벤토리 입력 처리 로직을 여기에 추가할 수 있습니다.
        }

        public override void Render()
        {

        }

        public override void Update()
        {

        }

        private void PromptPotionSelection()
        {
            if (player.inventory.Count == 0)
            {
                Console.WriteLine("인벤토리에 포션이 없습니다.");
                game.EndBattle();
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("사용할 포션을 선택하세요:");

            for (int i = 0; i < player.inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.inventory[i].name} (회복량: {player.inventory[i].hp})");
            }
            Console.WriteLine("0. 취소");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D0)
            {
                Console.WriteLine("포션 사용이 취소되었습니다.");
                game.EndBattle();
            }

            int index = (int)key - (int)ConsoleKey.D1;

            if (index >= 0 && index < player.inventory.Count)
            {
                UsePotion(index);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(2000);
                PromptPotionSelection();
            }
        }

        private void UsePotion(int index)
        {
            var potion = player.inventory[index];
            Console.WriteLine($"{potion.name}을(를) 사용합니다.");
            player.CurHP += potion.hp;
            player.inventory.RemoveAt(index); 
            Console.WriteLine($"현재 체력: {player.CurHP}");
            game.EndBattle();
            Thread.Sleep(2000);
        }
    }
}
