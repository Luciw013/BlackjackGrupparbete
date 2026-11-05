using System;
using System.Collections.Generic;

namespace BlackJackGrupp
{
    public class Game
    {
        private Deck deck;
        private Player player;
        private List<Card> playerCards = new();
        private List<Card> dealerCards = new();
        public decimal FinalBalance => player.Balance;      //hämtar aktuellt spelar-saldo
        public int RoundsPlayed => player.RoundsPlayed;     //hämtar antal spelade rundor. (pil istället för get{return...}


        public Game(string name)
        {
            deck = new Deck();
            deck.ShuffleCards();

            player = new Player(name);

            player.Balance = 100;
        }


        public void StartRound()
        {
            if (deck.CardsLeft() < 15)
            {
                deck.CreateDeck();
                deck.ShuffleCards();
            }

            playerCards.Clear();
            dealerCards.Clear();

            playerCards.Add(deck.DrawCard());
            dealerCards.Add(deck.DrawCard());

            playerCards.Add(deck.DrawCard());
            dealerCards.Add(deck.DrawCard());
        }

        public int CalculateHandValue(List<Card> hand)
        {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in hand)
            {
                total += card.Value;

                if (card.CardName == "Ess")
                {
                    aceCount++;
                }
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }


        public void ShowPlayerCards()
        {
            Console.WriteLine("Dina kort:");

            foreach (Card card in playerCards)
            {
                Console.WriteLine($"{card.CardSymbol}  {card.CardName}");
            }
            Console.WriteLine($"Dina Poäng: {CalculateHandValue(playerCards)}");
        }

        public void ShowDealerCard()
        {
            Console.WriteLine("Dealerns uppvända kort:");
            Console.WriteLine($"{dealerCards[0].CardSymbol} {dealerCards[0].CardName} ");
        }

        public void PlayerTurn()
        {
            bool keepPlaying = true;

            while (keepPlaying && CalculateHandValue(playerCards) < 21)
            {
                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");

                string choice = Console.ReadLine() ?? "";

                if (choice == "1")
                {
                    playerCards.Add(deck.DrawCard());
                }
                else if (choice == "2")
                {
                    keepPlaying = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
        }

        // Hanterar dealerns tur
        public void DealerTurn()
        {
            while (CalculateHandValue(dealerCards) < 17)
            {
                dealerCards.Add(deck.DrawCard());
            }
        }

        public void PlayGame()
        {
            while (player.Balance >= 1)
            {
                Console.WriteLine($"Du har {player.Balance} kr.");
                Console.Write("Ange insats: ");
                
                
                decimal bet;

                if (!decimal.TryParse(Console.ReadLine(), out bet) || !player.PlaceBet(bet))
                {
                    continue;
                }

                StartRound();

                ShowDealerCard();
                Console.WriteLine("[?]");

                ShowPlayerCards();

                PlayerTurn();

                if (CalculateHandValue(playerCards) <= 21)
                {
                    DealerTurn();
                }

                Console.WriteLine("Dealerns kort:");

                foreach (Card card in dealerCards)
                {
                    Console.WriteLine($"{card.CardName} {card.CardSymbol}");
                }

                int playerPoints = CalculateHandValue(playerCards);
                int dealerPoints = CalculateHandValue(dealerCards);

                if (playerPoints > 21 && player.Balance == 0)
                {
                    Console.WriteLine("Du är pank!");
                    Console.WriteLine("GAME OVER");
                }
                else if(playerPoints > 21)
                {
                    Console.WriteLine("Du förlorade...");
                }
                else if (dealerPoints > 21 || playerPoints > dealerPoints)
                {
                    player.AddMoney(bet * 2);
                    Console.WriteLine($"Du vann {bet} kr!");
                }
                else if (playerPoints == dealerPoints)
                {
                    player.AddMoney(bet);
                    Console.WriteLine("Oavgjort!");
                }
                else
                {
                    Console.WriteLine("Dealern vann!");
                    Console.WriteLine($"Dealerns Poäng: {CalculateHandValue(dealerCards)}");
                }

                player.RoundsPlayed++;

                Console.WriteLine($"Ditt saldo: {player.Balance} kr");

                Console.Write("Spela igen? (j/n): ");

                if (Console.ReadLine()?.ToLower() != "j")
                {
                    break;
                }
            }
        }
    }
}