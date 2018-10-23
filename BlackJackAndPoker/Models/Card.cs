using BlackJackAndPoker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.Models
{
    public struct Card
    {
        public readonly Rank Rank;
        public readonly Suit Suit;

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }
}
