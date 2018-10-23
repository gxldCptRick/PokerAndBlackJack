using BlackJackAndPoker.Enums;
using BlackJackAndPoker.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.Models
{
    public class Deck
    {
        private Queue<Card> _cards;
        public IEnumerable<Card> Cards => _cards;

        public Deck()
        {
            _cards = new Queue<Card>(52);
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
                    _cards.Enqueue(new Card(rank, suit));
                }
            }
           
        }

        public void ShuffleCards()
        {
            var deckInAList = new List<Card>(_cards);
            deckInAList.Shuffle();
            _cards = new Queue<Card>(deckInAList);
        }

        public Card DrawCard()
        {
            return _cards.Dequeue();   
        }

    }
}
