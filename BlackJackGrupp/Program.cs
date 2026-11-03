using System.ComponentModel.Design;
//using System.Text.Json;

//string jsonFileToplist = File.ReadAllText("Toplist.json");
//lista för Toplist resultat här

int choice = int.Parse(Console.ReadLine());
while (true)
{ 
    Console.WriteLine("=== Blackjack ===");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Topplista");
    Console.WriteLine("3. Regler");
    Console.WriteLine("4. Avsluta");
    Console.WriteLine("Skriv in ditt namn: ");
    string Name = Console.ReadLine();
    Console.WriteLine($"Ditt namn: {Name}");
    Console.WriteLine($"Du har: -- kr");  // eventuellt ersätt -- med variabel för spelarens aktuella saldo. 
    Console.WriteLine($"Ange insats (1-maxbelopp kr)"); //ersätt "maxbelopp" med variabel för aktuellt saldo
    

    if (choice == 1)
    {
        //metodanrop för spela
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











Menu();
