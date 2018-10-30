using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.WPF.ViewModels
{
    internal class PokerData : GameDataBase
    {
        private readonly PokerController _controller;
        private List<PlayerData> _players;

        public override event Action<ICardPlayer, WinCondition> WinningEvent;

        public override void DrawCardForPlayer(ICardPlayer player)
        {
            throw new NotImplementedException();
        }

        public override void EndRound()
        {
            throw new NotImplementedException();
        }

        public override void StartGame()
        {
            throw new NotImplementedException();
        }

        public override void TakeBets(ICardPlayer player, int bettingAmount)
        {
            throw new NotImplementedException();
        }
    }
}
