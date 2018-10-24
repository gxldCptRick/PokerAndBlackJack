using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;

namespace BlackJackAndPoker.Controllers
{
    public class BlackJackController
    {
        private Deck deck;
        private CardPlayer _house;
        public CardPlayer House => _house;
        public List<CardPlayer> Players { get; private set; }
        public Dictionary<CardPlayer, int> Bets { get; set; }
        public BlackJackController()
        {
            _house = new CardPlayer();
            Players = new List<CardPlayer>();
            Bets = new Dictionary<CardPlayer, int>();
        }

        public void StartGame(int amountOfPlayers = 1)
        {
            deck = new Deck();
            deck.ShuffleCards();
            Players.Clear();
            for (int i = 0; i < amountOfPlayers; i++)
            {
                var player = new CardPlayer()
                {
                    AmountOfMonies = 200
                };
                Players.Add(player);
            }
        }

        public void TakeInitialBet(int bet, CardPlayer playerTakingTurn)
        {
            Bets[playerTakingTurn] = bet;
            playerTakingTurn.Hand = GetStartingHand();
        }

        private List<Card> GetStartingHand()
        {
            List<Card> hand = new List<Card>();
            hand.Add(deck.DrawCard());
            hand.Add(deck.DrawCard());
            return hand;
        }
    }
}
