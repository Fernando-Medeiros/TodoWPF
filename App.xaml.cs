using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TodoWPF.Resource;
using TodoWPF.View;
using TodoWPF.ViewModel;

namespace TodoWPF
{
    public sealed partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        /// 
        public IServiceProvider Services { get; }

        private MainWindow ThisMainWindow => (MainWindow)Application.Current.MainWindow;

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddTransient<MainView>()
                .AddTransient<NewAccountView>()
                .AddTransient<RecoverPasswordView>()
                .AddSingleton<MainViewModel>()
                .BuildServiceProvider();
        }

        /// <summary>
        /// Configures the navigation for the application.
        /// </summary>
        public void GoTo(Endpoint endpoint)
        {
            switch (endpoint)
            {
                case Endpoint.Login:
                    ThisMainWindow.Main.Content = Services.GetService<MainView>();
                    break;
                case Endpoint.SignUp:
                    ThisMainWindow.Main.Content = Services.GetService<NewAccountView>();
                    break;
                case Endpoint.Recover:
                    ThisMainWindow.Main.Content = Services.GetService<RecoverPasswordView>();
                    break;
            }
        }
    }
}
