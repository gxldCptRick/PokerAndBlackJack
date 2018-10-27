namespace BlackJackAndPoker.WPF.ViewModels
{
    internal class MainData : ViewModelBase
    {
        private IGameData _gameData;

        public IGameData GameData
        {
            get => _gameData;
            set
            {
                _gameData = value;
                PropertyChanging();
            }
        }

        public MainData()
        {
            GameData = new BlackJackData();
        }
    }
}
