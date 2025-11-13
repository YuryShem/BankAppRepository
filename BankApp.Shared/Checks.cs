namespace BankApp.Shared
{
    public class Checks
    {
        public static bool IsAccountChoiseNumber(string number, int count)
        {
            if (int.TryParse(number, out int numb))
            {
                return numb < count && numb >= 0 ? true : false;
            }
            else 
            {
                return false; 
            }
        }

        public static bool IsNumber(string number, int count)
        {
            if (int.TryParse(number, out int numb))
            {
                return numb < count ? true : false;
            }
            else
            {
                return false;
            }
        }

        public static bool IsKey(ConsoleKeyInfo key, ConsoleKey consoleKey)
        {
            return key.Key == consoleKey ? true : false;
        }

        public static bool IsKey(ConsoleKeyInfo key, ConsoleKey consoleKey1, ConsoleKey consoleKey2)
        {
            return key.Key == consoleKey1 || key.Key == consoleKey2 ? true : false;
        }
    }
}
