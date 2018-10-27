using BlackJackAndPoker.Models;
using System.Collections.Generic;

namespace BlackJackAndPoker.WPF.ViewModel
{
    internal class PlayerData : ViewModelBase, ICardPlayer
    {
        private static int NumberOfPlayers;
        static PlayerData()
        {
            NumberOfPlayers = 0;
        }

        private string _name;
        private int _amountOfMonies;
        private List<Card> _hand;

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanging();
            }
        }

        public int AmountOfMonies
        {
            get => _amountOfMonies;
            set
            {
                _amountOfMonies = value;
                PropertyChanging();
            }
        }

        public List<Card> Hand
        {
            get => _hand;
            set
            {
                _hand = value;
                PropertyChanging();
            }
        }
        #endregion

        public PlayerData()
        {
            Name = $"Player {++NumberOfPlayers}";
        }
    }
}
