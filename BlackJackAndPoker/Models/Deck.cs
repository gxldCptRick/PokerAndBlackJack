using BlackJackAndPoker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.Models
{
    public class Deck
    {
        private readonly List<Card> _cards;
        public IEnumerable<Card> Cards => _cards;

        public Deck()
        {
            _cards = new List<Card>(52);
            InitializeCards();
        }

        private void InitializeCards()
        {
           var suits =  Enum.GetValues(typeof(Suit)).Cast<Suit>().ToArray();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>().ToArray();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
           
        }

        public void ShuffleCards()
        {
            //some sort of shuffle mechanics
        }

    }
}
