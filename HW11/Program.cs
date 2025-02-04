namespace HW11
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base() { }

        public WrongPasswordException(string message) : base(message) { }
    }
    public class WrongLoginException : Exception
    {
        public WrongLoginException() : base() { }
        public WrongLoginException(string message) : base(message) { }
    }

    public class UserRegistration
    {
        public bool Register(string login, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new WrongLoginException("Логин не может быть пустым.");
            }

            if (password != confirmPassword)
            {
                throw new WrongPasswordException("Пароли не совпадают.");
            }

            // Дополнительные проверки пароля могут быть добавлены здесь

            return true; // Если все проверки пройдены успешно
        }

        private static void ValidateLogin(string login)
        {
            if (login.Length >= 20 || login.Contains(" "))
            {
                throw new WrongLoginException("Логин должен быть меньше 20 символов и не содержать пробелов.");
            }
        }

        private static void ValidatePassword(string password, string confirmPassword)
        {
            if (password.Length >= 20 || password.Contains(" ") || !HasDigit(password))
            {
                throw new Exception("Пароль должен быть меньше 20 символов, не содержать пробелов и содержать хотя бы одну цифру.");
            }

            if (password != confirmPassword)
            {
                throw new Exception("Пароли не совпадают.");
            }
        }

        private static bool HasDigit(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
    class Program
    {
        static void Main()
        {
            UserRegistration userRegistration = new UserRegistration();

            try
            {
                bool result = userRegistration.Register("user123", "password", "password");
                Console.WriteLine($"Регистрация успешна: {result}");
            }
            catch (WrongLoginException ex)
            {
                Console.WriteLine($"Ошибка логина: {ex.Message}");
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine($"Ошибка пароля: {ex.Message}");
            }
        }
    }
}
