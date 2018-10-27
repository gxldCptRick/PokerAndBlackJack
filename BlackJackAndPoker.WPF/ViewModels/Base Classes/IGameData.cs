using BlackJackAndPoker.Controllers;
using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAndPoker.WPF.ViewModels
{
    interface IGameData : INotifyPropertyChanged
    {
        int MinPlayers { get; }
        int MaxPlayers { get; }
        int AmountOfPlayersSelected { get; set; }
        event Action<ICardPlayer, WinCondition> WinningEvent;
        List<PlayerData> Players { get; }
    }
}
