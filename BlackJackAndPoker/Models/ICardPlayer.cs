using System.Collections.Generic;

namespace BlackJackAndPoker.Models
{
    public interface ICardPlayer
    {
        int AmountOfMonies { get; set; }
        List<Card> Hand { get; set; }
    }
}