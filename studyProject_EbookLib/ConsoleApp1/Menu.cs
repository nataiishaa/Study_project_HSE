using EbookLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Menu
    { 
        /// <summary>
        /// Сериализация объекта MyLibrary.
        /// </summary>
        /// <param name="myLibrary"></param>
        public static void Ser(MyLibrary<PrintEdition> myLibrary)
        {
            try
            {
                UTF8Encoding temp = new UTF8Encoding(true);
                FileStream fs = new FileStream("mylibrary", FileMode.Create);
                DataContractJsonSerializer formater =
                new DataContractJsonSerializer(typeof(MyLibrary<PrintEdition>));
                formater.WriteObject(fs, myLibrary);
                fs.Close();
            }
            catch
            {
                Console.WriteLine("Ошибка при работе с файлом.");
 
            }
            
        }
        /// <summary>
        /// Десериализация объекта MyLibrary.
        /// </summary>
        /// <returns></returns>
        public static MyLibrary<PrintEdition> Deser()
        {
            try
            {
                UTF8Encoding temp = new UTF8Encoding(true);
                using var fs = new FileStream("mylibrary", FileMode.Open, FileAccess.Read);
                var formatter = new DataContractJsonSerializer(typeof(MyLibrary<PrintEdition>));
                return (MyLibrary<PrintEdition>)formatter.ReadObject(fs);

            }
            catch
            { 
                Console.WriteLine("Ошибка при работе с файлом.");
                return null;
            }
            
        }
        /// <summary>
        /// Метод, выполняющийся при выборе пользователем 1 в консольном меню.
        /// </summary>
        public static void Choice1()
        {    
            MyLibrary<PrintEdition> myLibrary = new MyLibrary<PrintEdition>();
            Random random = new Random();
            Generation.GenerateLibrary(ref myLibrary, random);
            myLibrary.onTake += Print.TakeHandler;
            foreach (PrintEdition printed in myLibrary)
             {
                printed.onPrint += Print.PrintHandler;
             }
            Print.PrintLibraryInConsole(myLibrary);
            Print.PrintAllBooks(myLibrary);
            Console.WriteLine(myLibrary.ToString());
            myLibrary.TakeBooks((char) random.Next((int)'A', (int)'Z' + 1));
            Console.WriteLine(myLibrary.ToString());
            Ser(myLibrary);
            MyLibrary<PrintEdition> fg = Deser();
            Print.PrintLibraryInConsole(fg);
            // Вывод среднего числа старниц в книге.
            if (fg.GetAverageCountOfPagesInBook != 0)
                Console.WriteLine($"Среднее число страниц во всех книгах: {fg.GetAverageCountOfPagesInBook:f2}\n");
            else
                Console.WriteLine("Cписок книг был пуст.");
            // Вывод среднего числа страниц в журнале.
            if (fg.GetAverageCountOfPagesInMagazine != 0)
                Console.WriteLine($"Среднее число страниц во всех журналах: {fg.GetAverageCountOfPagesInMagazine:f2}\n");
            else
                Console.WriteLine("Cписок журналов был пуст.");
        }
        /// <summary>
        /// Метод, выполняющийся при выборе пользователем 2 в консольном меню.
        /// </summary>
        public static void Choice2()
        {
            Console.ForegroundColor = System.ConsoleColor.Green;
            Console.WriteLine("Выполнение программы завершено. Спасибо, что воспользовались программой!");
            Console.ForegroundColor = System.ConsoleColor.White;          
        }      
    }
}
