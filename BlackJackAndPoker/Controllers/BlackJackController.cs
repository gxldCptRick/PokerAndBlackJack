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
                bool gameIsRunning = false;
                for (int i = 0; i < Players.Count && !gameIsRunning; i++)
                {
                    gameIsRunning = Players[i].AmountOfMonies > -50;
                }
                return !gameIsRunning;
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
            RemakeDeck();
            Players.Clear();
            for (int i = 0; i < amountOfPlayers; i++)
            {
                var player = new T()
                {
                    AmountOfMonies = 20
                };
                Players.Add(player);
            }
        }

        private void RemakeDeck()
        {
            deck = new Deck();
            deck.ShuffleCards();
        }

        public void RunHouseTurn()
        {
            TakeInitialBet(_house, 100);
            while (CountHand(_house.Hand) < 17)
            {
                HitPlayer(_house);
            }

            CheckForWinners();
        }

        private void CheckForWinners()
        {
            foreach (var player in Players)
            {
                CalculateWhoWon(player);
            }
            RemakeDeck();
        }

        private void CalculateWhoWon(ICardPlayer player)
        {
            var houseTotal = CountHand(_house.Hand);
            var playerTotal = CountHand(player.Hand);
            if (houseTotal > 21)
            {
                if (playerTotal <= 21)
                {
                    if (playerTotal == 21)
                    {
                        Winner?.Invoke(player, WinCondition.Blackjack);
                    }
                    else if (player.Hand.Count >= 5)
                    {
                        Winner?.Invoke(player, WinCondition.Five_Card_Charlie);
                    }
                    else
                    {
                        Winner?.Invoke(player, WinCondition.Win);
                    }
                }
                else
                {
                    Winner?.Invoke(player, WinCondition.Draw);
                }
            }
            else if (playerTotal > 21)
            {
                Winner?.Invoke(player, WinCondition.IsThisLoss);
            }
            else
            {
                if (player.Hand.Count >= 5)
                {
                    Winner?.Invoke(player, WinCondition.Five_Card_Charlie);
                }
                else if (playerTotal == 21)
                {
                    Winner?.Invoke(player, WinCondition.Blackjack);
                }
                else if (playerTotal > houseTotal)
                {
                    Winner?.Invoke(player, WinCondition.Win);
                }
                else if (houseTotal > playerTotal)
                {
                    Winner?.Invoke(player, WinCondition.IsThisLoss);
                }
                else
                {
                    Winner?.Invoke(player, WinCondition.Draw);
                }
            }
        }

        public void TakeInitialBet(ICardPlayer playerTakingTurn, int amountBetting)
        {
            if (amountBetting > 0)
            {
                Bets[playerTakingTurn] = amountBetting;
                playerTakingTurn.AmountOfMonies -= amountBetting;
                playerTakingTurn.Hand = GetStartingHand();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amountBetting), "Amount betting must be greater than zero.");
            }
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
            int currentlyRunningTotal = runningHandTotal;
            //if amount before aces is still less than or equal 21 and we have ace

            if (currentlyRunningTotal <= 21 && amountOfAces > 0)
            {
                if (currentlyRunningTotal == 10 && amountOfAces == 1)
                {
                    currentlyRunningTotal += 11;
                }
                else if (currentlyRunningTotal <= 9)
                {
                    currentlyRunningTotal += 11;
                    amountOfAces--;
                    if (amountOfAces > 0)
                    {
                        currentlyRunningTotal += amountOfAces;
                    }
                }
                else
                {
                    //just add the aces as one
                    currentlyRunningTotal += amountOfAces;
                }
            }
            return currentlyRunningTotal;
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
