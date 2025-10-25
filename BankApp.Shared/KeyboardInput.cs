using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankApp.Shared
{
    public class KeyboardInput
    {
        public static int InputAccountChoise(int count)
        {
            bool isCorrect;
            string number;
            do
            {
                Console.WriteLine("Enter a number of account to work or '0' to create new account:");
                number = ReadLine();
                isCorrect = Checks.IsNumber(number, count);
            }
            while (isCorrect);

            return Convert.ToInt16(number);
        }
    }
}
