using BlackJackAndPoker.Enums;
using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;

namespace BlackJackAndPoker.Controllers
{
    public class BlackJackController
    {
        private Deck deck;
        private ICardPlayer _house;
        public ICardPlayer House => _house;
        public List<ICardPlayer> Players { get; private set; }
        public Dictionary<ICardPlayer, int> Bets { get; set; }
        public bool IsGameOver
        {
            get
            {
                bool isGameOver = false;
                for (int i = 0; i < Players.Count && !isGameOver; i++)
                {
                    isGameOver = Players[i].AmountOfMonies > 0;
                }
                return isGameOver;
            }
        }

        public event Action<ICardPlayer, WinCondition> Winner;
        public event Action<ICardPlayer> Bust;

        public BlackJackController()
        {
            _house = new CardPlayer();
            Players = new List<ICardPlayer>();
            Bets = new Dictionary<ICardPlayer, int>();
        }

        public void StartGame<T>(int amountOfPlayers = 1) where T : ICardPlayer, new()
        {
            deck = new Deck();
            deck.ShuffleCards();
            Players.Clear();
            for (int i = 0; i < amountOfPlayers; i++)
            {
                var player = new T()
                {
                    AmountOfMonies = 200
                };
                Players.Add(player);
            }
        }

        public void RunHouseTurn()
        {
            TakeInitialBet(_house, 100);
            while (CountHand(_house.Hand) < 17)
            {
                HitPlayer(_house);
            }
        }

        public void TakeInitialBet(ICardPlayer playerTakingTurn, int bet)
        {
            Bets[playerTakingTurn] = bet;
            playerTakingTurn.AmountOfMonies -= bet;
            playerTakingTurn.Hand = GetStartingHand();
        }

        public void HitPlayer(ICardPlayer cardPlayer)
        {
            if (CountHand(cardPlayer.Hand) < 21)
            {
                cardPlayer.Hand.Add(deck.DrawCard());
                if (CountHand(cardPlayer.Hand) > 21)
                {
                    Bust?.Invoke(cardPlayer);
                }
            }
        }

        public int CountHand(List<Card> hand)
        {
            int runningHandTotal = 0;
            int amountOfAces = 0;
            foreach (var card in hand)
            {
                if (card.Rank != Rank.Ace)
                {
                    runningHandTotal += DetermineCardValue(card.Rank);
                }
                else
                {
                    amountOfAces++;
                }
            }

            runningHandTotal = AccountForAces(runningHandTotal, amountOfAces);
            return runningHandTotal;
        }

        private int AccountForAces(int runningHandTotal, int amountOfAces)
        {
            int totalAfterAces = runningHandTotal;
            //if amount before aces is still less than or equal 21 and we have ace

            if (totalAfterAces <= 21 && amountOfAces > 0)
            {
                //if the amount left is less than 11 add the ace as 11
                if (totalAfterAces == 10 && amountOfAces == 1)
                {
                    //add the 11 for the ace 
                    totalAfterAces += 11;
                }
                else if(totalAfterAces <= 9)
                {
                    totalAfterAces += 11;
                    amountOfAces--;
                    if (amountOfAces > 0)
                    {
                        totalAfterAces += amountOfAces;
                    }
                }
                else
                {
                    //just add the aces as one
                    totalAfterAces += amountOfAces;
                }
            }
            return totalAfterAces;
        }

        private int DetermineCardValue(Rank rank)
        {
            int value = 0;

            switch (rank)
            {
                case Rank.Ten:
                case Rank.Jack:
                case Rank.Queen:
                case Rank.King:
                    value = 10;
                    break;
                case Rank.Ace:
                    throw new ArgumentException(nameof(rank), "Ace Cannot Be Determined..");
                default:
                    value = (int)rank;
                    break;
            }

            return value;
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
