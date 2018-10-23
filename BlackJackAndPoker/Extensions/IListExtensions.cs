using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.Extensions
{
    public static class IListExtensions
    {
        private static Random rnJesus = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int currentPosition = list.Count;
            do
            {
                int positionToSwitchWith = rnJesus.Next(currentPosition--);
                T temporaryValue = list[positionToSwitchWith];
                list[positionToSwitchWith] = list[currentPosition];
                list[currentPosition] = temporaryValue;
            } while (currentPosition > 1);
        }
    }
}
