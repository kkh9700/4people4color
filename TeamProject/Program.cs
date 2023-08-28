using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace TeamProject
{
    internal class Program
    {
        private static Character player;
        private static Item[] inverntory;
        private static int ItemCount;
        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 인벤토리 생성
            inverntory = new Item[10];

            // 아이템 추가
            AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 5));
            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0));
        }

        static void AddItem(Item item)
        {
            inventory[ItemCount] = item;
            ++ItemCount;
        }

        static void EquipItem(Item item)
        {
            item.IsEquiped = true;
        }

        static void UnequipItem(Item item)
        {
            item.IsEquiped = false;
        }

        static int GetItemAtkAmount()
        {
            int itemAtk = 0;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                    break;

                ItemCount curItem = inventory[i];

                if (curItem.IsEquiped)
                    itemAtk += curItem.Atk;
            }
            return itemAtk;
        }

        static int GetItemDefAmount()
        {
            int itemDef = 0;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                    break;

                ItemCount curItem = inventory[i];

                if (curItem.IsEquiped)
                    itemDef += curItem.Def;
            }
            return itemDef;
        }

        static void DisplayGameIntro()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayBattle();
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();
            DisplayTitle("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");

            int itemAtk = GetItemAtkAmount();
            Console.Write($"공격력 : {player.Atk + itemAtk}");
            if (itemAtk != 0)
                Console.Write($"(+{itemAtk})");
            Console.WriteLine();

            int itemDef = GetItemDefAmount();
            Console.Write($"방어력 : {player.Def + itemDef}");
            if (itemDef != 0)
                Console.Write($"(+{itemDef})");
            Console.WriteLine();

            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }
                DisplayError("잘못된 입력입니다.");
            }
        }

        static void DisplayTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        static void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

    }

    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    public class Item
    {
        public string Name { get; }
        public string Description { get; }

        public int Atk { get; }
        public int Def { get; }

        public bool IsEquiped { get; set; }

        public Item(string name, string description, int atk, int def)
        {
            Name = name;
            Description = description;
            Atk = atk;
            Def = def;

            IsEquiped = false;
        }
    }


}