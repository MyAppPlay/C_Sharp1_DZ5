using System;
using System.IO;


/// <summary>
/// Гаврилов Владимир
/// </summary>
namespace Задание4
{
    class Program
    {
        static void Main()
        {
            string path = "data.txt";
            CreateGradebookAndAverageRatingList(out int lengthList, out string[] gradebook,
                out double[] averageRatingList, path);
            OpenGradebookInConsol(gradebook);
            CreateTreeMinAverage(lengthList, averageRatingList, out double minAverageRating1,
                out double minAverageRating2, out double minAverageRating3);
            PrintNamesWorstStudents(lengthList, gradebook, averageRatingList,
                GettingMinimumGrades(averageRatingList, minAverageRating1, minAverageRating2, minAverageRating3));
            Console.ReadKey();
        }

        /// <summary>
        /// Создание списка учеников и списка их средних оценок.
        /// </summary>
        /// <param name="lengthList">Длина  массива.(Певая строка сведений об учениках).</param>
        /// <param name="gradebook">Массив учеников с их оценками.</param>
        /// <param name="averageRatingList">Массив средних балов.</param>
        /// <param name="path">Путь местонахождения входных сведений.</param>
        private static void CreateGradebookAndAverageRatingList(out int lengthList, out string[] gradebook, out double[] averageRatingList, string path)
        {
            StreamReader streamReader = new StreamReader(path);
            lengthList = int.Parse(streamReader.ReadLine());
            gradebook = new string[lengthList];
            averageRatingList = new double[lengthList];
            for (int i = 0; i < lengthList; i++)
            {
                gradebook[i] = streamReader.ReadLine();
                string[] studentAndHisGrades = gradebook[i].Split(' ');
                averageRatingList[i] = (double)(int.Parse(studentAndHisGrades[2]) + int.Parse(studentAndHisGrades[3])
                    + int.Parse(studentAndHisGrades[4])) / 3;
            }
            streamReader.Close();
        }

        /// <summary>
        /// Получение трех минимальных средних баллов из представленного массива.
        /// </summary>
        /// <param name="lengthList">Длина массива.</param>
        /// <param name="averageRatingList">Массив средних баллов.</param>
        /// <param name="minAverageRating1">Самый минимальный средний балл.</param>
        /// <param name="minAverageRating2">Второй минимальный средний балл.</param>
        /// <param name="minAverageRating3">Третий минимальный средний балл.</param>
        private static void CreateTreeMinAverage(int lengthList, double[] averageRatingList, out double minAverageRating1, out double minAverageRating2, out double minAverageRating3)
        {
            minAverageRating1 = 5;
            minAverageRating2 = 5;
            minAverageRating3 = 5;
            for (int i = 0; i < lengthList; i++)
            {
                if (averageRatingList[i] <= minAverageRating1)
                    minAverageRating1 = averageRatingList[i];
                else if (averageRatingList[i] <= minAverageRating2)
                    minAverageRating2 = averageRatingList[i];
                else if (averageRatingList[i] <= minAverageRating3)
                    minAverageRating3 = averageRatingList[i];
            }
        }

        /// <summary>
        /// Получение одного минимального среднего балла, достаточного для определения трех худших учеников.
        /// </summary>
        /// <param name="averageRatingList">Массив средних баллов.</param>
        /// <param name="minAverageRating1"></param>
        /// <param name="minAverageRating2"></param>
        /// <param name="minAverageRating3"></param>
        /// <returns></returns>
        private static double GettingMinimumGrades(double[] averageRatingList, double minAverageRating1, double minAverageRating2, double minAverageRating3)
        {
            var ctn = 0;
            var minAverageRating = minAverageRating1;
            foreach (double volume in averageRatingList)
                if (volume <= minAverageRating1)
                    ctn++;
            if (ctn < 3)
            {
                foreach (double volume in averageRatingList)
                    if (volume <= minAverageRating2)
                        ctn++;
                minAverageRating = minAverageRating2;
            }
            if (ctn < 3)
            {
                foreach (double volume in averageRatingList)
                    if (volume <= minAverageRating3)
                        ctn++;
                minAverageRating = minAverageRating3;
            }

            return minAverageRating;
        }

        /// <summary>
        /// Вывод в консоль имен худших учеников.
        /// </summary>
        /// <param name="lengthList"></param>
        /// <param name="gradebook"></param>
        /// <param name="averageRatingList"></param>
        /// <param name="minAverageRating"></param>
        private static void PrintNamesWorstStudents(int lengthList, string[] gradebook, double[] averageRatingList, double minAverageRating)
        {
            Console.WriteLine("\tСписок худших учеников: ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (var i = 0; i < lengthList; i++)
            {
                if (averageRatingList[i] <= minAverageRating)
                {
                    string[] nameStudent = gradebook[i].Split(' ');
                    Console.WriteLine($" {nameStudent[0]} {nameStudent[1]} - \tcредний балл: {averageRatingList[i]:F2}");
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Вывод в консоль списка всех учеников и их оценок.
        /// </summary>
        /// <param name="gradebook">Массив учеников.</param>
        private static void OpenGradebookInConsol(string[] gradebook)
        {
            Console.WriteLine("\tСписок всех учеников и их оценки: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string student in gradebook)
                Console.WriteLine(student);
            Console.ResetColor();
        }

    }
}
