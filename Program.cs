using System;
using System.Text.RegularExpressions;


/// <summary>
/// Гаврилов Владимир
/// </summary>
namespace Задание1
{
    //    1. Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    //    а) без использования регулярных выражений;
    //    б) с использованием регулярных выражений.
    class Program
    {
        static void Main()
        {

            Console.WriteLine("\t\tПрограмма проверки корректности ввода логина №1");

            RegexLogin();

            Console.Clear();

            LoginCorrectNoRegex();
        }

        private static void RegexLogin()
        {
            string login;
            do
            {

                Console.WriteLine("Длина логина должа составлять 2 - 10 символов латинского алфавита и первым символом  не должно быть число");
                Console.WriteLine("\tПожалуйста введите ЛОГИН");
                login = Console.ReadLine();
                Console.Clear();
                LoginCorrectWithRegex(login);
                Console.WriteLine("\tДля выхода из программы наберите 0 или продолжайте вводить логины");
            }
            while (login != "0");
        }

        /// <summary>
        /// Проверка корректности логина БЕЗ использования регулярных выражений.
        /// </summary>
        private static void LoginCorrectNoRegex()
        {
            Console.WriteLine("\t\tПрограмма проверки корректности ввода логина №2");
            Console.WriteLine("\tПожалуйста введите ЛОГИН");
            string login;
            while (true)
            {
                login = Console.ReadLine();
                if (login == "0")
                    break;
                char[] loginChar = login.ToCharArray();
                bool correct = true;
                if (login.Length > 1 && login.Length < 11 && !(loginChar[0] > '0' && loginChar[0] < '9'))
                {
                    foreach (char ch in loginChar)
                    {
                        if ((ch > 'a' && ch < 'z') || (ch > '0' && ch < '9') || (ch > 'A' && ch < 'Z'))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("В логине используются неразрешенные символы");
                            correct = false;
                            break;
                        }
                    }
                    if(correct)
                    Console.WriteLine($"Логин: {login} \n\t...OK...\n");
                    Console.WriteLine("\tДля выхода из программы наберите 0 или продолжайте вводить логины");
                }
                else
                {
                    Console.WriteLine("\n\tДлинна логина должа составлять 2 - 10 символов латинского алфавита и первым символом не должно быть число");
                }
            }
        }

        /// <summary>
        /// Проверка корректности логина с использованием Regex.
        /// </summary>
        /// <param name="логин"></param>
        private static void LoginCorrectWithRegex(string login)
        {
            string pattern = @"^\D{1}[a-zAZ0-9]{1,9}";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(login) && login.Length <= 10)
                Console.WriteLine($"Логин: {login} \n\t...OK...\n");
            else Console.WriteLine($"Логин: {login} \n\tне корректен\n");
        }
    }
}
