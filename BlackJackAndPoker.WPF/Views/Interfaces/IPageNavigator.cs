using BlackJackAndPoker.WPF.Views.Enums;
using System;

namespace BlackJackAndPoker.WPF.Views.Interfaces
{
    internal interface IPageNavigator
    {
        event Action<PageRequest> PageChangeRequested;
    }
}
