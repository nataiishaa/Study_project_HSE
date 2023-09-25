using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librfigur
{
    public class Square : Figure
    {

        Point point;
        double a;
        public override double Area()
        {
            return Math.Pow(a, 2);
        }
        public override double Radius()
        {
            return a / Math.Sqrt(2);
        }
        public override double Height()
        {
            return a;
        }
        /// <summary>
        ///  Метод возвращает массив всех вершин.
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
        public Square(Point p, double len) : base()
        {
            point = p;
            if (len < 0)
            {
                throw new ArgumentException();
            }
            a = len;
        }
        public override string ToString()
        {
            string str = $"Square {point.X} {point.Y} {a}";
            return str;
        }
    }

}
