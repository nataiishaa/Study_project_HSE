using System;
using System.Collections.Generic;
using System.IO;
using EbookLib;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApp
{
   class Program
    {
        private static string posibilities = $"Вам доступны следующие операции:" +
                                          $"\n\t1) Формирование библиотеки. " +
                                          $"\n\t2) Выход из программы. \n" +
                                          $"Введите цифру выбранной операции: ";
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Вывод в консоль русского текста.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            System.Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Здравствуйте! Для работы с программой воспользуйтесь меню:");
            while (true)
            {
                Console.WriteLine(posibilities);
                string num = Console.ReadLine();
                int numberOfOperation;
                MyLibrary<PrintEdition> myLibrary = new MyLibrary<PrintEdition>();
                while (!int.TryParse(num, out numberOfOperation) || numberOfOperation > 2 || numberOfOperation < 1)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    Console.WriteLine("Вы ввели не число " +
                                      "или оно не попадает в диапозон от 1 до 2. Повторите ввод.");
                    Console.ForegroundColor = System.ConsoleColor.White;
                    num = Console.ReadLine();
                }
                if (numberOfOperation == 2)
                {
                    Menu.Choice2();
                    break;
                }
                else
                {
                    Menu.Choice1();
                }
            }
        }
    }
}