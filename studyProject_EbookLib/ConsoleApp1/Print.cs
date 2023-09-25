using EbookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Print
    {
        /// <summary>
        /// Обработчик события OnTake.
        /// Удаляет книги по первому символу из библиотеки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="libraryEventArgs"></param>
        public static void TakeHandler(object? sender, LibraryEventArgs libraryEventArgs)
        {
            MyLibrary<PrintEdition> library = (MyLibrary<PrintEdition>)sender;
            List<PrintEdition> books = new List<PrintEdition>(); ;
            Console.WriteLine($"ATTENTION! Books starts with {libraryEventArgs.start} were taken!");
            for (int i = 0; i < library.Count(); i++)
            {
                if (library[i] is Book)
                {
                    if (library[i].name[0].Equals(libraryEventArgs.start))
                    {
                        library.Remove(library[i]);
                        i--;
                    }
                }
            }
        }
        /// <summary>
        /// Обработчик события. Выводит информацию о печатном издании.
        /// </summary>
        /// <param name="sender"> Объект типа PrintEdition, вызывающий событие. </param>
        /// <param name="e"> Аргумент события.</param>
        public static void PrintHandler(object? sender, EventArgs e)
        {
            Console.WriteLine("PRINTED! " + sender.ToString());
        }
        /// <summary>
        /// Вывод всей библиотеки в консоль.
        /// </summary>
        /// <param name="library"></param>
        public static void PrintLibraryInConsole(MyLibrary<PrintEdition> library)
        {
            string context = String.Empty;
            foreach (var pr in library)
            {
                context += pr.ToString() + "\n";
            }
            Console.WriteLine(context);
        }
        /// <summary>
        /// Вывод книг в консоль.
        /// </summary>
        /// <param name="library"></param>
        public static void PrintAllBooks(MyLibrary<PrintEdition> library)
        {
            foreach (PrintEdition pr in library)
            {
                if (pr is Book)
                {
                    pr.Print();
                }
            }
        }
    }
}
