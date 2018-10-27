using BlackJackAndPoker.WPF.ViewModel;

namespace BlackJackAndPoker.WPF.ViewModels
{
    internal class MainData
    {
        public IGameData GameData { get; set; }

        public MainData()
        {
            GameData = new BlackJackData();
        }
    }
}
