
namespace BlackJackGrupp
{
    public class Deck
    {
        private List<Card> cards = new();

        public Deck()
        {
            string[] cardSymbols = { "Hjärter", "Ruter", "Klöver", "Spader" };

            List<string> cardNames = new List<string>()
            {
                "Ess", "Två", "Tre", "Fyra", "Fem","Sex", "Sju", "Åtta", "Nio", "Tio","Knekt", "Dam", "Kung"
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
    }
}
