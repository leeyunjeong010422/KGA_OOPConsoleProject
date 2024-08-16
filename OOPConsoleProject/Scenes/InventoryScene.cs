using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class InventoryScene : Scene
    {
        public enum State { Choice, PotionEffect, EquipGear }
        private State curState;

        private string input;

        private Game game;
        private Player player;

        public InventoryScene(Game game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
        }

        public override void Enter()
        {
            input = 0.ToString();
            Console.Clear();
            Console.WriteLine("인벤토리를 열고 있습니다.");
            Thread.Sleep(2000);
            Console.Clear();
            ShowInventory();
            Console.WriteLine();
            ShowGearInventory();
            Console.WriteLine();
            Console.WriteLine("[ 아무 키나 입력하면 계속 진행됩니다. ]");
            Console.ReadKey();
            curState = State.Choice;
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Choice)
            {
                Console.WriteLine("무엇을 하시겠습니까?");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[ 1. 포션 먹기(hp 회복) | 2. 장비 착용하기(방어력 증가) | 3. 돌아가기 ]: ");
                Console.ResetColor();
            }
            else if (curState == State.PotionEffect)
            {
                Console.WriteLine("<사용할 포션을 선택하세요>");
                Console.WriteLine();

                for (int i = 0; i < player.inventory.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i + 1}. {player.inventory[i].name} (회복량: {player.inventory[i].hp})");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("[ 사용하지 않고 나가기 (0) ]");
                Console.WriteLine();
                Console.Write("선택하기: ");
            }
            else if (curState == State.EquipGear)
            {
                Console.WriteLine("<장착할 방어구를 선택하세요>");
                Console.WriteLine();

                for (int i = 0; i < player.gearInventory.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i + 1}. {player.gearInventory[i].name} (방어력: {player.gearInventory[i].defensivePower})");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("[ 사용하지 않고 나가기 (0) ]");
                Console.WriteLine();
                Console.Write("선택하기: ");
            }
        }

        public override void Update()
        {
            if (curState == State.Choice)
            {
                if (string.IsNullOrEmpty(input))
                    return;

                if (input == "1")
                {
                    curState = State.PotionEffect;
                }
                else if (input == "2")
                {
                    curState = State.EquipGear;
                }
                else if (input == "3")
                {
                    //game.ChangeScene(SceneType.Return);
                    game.EndBattle();
                }
            }
            else if (curState == State.PotionEffect)
            {
                if (input == "0")
                {
                    curState = State.Choice;
                }

                else if (int.TryParse(input, out int index) && index >= 1 && index <= player.inventory.Count)
                {
                    UsePotion(index - 1);
                    curState = State.Choice;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                }
            }
            else if (curState == State.EquipGear)
            {
                if (input == "0")
                {
                    curState = State.Choice;
                }
                else if (int.TryParse(input, out int index) && index >= 1 && index <= player.gearInventory.Count)
                {
                    EquipGear(index - 1);
                    curState = State.Choice;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                }
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("<포션 인벤토리>");
            PromptPotionSelection();
            Console.WriteLine();
            foreach (var item in player.inventory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{item.name} (회복량: {item.hp})");
                Console.ResetColor();
            }
        }

        public void ShowGearInventory()
        {
            Console.WriteLine("<방어구 인벤토리>");
            PromptGearSelection();
            Console.WriteLine();
            foreach (var gear in player.gearInventory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{gear.name} (방어력: {gear.defensivePower})");
                Console.ResetColor();
            }
        }

        public void UsePotion(int index)
        {
            var potion = player.inventory[index];
            game.player.CurHP += potion.hp;

            if (game.player.CurHP > game.player.MaxHP)
            {
                game.player.CurHP = game.player.MaxHP;
            }

            player.inventory.RemoveAt(index);
            Console.WriteLine();
            Console.WriteLine($"{potion.name}을(를) 사용했습니다.");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"현재 체력: {game.player.CurHP}");
            Console.ResetColor();
            Thread.Sleep(2000);

            curState = State.Choice;
        }
        public void EquipGear(int index)
        {
            var gear = player.gearInventory[index];
            game.player.Defense += gear.defensivePower;

            player.gearInventory.RemoveAt(index);
            Console.WriteLine();
            Console.WriteLine($"{gear.name}을(를) 장착했습니다.");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"현재 방어력: {game.player.Defense}");
            Console.ResetColor();
            Thread.Sleep(2000);

            curState = State.Choice;
        }

        public void PromptPotionSelection()
        {
            if (player.inventory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("인벤토리에 포션이 없습니다.");
                Console.ResetColor();
                Thread.Sleep(1000);
                curState = State.Choice;
                return;
            }

        }

        public void PromptGearSelection()
        {
            if (player.gearInventory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("인벤토리에 방어구가 없습니다.");
                Console.ResetColor();
                Thread.Sleep(1000);
                curState = State.Choice;
                return;
            }
        }
    }
}
