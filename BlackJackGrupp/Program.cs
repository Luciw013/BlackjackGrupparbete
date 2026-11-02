using System.ComponentModel.Design;
void Menu()
{
    Console.WriteLine("=== Blackjack ===");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Topplista");
    Console.WriteLine("3. Regler");
    Console.WriteLine("4. Avsluta");

    Console.WriteLine("Skriv in ditt namn: ");
    string Name = Console.ReadLine();
    Console.WriteLine($"Ditt namn: {Name}");
}

Menu();