using System;
using System.Collections.Generic;
using Librfigur;
using System.IO;
using System.Text;

namespace Correctfivar12
{
    internal class Program
    {
        private static string posibilities = $"Вам доступны следующие операции:" +
                                             $"\n\t1) Ввод адреса файла, " +
                                             $"в котором содержится информация о правильных фигурах" +
                                             $"\n\t2) Вывод в файл " +
                                             $" информацию обо всех осортированных по файлам фигурах." +
                                             $"\n\t3) Выход из программы \n" +
                                             $"Введите цифру выбранной операции: ";


        private static int Parseint(string line)
        {
            int num;
            if (!int.TryParse(line, out num))
            {
                throw new ArgumentException("Ошибка в структуре файла.");
            }
            return num;
        }
        public static Figure Parse(ref string line)
        {
            string[] strings = line.Split(' ');
            if (strings.Length != 4)
            {
                throw new ArgumentException("Ошибка в структуре файла.");
            }

            string name = strings[0];
            int x = Parseint(strings[1]);
            int y = Parseint(strings[2]);
            int length = Parseint(strings[3]);
            if (name.Equals("EqTriangle"))
            {
                return new EqTriangle(new Point(x, y), length);
            }
            else if (name.Equals("Square"))
            {
                return new Square(new Point(x, y), length);
            }
            throw new ArgumentException("Ошибка в структуре файла.");
        }
        /// <summary>
        /// Метод считывабщий инфомацию из файла.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static List<Figure> GetFigureListFromFile(ref int n, ref int m, ref string path)
        {
            Console.WriteLine("Введите имя файла");
            path = Console.ReadLine();
            List<Figure> figures = new List<Figure>(0);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (File.Exists(path))
            {
                using (StreamReader fc = new StreamReader(path,Encoding.GetEncoding(1251)))
                {
                    string line;
                    int fl = -1;
                    while ((line = fc.ReadLine()) != null)
                    {
                        if (fl >= 0)
                        {
                            string[] l = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (fl == 0)
                            {
                                n = Parseint(l[2]);
                                fl++;
                                continue;
                            }
                            if (fl == 1)
                            {
                                m = Parseint(l[2]);
                                continue;
                            }
                        }
                        if (!line[0].Equals('-'))
                        {
                            try
                            {
                                Figure st = Parse(ref line);
                                figures.Add(st);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e);
                                break;
                            }
                        }
                        else
                        {
                            fl++;
                            continue;
                        }
                    }
                    if (fl == -1)
                    {
                        try
                        { 
                            throw new ArgumentException("Ошибка. Файл не корректен.");
                        }
                        catch(ArgumentException e)
                        {
                            Console.WriteLine(e.Message); 
                        }
                       
                    }
                }
            }
            else
            {
                Console.WriteLine("По введенному имени не существует файла.");
            }

            return figures;
        }

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Воспользутейсь меню для дальнешего просмотра! Параметры N и M считываются из файла, как показно в примере. Файлы без этих парметров считаются некорректными.");
            Console.WriteLine();
            List <Figure> figures = new List<Figure>(0);
            int n = 0, m = 0;
            string path = String.Empty;
            while (true)
            {
                Console.WriteLine(posibilities);
                string num = Console.ReadLine();
                int numberOfOperation;
                while (!int.TryParse(num, out numberOfOperation))
                {
                    Console.WriteLine("Вы ввели не число " +
                                      "или оно не попадает в диапозон от 1 до 3");
                    num = Console.ReadLine();
                }

                if (numberOfOperation == 3)
                {
                    break;
                }
                switch (numberOfOperation)
                {
                    case 1:
                        figures = GetFigureListFromFile(ref n, ref m, ref path);
                        break;
                    case 2:
                        FiltrTriange(figures, n);
                        FiltrSquare(figures, m);
                        break;
                }
            }
        }

        /// <summary>
        /// Метод фильтрует и записывает в файл информацию обо всех 
        /// правильных треугольниках с радиусом описанной окружности большим N.
        /// </summary>
        /// <param name="figures"></param>
        private static void FiltrTriange(List<Figure> figures, double N)
        {
            List<Figure> figureTriang = new List<Figure>();
            if (figures.Count > 0)
            {
                foreach (var figure in figures)
                {
                    if (figure.GetType().Name == "EqTriangle" && figure.Radius() > N)
                    {
                        figureTriang.Add(figure);
                    }
                }

                PrintListInFile(figureTriang, "EqTriangle.txt");
            }
            else
            {
                Console.WriteLine("Список фигур пуст.Треугольников нет в файле.");
            }
        }

        /// <summary>
        /// Метод  фильтруюет  фигуры и записывающий в файл информацию обо всех 
        /// квадратах с радиусом описанной окружности большим M.
        /// </summary>
        /// <param name="figures"></param>
        private static void FiltrSquare(List<Figure> figures, double M)
        {
            List<Figure> figureSquare = new List<Figure>();
            if (figures.Count > 0)
            {
                foreach (var figure in figures)
                {
                    if (figure.GetType().Name == "Square" && figure.Radius() > M)
                    {
                        figureSquare.Add(figure);
                    }
                }

                PrintListInFile(figureSquare, "Square.txt");
            }
            else
            {
                Console.WriteLine("Список фигур пуст.Квадратов в файле нет.");
            }
        }

        /// <summary>
        /// Запись в файл  отфильтрованных фигур или соответсвующих криериям отбора.
        /// </summary>
        /// <param name="figures">Список фигур.</param>
        /// <param name="path">Путь к файлу, в который нужно записать информацию.</param>
        private static void PrintListInFile(List<Figure> figures, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var st in figures)
                    {
                        string s = st.ToString();
                        sw.WriteLine(s);
                    }
                }
            }
        }

    }

}


