using BlackJackGrupp;
using System.ComponentModel.Design;
//using System.Text.Json;

//string jsonFileToplist = File.ReadAllText("Toplist.json");
//lista för Toplist resultat här

while (true)
{
    Console.WriteLine("=== Blackjack ===");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Topplista");
    Console.WriteLine("3. Regler");
    Console.WriteLine("4. Avsluta");
    Console.Write("Val: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("Skriv in ditt namn: ");
        string name = Console.ReadLine();

        Game game = new Game(name);
        game.PlayGame();
    }

    else if (choice == 2)
    {
        Console.WriteLine("---Topplista---");
        //metodanrop visa topplista

    }

    if (choice == 3)
    {
        //metodanrop för regler
    }

    else if (choice == 4)
    {
        break;
    }

    else
    {
        Console.WriteLine("Ogiltigt val");
        return;
    }

    //infoga metod för spara json?? (se exempel ToDoApp)











}
