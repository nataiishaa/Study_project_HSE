using EKRlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Program
{
    class Program
    {
        private static string posibilities = $"Вам доступны следующие операции:" +
                                          $"\n\t1) Формирование инфомации о транспортных средствах." +
                                          $"\n\t2) Выход из программы. \n" +
                                          $"Введите цифру выбранной операции: ";

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Для работы с программой воспользуйтесь меню:");
            while (true)
            {
                Console.WriteLine(posibilities);
                var transports = new List<Transport>();
                List<string> cars, motorboats;
                string num = Console.ReadLine();
                int numberOfOperation;
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
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    Console.WriteLine("Выполнение программы завершено. Спасибо, что воспользовались программой!");
                    Console.ForegroundColor = System.ConsoleColor.White;
                    break;
                }
                else
                {
                    (cars, motorboats) = Generation.GenerateArray(ref transports);
                    string carsPath = "../../../../Cars.txt";
                    carsPath = carsPath.Replace('/', Path.DirectorySeparatorChar);
                    File.WriteAllLines(carsPath, cars, encoding: System.Text.Encoding.Unicode);
                    string motorBoatPath = "../../../../MotorBoats.txt";
                    motorBoatPath = motorBoatPath.Replace('/', Path.DirectorySeparatorChar);
                    File.WriteAllLines(motorBoatPath, motorboats, encoding: System.Text.Encoding.Unicode);
                    continue;
                }
            }
        }
    }
}
