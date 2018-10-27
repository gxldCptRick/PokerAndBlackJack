using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackJackAndPoker.WPF.ViewModels
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected void PropertyChanging([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
