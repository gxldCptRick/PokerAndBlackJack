namespace BlackJackAndPoker.WPF.ViewModels
{
    internal class HalpData : ViewModelBase
    {
        private string _gameTitle;

        public string GameTitle
        {
            get => _gameTitle;
            set
            {
                _gameTitle = value;
                PropertyChanging();
            }
        }

        public HalpData()
        {
            GameTitle = "Halp";
        }
    }
}
