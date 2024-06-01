using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TodoWPF.Resources;
using TodoWPF.Service;

namespace TodoWPF.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LoginCommand = new BaseCommand(OnLoginClicked);
            SignUpCommand = new BaseCommand(OnSignUpClicked);
            NavigationCommand = new BaseCommand(OnNavigationClicked);
            RecoverPasswordCommand = new BaseCommand(OnRecoverClicked);
        }

        #region Interface
        public string LoginIcon => Icon.Login;
        public string EmailIcon => Icon.Email;
        public string PasswordIcon => Icon.Password;
        #endregion

        #region Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
        #endregion

        #region Commands
        public ICommand NavigationCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        #endregion

        #region Actions
        private void OnNavigationClicked(object sender)
        {
            if (IsBusy()) return;

            switch (sender)
            {
                case "login": break;
                case "signup": break;
                case "recover": break;
            }

            NotBusy();
        }

        private void OnLoginClicked(object sender)
        {
            if (IsBusy()) return;

            Password = ((PasswordBox)sender)?.Password;

            if (string.IsNullOrEmpty(Email))
                MessageBox.Show("O e-mail deve conter letras e seguir o padrão exemplo@exemplo.com...", "E-mail Inválido", MessageBoxButton.OK);

            else if (string.IsNullOrEmpty(Convert.ToString(Password)))
                MessageBox.Show("A senha deve conter letras e numeros e o @, por exemplo Senha@@00", "Senha Inválida", MessageBoxButton.OK);

            else
                MessageBox.Show("Login efetuado, clique em continuar para prosseguir...", "Credenciais", MessageBoxButton.OK);

            NotBusy();
        }

        private void OnSignUpClicked(object sender)
        {
            if (IsBusy()) return;

            Password = ((PasswordBox)sender)?.Password;

            if (string.IsNullOrEmpty(Email))
                MessageBox.Show("O e-mail deve conter letras e seguir o padrão exemplo@exemplo.com...", "E-mail Inválido", MessageBoxButton.OK);

            else if (string.IsNullOrEmpty(Convert.ToString(Password)))
                MessageBox.Show("A senha deve conter letras e numeros e o @, por exemplo Senha@@00", "Senha Inválida", MessageBoxButton.OK);

            else
                MessageBox.Show("Registro efetuado, clique em continuar para prosseguir...", "Credenciais", MessageBoxButton.OK);

            NotBusy();
        }

        private void OnRecoverClicked(object sender)
        {
            if (IsBusy()) return;

            if (string.IsNullOrEmpty(Email))
                MessageBox.Show("O e-mail deve conter letras e seguir o padrão exemplo@exemplo.com...", "E-mail Inválido", MessageBoxButton.OK);

            else
                MessageBox.Show("E-mail enviado, verifique a caixa de mensagens...", "Credenciais", MessageBoxButton.OK);

            NotBusy();
        }
        #endregion
    }
}
