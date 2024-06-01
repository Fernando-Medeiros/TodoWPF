using System.ComponentModel;

namespace TodoWPF.Service
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;

        protected bool IsBusy()
        {
            if (isBusy) return true;
            isBusy = true;
            return false;
        }

        protected void NotBusy() => isBusy = false;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
