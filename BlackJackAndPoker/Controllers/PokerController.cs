using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackAndPoker.Controllers
{
    public class PokerController
    {
        private int moneyPot;
        private int currentBet;
        private Deck deck;
        public int CurrentPot
        {
            get
            {
                var MoneyPot = BetPool.Values.Aggregate((aggroValue, nextValue) => aggroValue + nextValue);
                return MoneyPot;
            }
        }
        private ICardPlayer _house;
        public ICardPlayer House => _house;
        public List<ICardPlayer> Players { get; private set; }
        public IDictionary<ICardPlayer, int> BetPool;

        public PokerController()
        {
            Players = new List<ICardPlayer>();
            _house = new CardPlayer();
            BetPool = new Dictionary<ICardPlayer, int>();

        }

        public void StartingBet(ICardPlayer player, int AmountBetting)
        {
            if (player is null) throw new ArgumentNullException(nameof(player), "Player betting may not be null.");
            if (AmountBetting <= 0) throw new ArgumentOutOfRangeException(nameof(AmountBetting), "Amount betting must be greater than zero.");
            BetPool[player] = AmountBetting;
            player.AmountOfMonies -= AmountBetting;
        }

        public void Raise(ICardPlayer player, int amountRaising)
        {
            if (!BetPool.ContainsKey(player)) throw new ArgumentException("The Player Must have placed a bet before raising.", nameof(player));
            if (amountRaising <= 0) throw new ArgumentOutOfRangeException(nameof(amountRaising), "The amount raising must be greater than 0.");
            BetPool[player] += amountRaising;
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
            for (int i = 0; i < 5; i++)
            {
                foreach (ICardPlayer player in Players)
                {
                    player.Hand.Add(deck.DrawCard());
                }
            }
        }

        public void Discard(ICardPlayer player, List<Card> discardedCards)
        {
            foreach (Card card in discardedCards)
            {
                player.Hand.Remove(card);
                player.Hand.Add(deck.DrawCard());
            }
        }

        public void Ante()
        {
            foreach (ICardPlayer player in Players)
            {
                StartingBet(player, 10);
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
