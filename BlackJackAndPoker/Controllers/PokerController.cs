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

    }
}
