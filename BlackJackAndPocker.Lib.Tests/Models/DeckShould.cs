using System;
using System.Collections.Generic;
using System.Linq;
using BlackJackAndPoker.Enums;
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

        [TestMethod]
        public void Contain13HeartsAfterNewInstanceCreated()
        {
            //arrange / act
            var deck = new Deck();
            //assert 
            Assert.AreEqual(13, deck.Cards.Where((s) => s.Suit == Suit.Heart).Count());
        }

        [TestMethod]
        public void Contain13ClubsAfterNewInstanceCreated()
        {
            //arrange / act
            var deck = new Deck();
            //assert 
            Assert.AreEqual(13, deck.Cards.Where((s) => s.Suit == Suit.Club).Count());
        }

        [TestMethod]
        public void Contain13DiamondsAfterNewInstanceCreated()
        {
            //arrange / act
            var deck = new Deck();
            //assert 
            Assert.AreEqual(13, deck.Cards.Where((s) => s.Suit == Suit.Diamond).Count());
        }

        [TestMethod]
        public void Contain13SpadesAfterNewInstanceCreated()
        {
            //arrange / act
            var deck = new Deck();
            //assert 
            Assert.AreEqual(13, deck.Cards.Where((s) => s.Suit == Suit.Spade).Count());
        }

        [TestMethod]
        public void NotHaveTheCardsInTheSameOrderAsWhenTheyAreFirstCreatedAfterShuffling()
        {
            //arrange
            var deck = new Deck();
            var unexpected = deck.Cards;
            IEnumerable<Card> actual;
            //act
            deck.ShuffleCards();
            actual = deck.Cards;
            //assert 
            Assert.AreNotEqual(unexpected, actual);
        }

        [TestMethod]
        public void RemoveACardFromTheDeckWhenDrawCardIsCalled()
        {
            //arrange
            var deck = new Deck();

            //act 
            deck.DrawCard();
            //assert 
            Assert.AreEqual(51, deck.Cards.Count());
        }
    }
}
