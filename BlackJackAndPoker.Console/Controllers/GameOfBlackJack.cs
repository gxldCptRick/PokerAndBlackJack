using BlackJackAndPoker.ConsoleGame.Models;
using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackAndPoker.ConsoleGame.Controllers
{
    internal class GameOfBlackJack
    {
        private List<ConsoleCardPlayer> players;
        private BlackJackController c;
        private bool turnActive;
        private CardPlayer currentPlayer;
        private bool gameIsRunning;

        public void Start()
        {
            string[] menuSelection = { "Start" };
            Console.WriteLine("Welcome To Black Jack");
            var selection = ConsoleIO.PromptForMenuSelection(menuSelection, true);

            switch (selection)
            {
                case 1:
                    RunGame();
                    break;
                default:
                    break;
            }
        }

        public void RunGame()
        {
            InitializeGame();
            gameIsRunning = true;
            do
            {
                foreach (var player in players)
                {
                    if (player.AmountOfMonies > 1)
                    {
                        int initialBet = ConsoleIO.PromptForInt("Take Initial Bet", 1, player.AmountOfMonies);
                        c.TakeInitialBet(player, initialBet);
                    }
                }
                Console.WriteLine("You New Round...");
                for (int i = 0; i < players.Count && !c.IsGameOver; i++)
                {
                    currentPlayer = players[i];
                    RunTurn();
                }
                c.RunHouseTurn();
            } while (gameIsRunning);
        }

        private void RunTurn()
        {
            turnActive = true;
            string[] menuSelection = { "Hit", "Pass" };
            do
            {
                Console.WriteLine($"{currentPlayer}'s Turn ");
                currentPlayer.Hand.ForEach(c => Console.Write($"{c}, "));
                Console.WriteLine();
                int choice = ConsoleIO.PromptForMenuSelection(menuSelection, false);
                switch (choice)
                {
                    case 1:
                        c.HitPlayer(currentPlayer);

                        break;
                    case 2:
                        turnActive = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(choice), "You gotta select a value between one and two.");
                }

                Console.WriteLine($"{c.CountHand(currentPlayer.Hand)}");
            } while (turnActive);
        }

        private void InitializeGame()
        {
            int amountOfPlayers = ConsoleIO.PromptForInt("Enter How Many Players", 1, 5);
            c = new BlackJackController();
            c.Winner += (winner, winCondition) =>
            {
                Console.WriteLine($"{winner} has won.");
                Console.ReadKey();
            };

            c.Bust += (busted) =>
            {
                if (currentPlayer == busted)
                {
                    turnActive = false;
                }
                Console.WriteLine($"{busted} has busted");
            };

            c.StartGame<ConsoleCardPlayer>(amountOfPlayers);
            players = c.Players.Cast<ConsoleCardPlayer>().ToList();

            foreach (var player in players)
            {
                player.Name = ConsoleIO.PromptForInput("Enter A Name", allowEmpty: false);
            }
        }
    }
}
