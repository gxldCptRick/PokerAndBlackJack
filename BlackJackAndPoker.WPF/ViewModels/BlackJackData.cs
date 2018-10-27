using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackAndPoker.WPF.ViewModels
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
            MinPlayers = 1;
            MaxPlayers -= 5;
        }

        public override void StartGame()
        {
            _controller.StartGame<PlayerData>();
            Players = _controller.Players.Cast<PlayerData>().ToList();
        }

        private void RunDealerTurn()
        {
            _controller.RunHouseTurn();
        }

        public override void DrawCardForPlayer(ICardPlayer player)
        {
            _controller.HitPlayer(player);
            player.Hand = player.Hand;
        }

        public override void EndRound()
        {
            RunDealerTurn();
        }

        public override void TakeBets(ICardPlayer player, int bettingAmount)
        {
            _controller.TakeInitialBet(player, bettingAmount);
        }
    }
}
