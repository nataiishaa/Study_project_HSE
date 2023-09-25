using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librfigur
{
    public class EqTriangle : Figure
    {
        Point point;
        double a;
        public override double Area()
        {
            return (Math.Sqrt(3) * Math.Pow(a, 2)) / 4;
        }
        public override double Radius()
        {
            return (2 * a) / Math.Sqrt(3);
        }
        public override double Height()
        {
            return (Math.Sqrt(3) * a) / 2;
        }
        /// <summary>
        /// Метод возвращет массив всех вершин треугольника.
        /// </summary>
        /// <param name="leftVertex"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public Point[] AllPoint(Point leftVertex, double side)
        {
            List<Point> p = new List<Point>();
            p.Add(leftVertex);
            Point point = new Point(leftVertex.X, leftVertex.Y + side);
            p.Add(point);
            Point point1 = new Point(leftVertex.X + side / 2, leftVertex.Y + Height());
            p.Add(point);
            return p.ToArray();
        }
        /// <summary>
        /// Конструктор выбрасывает исключение при отрицательной длины строы.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="len"></param>
        /// <exception cref="ArgumentException"></exception>
        public EqTriangle(Point p, double len)
        {
            point = new Point(p.X, p.Y);
            if (len < 0)
            {
                throw new ArgumentException();
            }
            a = len;
        }
        public override string ToString()
        {
            string str = $"EqTriangle {point.X} {point.Y} {a}";
            return str;
        }

    }
}

