using System;
using System.Text;

/// <summary>
/// Гаврилов Владимир
/// </summary>
namespace Задание2
{
    class Message
    {
        /// <summary>
        /// Вывести только те слова сообщения, которые содержат не более n букв.
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="letters">оличество букв слова</param>
        public static void WordsLimitLetters(string message, int letters)
        {
            string[] words = message.Split(' ');
            foreach (string word in words)
                if (word.Length <= letters)
                    Console.Write(word + " ");
        }

        /// <summary>
        /// Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="endChar">последний символ слова</param>
        /// <returns></returns>
        public static string WordsDeleteEndedChar(string message, char endChar)
        {
            string[] words = message.Split(' ');
            string res = string.Empty;
            foreach (string word in words)
                if (word[word.Length - 1] != endChar)
                    res += word + " ";
            return res;
        }

        /// <summary>
        /// Найти самое длинное слово сообщения.
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <returns></returns>
        public static string LongestWord(string message)
        {
            string[] words = message.Split(' ');
            string res = words[0];
            foreach (string word in words)
                if (word.Length > res.Length)
                    res = word;
            return res;
        }

        /// <summary>
        /// Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="length"> длинна слова</param>
        /// <returns></returns>
        public static string LongestWords(string message, int length)
        {
            string[] words = message.Split(' ');
            StringBuilder res = new StringBuilder();
            foreach (string word in words)
                if (word.Length >= length)
                    res.Append(word + " ");
            return res.ToString();
        }
    }
}
