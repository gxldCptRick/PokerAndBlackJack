using System;
using System.Linq;
using BlackJackAndPoker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackAndPocker.Lib.Tests.Models
{
    [TestClass]
    public class DeckShould
    {
        [TestMethod]
        public void Contain52CardsAfterNewInstanceCreated()
        {
            //arrange / act
            var deck = new Deck();
            //assert 
            Assert.AreEqual(52, deck.Cards.Count());
        }
    }
}
