using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.ConsoleGame.Controllers
{
    class GameOfBlackJack
    {
        List<CardPlayer> players;
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
            string[] menuSelection = { "Hit","Pass" };
            do
            {
                int choice = ConsoleIO.PromptForMenuSelection(menuSelection, false);
                switch (choice)
                {
                    case 1:
                        c.HitPlayer(currentPlayer);
                        break;
                    default:
                        turnActive = false;
                        break;
                }
            } while (turnActive);
        }

        private void InitializeGame()
        {
            int amountOfPlayers = ConsoleIO.PromptForInt("Enter How Many Players", 1, 5);
            c = new BlackJackController();
            c.Winner += (winner, winCondition) => 
            {
                Console.WriteLine($"{winner} has Won!!!");
                gameIsRunning = false;
            };
            c.Bust += (busted) =>
            {
                if (currentPlayer == busted)
                {
                    turnActive = false;
                }
            };
            c.StartGame(amountOfPlayers);
            players = c.Players;
            foreach (var player in players)
            {
                int initialBet = ConsoleIO.PromptForInt("Take Initial Bet", 1, player.AmountOfMonies);
                c.TakeInitialBet(initialBet, player);
            }
        }
    }
}
