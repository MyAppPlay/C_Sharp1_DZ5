using System;


/// <summary>
/// Владимир Гаврилов
/// </summary>
namespace Задание3
{
    class Program
    {
        const string condition = "\t\tДля двух строк написать метод, определяющий,\n\t является ли одна строка перестановкой другой." +
            "Регистр можно не учитывать.\n";
        //     а) с использованием методов C#;
        //     б) * разработав собственный алгоритм.

        static void Main()
        {
            PermutationDemonstration();
        }

        private static void PermutationDemonstration()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(condition);
                Console.WriteLine("\tВведите первую строку сравнения.");
                string one = Console.ReadLine();
                Console.WriteLine("\tВведите вторую строку сравнения.");
                string two = Console.ReadLine();
                string result = IsPermutationStrings(one, two) ? "Строки соответсвуют условию" : "Строки не соответсвуют условию";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(result);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Для выхода из программы введите 0 ");
                string exit = Console.ReadLine();
                if (exit == "0")
                    return;
            } while (true);
        }

        public static bool IsPermutationStrings(string one, string two)
        {
            var ctn = 0;
            one = one.ToLower();
            two = two.ToLower();
            char[] chars = two.ToCharArray();
            foreach (char c in one)
                for (var i = 0; i < two.Length; i++)
                {
                    if (chars[i] == c)
                    {
                        chars[i] = '♥';
                        ctn++;
                    }
                }
            return ctn == one.Length;
        }
    }
}
