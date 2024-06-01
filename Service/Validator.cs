using System.Text.RegularExpressions;

namespace TodoWPF.Service
{
    public static class Validator
    {
        private const string name = @"^(?!.*([A-Za-zÀ-ÿ])\1\1)[A-Za-zÀ-ÿ]{3,18}(?: [A-Za-zÀ-ÿ]{3,18})?$";
        private const string email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private const string password = @"^(?=.*[a-zA-Z0-9çÇ@])[a-zA-Z0-9çÇ@]{8,16}$";

        public enum Target : byte { Name, Email, Password };

        public static bool Execute(Target target, string input)
        {
            switch (target)
            {
                case Target.Name: return Regex.IsMatch(input, name);
                case Target.Email: return Regex.IsMatch(input, email);
                case Target.Password: return Regex.IsMatch(input, password);
                default: return false;
            };
        }
    }
}
