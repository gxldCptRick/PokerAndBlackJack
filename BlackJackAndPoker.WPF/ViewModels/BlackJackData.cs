using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackAndPoker.WPF.ViewModel
{
    internal class BlackJackData : GameDataBase
    {
        private readonly BlackJackController _controller;
        private List<PlayerData> _players;

        public override event Action<ICardPlayer, WinCondition> WinningEvent
        {
            add => _controller.Winner += value;
            remove => _controller.Winner -= value;
        }

        public event Action<ICardPlayer> BustingEvent
        {
            add => _controller.Bust += value;
            remove => _controller.Bust -= value;
        }

        public BlackJackData()
        {
            _controller = new BlackJackController();
        }

        public void StartGame()
        {
            _controller.StartGame<PlayerData>();
            Players = _controller.Players.Cast<PlayerData>().ToList();
        }

        public void HitPlayer(PlayerData player)
        {
            _controller.HitPlayer(player);
            player.Hand = player.Hand;
        }

        public void SetInitialBetForPlayer(PlayerData player, int bettingAmount)
        {
            _controller.TakeInitialBet(player, bettingAmount);
        }

        public void RunDealerTurn()
        {
            _controller.RunHouseTurn();
        }
    }
}
