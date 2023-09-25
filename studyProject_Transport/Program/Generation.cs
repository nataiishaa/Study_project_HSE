using System;
using System.Collections.Generic;
using System.Text;
using EKRlib;

namespace Program
{
    public static class Generation
    {
        private static Random randomNumber = new Random();
        /// <summary>
        /// Метод генерирует список, состоящий из элементов типа Car и MotoBoat.
        /// </summary>
        /// <param name="transports">Передающийся по ссылке массив.</param>
        public static (List<string>, List<string>) GenerateArray(ref List<Transport> transports)
        {
            List<string> cars = new List<string>(), motorboats = new List<string>();
            // Количество элементов в списке.
            int numberOfElements = randomNumber.Next(6, 10);
            for (int i = 0; i < numberOfElements; i++)
            {
                int choise = randomNumber.Next(2);
                try
                {
                    string model;
                    uint power;
                    (model, power) = GenerateTransportParametres();
                    if (choise == 0)
                    {
                        transports.Add(new Car(model, power));
                        cars.Add(transports[i].ToString());
                    }
                    else
                    {
                        transports.Add(new MotorBoat(model, power));
                        motorboats.Add(transports[i].ToString());
                    }
                    Console.WriteLine(transports[i].StartEngine());
                }
                catch (TransportException te)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(te.Message);
                    Console.ResetColor();
                    i--;
                }
            }
            return (cars, motorboats);
        }
        /// <summary>
        /// Генерирует параметры для конструктора транспорта.
        /// </summary>
        /// <returns>Возвращает кортеж, состоящий из предположительной Model и Power.</returns>
        private static (string, uint) GenerateTransportParametres()
        {
            int lengthStr = 5;
            var stringModel = new StringBuilder(lengthStr);
            for (int i = 0; i < lengthStr; i++)
            {
                int choice = randomNumber.Next(2);
                if (choice % 2 == 0)
                {
                    stringModel.Append((char)randomNumber.Next('A', 'Z' + 1));
                }
                if (choice % 2 == 1)
                {
                    stringModel.Append(randomNumber.Next(0, 10));
                }
            }
            uint power = (uint)randomNumber.Next(10, 100);
            return (stringModel.ToString(), power);
        }
    }
}