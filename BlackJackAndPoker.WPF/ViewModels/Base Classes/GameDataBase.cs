using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;

namespace BlackJackAndPoker.WPF.ViewModels
{
    internal abstract class GameDataBase : ViewModelBase, IGameData
    {
        private List<PlayerData> _players;
        private int _amountOfPlayersSelected;

        public int MinPlayers { get; protected set; }
        public int MaxPlayers { get; protected set; }
        public int AmountOfPlayersSelected
        {
            get => _amountOfPlayersSelected;
            set
            {
                _amountOfPlayersSelected = value;
                PropertyChanging();
            }
        }
        public abstract event Action<ICardPlayer, WinCondition> WinningEvent;
        public List<PlayerData> Players
        {
            get => _players;
            set
            {
                _players = value;
                PropertyChanging();
            }
        }

        public abstract void StartGame();
        public abstract void DrawCardForPlayer(ICardPlayer player);
        public abstract void EndRound();
        public abstract void TakeBets(ICardPlayer player, int bettingAmount);
    }
}
