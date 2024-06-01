using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TodoWPF.Model;
using TodoWPF.Resource;
using TodoWPF.Service;

namespace TodoWPF.ViewModel
{
    public sealed partial class MainViewModel : BaseViewModel
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
        private string name;
        private string email;
        private string password;

        public string Name { get => name; set { name = value ?? name; OnPropertyChanged(nameof(Name)); } }
        public string Email { get => email; set { email = value ?? email; OnPropertyChanged(nameof(Email)); } }
        public string Password { get => password; set { password = value ?? password; OnPropertyChanged(nameof(Password)); } }
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

            if (sender is Endpoint endpoint)
            {
                App.Current.GoTo(endpoint);
            }
            NotBusy();
        }

        private void OnLoginClicked(object sender)
        {
            Password = ((PasswordBox)sender)?.Password;

            if (IsBusy()) return;
            if (CheckEmail() && CheckPassword())
            {
                MessageBox.Show("Login efetuado, clique em continuar para prosseguir...", "Credenciais", MessageBoxButton.OK);
                App.Current.Customer = new Customer();
                App.Current.GoTo(Endpoint.Dashboard);
            }
            NotBusy();
        }

        private void OnSignUpClicked(object sender)
        {
            Password = ((PasswordBox)sender)?.Password;

            if (IsBusy()) return;
            if (CheckName() && CheckEmail() && CheckPassword())
            {
                MessageBox.Show("Registro efetuado, clique em continuar para prosseguir...", "Credenciais", MessageBoxButton.OK);
                App.Current.GoTo(Endpoint.Login);
            }
            NotBusy();
        }

        private void OnRecoverClicked(object sender)
        {
            if (IsBusy()) return;
            if (CheckEmail())
            {
                MessageBox.Show("E-mail enviado, verifique a caixa de mensagens...", "Credenciais", MessageBoxButton.OK);
                App.Current.GoTo(Endpoint.Login);
            }
            NotBusy();
        }
        #endregion

        #region Aux
        private bool CheckName()
        {
            if (Validator.Execute(Validator.Target.Name, Name)) return true;
            MessageBox.Show("O nome completo deve conter apenas letras", "Nome Inválido", MessageBoxButton.OK);
            return false;
        }

        private bool CheckEmail()
        {
            if (Validator.Execute(Validator.Target.Email, Email)) return true;
            MessageBox.Show("O e-mail deve conter letras, números e seguir o padrão exemplo2d@exemplo.com...", "E-mail Inválido", MessageBoxButton.OK);
            return false;
        }
        private bool CheckPassword()
        {
            if (Validator.Execute(Validator.Target.Password, Password)) return true;
            MessageBox.Show("A senha deve conter aA - zZ, 0 - 9, @ e ter entre 8 a 16 caracteres, exemplo SenhA@37", "Senha Inválida", MessageBoxButton.OK);
            return false;
        }
        #endregion
    }
}
