using BankApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Services;
using static System.Console;

namespace BankApp.Console
{
    public class UserInteractionLogic
    {
        public static void DoLoginOrRegisterChoise(char key)
        {
            int personId = 0;

            if (key == 'l')
            {
                LoginServices.LogIn(UserInteraction.EnterLogin(), UserInteraction.EnterPassword());
            }
            if (key == 'r')
            {
                LoginServices.DoRegister(UserInteraction.EnterName(), UserInteraction.EnterSurname(), UserInteraction.EnterUniqueLogin(), UserInteraction.EnterPassword());
            }
        }
    }
}
