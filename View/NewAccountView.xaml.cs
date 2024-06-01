using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using TodoWPF.ViewModel;

namespace TodoWPF.View
{
    public sealed partial class NewAccountView : Page
    {
        public NewAccountView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<MainViewModel>();
        }
    }
}
