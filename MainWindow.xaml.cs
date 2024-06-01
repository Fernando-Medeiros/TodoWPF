using System.Windows;
using TodoWPF.Resource;

namespace TodoWPF
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.Current.GoTo(Endpoint.Login);
        }
    }
}
