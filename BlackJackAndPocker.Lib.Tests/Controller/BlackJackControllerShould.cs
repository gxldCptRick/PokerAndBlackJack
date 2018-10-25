using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackJackAndPocker.Lib.Tests.Controller
{
    [TestClass]
    public class BlackJackControllerShould
    {
        [TestMethod]
        public void FireBustEventWhenHandIHitTooMuch()
        {
            //arrange
            var blackJackController = new BlackJackController();
            bool busted = false;
            blackJackController.Bust += (busterBlader) => busted = true;

            //act
            RunBusterMoves(blackJackController);

            //assert
            Assert.IsTrue(busted);
        }

        [TestMethod]
        public void KeepHittingHouseHandWhileUnder17()
        {
            //arrange 
            var blackJackController = new BlackJackController();
            blackJackController.StartGame<CardPlayer>();

            //act
            blackJackController.RunHouseTurn();
            List<Card> houseHand = blackJackController.House.Hand;

            //assert
            Assert.IsTrue(blackJackController.CountHand(houseHand) >= 17);
        }

        private void RunBusterMoves(BlackJackController blackJackController)
        {
            blackJackController.StartGame<CardPlayer>();
            var player = blackJackController.Players[0];
            blackJackController.TakeInitialBet(player, 100);

            for (int i = 0; i < 30; i++)
            {
                blackJackController.HitPlayer(player);
            }
        }
    }
}
