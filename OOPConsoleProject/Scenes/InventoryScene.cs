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
            Console.Clear();
            ShowInventory();
            Console.WriteLine();
            PromptPotionSelection();

        }

        public override void Exit()
        {
            //game.ChangeScene(SceneType.Shop);
        }

        public override void Input()
        {
            
        }

        public override void Render()
        {

        }

        public override void Update()
        {

        }

        public void ShowInventory()
        {
            Console.WriteLine("<포션 인벤토리>");
            foreach (var item in player.inventory)
            {
                Console.WriteLine($"{item.name} (회복량: {item.hp})");
            }
        }

        public void ShowGearInventory()
        {
            Console.WriteLine("<방어구 인벤토리>");
            foreach (var gear in player.gearInventory)
            {
                Console.WriteLine($"{gear.name} (방어력: {gear.defensivePower})");
            }
        }

        public void PromptPotionSelection()
        {
            if (player.inventory.Count == 0)
            {
                Console.WriteLine("인벤토리에 포션이 없습니다.");
                game?.EndBattle();
                return;
            }

            Console.WriteLine("사용할 포션을 선택하세요");

            for (int i = 0; i < player.inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.inventory[i].name} (회복량: {player.inventory[i].hp})");
            }
            Console.WriteLine("0. 사용하지 않고 나가기");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D0)
            {
                Console.WriteLine("포션 사용이 취소되었습니다. 되돌아 갑니다.");
                Thread.Sleep(2000);
                game.ChangeScene(SceneType.Shop);
                return;
            }

            int index = (int)key - (int)ConsoleKey.D1;

            if (index >= 0 && index < player.inventory.Count)
            {
                UsePotion(index);
                Console.WriteLine();
                PromptPotionSelection();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine();
                PromptPotionSelection();
            }
        }

        public void UsePotion(int index)
        {
            if (index >= 0 && index < player.inventory.Count)
            {
                var potion = player.inventory[index];
                game.player.CurHP += potion.hp;

                if (game.player.CurHP > game.player.MaxHP)
                {
                    game.player.CurHP = game.player.MaxHP;
                }

                player.inventory.RemoveAt(index);
                Console.WriteLine($"{potion.name}을(를) 사용했습니다. 현재 체력: {game.player.CurHP}");
                Console.WriteLine();

                if (player.inventory.Count == 0)
                {
                    Console.WriteLine("인벤토리에 더 이상 포션이 없습니다.");
                    Thread.Sleep(2000);
                    game.EndBattle(); 
                }
                else
                {
                    Console.WriteLine();
                    PromptPotionSelection(); 
                }

            }
            else
            {
                Console.WriteLine("잘못된 포션 인덱스입니다.");
            }
        }

        public void PromptGearSelection()
        {
            if (player.gearInventory.Count == 0)
            {
                Console.WriteLine("인벤토리에 방어구가 없습니다.");
                game?.EndBattle();
                return;
            }

            Console.WriteLine("장착할 방어구를 선택하세요");

            for (int i = 0; i < player.gearInventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.gearInventory[i].name} (방어력: {player.gearInventory[i].defensivePower})");
            }
            Console.WriteLine("0. 장착하지 않고 나가기");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D0)
            {
                Console.WriteLine("방어구 장착이 취소되었습니다. 되돌아 갑니다.");
                Thread.Sleep(2000);
                game.ChangeScene(SceneType.Shop);
                return;
            }

            int index = (int)key - (int)ConsoleKey.D1;

            if (index >= 0 && index < player.gearInventory.Count)
            {
                EquipGear(index);
                Console.WriteLine();
                PromptGearSelection();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine();
                PromptGearSelection();
            }
        }

        public void EquipGear(int index)
        {
            if (index >= 0 && index < player.gearInventory.Count)
            {
                var gear = player.gearInventory[index];
                game.player.Defense += gear.defensivePower;

                player.gearInventory.RemoveAt(index);
                Console.WriteLine($"{gear.name}을(를) 장착했습니다. 현재 방어력: {game.player.Defense}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("잘못된 방어구 인덱스입니다.");
            }
        }
    }
}
