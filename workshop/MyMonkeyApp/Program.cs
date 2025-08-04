using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;

namespace MyMonkeyApp;

internal class Program
{
    private static void Main(string[] args)
    {
        DisplayWelcome();
        
        bool running = true;
        while (running)
        {
            try
            {
                DisplayMenu();
                string? choice = Console.ReadLine();
                
                switch (choice?.ToLower())
                {
                    case "1":
                        DisplayAllMonkeys();
                        break;
                    case "2":
                        SearchMonkeyByName();
                        break;
                    case "3":
                        DisplayRandomMonkey();
                        break;
                    case "4":
                    case "q":
                    case "quit":
                        running = false;
                        Console.WriteLine("🐵 원숭이 탐험을 마칩니다. 안녕히 가세요!");
                        break;
                    default:
                        Console.WriteLine("❗ 잘못된 선택입니다. 다시 시도해주세요.");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❗ 오류가 발생했습니다: {ex.Message}");
                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
            }
        }
    }

    private static void DisplayWelcome()
    {
        Console.Clear();
        Console.WriteLine(@"
🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳
🌳                                      🌳
🌳        🐵 원숭이 탐험가에 오신 것을     🌳
🌳           환영합니다! 🦍            🌳
🌳                                      🌳
🌳   세계의 다양한 원숭이들을 만나보세요!    🌳
🌳                                      🌳
🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳🌳
");
        Console.WriteLine();
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        DisplayWelcome();
        Console.WriteLine("📋 메뉴를 선택하세요:");
        Console.WriteLine();
        Console.WriteLine("1️⃣  모든 원숭이 목록 보기");
        Console.WriteLine("2️⃣  이름으로 원숭이 찾기");
        Console.WriteLine("3️⃣  무작위 원숭이 선택");
        Console.WriteLine("4️⃣  종료");
        Console.WriteLine();
        Console.Write("선택: ");
    }

    private static void DisplayAllMonkeys()
    {
        Console.Clear();
        Console.WriteLine("🌍 전 세계의 원숭이들:");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine();

        List<Monkey> monkeys = MonkeyHelper.GetAllMonkeys();
        
        for (int i = 0; i < monkeys.Count; i++)
        {
            Monkey monkey = monkeys[i];
            Console.WriteLine($"{i + 1}. {monkey.Name}");
            Console.WriteLine($"   서식지: {monkey.Habitat}");
            Console.WriteLine($"   개체수: {monkey.Population:N0}마리");
            Console.WriteLine($"   크기: {monkey.Size}");
            Console.WriteLine();
        }
    }

    private static void SearchMonkeyByName()
    {
        Console.Clear();
        Console.WriteLine("🔍 원숭이 이름 검색:");
        Console.WriteLine(new string('=', 30));
        Console.WriteLine();
        
        Console.Write("찾고 싶은 원숭이의 이름을 입력하세요 (영어): ");
        string? name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("❗ 유효한 이름을 입력해주세요.");
            return;
        }

        Monkey? monkey = MonkeyHelper.GetMonkeyByName(name);
        
        if (monkey == null)
        {
            Console.WriteLine($"❌ '{name}' 이름의 원숭이를 찾을 수 없습니다.");
            Console.WriteLine();
            Console.WriteLine("💡 다음 이름들을 시도해보세요:");
            List<Monkey> allMonkeys = MonkeyHelper.GetAllMonkeys();
            foreach (Monkey m in allMonkeys)
            {
                Console.WriteLine($"   • {m.Name}");
            }
        }
        else
        {
            DisplayMonkeyDetails(monkey);
        }
    }

    private static void DisplayRandomMonkey()
    {
        Console.Clear();
        Console.WriteLine("🎲 무작위 원숭이 선택:");
        Console.WriteLine(new string('=', 30));
        Console.WriteLine();
        
        Console.WriteLine("원숭이를 선택하는 중...");
        
        // 약간의 서스펜스를 위한 지연
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }
        
        Console.WriteLine();
        Console.WriteLine();
        
        Monkey randomMonkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine("🎉 선택된 원숭이:");
        DisplayMonkeyDetails(randomMonkey);
    }

    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine();
        Console.WriteLine(monkey.AsciiArt);
        Console.WriteLine();
        Console.WriteLine($"🏷️  이름: {monkey.Name}");
        Console.WriteLine($"🌍 서식지: {monkey.Habitat}");
        Console.WriteLine($"👥 개체수: {monkey.Population:N0}마리");
        Console.WriteLine($"📏 크기: {monkey.Size}");
        Console.WriteLine($"🍎 식성: {monkey.Diet}");
        Console.WriteLine($"📝 설명: {monkey.Description}");
        Console.WriteLine();
    }
}
