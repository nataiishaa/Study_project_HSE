using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Librfigur
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>
        /// Конструктор с двумя параметрами – значениями абсциссы и ординаты  точки.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"Координаты точки Х:{X} Y:{Y}";
        }
    }

}



