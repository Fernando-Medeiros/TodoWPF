using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using TodoWPF.ViewModel;

namespace TodoWPF.View
{
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<MainViewModel>();
        }
    }
}
