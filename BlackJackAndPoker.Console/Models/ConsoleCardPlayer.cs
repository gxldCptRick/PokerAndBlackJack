using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.ConsoleGame.Models
{
    internal class ConsoleCardPlayer : CardPlayer
    {
        public string Name { get; set; }
        public ConsoleCardPlayer()
        {
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
