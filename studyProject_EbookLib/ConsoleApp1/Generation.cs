using System;
using EbookLib;

namespace ConsoleApp
{
    public class Generation
    {
        public static void GenerateLibrary(ref MyLibrary<PrintEdition> myLibrary, Random randomNumber)
        {
            Console.WriteLine("Введите количество печатных изданий:");
            int numberOfElements;
            while (!int.TryParse(Console.ReadLine(), out numberOfElements) || (numberOfElements<=0))
            {
                Console.ForegroundColor = System.ConsoleColor.Red;
                Console.WriteLine("Ошибка,повторите ввод количества.");
                Console.ForegroundColor = System.ConsoleColor.White;
            }
            for (int i = 0; i < numberOfElements; i++)
            {
                int choise = randomNumber.Next(2);
                int numberOfPages;
                string content = GenerateString(randomNumber);
                while (true)
                {
                    (numberOfPages, content) = GenerateParameters(randomNumber);
                    try
                    {
                        if (choise == 0)
                        {
                            myLibrary.Add(new Book(content, numberOfPages, GenerateString(randomNumber)));
                        }
                        else
                        {
                            myLibrary.Add(new Magazine(content, numberOfPages, randomNumber.Next(5, 12)));
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                    break;
                }
            }
        }
        public static (int, string) GenerateParameters(Random randomNumber)
        {
            int numberOfPages = randomNumber.Next(-10, 100);
            string content = GenerateString(randomNumber);
            return (numberOfPages, content);
        }
        public static string GenerateString(Random random)
        {
            string result = string.Empty;
            int lenght = random.Next(2, 10);
            for (int i = 1; i < lenght; i++)
            {
                if (i == 1)
                {
                    result += (char) random.Next((int)'A', (int) 'Z' + 1);
                }
                else
                {
                    result += (char) random.Next((int)'a', (int) 'z' + 1);
                }
            }
            return result;
        }
    }
}