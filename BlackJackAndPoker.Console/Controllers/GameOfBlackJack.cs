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
                Console.WriteLine("You New Round...");
                for (int i = 0; i < players.Count && c.IsGameOver; i++)
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
                int choice = ConsoleIO.PromptForMenuSelection(menuSelection, false);
                switch (choice)
                {
                    case 1:
                        c.HitPlayer(currentPlayer);
                        break;
                    case 2:
                        turnActive = false;
                        Console.WriteLine($"");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(choice),"You gotta select a value between one and two.");
                }
            } while (turnActive);
        }

        private void InitializeGame()
        {
            int amountOfPlayers = ConsoleIO.PromptForInt("Enter How Many Players", 1, 5);
            c = new BlackJackController();
            c.Winner += (winner, winCondition) =>
            {
                if (winner != c.House)
                {
                    Console.WriteLine($"{winner} has Won!!!");
                }
                else
                {
                    Console.WriteLine($"the house has Won!!!");
                }

                gameIsRunning = false;
            };

            c.Bust += (busted) =>
            {
                if (currentPlayer == busted)
                {
                    turnActive = false;
                }
            };

            c.StartGame<ConsoleCardPlayer>(amountOfPlayers);
            players = c.Players.Cast<ConsoleCardPlayer>().ToList();
            foreach (var player in players)
            {
                int initialBet = ConsoleIO.PromptForInt("Take Initial Bet", 1, player.AmountOfMonies);
                c.TakeInitialBet(player, initialBet);
            }
        }
    }
}
