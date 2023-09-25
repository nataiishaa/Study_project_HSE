using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EKRlib
{
    /// <summary>
    /// Описание класса Car с параметрическим конструктором, описывающий автомобиль. 
    /// </summary>
    public class Car : Transport
    {
        public Car(string model, uint power) : base(model, power)
        {
        }
        /// <summary>
        /// Переопределенный метод запуска двигателя.
        /// </summary>
        /// <returns></returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }
        /// <summary>
        /// Переопределенный метод вывода на экран информации об объеуте типа Car.
        /// </summary>
        /// <returns> Строка вывода на экран.</returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
    }
}