using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.Controllers
{
    public class PokerController
    {
        private int moneyPot;
        private int currentBet;
        private Deck deck;
        public List<ICardPlayer> Players { get; private set; }

        public PokerController()
        {
            Players = new List<ICardPlayer>();

        }

        public void StartGame<T>(int amountOfPlayers = 2) where T : ICardPlayer, new()
        {
            RemakeDeck();
            Players.Clear();
            for (int i = 0; i < amountOfPlayers; i++)
            {
                var player = new T()
                {
                    //Start with 100 dollars at the beginning of the game
                    AmountOfMonies = 100
                };
                Players.Add(player);
            }

            currentBet = 0;

            Ante();
            Deal();
        }

        /// <summary>
        /// Creates a new deck and shuffles it for the new game
        /// </summary>
        private void RemakeDeck()
        {
            deck = new Deck();
            deck.ShuffleCards();
        }

        private void Deal()
        {
            for(int i = 0; i < 5; i++)
            {
                foreach(ICardPlayer player in Players)
                {
                    player.Hand.Add(deck.DrawCard());
                }
            }
        }

        public void Discard(ICardPlayer player, List<Card> discardedCards)
        {
            foreach(Card card in discardedCards)
            {
                player.Hand.Remove(card);
                player.Hand.Add(deck.DrawCard());
            }
        }

        public void Ante()
        {
            foreach(ICardPlayer player in Players)
            {
                player.AmountOfMonies -= 10;
                moneyPot += 10;
            }
        }

        public void Call(ICardPlayer player)
        {
            player.AmountOfMonies -= (currentBet - player.LastBet);
            moneyPot += (currentBet - player.LastBet);

            player.LastBet = currentBet;

            //Prevents going into the negative when going all in on a high raise
            if (player.AmountOfMonies < 0)
            {
                player.AmountOfMonies = 0;
            }
        }

        public void AllIn(ICardPlayer player)
        {
            moneyPot += player.AmountOfMonies;
            player.AmountOfMonies = 0;
        }

        public void Raise(ICardPlayer player, int raiseAmount)
        {
            currentBet = raiseAmount;
            Call(player);
        }

        public void EndBettingPhase()
        {
            currentBet = 0;
            
            foreach (ICardPlayer player in Players)
            {
                player.LastBet = 0;
            }
        }
    }
}
