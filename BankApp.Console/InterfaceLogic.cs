using BankApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Console
{
    internal class InterfaceLogic
    {
        public void LoginOrRegisterChoise(char key)
        {
            if (key == 'l')
            {
                WriteLine("");
            }
            if (key == 'r')
            {
                WriteLine("Register");
            }
        }

        public int Login(string login, string password)
        {
            using (var context = new BankDbConnection())
            {
                var accounts = context.LoginsAndPasswords.ToList();
                foreach (var account in accounts)
                {
                    if (login == account.Login && password == account.Password)
                    {
                        return account.AccountId;
                    }
                }
            }

            return 0;
        }
    }
}
