using BlackJackGrupp;
using System.ComponentModel.Design;
using System.Text.Json;

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

    /*if (choice == 3)
    {
        Console.WriteLine("---fel kort---"); //metodanrop för regler*/
    else if (choice == 3)
    {
        Console.WriteLine("===== SPELREGLER BLACKJACK =====");

        Console.WriteLine();
        Console.WriteLine("Målet med spelet är att komma så nära 21 som möjligt utan att gå över 21.");

        Console.WriteLine();
        Console.WriteLine("--- KORTENS VÄRDE ---");
        Console.WriteLine("Kort 2-10 är värda sin siffra.");
        Console.WriteLine("Knekt, dam och kung är värda 10.");
        Console.WriteLine("Ess är värt 1 eller 11.");

        Console.WriteLine();
        Console.WriteLine("--- SÅ SPELAR DU ---");
        Console.WriteLine("1. Spelaren lägger en insats.");
        Console.WriteLine("2. Spelaren och dealern får två kort var.");
        Console.WriteLine("3. Spelarens kort är uppvända.");
        Console.WriteLine("4. Dealern har ett uppvänt och ett dolt kort.");

        Console.WriteLine();
        Console.WriteLine("--- SPELETS GÅNG ---");
        Console.WriteLine("Du väljer om du vill dra ett kort eller stanna.");
        Console.WriteLine("Du får dra kort tills du stannar eller kommer över 21.");
        Console.WriteLine("Går du över 21 förlorar du direkt.");

        Console.WriteLine();
        Console.WriteLine("--- DEALERN ---");
        Console.WriteLine("Dealern vänder upp sitt dolda kort.");
        Console.WriteLine("Dealern drar kort tills summan är minst 17.");
        Console.WriteLine("Går dealern över 21 vinner spelaren.");

        Console.WriteLine();
        Console.WriteLine("--- VINST ---");
        Console.WriteLine("Den som kommer närmast 21 vinner.");
        Console.WriteLine("Vid lika resultat blir det oavgjort.");
        Console.WriteLine("Vid vinst får spelaren tillbaka sin insats");
        Console.WriteLine("samt lika mycket till i vinst.");

        Console.WriteLine();
        Console.WriteLine("Tryck på Enter för att återgå till menyn.");
        Console.ReadLine();
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
