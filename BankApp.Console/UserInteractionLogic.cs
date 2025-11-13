using BankApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Services;
using static System.Console;
using System.Reflection.Metadata.Ecma335;
using BankApp.Shared;

namespace BankApp.Console
{
    public class UserInteractionLogic
    {
        public static int DoLoginOrRegisterChoise(char key)
        {
            //int personId = 0;
            switch (key)
            {
                case 'l': return LoginServices.LogIn(EnteringData.EnterLogin(), EnteringData.EnterPassword());
                case 'r': return LoginServices.DoRegister(EnteringData.EnterName(), EnteringData.EnterSurname(), EnteringData.EnterUniqueLogin(), EnteringData.EnterPassword());
                default: throw new ArgumentException(KeyboardInput.OutputStringIfNotCorrectValue());
            }


            //if (key == 'l')
            //{
            //    return LoginServices.LogIn(EnteringData.EnterLogin(), EnteringData.EnterPassword());
            //}
            //if (key == 'r')
            //{
            //    return LoginServices.DoRegister(EnteringData.EnterName(), EnteringData.EnterSurname(), EnteringData.EnterUniqueLogin(), EnteringData.EnterPassword());
            //}
        }
    }
}
