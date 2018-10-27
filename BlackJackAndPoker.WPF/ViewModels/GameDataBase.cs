using System;
using System.Collections.Generic;
using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;

namespace BlackJackAndPoker.WPF.ViewModel
{
    internal abstract class GameDataBase : ViewModelBase, IGameData
    {
        private List<PlayerData> _players;
        public int MinPlayers { get; }
        public int MaxPlayers { get; }
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
    }
}
