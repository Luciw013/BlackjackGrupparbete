namespace BlackJackGrupp
{
    public class Card
    {
        public string CardSymbol { get; set; }
        public string CardName { get; set; }
        public int Value { get; set; }

        public Card(string cardSymbol, string cardName, int value)
        {
            CardSymbol = cardSymbol;
            CardName = cardName;
            Value = value;
        }
    }
}

