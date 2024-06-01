using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using TodoWPF.ViewModel;

namespace TodoWPF.View
{
    public sealed partial class RecoverPasswordView : Page
    {
        public RecoverPasswordView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<MainViewModel>();
        }
    }
}
