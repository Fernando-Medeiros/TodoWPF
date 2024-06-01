using System.Windows;
using TodoWPF.View;

namespace TodoWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Main.Content = new MainView();
        }
    }
}
