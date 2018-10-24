using System.Collections.Generic;

namespace BlackJackAndPoker.Models
{
    public class CardPlayer
    {
        private int _amountOfMonies;
        // public string Name { get; set; }
        public int AmountOfMonies
        {
            get => _amountOfMonies;
            set => _amountOfMonies = value;
        }
        public List<Card> Hand { get; set; }

        public CardPlayer()
        {
        }
    }
}
