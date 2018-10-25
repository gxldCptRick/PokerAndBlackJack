using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Enums;
using BlackJackAndPoker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackJackAndPocker.Lib.Tests.Controller.BlackJackUnitTests
{
    [TestClass]
    public class BlackJackController_CountCardsTests
    {
        [TestMethod]
        public void TheResultFromAddingAJackAndAnAceIs21()
        {
            var controller = new BlackJackController();
            var cards = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Jack, Suit.Diamond)
            };
            var expected = 21;
            int actual;

            actual = controller.CountHand(cards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheResultAFourAcesIsFourteen()
        {
            var controller = new BlackJackController();
            var cards = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Heart)
            };
            var expected = 14;
            int actual;

            actual = controller.CountHand(cards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheResultForTwoAcesAndaJackIsEleven()
        {
            var controller = new BlackJackController();
            var cards = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
            };
            var expected = 12;
            int actual;

            actual = controller.CountHand(cards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheResultForATwoAThreeAndAFourWithTwoAces()
        {
            var controller = new BlackJackController();
            var cards = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Three, Suit.Spade),
                new Card(Rank.Four, Suit.Spade),
                new Card(Rank.Two, Suit.Diamond)
            };
            var expected = 21;
            int actual;

            actual = controller.CountHand(cards);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TheResultFor3TwosAFourAndAnAce()
        {
            var controller = new BlackJackController();
            var cards = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Four, Suit.Spade),
                new Card(Rank.Two, Suit.Spade),
                new Card(Rank.Two, Suit.Diamond),
                new Card(Rank.Two, Suit.Diamond)
            };
            var expected = 21;
            int actual;

            actual = controller.CountHand(cards);

            Assert.AreEqual(expected, actual);
        }
    }
}
