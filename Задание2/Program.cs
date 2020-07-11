using System;
using System.IO;


/// <summary>
/// Гаврилов Владимир
/// </summary>
namespace Задание2 // Подготовлено для публичной демонстрации.
{
    class Program
    {
                       //Разработать класс Message, содержащий следующие статические методы для обработки
        const string a = "Вывести только те слова сообщения, которые содержат не более n букв.";
        const string b = "Удалить из сообщения все слова, которые заканчиваются на заданный символ.";
        const string c = "Найти самое длинное слово сообщения.";
        const string d = "Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.";
                       //Продемонстрируйте работу программы на текстовом файле с вашей программой.

        static void Main()
        {
            FinalDemonstration();
        }

        private static void FinalDemonstration()
        {
            do
            {

                Console.Clear();

                DemonstrationWorkedMessageClass();
                Console.WriteLine("\nЖелаете продолжить? (Длявыхода из программы наберите 0)");
                string exit = Console.ReadLine();
                if (exit == "0")
                    return;
            }
            while (true);
        }

        public static void DemonstrationWorkedMessageClass()
        {

            StreamReader streamReader = new StreamReader("data.txt");
            string resourse = streamReader.ReadToEnd();
            Console.WriteLine("\t\tИмеется текстовый фал со следующим текстом:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{resourse}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tКакое действие следует выполнить?\n\t");
            Console.WriteLine($"\t1.{a}\n\t2.{b}\n\t3.{c}\n\t4.{d}\n");
            int value;
            int.TryParse(Console.ReadLine(), out value);

            switch (value)
            {
                case 1:
                    Console.WriteLine("Слова больше скольки символов следует удалить?");
                    int letters;
                    int.TryParse(Console.ReadLine(), out letters);
                    Console.Write("Остались такие слова: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Message.WordsLimitLetters(resourse, letters);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.WriteLine("Слова заканчивающиеся каким символом следует удалить?");
                    char ch;
                    char.TryParse(Console.ReadLine(), out ch);
                    Console.Write("Остались следующие слова: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Message.WordsDeleteEndedChar(resourse, ch));
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.Write($"Самое длинное слово: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Message.LongestWord(resourse));
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.WriteLine("Слова больше скольки символов следует оставить?");
                    int words;
                    int.TryParse(Console.ReadLine(), out words);
                    Console.Write("Остались следующие слова: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Message.LongestWords(resourse, words+1));
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }
        }
    }
}
