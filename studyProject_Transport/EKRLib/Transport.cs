using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EKRlib
{
    /// <summary>
    /// Абстратный класс транспорт описывает абстрактное транспортное средство.
    /// </summary>
    public abstract class Transport
    {
        
        private string model;
        private uint power;
        /// <summary>
        /// Создание строкового свойство Model.Проверка на корректность названия.
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                string pattern = @"[^A-Z0-9]";
                if ((value.Length != 5) || Regex.IsMatch(value, pattern))
                {
                    throw new TransportException($"Недопустимая модель {value}");
                }
                model = value;
            }
        }
        /// <summary>
        /// Создание и проверка целочисленного свойства Power(мощность в лошадиныхсилах).
        /// Проверка на корректность данных.
        /// </summary>
        public uint Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value < 20)
                {
                    throw new TransportException("мощность не может быть меньше 20 л.с.");
                }
                power = value;
            }
        }
        /// <summary>
        /// Метод вывода на экран  информации об объекте типа Transport.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }
        // Абстрактный метод для получения звука (в виде строки).
        public abstract string StartEngine();
        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }
    }
}