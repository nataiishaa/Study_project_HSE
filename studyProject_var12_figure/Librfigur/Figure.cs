using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librfigur
{
    public class Figure
    {
        // Одномерный массив содержит координаты всех точек.
        List<Point> points = new List<Point>();
        int length;
        public int Length
        {
            get { return length; }
        }
        /// <summary>
        /// Витуально свойство, предоставялющее значение площади фигуры.
        /// </summary>
        /// <returns></returns>
        public virtual double Area()
        {
            return 0;
        }

        public virtual double Height()
        {
            return 0;
        }

        public Figure()
        {
        }

        /// <summary>
        /// Массив, содержащий координаты  всех вершин фигуры на плоскости.
        /// </summary>
        /// <param name="array"></param>
        public Figure(Point[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                points.Add(array[i]);
            }
        }

        public virtual double Radius() => 0;

        public override string ToString()
        {
            string str = string.Empty;
            for (int i = 0; i < points.Count; i++)
            {
                str += $"Координаты точки Х:{points[i].X} Y:{points[i].Y}\n";
            }

            str += $"{Length} {GetType().Name} {Area()}";
            return str;
        }
    }
}

