using System.Collections.Generic;

namespace BlackJackAndPoker.Models
{
    public class CardPlayer : ICardPlayer
    {
        private int _amountOfMonies;
        public int AmountOfMonies
        {
            get => _amountOfMonies;
            set => _amountOfMonies = value;
        }
        public List<Card> Hand { get; set; }
        public CardPlayer()
        {
        }

        public override string ToString()
        {
            return "House";
        }
    }
}
