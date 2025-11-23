using BankApp.Services;
using BankApp.Shared;

namespace BankApp.Console
{
    public class UserInteractionLogic
    {
        public static int DoLoginOrRegisterChoise(char key)
        {
            switch (key)
            {
                case 'l': return LoginServices.LogIn();
                case 'r': return LoginServices.DoRegister(EnteringData.EnterName(), EnteringData.EnterSurname(), EnteringData.EnterUniqueLogin(), EnteringData.EnterPassword());
                default: throw new ArgumentException(OutputData.OutputStringIfNotCorrectValue());
            }
        }
    }
}
