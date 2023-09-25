
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EKRlib
{
    /// <summary>
    /// Класс MotorBoat с параметрическим конструктором, описывающий моторную лодку.
    /// </summary>
    public class MotorBoat : Transport
    {
        public MotorBoat(string model, uint power) : base(model, power)
        {
        }
        /// <summary>
        /// Переопределенный метод звуков двигателя.
        /// </summary>
        /// <returns></returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }
        /// <summary>
        /// Переопределенный метод вывода информации MotorBoat.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }
    }
}