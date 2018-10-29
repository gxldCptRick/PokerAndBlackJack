using System;
using System.Collections.Generic;
using System.ComponentModel;
using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using BlackJackAndPoker.WPF.ViewModels;

namespace BlackJackAndPoker.WPF.ViewModels
{
    internal class PokerData : IGameData
    {
        public int MinPlayers => throw new NotImplementedException();

        public int MaxPlayers => throw new NotImplementedException();

        public int AmountOfPlayersSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<PlayerData> Players => throw new NotImplementedException();

        public event Action<ICardPlayer, WinCondition> WinningEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        public void DrawCardForPlayer(ICardPlayer player)
        {
            throw new NotImplementedException();
        }

        public void EndRound()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void TakeBets(ICardPlayer player, int bettingAmount)
        {
            throw new NotImplementedException();
        }
    }
}