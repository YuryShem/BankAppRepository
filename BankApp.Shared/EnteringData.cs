using BankApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankApp.Shared
{
    public class EnteringData
    {
        public static string EnterLogin()
        {
            bool isMatch;
            string login;
            do
            {
                WriteLine("Enter login:");
                login = ReadLine();
                isMatch = string.IsNullOrEmpty(login);
            }
            while (isMatch);

            return login;
        }

        public static string EnterUniqueLogin() // check true
        {
            bool isMatch;
            string login;
            do
            {
                WriteLine("Enter login:");
                login = ReadLine();
                isMatch = string.IsNullOrEmpty(login) && LoginChecks.IsUniqueLogin(login);
            }
            while (isMatch == false);

            return login;
        }

        public static string EnterPassword()
        {
            bool isMatch;
            string password;
            do
            {
                WriteLine("Enter password:");
                password = ReadLine();
                isMatch = string.IsNullOrEmpty(password);
            }
            while (isMatch);

            return password;
        }

        public static string EnterName()
        {
            bool isMatch;
            string name;
            do
            {
                WriteLine("Enter your name: ");
                name = ReadLine();
                isMatch = string.IsNullOrEmpty(name) && name.All(char.IsLetter);
            }
            while (isMatch == false);

            return name;
        }

        public static string EnterSurname()
        {
            bool isMatch;
            string surname;
            do
            {
                WriteLine("Enter your surname");
                surname = ReadLine();
                isMatch = string.IsNullOrEmpty(surname) && surname.All(char.IsLetter);
            }
            while (isMatch == false);

            return surname;
        }

        public static long CreateIBAN()
        {
            long min = 100000000000000000;
            long max = 999999999999999999;
            Random random = new Random();
            byte[] buf = new byte[8];

            random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return Math.Abs(longRand % (max - min)) + min;
        }

        public static long CreateUniqueIBAN()
        {
            bool isUniqueIBAN;
            long iban;
            using (var context = new BankDbConnection())
            {
                do
                {
                    iban = EnteringData.CreateIBAN();
                    var accounts = context.Accounts.Where(l => l.IBAN == iban).ToList();
                    if (accounts.Count > 0)
                    {
                        isUniqueIBAN = false;
                    }
                    else
                    {
                        isUniqueIBAN = true;
                    }
                }
                while (!isUniqueIBAN);
            }

            return iban;
        }
    }
}
