namespace BlackJackGrupp
{
    public class Player
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Skriv in giltigt namn");
                }
            }
        }
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    Console.WriteLine("Saldot kan inte vara negativt.");
                }
            }
        }
        private int roundsPlayed = 0;
        public int RoundsPlayed
        {
            get { return roundsPlayed; }
            set
            {
                if (value >= 0)
                {
                    roundsPlayed = value;
                }
                else
                {
                    Console.WriteLine("Rundan kan inte vara negativt.");
                }
            }
        }


        public Player(string name)   //konstruktorn
        {
            Name = name;
        }




        public bool PlaceBet(decimal amount)
        {
            if (amount < 1 || amount > Balance) //Spelaren kan inte satsa mindre än 1 eller mer än saldo
            {
                Console.WriteLine("Du kan satsa som minst 1kr, som högst ditt saldo");
                return false;
            }
            Balance -= amount;
            Console.WriteLine($"Du har satsat: {amount} kr");
            return true;
        }

        public void AddMoney(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Beloppet måste vara större än 0.");
            }
        }
    }
}

