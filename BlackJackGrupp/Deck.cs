using System;
using System.Linq;

namespace BlackJackGrupp
{
    public class Deck
    {
        private List<Card> cards = new();

        public Deck()
        {
            CreateDeck(); //varje nytt objekt startar med 52 kort
        }

        public void CreateDeck() // Skapar en ny kortlek med 52 kort när objektet skapas
        {

            cards.Clear(); //Nollställer kortleken så den kan shuffla 52 nya igen

            string[] cardSymbols = { "Hjärter", "Ruter", "Klöver", "Spader" };

            List<string> cardNames = new List<string>()
            {
                "[Ess]", "[2]", "[3]", "[4]", "[5]","[6]", "[7]", "[8]", "[9]", "[10]","[Knekt]", "[Dam]", "[Kung]"
            };


            List<int> cardValues = new List<int>()
        {
            11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10
        };

            foreach (string symbol in cardSymbols) //loopar igenom alla symboler
            {
                for (int i = 0; i < cardNames.Count; i++) //loopar kortnamnen in i varje symbol
                {
                    Card newCard = new Card(symbol, cardNames[i], cardValues[i]); // skapar ett kort med färg, namn och värdet

                    cards.Add(newCard); //läggs till i listan

                }
            }
        }
        public void ShuffleCards()
        {
            Random random = new Random();
            cards = cards.OrderBy(card => random.Next()).ToList();  //sorterar korten efter ett slumpmässigt värde
        }

        public int CardsLeft()  //Visar hur många kort som finns kvar i kortleken
        {
            return cards.Count;  
        }

        public Card DrawCard()  
        {
            Card drawnCard = cards[0];
            cards.RemoveAt(0);

            return drawnCard;
        }


    }
}