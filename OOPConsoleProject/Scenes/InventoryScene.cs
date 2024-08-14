﻿using OOPConsoleProject.Players;

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
            Console.Clear();
            Console.WriteLine("인벤토리를 열고 있습니다.");
            Thread.Sleep(2000);
            Console.Clear();
            ShowInventory();
            Console.WriteLine();
            ShowGearInventory();
            Console.WriteLine("아무 키나 입력하면 계속 진행됩니다.");
            Console.ReadKey();
            curState = State.Choice;
            Render();
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            input = Console.ReadLine();
            Update();
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Choice)
            {
                Console.WriteLine("무엇을 하시겠습니까?");
                Console.Write("[ 1. 포션 먹기(hp 회복) | 2. 장비 착용하기(방어력 증가) | 3. 돌아가기 ]: ");
            }
            else if (curState == State.PotionEffect)
            {
                ShowInventory();
                PromptPotionSelection();
            }
            else if (curState == State.EquipGear)
            {
                ShowGearInventory();
                PromptGearSelection();
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
                    game.ChangeScene(SceneType.Return);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                    Render();
                }
            }
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
                Thread.Sleep(2000);
                curState = State.Choice;
                Render();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("사용할 포션을 선택하세요");
            for (int i = 0; i < player.inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.inventory[i].name} (회복량: {player.inventory[i].hp})");
            }
            Console.WriteLine("0. 사용하지 않고 나가기");

            input = Console.ReadLine();

            if (input == "0")
            {
                curState = State.Choice;
                Render();
            }
            else if (int.TryParse(input, out int index) && index >= 1 && index <= player.inventory.Count)
            {
                UsePotion(index - 1);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                PromptPotionSelection();
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
            Console.WriteLine($"{potion.name}을(를) 사용했습니다. 현재 체력: {game.player.CurHP}");
            Thread.Sleep(2000);

            curState = State.Choice; 
            Render();
        }

        public void PromptGearSelection()
        {
            if (player.gearInventory.Count == 0)
            {
                Console.WriteLine("인벤토리에 방어구가 없습니다.");
                Thread.Sleep(2000);
                curState = State.Choice; 
                Render();
                return;
            }

            Console.WriteLine("장착할 방어구를 선택하세요:");
            for (int i = 0; i < player.gearInventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.gearInventory[i].name} (방어력: {player.gearInventory[i].defensivePower})");
            }
            Console.WriteLine("0. 장착하지 않고 나가기");

            input = Console.ReadLine();

            if (input == "0")
            {
                curState = State.Choice;
                Render();
            }
            else if (int.TryParse(input, out int index) && index >= 1 && index <= player.gearInventory.Count)
            {
                EquipGear(index - 1);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                PromptGearSelection();
            }
        }

        public void EquipGear(int index)
        {
            var gear = player.gearInventory[index];
            game.player.Defense += gear.defensivePower;

            player.gearInventory.RemoveAt(index);
            Console.WriteLine($"{gear.name}을(를) 장착했습니다. 현재 방어력: {game.player.Defense}");
            Thread.Sleep(2000);

            curState = State.Choice;
            Render();
        }
    }
}
