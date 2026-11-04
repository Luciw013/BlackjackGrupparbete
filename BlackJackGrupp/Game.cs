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
                Console.WriteLine($"{card.CardName} i {card.CardSymbol}");
            }

            Console.WriteLine($"Poäng: {CalculateHandValue(playerCards)}");
        }

        public void ShowDealerCard()
        {
            Console.WriteLine("Dealerns uppvända kort:");
            Console.WriteLine($"{dealerCards[0].CardName} i {dealerCards[0].CardSymbol}");
        }

        public void PlayerTurn()
        {
            bool keepPlaying = true;

            while (keepPlaying && CalculateHandValue(playerCards) < 21)
            {
                ShowPlayerCards();

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
    }
}