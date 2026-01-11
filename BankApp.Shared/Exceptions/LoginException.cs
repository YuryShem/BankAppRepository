namespace BankApp.Shared.Exeptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Login or password is incorrect.") { }

        public LoginException(Exception inner) : base("Login or password is incorrect.", inner) { }

        public LoginException(string login, string password) 
            : base($"Login or password is incorrect: {login}, {password}")
        {
        }

        public LoginException(string login, string password, Exception inner)
            : base($"Login or password is incorrect: {login}, {password}", inner)
        {
        }
    }
}
